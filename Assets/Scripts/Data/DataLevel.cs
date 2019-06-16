using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "DataLevel/Level")]
public class DataLevel : ScriptableObject
{
    [SerializeField]
    public GameObject levelData;

    [SerializeField]
    public bool levelLock;

    [SerializeField]
    public float carrotPointData;

    [SerializeField]
    public float pearPointData;

    [SerializeField]
    public float coinData;

    [SerializeField]
    public Vector3 playerPositionData;

    public float xMin, xMax, yMin, yMax;
}
