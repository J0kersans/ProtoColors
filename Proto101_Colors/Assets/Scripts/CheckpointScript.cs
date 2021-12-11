using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointScript : MonoBehaviour
{
    private GameObject player;
    private PlayerControl playerControl;
    private Renderer checkpointRenderer;
    Vector3 playerFirstCheckpoint;
    Vector3 checkPoint;

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
        if (playerControl.playerIsDead == true)
        {
            player.transform.position = playerFirstCheckpoint;
            playerControl.playerLife = 5;
            Debug.Log("Player is dead 2");
        }

        if (playerControl.playerLife < 0)
        {
            playerControl.playerIsDead = false;
        }
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerFirstCheckpoint = checkPoint;
            checkpointRenderer.material.SetColor("_Color", new Color(0, 255, 12));
            Debug.Log("Collision");

        }
    }
}
