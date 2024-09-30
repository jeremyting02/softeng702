using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveforwards : MonoBehaviour
{
    public float speed = 10f;

    void Update()
    {
        // for the ambulance
        transform.Translate(-Vector3.forward * speed * Time.deltaTime, Space.World);
    }
}