using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutoScript : MonoBehaviour
{
    #region Component
    //1ère phase tuto
    private GameObject firstTuto;

//2ème phase tuto
    private GameObject secondTuto;

//Tuto Pouvoir Jump
    private GameObject aTuto;
    private GameObject zTuto;
    private GameObject rTuto;

//Player Control Component
    private GameObject player;
    private PlayerControl playerControl;

    private bool aTutoDone = false;
    private bool zTutoDone = false;
    #endregion 

    // Start is called before the first frame update
    void Start()
    {
//Tutos
        firstTuto = GameObject.Find("FirstTutoButtons");
        secondTuto = GameObject.Find("SecondTutoButtons");
        aTuto = GameObject.Find("A_Button");
        zTuto = GameObject.Find("Z_Button");
        rTuto = GameObject.Find("R_Button");

//Player Component
        player = GameObject.Find("Player");
        playerControl = player.GetComponent<PlayerControl>();

//Tutos images
        firstTuto.SetActive(true);
        secondTuto.SetActive(false);
        aTuto.SetActive(false);
        zTuto.SetActive(false);
        rTuto.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
//Complete Tuto Moves
        if(firstTuto.activeSelf == true)
        {
            Debug.Log("firstTuto is true");

            if (Input.GetButtonDown("Horizontal"))
            {
                StartCoroutine(CloseFirstTuto());
                Debug.Log("Moves");
            }   
        }

//Complete Tuto Jump        
        if (secondTuto.activeSelf == true)
        {
            Debug.Log("secondTuto is true");

            if (Input.GetButtonDown("Jump"))
            {
                StartCoroutine(CloseSecondTuto());
                Debug.Log("Jump");
            }
        }

//Complete Tuto PowerJump
        if (playerControl.powerJumpAutorisation == true && aTutoDone == false)
        {

            aTuto.SetActive(true);

            if (aTuto.activeSelf == true )
            {

                if (Input.GetKeyDown("a"))
                {
                    Debug.Log("ATuto en cours");
                    StartCoroutine(CloseATuto());
                }
            }           
        }

//Complete Tuto SlowFall
        if (playerControl.slowFallAutorisation == true && zTutoDone == false)
        {

            zTuto.SetActive(true);

            if (zTuto.activeSelf == true)
            {

                if (Input.GetKeyDown("z"))
                {
                    Debug.Log("ZTuto en cours");
                    StartCoroutine(CloseZTuto());
                }
            }
        }

//Complete Tuto Cancel Powers
        if (rTuto.activeSelf == true)
        {
            StartCoroutine(CloseRTuto());
        }
    }

//Close Tuto Moves
    IEnumerator CloseFirstTuto()
    {
        yield return new WaitForSeconds(2);
        firstTuto.SetActive(false);
        secondTuto.SetActive(true);
        StopAllCoroutines();
    }

//Close Tuto Jump
    IEnumerator CloseSecondTuto()
    {
        Debug.Log("Space Tuto en cours");

        yield return new WaitForSeconds(2);
        secondTuto.SetActive(false);
        StopAllCoroutines();
    }

//Close Tuto Power Jump
    IEnumerator CloseATuto()
    {
        yield return new WaitForSeconds(2);
        Debug.Log("ATuto done");
        aTuto.SetActive(false);
        rTuto.SetActive(true);
        aTutoDone = true;
        StopAllCoroutines();
    }

//Close Tuto Slow Fall
    IEnumerator CloseZTuto()
    {
        yield return new WaitForSeconds(2);
        Debug.Log("ZTuto done");
        zTuto.SetActive(false);
        rTuto.SetActive(true);
        zTutoDone = true;
        StopAllCoroutines();
    }

//Close Tuto Cancel Powers
    IEnumerator CloseRTuto()
    {
        if (Input.GetKeyDown("r") && rTuto.activeSelf == true)
        {
            yield return new WaitForSeconds(2);
            rTuto.SetActive(false);
            StopAllCoroutines();
        }    
    }
}
