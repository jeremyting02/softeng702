using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveHelicopter : MonoBehaviour
{
    public float straightDistance = 10f; // Distance to move straight initially
    public float straightAfterTurnDistance = 10f; // Distance to move straight after each turn
    public float leftTurnDuration = 2f; // Time duration to complete each left turn
    public float speed = 2f; // Speed of the helicopter movement
    public float bankAngle = 10f; // Angle to bank the helicopter during the turn

    private float distanceTraveled = 0f; // Track the distance traveled forward
    private float turnTime = 0f; // Time spent turning left
    private Quaternion startRotation; // Starting rotation before turning
    private Quaternion endRotation; // Ending rotation after the turn
    private bool isTurning = false; // Flag to indicate if the helicopter is currently turning

    void Start()
    {
        // Store the starting rotation
        startRotation = transform.rotation;

        // Set the final rotation after the left turn (90 degrees to the left)
        endRotation = Quaternion.Euler(0, transform.eulerAngles.y - 90f, 0);
    }

    void Update()
    {
        // Check if the helicopter is turning
        if (isTurning)
        {
            TurnLeft();
        }
        else
        {
            // Move forward and check if the straight movement is done
            if (distanceTraveled < straightDistance)
            {
                MoveStraight(straightDistance);
            }
            else
            {
                // Start turning left after moving straight
                isTurning = true;
                distanceTraveled = 0f; // Reset distance for the next move
            }
        }
    }

    void MoveStraight(float distanceToMove)
    {
        // Move the helicopter forward in the corrected direction (-90 degrees on the Y axis)
        float moveStep = speed * Time.deltaTime;
        Vector3 adjustedForward = Quaternion.Euler(0, -90, 0) * transform.forward;
        transform.Translate(adjustedForward * moveStep, Space.World);

        distanceTraveled += moveStep;

        // After moving straight for the desired distance, we check if we need to transition
        if (distanceTraveled >= distanceToMove)
        {
            // Transition to turning left after the initial move
            distanceTraveled = 0f; // Reset for future use
            isTurning = true; // Trigger the left turn
        }
    }

    void TurnLeft()
    {
        turnTime += Time.deltaTime;

        // Perform smooth interpolation between the start and end rotation over time
        float t = turnTime / leftTurnDuration;
        transform.rotation = Quaternion.Slerp(startRotation, endRotation, t);

        // Simulate helicopter banking by adjusting the Z-axis tilt (banking left during the turn)
        float bank = Mathf.Sin(t * Mathf.PI) * bankAngle; // Bank angle peaks at halfway through the turn
        transform.rotation = transform.rotation * Quaternion.Euler(0, 0, bank);

        // Move forward during the turn to simulate forward motion while turning
        float moveStep = speed * Time.deltaTime;
        Vector3 adjustedForward = Quaternion.Euler(0, -90, 0) * transform.forward;
        transform.Translate(adjustedForward * moveStep, Space.World);

        // After completing the left turn, reset variables and move straight again
        if (turnTime >= leftTurnDuration)
        {
            // Reset for the next straight movement
            turnTime = 0f; // Reset turn time for future use
            startRotation = transform.rotation; // Set the new start rotation for the next turn
            endRotation = Quaternion.Euler(0, transform.eulerAngles.y - 90f, 0); // Prepare for the next left turn
            isTurning = false; // Reset the turning flag to move straight again

            // Reset distanceTraveled to prepare for moving straight again
            distanceTraveled = 0f; 
            straightDistance = straightAfterTurnDistance; // Set to the distance for straight after the turn
        }
    }
}