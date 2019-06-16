using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int pointCarrot, pointPear, pointCoin;

    public bool isDead = false;
    public bool isWin = false;

    public int hitCarrot, hitPear, hitCoin;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        pointCarrot = 10;
        pointPear = 10;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && isDead)
        {
            isDead = false;
            ResetPoint();
            SceneManager.LoadScene("Play");
        }
        if (Input.GetMouseButtonDown(0) && isWin)
        {
            isWin = false;
            ResetPoint();
            SceneManager.LoadScene("Home");
        }

    }

    private void OnMouseDown()
    {
        if (isDead)
        {
            isDead = false;
            ResetPoint();
            SceneManager.LoadScene("Play");
        }
        if (isWin)
        {
            isWin = false;
            ResetPoint();
            SceneManager.LoadScene("Home");
        }
    }

    public void ResetPoint()
    {
        pointCarrot = 10;
        pointPear = 10;
        pointCoin = 0;

        //current point
        hitCarrot = 0;
        hitPear = 0;
        hitCoin = 0;
    }

    //public void SaveData()
    //{
    //    if(isWin )
    //    {
    //        string levelName = "Level" + MapManager.instance.currentMap;
    //        DataManager.instance.SaveData(levelName, hitCoin, hitPear, hitCarrot);
    //    }
    //}

    public void CompareData()
    {
        string levelName = "Level" + MapManager.instance.currentMap;
        DataManager.instance.CompareDataLevel(levelName, hitCoin, hitPear, hitCarrot);
    }

}
