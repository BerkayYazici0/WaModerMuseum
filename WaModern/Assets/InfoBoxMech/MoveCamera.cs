using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public Transform cameraPosition;

    private void Update()
    {
        transform.position = new Vector3(cameraPosition.position.x, cameraPosition.position.y, cameraPosition.position.z);
    }
}
