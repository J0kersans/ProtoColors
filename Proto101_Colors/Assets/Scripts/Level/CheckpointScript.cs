using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointScript : MonoBehaviour
{
//Appel de variable
    private GameObject player;
    private PlayerControl playerControl;

//Acquisition des positions du joueur et du checkpoint
    Vector3 playerFirstCheckpoint;
    Vector3 checkPoint;

//Acquisition du renderer
    private Renderer checkpointRenderer; 

    // Start is called before the first frame update
    public void Start()
    {
        player = GameObject.Find("Player");
        playerControl = player.GetComponent<PlayerControl>();

        playerFirstCheckpoint = player.transform.position;
        checkPoint = gameObject.transform.position;

        checkpointRenderer = gameObject.GetComponent<Renderer>();
    }

    // Update is called once per frame
    public void Update()
    {
//Si le joueur meurt il respawn à sa position de départ
        if (playerControl.Health == 0f)
        {
            player.transform.position = playerFirstCheckpoint;
            playerControl.Health = 100f;
            Debug.Log("Player is dead 2");
        }
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
//Si le joueur est entré en collision avec un Checkpoint, la position du checkpoint devient sa position de départ
        if (collision.gameObject.CompareTag("Player") )
        {
            playerFirstCheckpoint = checkPoint;
            checkpointRenderer.material.SetColor("_Color", new Color(0, 255, 12));
            Debug.Log("Collision");
        }
    }
}
