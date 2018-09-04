using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    public AudioSource effectSource;
    public AudioSource musicSource;
    public AudioSource pointSource;
    public static SoundManager instance = null;
    	
	void Awake () 
    {
		if(!instance)
        {
            instance = this;
        } 
        else if(instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
	}

    public void PlaySingle(AudioClip clip)
    {
        effectSource.clip = clip;
        effectSource.Play();
    }

    public void PlayPointSound(AudioClip clip)
    {
        pointSource.clip = clip;
        pointSource.Play();
    }
	
}
