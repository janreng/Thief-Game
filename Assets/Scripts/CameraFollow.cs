using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public static CameraFollow instance;

    [SerializeField]
    private Transform target;

    Vector3 velocity = Vector3.zero;

    public float smoothTime = .15f;

    public bool yMaxEnabled = false;
    public float yMaxValue = 0;

    public bool yMinEnabled = false;
    public float yMinValue = 0;

    public bool xMaxEnabled = false;
    public float xMaxValue = 0;
    public bool xMinEnabled = false;
    public float xMinValue = 0;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    void FixedUpdate()
    {

        //target position
        Vector3 targetPos = target.position;

        //vertical
        if (yMinEnabled && yMaxEnabled)
            targetPos.y = Mathf.Clamp(target.position.y, yMinValue, yMaxValue);

        else if (yMinEnabled)
            targetPos.y = Mathf.Clamp(target.position.y, yMinValue, target.position.y);

        else if (yMaxEnabled)
            targetPos.y = Mathf.Clamp(target.position.y, target.position.y, yMaxValue);

        //horizontal
        if (xMinEnabled && xMaxEnabled)
            targetPos.x = Mathf.Clamp(target.position.x, xMinValue, xMaxValue);

        else if (xMinEnabled)
            targetPos.x = Mathf.Clamp(target.position.x, xMinValue, target.position.x);

        else if (xMaxEnabled)
            targetPos.x = Mathf.Clamp(target.position.x, target.position.x, xMaxValue);


        //align the camera and targets z position
        targetPos.z = transform.position.z;

        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, smoothTime);
    }

    public void SetBound(float xMin, float xMax, float yMin, float yMax)
    {
        xMinValue = xMin;
        xMaxValue = xMax;
        yMinValue = yMin;
        yMaxValue = yMax;
    }
}
