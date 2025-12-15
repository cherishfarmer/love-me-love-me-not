using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CenterSway : MonoBehaviour
{
    private float rotateSpeed = 50f;
    private float maxRotation = 50f;
    // Update is called once per frame
    void Update()
    {
        float angle = Mathf.PingPong(Time.time * rotateSpeed, maxRotation * 2) - maxRotation;
        transform.rotation = Quaternion.Euler(0, 0, angle); // Rotate around the Z-axis for 2D
    }
}
