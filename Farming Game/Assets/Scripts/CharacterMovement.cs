using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float speed = 5f;

    private Rigidbody rid;

    void Start()
    {
        rid = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(horizontal, 0f, vertical);

        rid.velocity = move * speed;

        if (move != Vector3.zero)
        {
            rid.transform.forward = move;
        }
    }
}