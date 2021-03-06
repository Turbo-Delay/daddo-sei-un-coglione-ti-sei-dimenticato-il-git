using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOrbit : MonoBehaviour
{
    public float lookSensitivity;

    public float minXLook;

    public float maxXLook;

    public Transform camAnchor;

    public bool invertXRotation;

    private float curXRot;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    // Update is called once per frame
    void LateUpdate()
    {
        // get mouse position
        float x = Input.GetAxis("Mouse X");
        float y = Input.GetAxis("Mouse Y");

        //move camera horizoltay
        transform.eulerAngles += Vector3.up * x * lookSensitivity;

        // move camera verticaly
        if(invertXRotation)
            curXRot += y * lookSensitivity;
        else
            curXRot -= y * lookSensitivity;

        curXRot = Mathf.Clamp(curXRot, minXLook, maxXLook);
        Vector3 angle = camAnchor.eulerAngles;
        angle.x = curXRot;
        camAnchor.eulerAngles = angle;
    }
}
