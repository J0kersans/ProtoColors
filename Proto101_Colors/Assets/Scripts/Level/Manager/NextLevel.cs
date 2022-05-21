using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public SceneManagerScript levelManagement;

    public PlayerControl playerPowers;

//Lancer la sc�ne suivante apr�s collision avec le player
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collisionGameObject = collision.gameObject;

        if(collisionGameObject.name == "Player")
        {
            levelManagement.Play();
           // playerPowers.powerJumpAutorisation = true;
            //playerPowers.slowFallAutorisation = true;
        }
    }

}
