using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakSlug : MonoBehaviour
{
    [SerializeField]
    private EdgeCollider2D weak1, weak2;

    [SerializeField]
    private SlugMovement slugMovement;

    public bool hitWeak = false;

    public void ActiveWeak1()
    {
        weak1.enabled = true;
        weak2.enabled = false;
    }

    public void ActiveWeak2()
    {
        weak1.enabled = false;
        weak2.enabled = true;
    }

    public void DisableCollider()
    {
        weak1.enabled = false;
        weak2.enabled = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            Debug.Log("Hit Player");
            slugMovement.DisableCollider();
            hitWeak = true;
        }
    }
}
