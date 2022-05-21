 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    /*public float speed;
    public float stoppingDistance;
    public float retreatDistance;*/

    private float timeBtwShots;
    public float startTimeBtwShots;

[Header("Projectile Direction")]
    public bool shootingTop;
    public bool shootingBot;
    public bool shootingRight;
    public bool shootingLeft;


    public GameObject projectile;
    public Projectile projectileScript;
    //public Transform player;
 
    void Start()
    {
        projectileScript = projectile.GetComponent<Projectile>();
        // player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
   void Update()
    {
//Direction des projectiles

        /*if (shootingTop == true)
        {
            projectileScript.shootTopEvent();
        }
        if (shootingBot == true)
        {
            projectileScript.shootBotEvent();
        }
        if (shootingRight == true)
        {
            projectileScript.shootRightEvent();
        }
        if (shootingLeft == true)
        {
            projectileScript.shootLeftEvent();
        }*/
     

        //Cadence de tir
        if (timeBtwShots <= 0)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }
}
