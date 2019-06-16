using Newtonsoft.Json;
using SimpleJSON;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
public class DataGame
{
    public string levelName;
    public int pointCoin;
    public int pointPear;
    public int pointCarrot;
}


public class DataManager : MonoBehaviour
{
    public static DataManager instance;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    public void SaveData(string @levelName, int @pointCoin, int @pointPear, int @pointCarrot)
    {
        DataGame data = new DataGame()
        {
            levelName = @levelName,
            pointCoin = @pointCoin,
            pointPear = @pointPear,
            pointCarrot = @pointCarrot
        };

        string json = JsonConvert.SerializeObject(data);
        string path = Application.persistentDataPath + "/" + @levelName + ".json";
        Debug.Log(path);
        File.WriteAllText(path, json);
    }

    public void CompareDataLevel(string @levelName, int @pointCoin, int @pointPear, int @pointCarrot)
    {
        var data = LoadData(@levelName);
        Debug.Log("Data: " + data);
        if(data != null)
        {
            if (pointCarrot > data.pointCarrot || @pointPear > data.pointPear || @pointCoin > data.pointCoin)
                SaveData(@levelName, @pointCoin, @pointPear, @pointCarrot);
        }
        else
            SaveData(@levelName, @pointCoin, @pointPear, @pointCarrot);
    }

    public DataGame LoadData(string @levelName)
    {
        string path = Application.persistentDataPath + "/" + @levelName + ".json";
        Debug.Log("Load Data =>>> " + @levelName + " | path: " + path);
        if (File.Exists(path))
        {
            var json = File.ReadAllText(path);
            Debug.Log(json);
            var data = JsonConvert.DeserializeObject<DataGame>(json);
            return data;
        }
        return null;
    }
}

