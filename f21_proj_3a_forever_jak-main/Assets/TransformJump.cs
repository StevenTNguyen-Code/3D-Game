using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformJump : MonoBehaviour
{
    public GroundCheck groundCheck;
    public float jumpForce = 20;
    public float gravity = -9.81f;
    public float gravityScale = 5;
    float velocity;

    void Update()
    {
        velocity += gravity * gravityScale * Time.deltaTime;

        if (groundCheck.isGrounded && velocity < 0)
        {
            velocity = 0;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            velocity = jumpForce;
        }

        transform.Translate(new Vector3(0, velocity, 0) * Time.deltaTime);
    }
}