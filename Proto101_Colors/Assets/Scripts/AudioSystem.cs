using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSystem : MonoBehaviour
{
    #region Variables
    public static AudioSystem Instance
    { get;
      private set; }
    #endregion

    // Start is called before the first frame update
    private void Awake()
    {
      if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }

      else
        {
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
