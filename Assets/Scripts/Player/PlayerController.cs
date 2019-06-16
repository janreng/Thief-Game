using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Transform groundCheck;

    [SerializeField]
    private LayerMask whatIsGround;

    [SerializeField]
    private Rigidbody2D rigid;

    [SerializeField]
    private float speed = 1.5f;

    [SerializeField]
    private float force;

    [SerializeField]
    private Transform muzzle;

    [SerializeField]
    private GameObject bulletPrefab;

    [SerializeField]
    private CircleCollider2D bottomCollier, topCollider;

    [SerializeField]
    private SkeletonAnimation anim;

    [SerializeField]
    private BulletPool pool;

    float groundRadius = .2f;
    bool ground = false;

    bool facingRight = true;

    public bool isPlay = false;

    bool doubleJump;

    void FixedUpdate()
    {
        //float move = Input.GetAxis("Horizontal");

        rigid.velocity = new Vector3(speed, rigid.velocity.y, 0);

        ground = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);

        if (ground)
            doubleJump = false;

        //animation
        if (ground && rigid.velocity.x != 0)
            anim.AnimationName = "animation";
        else
            anim.AnimationName = "gun";

        // direction player
        if (speed > 0 && !facingRight)
            Flip();
        else if (speed < 0 && facingRight)
            Flip();

    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    public void Jump()
    {
        if ((ground || !ground) && !doubleJump)
        {
            AudioManager.instance.PlaySound("jump");
            anim.AnimationName = "gun";
            rigid.AddForce(new Vector2(0, force));
            if (!doubleJump && !ground)
                doubleJump = true;
        }
    }

    public void MoveRightDown()
    {
        speed = 1.5f;
    }

    public void MoveRightUp()
    {
        speed = 0f;
    }

    public void MoveLeftDown()
    {
        speed = -1.5f;
    }

    public void MoveLeftUp()
    {
        speed = 0f;
    }

    public void Fire()
    {
        AudioManager.instance.PlaySound("point");
        //GameObject bullet = Instantiate(bulletPrefab, muzzle.position, Quaternion.identity);
        foreach(var item in pool.bulletPool)
        {
            if(!item.activeInHierarchy)
            {
                item.SetActive(true);
                item.transform.position = muzzle.position;
                break;
            }
        }
    }

    void OnMouseDown()
    {
        Debug.Log("Play");
        isPlay = true;
        UIManager.instance.EnableJumpAndFire();
    }

    //enable collider
    public void EnableCollider()
    {
        bottomCollier.enabled = true;
        topCollider.enabled = true;
    }

    //disable collider
    public void DisableCollider()
    {
        isPlay = false;
        bottomCollier.enabled = false;
        topCollider.enabled = false;
    }
}
