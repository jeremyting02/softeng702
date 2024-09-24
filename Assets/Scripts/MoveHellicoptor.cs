using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveHelicopter : MonoBehaviour
{
    public float radius = 5f; // Radius of the circular path
    public float speed = 2f; // Speed of the movement

    private Vector3 initialPosition; // Starting position
    private float angle = 0f; // Current angle in radians

    void Start()
    {
        // Store the starting position of the helicopter
        initialPosition = transform.position;
    }

    void Update()
    {
        // Update the angle based on speed and time
        angle += speed * Time.deltaTime;

        // Calculate the new position based on the angle and radius
        float x = Mathf.Cos(angle) * radius; // X position
        float z = Mathf.Sin(angle) * radius; // Z position

        // Update the position of the helicopter, keeping the original Y height
        transform.position = new Vector3(initialPosition.x + x, initialPosition.y, initialPosition.z + z);
    }
}