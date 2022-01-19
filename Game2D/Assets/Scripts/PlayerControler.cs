using Cofdream.ToolKit;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    [SerializeField] new Rigidbody2D rigidbody2D;
    [SerializeField] float maxSpeedX;
    [SerializeField] SpriteRenderer sprite;
    [SerializeField] Animator animator;

    public float jumpPower = 3f;
    public bool canJump;

    public Collider2DTrigger trigger;

    void Start()
    {

    }

    private void Update()
    {
        if (Input.GetKeyDown("Jump"))
        {
            rigidbody2D.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        }


        if (Input.GetButtonUp("Horizontal"))
        {
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.normalized.x * 0.5f, rigidbody2D.velocity.y);
        }

        float x = Input.GetAxisRaw("Horizontal");
        if (x != 0)
        {
            sprite.flipX = Input.GetAxisRaw("Horizontal") == -1;
        }

        if (Mathf.Abs(rigidbody2D.velocity.x) < 0.3f)
        {
            animator.SetBool("IsWalk", false);
        }
        else
        {
            animator.SetBool("IsWalk", true);
        }
    }

    private void FixedUpdate()
    {
        if (canJump == false)
        {
            if (rigidbody2D.IsTouchingLayers())
            {
                canJump = true;
                animator.SetBool("IsJump", true);
            }
        }
        if (canJump && Input.GetKeyDown(KeyCode.Space))
        {
            canJump = false;
            
            animator.SetBool("IsJump", true);
        }

        float x = Input.GetAxisRaw("Horizontal");
        rigidbody2D.AddForce(Vector2.right * x, ForceMode2D.Impulse);

        if (rigidbody2D.velocity.x > maxSpeedX)
        {
            rigidbody2D.velocity = new Vector2(maxSpeedX, rigidbody2D.velocity.y);
        }
        else if (rigidbody2D.velocity.x < -maxSpeedX)
        {
            rigidbody2D.velocity = new Vector2(-maxSpeedX, rigidbody2D.velocity.y);
        }

        //rigidbody2D.velocity = new Vector2(Mathf.Max(rigidbody2D.velocity.x, maxSpeedX), rigidbody2D.velocity.y);
    }
}