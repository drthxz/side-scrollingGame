using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Voice : MonoBehaviour
{
    

    AudioSource Bgm;
    float musicVolume = 1f;

    // Start is called before the first frame update
    void Start()
    {
        Bgm = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Bgm.volume = musicVolume;
        
    }

    public void SetVolume(float vol)
    {
        musicVolume = vol;
    }

    
}
