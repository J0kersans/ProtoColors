using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutoScript : MonoBehaviour
{
//1ère phase tuto
    public Image tutoHautBas;
    public Image tutoGauche;
    public Image tutoDroite;

//2ème phase tuto
    public Image tutoEspace;

    // Start is called before the first frame update
    void Start()
    {
        tutoHautBas.gameObject.SetActive(true);
        tutoDroite.gameObject.SetActive(true);
        tutoGauche.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Horizontal"))
        {
            StartCoroutine(Close());
            Debug.Log("Moves");
        }
    }

   IEnumerator Close()
    {
        yield return new WaitForSeconds(3);
        tutoHautBas.gameObject.SetActive(false);
        tutoDroite.gameObject.SetActive(false);
        tutoGauche.gameObject.SetActive(false);
        tutoEspace.gameObject.SetActive(false);
    }

}
