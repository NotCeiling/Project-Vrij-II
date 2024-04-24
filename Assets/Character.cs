using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 1f;
    public float gravity = 9.81f;
    public float jumpHeight = 1f;
    public float yVelocity = 0f;

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 velocity = new Vector3(horizontal, 0, vertical) * speed;

        if (controller.isGrounded)
        { 
            if (Input.GetKeyDown(KeyCode.Space))
            {
                yVelocity = jumpHeight;
            } 
        }
        else
        {
            yVelocity = yVelocity - (gravity * Time.deltaTime);
        }
        velocity.y = yVelocity;

        controller.Move(velocity * Time.deltaTime);
    }
}
