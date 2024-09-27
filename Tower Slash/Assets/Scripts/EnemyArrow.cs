using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArrow : MonoBehaviour
{
    public enum ArrowType { Green, Red, Rotating }
    public ArrowType arrowType;
    public bool isActive = true;

    public GameObject destructionEffectPrefab; 

    void Start()
    {
        SetRandomRotation();
    }

    void SetRandomRotation()
    {
        if (arrowType == ArrowType.Green)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        else
        {
            float[] angles = { 0f, 90f, 180f, 270f };
            float randomAngle = angles[Random.Range(0, angles.Length)];
            transform.rotation = Quaternion.Euler(0f, 0f, randomAngle);
        }
    }

    public void OnCorrectSwipe()
    {
        if (destructionEffectPrefab != null)
        {
            Instantiate(destructionEffectPrefab, transform.position, Quaternion.identity);
        }

        Debug.Log("Correct swipe detected. Destroying arrow: " + gameObject.name);
        Destroy(gameObject);
    }

    void OnDestroy()
    {
        Debug.Log("Arrow destroyed: " + gameObject.name);
    }
}
