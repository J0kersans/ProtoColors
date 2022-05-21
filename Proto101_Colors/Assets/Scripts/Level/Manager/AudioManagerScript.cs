using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerScript : MonoBehaviour
{
    [Header("General")]
    [SerializeField] private AudioClip zeWorld;
    [SerializeField] private AudioClip superJump;


    public AudioClip ZeWorld { get => zeWorld; }
    public AudioClip SuperJump { get => superJump; }

    public static AudioSource audioGame;
    public static AudioClip clip;

    void Start()
    {
        audioGame = GetComponent<AudioSource>();
    }


    public static void PlayAudio()
    {
        audioGame.PlayOneShot(clip);
    }
}
