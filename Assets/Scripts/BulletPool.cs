using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    public GameObject[] bulletPool;
    // Start is called before the first frame update
    void Start()
    {
        bulletPool = new GameObject[5];
        for(int i = 0; i < bulletPool.Length; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab, this.transform);
            bulletPool[i] = bullet;
            bullet.SetActive(false);
        }
    }
}
