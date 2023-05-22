using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileCamera : MonoBehaviour
{
    public VariableJoystick variableJoystick;
    public float mouseSens = 100f;
    public float xRot = 0f;
    public Transform Parent;
    public void FixedUpdate()
    {
        float mousex = variableJoystick.Horizontal * mouseSens * Time.deltaTime;
        float mousey = variableJoystick.Vertical * mouseSens * Time.deltaTime;
        Parent.Rotate(Vector3.up * mousex);

        xRot -= mousey;
        xRot = Mathf.Clamp(xRot, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);
    }
}

