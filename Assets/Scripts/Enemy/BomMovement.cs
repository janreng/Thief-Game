using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class BomMovement : MonoBehaviour
{
    [SerializeField]
    private float speed;

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(-0.1f, -0.1f, 0) * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ground") || collision.CompareTag("Player"))
        {
            speed = 0;
            animator.SetBool("isDestroy", true);
            Destroy(this.gameObject, 2f);
        }
    }
}
