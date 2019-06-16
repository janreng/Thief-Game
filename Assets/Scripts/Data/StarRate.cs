using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarRate : MonoBehaviour
{
    public GameObject starYellow;

    public void CheckStarLevel()
    {
        Debug.Log("Check Star");
        string map = "Level" + MapManager.instance.currentMap;
        var data = DataManager.instance.LoadData(map);

        if (data == null)
            return;

        var datalevel = LevelManager.instance.GetDataLvel(map);
        float rate = (data.pointCarrot + data.pointCoin + data.pointPear) / (datalevel.coinData + datalevel.carrotPointData + datalevel.pearPointData);
        Debug.Log("Rate: " + rate);

        if (rate >= 0.2)
            ShowStarYellow(1);
        if (rate >= 0.5)
            ShowStarYellow(2);
        if (rate >= 0.9)
            ShowStarYellow(3);
        if( rate > 1 && rate <= 0)
            ShowStarYellow(0);

    }

    void ShowStarYellow(int number)
    {
        Debug.Log("Show Star Yellow");
        for (int i = 0; i < number; i++)
            starYellow.transform.GetChild(i).gameObject.SetActive(true);
    }
}
