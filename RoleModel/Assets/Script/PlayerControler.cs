using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    [Range(0, 100f)]
    public float maxSpeed = 10f;

    [Header("加速度")]
    [Range(0, 100f)]
    public float maxAcceleration = 10f;

    [SerializeField]
    Rect allowedArea = new Rect(-4.5f, -4.5f, 9, 9);

    [SerializeField, Range(0f, 1f)]
    float bounchiness = 0.5f;

    Vector3 velocity;

    public Vector2 playerInput;


    void Start()
    {

    }


    void Update()
    {

        playerInput.x = Input.GetAxis("Horizontal");
        playerInput.y = Input.GetAxis("Vertical");

        playerInput = Vector2.ClampMagnitude(playerInput, 1f);

        Vector3 desiredVelocity = new Vector3(playerInput.x, 0, playerInput.y) * maxSpeed;//期望速度
        float maxSpeedChange = maxAcceleration * Time.deltaTime;

        velocity.x = Mathf.MoveTowards(velocity.x, desiredVelocity.x, maxSpeedChange);
        velocity.z = Mathf.MoveTowards(velocity.z, desiredVelocity.z, maxSpeedChange);

        Vector3 displacement = velocity * Time.deltaTime;

        Vector3 newPosition = transform.localPosition + displacement;

        //if (newPosition.x < allowedArea.xMin)
        //{
        //    newPosition.x = allowedArea.xMin;
        //    velocity.x = -velocity.x * bounchiness;
        //}
        //else if (newPosition.x > allowedArea.xMax)
        //{
        //    newPosition.x = allowedArea.xMax;
        //    velocity.x = -velocity.x * bounchiness;
        //}

        //if (newPosition.z < allowedArea.yMin)
        //{
        //    newPosition.z = allowedArea.yMin;
        //    velocity.z = -velocity.z * bounchiness;
        //}
        //else if (newPosition.z > allowedArea.yMax)
        //{
        //    newPosition.z = allowedArea.yMax;
        //    velocity.z = -velocity.z * bounchiness;
        //}

        transform.localPosition = newPosition;
    }
}
