using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuVoice : MonoBehaviour
{
    

    AudioSource Bgm;
    float musicVolume = 1f;

    public AudioClip [] mainBGM;

    // Start is called before the first frame update
    void Start()
    {
        Bgm = GetComponent<AudioSource>();
        Bgm.clip=mainBGM[Random.Range (0, mainBGM.Length)];
        Bgm.Play();
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
