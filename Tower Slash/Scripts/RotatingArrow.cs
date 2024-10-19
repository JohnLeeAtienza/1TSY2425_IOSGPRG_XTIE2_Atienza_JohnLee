using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingArrow : MonoBehaviour
{
    public float rotationSpeed = 100f; // Rotation speed in degrees per second
    public float minStopAngle = 90f; // Minimum angle to stop rotating
    public float maxStopAngle = 180f; // Maximum angle to stop rotating
    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (!IsWithinStopRange())
        {
            RotateArrow();
        }
    }

    void RotateArrow()
    {
        transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
    }

    bool IsWithinStopRange()
    {
        if (player == null)
            return false;

        Vector2 directionToPlayer = (player.position - transform.position).normalized;
        float angleToPlayer = Mathf.Atan2(directionToPlayer.y, directionToPlayer.x) * Mathf.Rad2Deg;

        float currentAngle = transform.eulerAngles.z;

        float angleDifference = Mathf.DeltaAngle(currentAngle, angleToPlayer);

        Debug.Log("Angle to Player: " + angleToPlayer);
        Debug.Log("Current Angle: " + currentAngle);
        Debug.Log("Angle Difference: " + angleDifference);

        return angleDifference >= minStopAngle && angleDifference <= maxStopAngle;
    }
}
