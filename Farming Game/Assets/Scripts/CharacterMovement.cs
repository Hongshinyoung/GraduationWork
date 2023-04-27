using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public Transform cameraTransform;
    public CharacterController controller;

    public float moveSpeed = 5f;
    public float jumpSpeed = 5f;
    public float gravity = -9.81f;
    public float yVelocity = 0;

    PlayerInteraction playerInteraction;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        playerInteraction = GetComponentInChildren<PlayerInteraction>(); //자식 객체에서 특정 컴포넌트 가져오기(가장 상위에 있는)

        //태양 움직임 체크
        if (Input.GetKey(KeyCode.RightBracket))
        {
            TimeManager.Instance.Tick();
        }
    }

    void Update()
    {
        Move();
        Interact();
    }

    public void Move() //움직임 구현 함수
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 moveDirection = new Vector3(h, 0, v);

        moveDirection = cameraTransform.TransformDirection(moveDirection);

        moveDirection *= moveSpeed;

        if (controller.isGrounded)
        {
            yVelocity = 0;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                yVelocity = jumpSpeed;
            }
        }

        yVelocity += (gravity * Time.deltaTime);
        moveDirection.y = yVelocity;
        controller.Move(moveDirection * Time.deltaTime);
    }

    public void Interact() //상호작용 구현 함수
    {
        //Tool interaction
        if (Input.GetButtonDown("Fire1"))
        {
            //Interact
            playerInteraction.Interact();
        }

        //마우스 왼쪽 클릭 시 playerInteraction.Interact() 호출
    }
}