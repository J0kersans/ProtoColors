using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    //public List<Pouvoirs> playerPower = new List<Pouvoirs>();

    #region MoveElements

    public float MovementSpeed = 4;
    public float JumpForce = 6;

    #endregion

    #region PowerElements

    public GameObject Power1;
    public GameObject Power2;
    //public GameObject Power3;

    public GameObject blueBack;
    public GameObject redBack;

    public bool powerJump = false;
    public bool powerFall = false;
    public bool powerJumpAutorisation = false;
    public bool powerFallAutorisation = false;

    #endregion

    private Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

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

    }

    //Débloquer les pouvoirs
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

    }

    //Utiliser les pouvoirs
    void PowerUsage()
    {
        if(Input.GetKeyDown("a") && powerJumpAutorisation == true)
        {
            powerFall = false;
            powerJump = true;
            
        }

        if (Input.GetKeyDown("z") && powerFallAutorisation == true)
        {
            powerJump = false;
            powerFall = true;
        }

        if(Input.GetKeyDown("r"))
        {
            powerJump = false;
            powerFall = false;
        }
    }

    //Détails des pouvoirs
    void Powers()
    {
        if(powerJump == true)
        {
            JumpForce = 15;
            redBack.SetActive(true);
        }
        else if(powerJump == false)
        {
            JumpForce = 6;
            redBack.SetActive(false);
        }

        if(powerFall == true)
        {
            GetComponent<Rigidbody2D>().drag = 9;
            blueBack.SetActive(true);
        }
        else if(powerFall == false)
        {
            GetComponent<Rigidbody2D>().drag = 1;
            blueBack.SetActive(false);
        }
    }
}