using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sfxController : MonoBehaviour
{
    public float volumen;
    public bool isLoopable;
    public float delayTime;
    public string clipName;
    AudioSource audioSource;

    private void Awake()
    {
        //volumen = 1f;
       // isLoopable = false;
       // delayTime = 0f;

    }
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = volumen;
        audioSource.loop = isLoopable;
    }

    //public void Play()
    //{
    //    if (delayTime != 0 && clipName != null)
    //    {
    //        AudioManager.Instance.PlaySfx(clipName, isLoopable, volumen, delayTime);
    //    }
    //    else if (volumen != 1f && clipName != null)
    //    {
    //        AudioManager.Instance.PlaySfx(clipName, isLoopable, volumen);
    //    }
    //    else if (isLoopable && clipName != null)
    //    {
    //        AudioManager.Instance.PlaySfx(clipName, isLoopable);
    //    }
    //    else if (clipName != null && volumen != 1f )
    //    {
    //        AudioManager.Instance.PlaySfx(clipName, volumen);
    //    }
    //    else
    //    {
    //        AudioManager.Instance.PlaySfx(clipName);
    //    }

    //}

    private void OnBecameInvisible()
    {

        audioSource.Stop();
    }

    private void OnBecameVisible()
    {
        if(delayTime!= 0f)
        {
            audioSource.PlayDelayed(delayTime);
        }
        else
        {
            audioSource.Play();
        }
    }
}
