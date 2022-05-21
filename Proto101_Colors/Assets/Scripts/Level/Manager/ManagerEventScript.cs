using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerEventScript : MonoBehaviour
{
    private PlayerControl Player;
   
    public GameObject cam;
    Animator camShake; 

    // Start is called before the first frame update
    void Start()
    {
        camShake = cam.GetComponent<Animator>();
        Player = FindObjectOfType<PlayerControl>();
    }

    // Update is called once per frame
    void Update()
    {
        camShake.SetBool("Shake", false);
        if (Player.collisionHappening == true)
        {
            Debug.Log("Scrip Collision Found");
            camShake.SetBool("Shake", true);
        }
    }
}
