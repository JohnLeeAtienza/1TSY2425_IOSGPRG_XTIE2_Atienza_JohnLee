using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DashGauge : MonoBehaviour
{
    public float maxDash = 100f;
    public float currentDash = 0f;
    public float dashIncreaseAmount = 5f;
    public float dashDuration = 2f;
    public Slider dashSlider; // Reference to the slider

    void Start()
    {
        currentDash = 0f;
        UpdateGauge();
    }

    public void IncreaseDash()
    {
        currentDash += dashIncreaseAmount;
        if (currentDash > maxDash)
        {
            currentDash = maxDash;
        }
        UpdateGauge();
    }

    public void ResetDashGauge()
    {
        currentDash = maxDash; // Resets the dash gauge to maximum
        UpdateGauge();
    }

    public float CurrentDashGauge // Property to access the current dash value
    {
        get { return currentDash; }
    }

    public void UseDash()
    {
        if (currentDash >= maxDash)
        {
            currentDash = 0f;
            StartCoroutine(Dash());
            UpdateGauge();
        }
    }

    private IEnumerator Dash()
    {
        float dashTime = 0f;
        while (dashTime < dashDuration)
        {
            // Implement dash effect here (e.g., move player forward)
            dashTime += Time.deltaTime;
            yield return null;
        }
    }

    private void UpdateGauge()
    {
        if (dashSlider != null)
        {
            dashSlider.value = currentDash / maxDash;
        }
    }
}
