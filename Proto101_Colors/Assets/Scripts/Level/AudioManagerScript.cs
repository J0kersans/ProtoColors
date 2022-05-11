using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerScript : MonoBehaviour
{
    [Header("General")]
    [SerializeField] private AudioClip zeWorld;


    public AudioClip ZeWorld { get => zeWorld; }

    public static AudioSource audioScene;
    public static AudioClip clip;

    void Start()
    {
        audioScene = GetComponent<AudioSource>();
    }


    public static void PlayAudio()
    {
        audioScene.PlayOneShot(clip);
    }
}
