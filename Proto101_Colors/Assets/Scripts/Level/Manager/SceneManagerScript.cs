using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    public void Play()
    {
        StartCoroutine(play());
    }

    IEnumerator play()
    {
        yield return new WaitForSeconds(0.5f);
        Debug.Log("Play");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
}
