using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource musicPlayer;
    public AudioSource soundPlayer;
    public AudioSource soundPlayer2;
    // Start is called before the first frame update
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(instance);
        }
        
    }

    public void PlayMusic(string name)
    {
        if (!musicPlayer.isPlaying)
        {
            AudioClip clip = Resources.Load<AudioClip>(name);
            musicPlayer.clip = clip;
            musicPlayer.volume = 0.5f;
            musicPlayer.Play();
        }
    }

    public void PlayMusic(string name, float volume)
    {
        if (!musicPlayer.isPlaying)
        {
            AudioClip clip = Resources.Load<AudioClip>(name);
            musicPlayer.clip = clip;
            musicPlayer.volume = volume;
            musicPlayer.Play();
        }
    }

    public void StopMusic()
    {
        musicPlayer.Stop();
    }

    public void PlaySE(string name)
    {
        soundPlayer.pitch = 1f;
        AudioClip clip = Resources.Load<AudioClip>(name);
        soundPlayer.PlayOneShot(clip);
    }

    public void PlayLowSE(string name, float pitch)
    {
        soundPlayer2.pitch = pitch;
        AudioClip clip = Resources.Load<AudioClip>(name);
        soundPlayer2.PlayOneShot(clip);
    }

    public void PlaySE(string name, float volume)
    {
        soundPlayer.pitch = 1f;
        AudioClip clip = Resources.Load<AudioClip>(name);
        soundPlayer.PlayOneShot(clip, volume);
    }

}
