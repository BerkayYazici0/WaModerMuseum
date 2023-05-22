using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickPlayerExample : MonoBehaviour
{
    public float speed;
    public VariableJoystick variableJoystick;
    public Rigidbody rb;

    public void FixedUpdate()
    {
        Vector3 direction = transform.forward * variableJoystick.Vertical + transform.right * variableJoystick.Horizontal;
        transform.Translate(direction * speed * Time.deltaTime);
    }
}