using System;
using System.IO;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    public Sound[] musicSounds, sfxSounds;
    public AudioSource musicSource, sfxSource;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        PlayMusic("title");
    }

    public void PlayMusic(string name)
    {
        AudioClip clip = FindMusicClip(name);
        musicSource.clip = clip;
        musicSource.volume = 1f;
        musicSource.loop = true;
        try
        {
            musicSource.Play();
        }
        catch (IOException error)
        {
            Debug.Log("Error: " + error.Message);
        }
    }

    public void PlayMusic(string name, bool isLoop)
    {
        AudioClip clip = FindMusicClip(name);
        musicSource.clip = clip;
        musicSource.volume = 1f;
        musicSource.loop = isLoop;
        musicSource.Play();
    }
    public void PlayMusic(string name, float volume)
    {
        AudioClip clip = FindMusicClip(name);
        musicSource.clip = clip;
        musicSource.volume = volume;
        musicSource.loop = true;
        try
        {
            musicSource.Play();
        }
        catch (IOException error)
        {
            Debug.Log("Error: " + error.Message);
        }
    }

    public void PlayMusic(string name, bool isLoop, float volume)
    {
        AudioClip clip = FindMusicClip(name);
        musicSource.clip = clip;
        musicSource.loop = isLoop;
        musicSource.volume = volume;
        try
        {
            musicSource.Play();
        }
        catch (IOException error)
        {
            Debug.Log("Error: " + error.Message);
        }
    }

    public void PlayMusic(string name, bool isLoop, float volume, float delay)
    {
        AudioClip clip = FindMusicClip(name);
        musicSource.clip = clip;
        musicSource.loop = isLoop;
        musicSource.volume = volume;
        try
        {
            musicSource.PlayDelayed(delay);
        }
        catch (IOException error)
        {
            Debug.Log("Error: " + error.Message);
        }
    }

    public void StopMusic()
    {
        musicSource.Stop();
    }

    public void PlaySfx(string name)
    {
        AudioClip clip = FindSfxClip(name);
        try
        {
            sfxSource.PlayOneShot(clip);
        }
        catch (IOException error)
        {
            Debug.Log("Error: " + error.Message);
        }
    }
    public void PlaySfx(string name, float volume)
    {
        AudioClip clip = FindSfxClip(name);
        try
        {
            sfxSource.PlayOneShot(clip, volume);
        }
        catch (IOException error)
        {
            Debug.Log("Error: " + error.Message);
        }
    }

    public void PlaySfx(string name, bool isLoop)
    {
        AudioClip clip = FindSfxClip(name);
        sfxSource.clip = clip;
        sfxSource.loop = isLoop;
        try
        {
            sfxSource.Play();
        }
        catch (IOException error)
        {
            Debug.Log("Error: " + error.Message);
        }
    }

    public void PlaySfx(string name, bool isLoop, float volume)
    {
        AudioClip clip = FindSfxClip(name);
        sfxSource.clip = clip;
        sfxSource.loop = isLoop;
        sfxSource.volume = volume;
        try
        {
            sfxSource.PlayOneShot(clip);
        }
        catch (IOException error)
        {
            Debug.Log("Error: " + error.Message);
        }

    }

    public void PlaySfx(string name, bool isLoop, float volume, float delay)
    {
        AudioClip clip = FindSfxClip(name);
        sfxSource.clip = clip;
        sfxSource.loop = isLoop;
        sfxSource.volume = volume;
        try
        {
            sfxSource.PlayDelayed(delay);
        }
        catch (IOException error)
        {
            Debug.Log("Error: " + error.Message);
        }

    }

    public void StopSfx()
    {
        sfxSource.Stop();
    }

    private AudioClip FindMusicClip(string name)
    {
        Sound sound = Array.Find(musicSounds, x => x.name == name);
        if (sound != null)
        {
            return sound.clip;
        }
        else
        {
            Debug.Log("Sound Not Found");
            return null;
        }
    }

    private AudioClip FindSfxClip(string name)
    {
        Sound sound = Array.Find(sfxSounds, x => x.name == name);
        if (sound != null)
        {
            return sound.clip;
        }
        else
        {
            Debug.Log("Sound Not Found");
            return null;
        }
    }
}