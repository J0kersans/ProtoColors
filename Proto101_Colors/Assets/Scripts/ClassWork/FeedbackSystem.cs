using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedbackSystem : MonoBehaviour
{
    #region Variables
    
    public static  FeedbackSystem Instance { get; private set; } // private set pour bloquer l'accès de modifier a d'autre script
    public enum FeedbackType
    {

    }

    #endregion

    #region Messages 

    private void Awake()
    {
        if (Instance == null) // s'assure que instance est null
        {
            Instance = this; // on assigne l'instance à ce script
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    #endregion

    #region Methods 

    public void PlayFeedback()
    {

    }

    #endregion
}
