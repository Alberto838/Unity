using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource source;
    static AudioSource staticSource;

    private void Start() 
    {
        staticSource = source;
    }

    public static void PlaySound(string soundName) 
    {
        AudioClip soundToPlay = Resources.Load<AudioClip>("Sounds/" + soundName);
        staticSource.PlayOneShot(soundToPlay);
    }

}
