using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SE : MonoBehaviour {

	AudioSource inWater;
    float musicVolume = 1f;
	// Use this for initialization
	void Start () {
		inWater=GetComponent<AudioSource>();
	}
	
	// Update is called once per frame

	void Update()
    {
        inWater.volume = musicVolume;
    }

    public void SetVolume(float vol)
    {
        musicVolume = vol;
    }
	void OnTriggerEnter(Collider other)
    {
        
            inWater.Play();
        
    }

	void OnTriggerExit(Collider other)
	{
		
            inWater.Stop();
        
	}
}
