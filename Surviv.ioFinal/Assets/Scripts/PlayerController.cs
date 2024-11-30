using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Transform weaponHolder; 
    public Joystick movementJoystick; 
    public Joystick rotationJoystick;
    public Button shootButton; 

    private Weapon currentWeapon; 

    public int ammo9mm = 10;
    public int ammo12Gauge = 10;
    public int ammo556mm = 10;

    public TextMeshProUGUI ammo9mmText;
    public TextMeshProUGUI ammo12GaugeText;
    public TextMeshProUGUI ammo556mmText;

    void Start()
    {
        shootButton.onClick.AddListener(OnShootButtonPressed);
    }

    void Update()
    {
        MovePlayer();
        RotatePlayerWithJoystick();
        UpdateAmmoUI();
    }

    void MovePlayer()
    {
        Vector3 moveDirection = new Vector3(movementJoystick.Horizontal, movementJoystick.Vertical, 0f);
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }

    void RotatePlayerWithJoystick()
    {
        Vector3 direction = new Vector3(rotationJoystick.Horizontal, rotationJoystick.Vertical, 0f);
        if (direction.magnitude > 0.1f) 
        {
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }

    void OnShootButtonPressed()
    {
        if (currentWeapon != null)
        {
            currentWeapon.TryShoot();
            DecreaseAmmo(currentWeapon.weaponType);
        }
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

    void DecreaseAmmo(WeaponType weaponType)
    {
        switch (weaponType)
        {
            case WeaponType.Handgun:
                if (ammo9mm > 0)
                    ammo9mm--;
                break;
            case WeaponType.Shotgun:
                if (ammo12Gauge > 0)
                    ammo12Gauge--;
                break;
            case WeaponType.AssaultRifle:
                if (ammo556mm > 0)
                    ammo556mm--;
                break;
        }
        UpdateAmmoUI();
    }

    public void EquipWeapon(Weapon newWeapon)
    {
        if (currentWeapon != null)
        {
            Destroy(currentWeapon.gameObject); 
        }
        currentWeapon = Instantiate(newWeapon, weaponHolder.position, weaponHolder.rotation, weaponHolder);
    }
}
