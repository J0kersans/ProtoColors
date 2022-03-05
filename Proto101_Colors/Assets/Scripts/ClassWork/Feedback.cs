using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Feedback : MonoBehaviour // this class will only serve as a base for other class
{
    #region Methods

    public virtual void Play() // Cette fonction pour etre override 
    {
        Debug.Log("FeedbackPlayed");
    }

    #endregion
}
