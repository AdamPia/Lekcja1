using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    float mouseSensivity = 100f;
    Transform playerbody;
    float xRotation = 0f;
    float yRotation = 0f;


    private void Start()
    {
        playerbody = transform.parent;
    }

    private void Update()
    {
        CameraRotation();
    }

    private void CameraRotation()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        yRotation += mouseX;
        playerbody.localRotation = Quaternion.Euler(0f, yRotation, 0f);
        //playerbody.Rotate(Vector3.up * mouseX);
    }
}
