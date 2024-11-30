using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickController : MonoBehaviour
{
    public Joystick joystick;

    public float Horizontal => joystick.Horizontal;
    public float Vertical => joystick.Vertical;
}
