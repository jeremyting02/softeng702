using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveHelicopter : MonoBehaviour
{
    public float straightDistance = 10f; 
    public float straightAfterTurnDistance = 10f; 
    public float leftTurnDuration = 2f; 
    public float speed = 2f; 
    public float bankAngle = 10f; 

    private float distanceTraveled = 0f; 
    private float turnTime = 0f; 
    private Quaternion startRotation; 
    private Quaternion endRotation; 
    private bool isTurning = false; 

    void Start()
    {
        startRotation = transform.rotation;

        // Set the final rotation after the left turn (90 degrees to the left)
        endRotation = Quaternion.Euler(0, transform.eulerAngles.y - 90f, 0);
    }

    void Update()
    {
        if (isTurning)
        {
            TurnLeft();
        }
        else
        {
            if (distanceTraveled < straightDistance)
            {
                MoveStraight(straightDistance);
            }
            else
            {
                isTurning = true;
                distanceTraveled = 0f; 
            }
        }
    }

    void MoveStraight(float distanceToMove)
    {
        float moveStep = speed * Time.deltaTime;
        Vector3 adjustedForward = Quaternion.Euler(0, -90, 0) * transform.forward;
        transform.Translate(adjustedForward * moveStep, Space.World);

        distanceTraveled += moveStep;

        if (distanceTraveled >= distanceToMove)
        {

            distanceTraveled = 0f; 
            isTurning = true; 
        }
    }

    void TurnLeft()
    {
        turnTime += Time.deltaTime;


        float t = turnTime / leftTurnDuration;
        transform.rotation = Quaternion.Slerp(startRotation, endRotation, t);

        float bank = Mathf.Sin(t * Mathf.PI) * bankAngle; 
        transform.rotation = transform.rotation * Quaternion.Euler(0, 0, bank);

        float moveStep = speed * Time.deltaTime;
        Vector3 adjustedForward = Quaternion.Euler(0, -90, 0) * transform.forward;
        transform.Translate(adjustedForward * moveStep, Space.World);

        if (turnTime >= leftTurnDuration)
        {
            turnTime = 0f; 
            startRotation = transform.rotation;
            endRotation = Quaternion.Euler(0, transform.eulerAngles.y - 90f, 0); 
            isTurning = false; 

            distanceTraveled = 0f; 
            straightDistance = straightAfterTurnDistance; 
        }
    }
}