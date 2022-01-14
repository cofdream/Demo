using Cofdream.ToolKit;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    [SerializeField] new Rigidbody2D rigidbody2D;

    [SerializeField, ReadOnly] float maxSpeedX;

    public float jump = 3f;
    public bool canJump;

    public Collider2DTrigger trigger;

    void Start()
    {

    }

    private void FixedUpdate()
    {
        if (canJump && Input.GetKeyDown(KeyCode.Space))
        {
            //rigidbody2D.velocity = new Vector2(Mathf.Max(rigidbody2D.velocity.x, maxSpeedX), rigidbody2D.velocity.y);
        }
        float x = Input.GetAxis("Horizontal");

        if (x != 0)
        {
            rigidbody2D.AddForce(new Vector2(x, 0));
        }


        rigidbody2D.velocity = new Vector2(Mathf.Max(rigidbody2D.velocity.x, maxSpeedX), rigidbody2D.velocity.y);
    }
}