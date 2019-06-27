using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;

public class Menu : MonoBehaviour {
	public ToggleGroup toggleGroup;
	GameObject Setting;
	public bool isSetting=false;



	// Use this for initialization
	public virtual void Start () {
		Setting=GameObject.Find("Setting");
		Setting.SetActive(isSetting);

	}

	public void GameStart(){
		SceneManager.LoadScene("Level_Teaching");
	}

	public virtual void Exit(){
		Application.Quit();
	}


	public virtual void Settings()
    {
        isSetting = !isSetting;
        Setting.SetActive(isSetting);

    }
	public virtual void Full()
    {
        string temp = toggleGroup.ActiveToggles().FirstOrDefault().GetComponentInChildren<Text>().text;
        if(temp == "fullモード")
        {
            Screen.fullScreen = true;
        }
        else
        {
            Screen.fullScreen = false;
        }

    }

}
