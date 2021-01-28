using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance = null;

    public static SoundManager Instance
    {
        get
        {
            instance = FindObjectOfType<SoundManager>();
            if (instance == null)
            {
                if (instance == null)
                {
                    instance = new GameObject("SoundManager").AddComponent<SoundManager>();
                }
            }
            return instance;
        }
           
        
    }

    public AudioSource backGroundmusic;
    public AudioSource[] sfxAudio;

     void Start()
    {
        sfxAudio = GameObject.Find("SoundManager").GetComponents<AudioSource>();
     //   sfxAudio[1].Play();
    }

    public void SetbackVolume(float volume)
    {
        backGroundmusic.volume = volume;
    }

    
    public void SetSoundVolume(float volume)
    {
        sfxAudio[sfxAudio.Length].volume = volume;
    }


     

}
