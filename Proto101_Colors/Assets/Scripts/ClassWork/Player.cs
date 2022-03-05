using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{


    void Start()
    {
        AudioComponent audioComp = GetComponent<AudioComponent>();
       // audioComp.Play(audioComp.audioList[0]);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
            //FeedbackSystem.Instance;
        }
    }

    private void Jump()
    {
        //jumpFeedback.PlayFeedbacks();
    }
}
