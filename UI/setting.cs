using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;


public class setting : Menu {

    GameObject optional;
    bool isOpen=false;

    AudioSource BGM;
    
    // Use this for initialization
    public override void Start () {
        base.Start();
        optional = GameObject.Find("Optionals");
        optional.SetActive(isOpen);

        BGM = GetComponent<AudioSource>();
    }

    public void Optionals()
    {
        if (isSetting == false) { 
        isOpen = !isOpen;
        optional.SetActive(isOpen);
        if (isOpen == true) { 
        Time.timeScale = 0;
        BGM.Pause();
        }
        else
        {
            Time.timeScale = 1;
            BGM.Play();
        }
        }
    }

    public override void Settings()
    {
        base.Settings();
    }

    public override void Full()
    {
        base.Full();
    }

    public void Title(){
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public override void Exit(){
    Application.Quit();
    }
}
