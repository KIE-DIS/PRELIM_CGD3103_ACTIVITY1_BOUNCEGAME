using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPoint : MonoBehaviour
{
    float xRotation, yRotation = 0f;
    public Rigidbody golfBall;
    public float rotationSpeed = 5f;
    public float shootPower = 30f;
    public LineRenderer shootLine;

    void Update()
    {
        transform.position = golfBall.position;

        if (Input.GetMouseButton(0))
        {
            xRotation += Input.GetAxis("Mouse X") * rotationSpeed;
            yRotation += Input.GetAxis("Mouse Y") * rotationSpeed;
            if (yRotation < -35f)
            {
                yRotation = -35f;
            }
            transform.rotation = Quaternion.Euler(yRotation, xRotation, 0f);
            shootLine.gameObject.SetActive(true);
            shootLine.SetPosition(0, transform.position);
            shootLine.SetPosition(1, transform.position + transform.forward * 4f);
        }

        if (Input.GetMouseButtonUp(0))
        {
            golfBall.velocity = transform.forward * shootPower;
            shootLine.gameObject.SetActive(false);
        }
    }
}
