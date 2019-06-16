using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HomeUIManager : MonoBehaviour
{
    public static HomeUIManager instance;

    [Header("Shop UI")]
    [SerializeField]
    private GameObject shopUI;

    [Header("Home UI")]
    [SerializeField]
    private GameObject homeUI;

    public Image soundImage;

    [Header("Map UI")]
    [SerializeField]
    private StarRate starRate;
    [SerializeField]
    private GameObject mapUI;
    [SerializeField]
    private GameObject mapView;
    private int i = 0;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    private void Start()
    {
        Time.timeScale = 1;
        CheckMuteSound();
    }

    //shop
    public void ShowShopUI()
    {
        shopUI.SetActive(true);
    }

    public void HideShopUI()
    {
        shopUI.SetActive(false);
    }

    //home
    public void ShowHomeUI()
    {
        homeUI.SetActive(true);
    }

    public void HideHomeUI()
    {
        homeUI.SetActive(false);
    }

    //map
    public void ShowMapUI()
    {
        mapUI.SetActive(true);
        for (int i = 0; i < mapView.transform.childCount; i++)
        {
            if (i == 0)
            {
                mapView.transform.GetChild(i).gameObject.SetActive(true);
                mapView.transform.GetChild(i).GetComponent<StarRate>().CheckStarLevel();
            }
            else
                mapView.transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    public void HideMapUI()
    {
        mapUI.SetActive(false);
    }

    public void BtnMapPrevious()
    {
        if (i - 1 >= 0)
        {
            i--;
            MapManager.instance.currentMap--;
            DisplayMap();
        }
    }

    public void BtnMapNext()
    {
        if (i + 1 < mapView.transform.childCount)
        {
            i++;
            MapManager.instance.currentMap++;
            DisplayMap();
        }
    }

    public void DisplayMap()
    {
        foreach (Transform child in mapView.transform)
        {
            child.gameObject.SetActive(false);
        }
        mapView.transform.GetChild(i).gameObject.SetActive(true);
    }


    public void PlayGame()
    {
        string map = "Level" + MapManager.instance.currentMap;
        Debug.Log("Level Select: " + map);
        bool isLock = LevelManager.instance.CheckLockLevel(map);
        if (!isLock)
            SceneManager.LoadScene("Play");
    }

    public void SelectMap()
    {
        PlayGame();
    }



    public void PressSound()
    {
        AudioManager.instance.MuteSound();
        AudioManager.instance.isMute = !AudioManager.instance.isMute;
        CheckMuteSound();
    }

    void CheckMuteSound()
    {
        if (AudioManager.instance.isMute)
        {
            soundImage.sprite = AudioManager.instance.offSound;
        }
        else
        {
            soundImage.sprite = AudioManager.instance.onSound;
        }
    }

}
