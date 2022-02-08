using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedbackComponent : MonoBehaviour
{
    #region Variables

    [SerializeField]
    private List<Feedback> feedbacks = new List<Feedback>();

    #endregion

    #region Methods

    private void PlayFeedbacks()
    {
        foreach(Feedback feedback in feedbacks)
        {
            //item.Play();
        }
    }

    #endregion
}
