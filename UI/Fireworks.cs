using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireworks : MonoBehaviour {

	// Use this for initialization
	AudioSource sound;
	public AudioClip[] fireWorks;
	float time=1;
	float musicVolume = 1f;
	void Start () {
		sound=GetComponent<AudioSource>();
		
		
		
	}
	
	// Update is called once per frame
	void Update () {
		sound.volume = musicVolume;
		time+=Time.deltaTime;
		if(time>=1){
			time=0;
			sound.PlayOneShot(fireWorks[Random.Range (0, fireWorks.Length)]);
		}
	}

	public void SetVolume(float vol)
    {
        musicVolume = vol;
    }
}
