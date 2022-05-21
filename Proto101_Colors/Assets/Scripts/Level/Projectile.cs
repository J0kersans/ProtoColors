using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public float projectileSpeed = 5;



    /*private Transform player;
    private Vector2 target;*/
    // Start is called before the first frame update
    void Start()
    {
        /* player = GameObject.FindGameObjectWithTag("Player").transform;

         target = new Vector2(player.position.x, player.position.y);*/
    }

    // Update is called once per frame
    void Update()
    {
        /*transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if(transform.position.x == target.x && transform.position.y == target.y)
        {
            Destroy(gameObject);
        }*/
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other)
        {
            Destroy(gameObject);
        }
    }
    public void shootTopEvent()
    {
        StartCoroutine(shootTop());
    }
    public void shootBotEvent()
    {
        StartCoroutine(shootBot());
    }
    public void shootRightEvent()
    {
        StartCoroutine(shootRight());
    }
    public void shootLeftEvent()
    {
        StartCoroutine(shootLeft());
    }

    IEnumerator shootTop()
    {
        transform.position += new Vector3(0, 1, 0) * projectileSpeed * Time.deltaTime;
        StartCoroutine(projectileDestruction());

        yield return null;
    }

    IEnumerator shootBot()
    {
        transform.position += new Vector3(0, -1, 0) * projectileSpeed * Time.deltaTime;
        StartCoroutine(projectileDestruction());

        yield return null;
    }

    IEnumerator shootRight()
    {
        transform.position += new Vector3(1, 0, 0) * projectileSpeed * Time.deltaTime;
        StartCoroutine(projectileDestruction());

        yield return null;
    }

    IEnumerator shootLeft()
    {
        transform.position += new Vector3(-1, 0, 0) * projectileSpeed * Time.deltaTime;
        StartCoroutine(projectileDestruction());

        yield return null;
    }
    IEnumerator projectileDestruction()
    {
        yield return new WaitForSeconds(4);
        Destroy(gameObject);
    }
}
