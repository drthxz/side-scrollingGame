using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SaveLoad : MonoBehaviour
{

    const string fileName = "data.txt";

    Scene now_Scene;

    public void Save()
    {

        PlayerData data = new PlayerData();

        now_Scene = SceneManager.GetActiveScene();
        data.pos = Manager.instance.GetPlayer().transform.position;
        //data.pos = GameObject.Find("Character").transform.position;
        data.level = now_Scene.name;

        data.isLoad = true;
 
        if (!WriteData(fileName, data))
        {
            Debug.Log("save failed");
        }

    }

    public bool WriteData<T>(string file, T data) where T : class
    {
        string json = JsonUtility.ToJson(data);
        return WriteTextFile(fileName, json);
    }

    bool WriteTextFile(string file, string data)
    {
        bool ret = true;
        try
        {
            using (StreamWriter streamWriter = new StreamWriter(file))
            {
                streamWriter.Write(data);
            }
        }
        catch (System.Exception)
        {
            ret = false;
        }
        return ret;
    }

    public void Load()
    {

        PlayerData data = ReadData<PlayerData>(fileName);

        if (data != null)
        {
            now_Scene = SceneManager.GetActiveScene();
            if(data.level != now_Scene.name)
            {
               
                SceneManager.LoadScene(data.level);
            }
            Manager.instance.GetPlayer().transform.position = data.pos;
            //GameObject.Find("Character").transform.position = data.pos;

        }
        else
        {
            Debug.Log("Load failed");
        }
    }

    public T ReadData<T>(string file) where T : class
    {
        T data = null;
        string json = ReadTextFile(fileName);
        if (json != null)
        {
            data = JsonUtility.FromJson<T>(json);
        }
        return data;
    }

    string ReadTextFile(string file)
    {
        string data = null;
        try
        {
            using (StreamReader streamReader = new StreamReader(file))
            {
                data = streamReader.ReadToEnd();
            }
        }
        catch (System.Exception e)
        {
            Debug.Log("ERROR:" + e.ToString());
        }
        return data;
    }

    class PlayerData
    {
        public Vector3 pos;
        public string level;
        public bool isLoad;

    }

}
