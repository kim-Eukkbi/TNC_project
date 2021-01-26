using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource backGroundmusic;
  //  public AudioSource soundEffect;

    public void SetbackVolume(float volume)
    {
        backGroundmusic.volume = volume;
    }
 /*
    public void SetSoundVolume(float volume)
    {
        soundEffect.volume = volume;
    }

    public void OnSfx()
    {
        soundEffect.Play();
    }
 */
}
