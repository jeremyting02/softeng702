using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveforwards : MonoBehaviour
{
    // Speed of the car (modifiable in the Inspector)
    public float speed = 10f;

    // Update is called once per frame
    void Update()
    {
        // Move the car forward along the world's Z-axis (ground plane)
        transform.Translate(-Vector3.forward * speed * Time.deltaTime, Space.World);
    }
}