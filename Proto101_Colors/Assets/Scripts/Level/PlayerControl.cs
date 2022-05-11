using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
//Etat du joueur(vie)
    #region CheckpointSystem
    public float Health = 100f;
    public bool playerIsDead = false;
    #endregion

//Vitesse et Force de saut
    #region MoveElements
    public float MoveSpeed = 5;
    public float JumpForce = 6;
    #endregion

//Obtention et Utilisation de pouvoir
    #region PowerElements
    public GameObject PowerJump;
    public GameObject PowerSlowFall;

    public GameObject powerJumpBackground;
    public GameObject slowFallBackground;

    public bool powerJump = false;
    public bool slowFall = false;
    public bool powerJumpAutorisation = false;
    public bool slowFallAutorisation = false;
    #endregion

//Changement back après pouvoir
    #region PowerUseFeedback
    //public GameObject Jump;
    //public GameObject Fall;
    public Image Back1;
    public Image Back2;
    #endregion

//Obstacles
    #region Environement 
    public GameObject baseObstacle;
    public GameObject blueEnvironment;
    public GameObject blueObstacle;
    public GameObject redEnvironment;
    #endregion

    public AudioManagerScript sceneAudio;
    public ShakeScript shaking;
    public bool collisionHappening;
    private Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        //spawnPoint = gameObject.transform.position;
        //checkpointRenderer = checkpoint.GetComponent<Renderer>();

       // DontDestroyOnLoad(gameObject);
    }

    public void Update()
    {
        collisionHappening = false;
        PowerUsage();
        Powers();

//Saut et mouvement (droite/gauche) du joueur
        #region Movements
        var movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MoveSpeed;

        if (Input.GetButtonDown("Jump") && Mathf.Abs(rb2d.velocity.y) < 0.001f)
        {
            rb2d.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
        }
        #endregion

    }

//Débloquer les pouvoirs + mourir 
    public void OnCollisionEnter2D(Collision2D collision)
    {

//Débloquer pouvoir Saut
        if (collision.gameObject.CompareTag("Power1"))
        {
            powerJumpAutorisation = true;
            //Jump.gameObject.SetActive(true);
            Destroy(PowerJump.gameObject);
        }

//Débloquer pouvoir Chute ralenti
        if (collision.gameObject.CompareTag("Power2"))
        {
            slowFallAutorisation = true;
            //Fall.gameObject.SetActive(true);
            Destroy(PowerSlowFall.gameObject);
        }

//Limite du niveau en cas de chute
        if (collision.gameObject.CompareTag("LevelLimit"))
        {
            Health = 0;
            Debug.Log(Health);
        }

//Obstacle réduisant la vie du joueur
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            collisionHappening = true;
            Health -= 20f;
            //ShakeScript.Shaking();
            Debug.Log(Health);
        }
    }

//Utiliser les pouvoirs
    public void PowerUsage()
    {

//La touche "A" active le PowerJump et désactive le SlowFall
        if (Input.GetKeyDown("a") && powerJumpAutorisation == true)
        {
            slowFall = false;
            powerJump = true;
            Back1.gameObject.SetActive(true);
            Back2.gameObject.SetActive(false); 
        }

//La touche "Z" active le SlowFall et désactive le PowerJump
        if (Input.GetKeyDown("z") && slowFallAutorisation == true)
        {
            powerJump = false;
            slowFall = true;
            AudioManagerScript.clip = sceneAudio.ZeWorld;
            AudioManagerScript.PlayAudio();
            Back1.gameObject.SetActive(false);
            Back2.gameObject.SetActive(true);
        }

//La touche "R" désactive tout pouvoir 
        if (Input.GetKeyDown("r"))
        {
            powerJump = false;
            slowFall = false;
            Back1.gameObject.SetActive(false);
            Back2.gameObject.SetActive(false);

            baseObstacle.SetActive(true);
        }
    }

//Détails des pouvoirs
    public void Powers()
    {

//Force de saut et changement d'environnement
        if (powerJump == true)
        {
            JumpForce = 15;
            powerJumpBackground.SetActive(true);
            redEnvironment.SetActive(true);
        }
        else if (powerJump == false)
        {
            JumpForce = 6;
            powerJumpBackground.SetActive(false);
            redEnvironment.SetActive(false);
        }

//Ralentissement de chute et changement d'environnement
        if (slowFall == true)
        {
            rb2d.drag = 9;
            slowFallBackground.SetActive(true);
            blueEnvironment.SetActive(true);
            blueObstacle.SetActive(true);
        }
        else if (slowFall == false)
        {
            rb2d.drag = 1;
            slowFallBackground.SetActive(false);
            blueEnvironment.SetActive(false);
            blueObstacle.SetActive(false);
        }
    }

    /* private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Checkpoint"))
        {
            spawnPoint = collision.gameObject.transform.position;
            checkpointRenderer = collision.gameObject.GetComponent<Renderer>();
            checkpointRenderer.material.SetColor("_Color", new Color(0, 255, 12));
            Debug.Log("Collision");

        }
    }*/
    
//Position de spawn
   private void OnLevelWasLoaded(int level)
    {
        FindStartPos();
    }

    void FindStartPos()
    {
        transform.position = GameObject.FindWithTag("StartPos").transform.position;
    }
}