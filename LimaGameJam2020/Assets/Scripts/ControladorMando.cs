using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ControladorMando
{

    public static bool PressX()
    {
        return Input.GetButtonDown("x Button");
    }
    public static bool ReleaseButtonX()
    {
        return Input.GetButtonUp("x Button");
    }
    public static bool PressY()
    {
        return Input.GetButtonDown("y Button");
    }
    public static bool ReleaseButtonY()
    {
        return Input.GetButtonUp("y Button");
    }
    public static bool PressA()
    {
        return Input.GetButtonDown("a Button");
    }

    public static bool ReleaseButtonA()
    {
        return Input.GetButtonUp("a Button");
    }
    public static bool PressB()
    {
        return Input.GetButtonDown("b Button");
    }

    public static bool ReleaseButtonB()
    {
        return Input.GetButtonUp("b Button");
    }

    public static Vector2 LeftJoystick()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        return new Vector2(h, v);
    }

    public static Vector2 RightJoystick()
    {
        float h = Input.GetAxis("Horizontal2");
        float v = Input.GetAxis("Vertical2");

        return new Vector2(h, v);
    }

    public static float PressRT()
    {
        return Input.GetAxis("RT");
    }
}
