using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Transform weapon; 
    public Joystick joystick; 

    private int ammo9mm = 0;
    private int ammo12Gauge = 0;
    private int ammo556mm = 0;

    public TextMeshProUGUI ammo9mmText;
    public TextMeshProUGUI ammo12GaugeText;
    public TextMeshProUGUI ammo556mmText;

    void Update()
    {
        MovePlayer();
        RotatePlayerToCursor();
        UpdateAmmoUI();
    }

    void MovePlayer()
    {
        Vector3 moveDirection = new Vector3(joystick.Horizontal, joystick.Vertical, 0f);
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }

    void RotatePlayerToCursor()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = (mousePosition - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    public void AddAmmo(Ammo.AmmoType ammoType, int amount)
    {
        switch (ammoType)
        {
            case Ammo.AmmoType.NineMM:
                ammo9mm += amount;
                break;
            case Ammo.AmmoType.TwelveGauge:
                ammo12Gauge += amount;
                break;
            case Ammo.AmmoType.Five56MM:
                ammo556mm += amount;
                break;
        }
        UpdateAmmoUI();
    }

    void UpdateAmmoUI()
    {
        if (ammo9mmText != null)
            ammo9mmText.text = $"9mm: {ammo9mm}";
        if (ammo12GaugeText != null)
            ammo12GaugeText.text = $"12 Gauge: {ammo12Gauge}";
        if (ammo556mmText != null)
            ammo556mmText.text = $"5.56mm: {ammo556mm}";
    }
}
