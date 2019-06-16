using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlugMovement : MonoBehaviour
{
    [SerializeField]
    private float speed;

    [SerializeField]
    private Vector3 startPosition;

    [SerializeField]
    private PolygonCollider2D collider1, collider2;

    [SerializeField]
    WeakSlug weakSlug;

    Rigidbody2D rigid;
    Animator animator;

    bool isDead = false;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead)
        {
            rigid.velocity = new Vector3(speed, rigid.velocity.y, 0);
            if (DistanceMove() > 2f)
            {
                startPosition = transform.position;
                speed *= -1;
                Vector3 scale = transform.localScale;
                scale.x *= -1;
                transform.localScale = scale;
            }
        }

        if (weakSlug.hitWeak)
            SlugDead();
    }

    float DistanceMove()
    {
        return (transform.position - startPosition).magnitude;
    }

    void ActiveCollider1()
    {
        collider1.enabled = true;
        collider2.enabled = false;
        weakSlug.ActiveWeak1();
    }

    void ActiveCollider2()
    {
        collider1.enabled = false;
        collider2.enabled = true;
        weakSlug.ActiveWeak2();
    }

    public void DisableCollider()
    {
        collider1.enabled = false;
        collider2.enabled = false;
    }

    void SlugDead()
    {
        DisableCollider();
        weakSlug.DisableCollider();
        isDead = true;
        speed = 0;
        collider1.enabled = false;
        collider2.enabled = false;
        animator.SetBool("isDead", true);
        Destroy(gameObject, 1.5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("bullet"))
        {
            SlugDead();
        }
    }
}
