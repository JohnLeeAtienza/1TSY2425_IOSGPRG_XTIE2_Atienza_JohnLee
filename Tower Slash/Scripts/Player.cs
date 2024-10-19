using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Player : MonoBehaviour
{
    public int health = 3;
    public DashGauge dashGauge;
    public float maxDashGauge = 100f;
    private Vector2 startTouchPosition;
    private Vector2 currentPosition;
    private bool stopTouch = false;
    public float swipeRange = 50f;
    private EnemyArrow currentArrow;
    public float dashDistance = 5f;
    public float dashDuration = 0.5f;
    private bool isDashing = false;
    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        if (health <= 0)
        {
            SceneManager.LoadScene("GameOverScene");
        }

        SwipeDetection();
        if (Input.GetButtonDown("Dash") && !isDashing && health > 0)
        {
            StartCoroutine(Dash());
        }
    }

    void SwipeDetection()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startTouchPosition = Input.mousePosition;
            stopTouch = false;
        }

        if (Input.GetMouseButton(0))
        {
            currentPosition = Input.mousePosition;
            Vector2 distance = currentPosition - startTouchPosition;

            if (!stopTouch)
            {
                if (distance.y > swipeRange)
                {
                    SwipeUp();
                    stopTouch = true;
                }
                else if (distance.y < -swipeRange)
                {
                    SwipeDown();
                    stopTouch = true;
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            stopTouch = true;
        }
    }

    void SwipeUp()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (hit.collider != null)
        {
            currentArrow = hit.collider.GetComponent<EnemyArrow>();
            if (currentArrow != null && currentArrow.arrowType == EnemyArrow.ArrowType.Green)
            {
                currentArrow.OnCorrectSwipe();
                dashGauge.IncreaseDash();
                ScoreManager.Instance.AddScore(1);
            }
        }
    }

    void SwipeDown()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (hit.collider != null)
        {
            currentArrow = hit.collider.GetComponent<EnemyArrow>();
            if (currentArrow != null && currentArrow.arrowType == EnemyArrow.ArrowType.Red)
            {
                currentArrow.OnCorrectSwipe();
                dashGauge.IncreaseDash();
                ScoreManager.Instance.AddScore(1);
            }
        }
    }

    private IEnumerator Dash()
    {
        isDashing = true;
        Vector3 dashTarget = transform.position + transform.up * dashDistance;
        float dashTime = 0;

        while (dashTime < dashDuration)
        {
            transform.position = Vector3.Lerp(transform.position, dashTarget, dashTime / dashDuration);
            dashTime += Time.deltaTime;
            yield return null;
        }

        transform.position = dashTarget;
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, 0.5f);
        foreach (Collider2D enemy in hitEnemies)
        {
            if (enemy.CompareTag("Enemy"))
            {
                ScoreManager.Instance.AddScore(1);
                Destroy(enemy.gameObject);
                health--;
            }
        }

        if (health <= 0)
        {
            SceneManager.LoadScene("GameOverScene");
        }

        isDashing = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            health--;
            Destroy(other.gameObject);
            if (health <= 0)
            {
                SceneManager.LoadScene("GameOverScene");
            }
        }
    }
}
