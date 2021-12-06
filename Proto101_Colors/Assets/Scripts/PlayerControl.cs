using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    public int playerLife = 5;
    public GameObject endScreen;
 
    #region MoveElements

    public float MovementSpeed = 5;
    public float JumpForce = 6;

    #endregion

    #region PowerElements

    public GameObject Power1;
    public GameObject Power2;

    public GameObject blueBack;
    public GameObject redBack;

    public bool powerJump = false;
    public bool powerFall = false;
    public bool powerJumpAutorisation = false;
    public bool powerFallAutorisation = false;

    #endregion

    #region Environement 

    public GameObject baseObstacle;
    public GameObject blueEra;
    public GameObject blueObstacle;
    public GameObject redEra;

    #endregion

    private Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        endScreen.SetActive(false);
    }

    void Update()
    {
        PowerUsage();
        Powers();

        //Différent mouvement du player

        #region Movements

        var movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MovementSpeed;

        if (Input.GetButtonDown("Jump") && Mathf.Abs(rb2d.velocity.y) < 0.001f)
        {
            rb2d.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
        }

        #endregion

        if (playerLife <= 0)
        {
            endScreen.SetActive(true);
            Time.timeScale = 0;
        }

    }

    //Débloquer les pouvoirs + mourir 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Power1"))
        {
            powerJumpAutorisation = true;
            Destroy(Power1.gameObject);
        }

        if (collision.gameObject.CompareTag("Power2"))
        {
            powerFallAutorisation = true;
            Destroy(Power2.gameObject);
        }

       if (collision.gameObject.CompareTag("LevelLimit"))
        {
            playerLife = 0;
            Debug.Log(playerLife);
        }

        if (collision.gameObject.CompareTag("Obstacle"))
        {
            playerLife -= 1;
            Debug.Log(playerLife);
        }

    }

    //Utiliser les pouvoirs
    void PowerUsage()
    {
        //La touche "a" active le saut boosté
        if(Input.GetKeyDown("a") && powerJumpAutorisation == true)
        {
            powerFall = false;
            powerJump = true;
            
        }

        //La touche "z" active la chute ralenti
        if (Input.GetKeyDown("z") && powerFallAutorisation == true)
        {
            powerJump = false;
            powerFall = true;
        }

        //La touche "r" désactive tout pouvoir 
        if (Input.GetKeyDown("r"))
        {
            powerJump = false;
            powerFall = false;

            baseObstacle.SetActive(true);
        }
    }

    //Détails des pouvoirs
    void Powers()
    {
        //Détails saut boosté et changement d'environnement
        if (powerJump == true)
        {
            JumpForce = 15;
            redBack.SetActive(true);
            redEra.SetActive(true);
        }
        else if(powerJump == false)
        {
            JumpForce = 6;
            redBack.SetActive(false);
            redEra.SetActive(false);
        }

        //Détails chute ralenti et changement d'environnement
        if(powerFall == true)
        {
            rb2d.drag = 9;
            blueBack.SetActive(true);
            blueEra.SetActive(true);
            blueObstacle.SetActive(true);
        }
        else if(powerFall == false)
        {
            rb2d.drag = 1;
            blueBack.SetActive(false);
            blueEra.SetActive(false);
            blueObstacle.SetActive(false);
        }
    }
}