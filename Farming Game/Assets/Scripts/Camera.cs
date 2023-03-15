using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public float sesitivity = 800;
    public float rotationX =15f;
    public float rotationY = 900;

    void Start()
    {

    }

    void Update()
    {
        float mouseMoveX = Input.GetAxis("Mouse X");
        float mouseMoveY = Input.GetAxis("Mouse Y");

        rotationY += mouseMoveX * sesitivity * Time.deltaTime;

        rotationX += mouseMoveY * sesitivity * Time.deltaTime;

        if (rotationX > 35f)
        {
            rotationX = 35f;
        }

        if (rotationX < -30f)
        {
            rotationX = -30f;
        }

        transform.eulerAngles = new Vector3(-rotationX, rotationY, 0);
    }
}
