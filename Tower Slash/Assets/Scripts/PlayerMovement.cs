using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    public float speed = 2f;
    public float leapDistance = 2f;

    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);

        if (Input.GetMouseButtonDown(0))
        {
            // Add leap distance
            transform.Translate(Vector2.up * leapDistance);
            // Add score logic here
        }
    }
}
