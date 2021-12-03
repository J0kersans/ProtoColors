using UnityEngine;

public class PlayerControl : MonoBehaviour
{
/*
    #region FallDamage

    public int playerLife = 5;
    bool _grounded = false;
    bool wasGrounded;
    bool wasFalling;
    float startOfFall;
    public float minimumFall = 2f;

    #endregion
*/
    #region MoveElements

    public float MovementSpeed = 4;
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

    public GameObject blueEra;
    public GameObject redEra;

    #endregion

    public Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        PowerUsage();
        Powers();
       /* CheckGround();

        if (!wasFalling && isFalling)
        {
            startOfFall = transform.position.y;
        }

        if (!wasGrounded && _grounded)
        {
            TakeDamage();
        }
        wasGrounded = _grounded;
       

        //Conditions de défaites 

        if(playerLife == 0)
        {
            Destroy(gameObject);
        }
*/
        //Différent mouvement du player

        #region Movements

        var movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MovementSpeed;

        if (Input.GetButtonDown("Jump") && Mathf.Abs(rb2d.velocity.y) < 0.001f)
        {
            rb2d.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
        }

        #endregion

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

       /* if (collision.gameObject.CompareTag("LevelLimit"))
        {
            playerLife = 0;
        }*/

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
            GetComponent<Rigidbody2D>().drag = 9;
            blueBack.SetActive(true);
            blueEra.SetActive(true);
        }
        else if(powerFall == false)
        {
            GetComponent<Rigidbody2D>().drag = 1;
            blueBack.SetActive(false);
            blueEra.SetActive(false);
        }
    }

   /* void CheckGround()
    {
        _grounded = Physics.Raycast(transform.position + Vector3.up, -Vector3.up, 1.01f);
    }

    bool isFalling { get { return (!_grounded && rb2d.velocity.y < 0); } }

    void TakeDamage()
    {
        float fallDistance = startOfFall - transform.position.y;

        if (fallDistance > minimumFall)
        {
            playerLife -= 1;
            Debug.Log("Perte de HP");
            Debug.Log(playerLife);
        }
    }*/
}