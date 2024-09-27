using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector2 startTouchPosition, endTouchPosition;
    public float minSwipeDistance = 50f; // Minimum distance to be considered a swipe
    public LayerMask enemyLayer; // Layer to detect arrows

    void Update()
    {
        HandleMovement();
        HandleSwipeDetection();
    }

    void HandleMovement()
    {
        // Continuous upward movement
        transform.Translate(Vector3.up * Time.deltaTime);
    }

    void HandleSwipeDetection()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startTouchPosition = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            endTouchPosition = Input.mousePosition;
            DetectSwipe();
        }
    }

    void DetectSwipe()
    {
        float distance = Vector2.Distance(startTouchPosition, endTouchPosition);
        if (distance >= minSwipeDistance)
        {
            Vector2 direction = endTouchPosition - startTouchPosition;
            string swipeDirection = GetSwipeDirection(direction);
            Debug.Log("Swipe detected: " + swipeDirection);
            HandleSwipe(swipeDirection);
        }
    }

    string GetSwipeDirection(Vector2 direction)
    {
        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            return direction.x > 0 ? "Right" : "Left";
        }
        else
        {
            return direction.y > 0 ? "Up" : "Down";
        }
    }

    void HandleSwipe(string swipeDirection)
    {
        Vector2 worldPoint = Camera.main.ScreenToWorldPoint(startTouchPosition);
        Collider2D[] hits = Physics2D.OverlapPointAll(worldPoint, enemyLayer);

        foreach (var hit in hits)
        {
            EnemyArrow enemyArrow = hit.GetComponent<EnemyArrow>();
            if (enemyArrow != null && enemyArrow.isActive)
            {
                if ((enemyArrow.arrowType == EnemyArrow.ArrowType.Green && swipeDirection == "Up") ||
                    (enemyArrow.arrowType == EnemyArrow.ArrowType.Red && swipeDirection == "Down"))
                {
                    enemyArrow.OnCorrectSwipe();
                }
                else
                {
                    Debug.Log("Incorrect swipe direction for the arrow.");
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            EnemyArrow enemyArrow = collision.GetComponent<EnemyArrow>();
            if (enemyArrow != null && enemyArrow.isActive)
            {
                enemyArrow.OnCorrectSwipe();
            }
        }
    }

    void OnDrawGizmos()
    {
        if (startTouchPosition != Vector2.zero && endTouchPosition != Vector2.zero)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(Camera.main.ScreenToWorldPoint(startTouchPosition), Camera.main.ScreenToWorldPoint(endTouchPosition));
        }
    }
}
