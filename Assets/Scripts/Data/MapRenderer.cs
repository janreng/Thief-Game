using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapRenderer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform child in this.transform)
        {
            Destroy(child.gameObject);
        }
        string map = "Level" + MapManager.instance.currentMap;
        LevelManager.instance.LoadLevel(map);
        GameManager.instance.ResetPoint();
    }
}
