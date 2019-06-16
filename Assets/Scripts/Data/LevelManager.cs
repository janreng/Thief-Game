using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Spine.Unity;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    [SerializeField]
    List<DataLevel> dataLevel;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    public void LoadLevel(string levelSelect)
    {
        foreach (var item in dataLevel)
        {
            if (item.levelData.name == levelSelect && item.levelLock == false)
            {
                GameObject map = Instantiate(item.levelData);
                Debug.Log("Render map: " + map.name);
                map.name = item.levelData.name;
                map.transform.SetParent(GameObject.Find("LevelGame").transform);

                CameraFollow.instance.SetBound(item.xMin, item.xMax, item.yMin, item.yMax);
            }
        }
    }

    public bool CheckLockLevel(string levelSelect)
    {
        Debug.Log("Check Lock =>>> " + levelSelect);
        foreach (var item in dataLevel)
        {
            if (item.levelData.name == levelSelect)
            {
                return item.levelLock;
            }
        }
        return false;
    }

    public DataLevel GetDataLvel(string levelName)
    {
        Debug.Log("Get DataLevel =>>> " + levelName);
        foreach (var item in dataLevel)
        {
            if (item.levelData.name == levelName)
                return item;
        }
        return null;
    }

}
