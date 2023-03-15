using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public Transform cameraTransform;
    public CharacterController characterController;

    public float moveSpeed = 5f;
    public float jumpSpeed = 5f;
    public float gravity = -9.81f;
    public float yVelocity = 0;

    void Start()
    {

    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 moveDirection = new Vector3(h, 0, v);

        moveDirection = cameraTransform.TransformDirection(moveDirection);

        moveDirection *= moveSpeed;

        if (characterController.isGrounded)
        {
            yVelocity = 0;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                yVelocity = jumpSpeed;
            }
        }

        yVelocity += (gravity * Time.deltaTime);
        moveDirection.y = yVelocity;
        characterController.Move(moveDirection * Time.deltaTime);
    }
}