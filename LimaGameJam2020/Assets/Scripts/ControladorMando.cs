using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ControladorMando
{

    public static bool PressX(string _jugador)
    {
        return Input.GetButtonDown(_jugador + "x Button");
    }
    public static bool ReleaseButtonX(string _jugador)
    {
        return Input.GetButtonUp(_jugador + "x Button");
    }
    public static bool PressY(string _jugador)
    {
        return Input.GetButtonDown(_jugador + "y Button");
    }
    public static bool ReleaseButtonY(string _jugador)
    {
        return Input.GetButtonUp(_jugador + "y Button");
    }
    public static bool PressA(string _jugador)
    {
        return Input.GetButtonDown(_jugador + "a Button");
    }

    public static bool ReleaseButtonA(string _jugador)
    {
        return Input.GetButtonUp(_jugador + "a Button");
    }
    public static bool PressB(string _jugador)
    {
        return Input.GetButtonDown(_jugador + "b Button");
    }

    public static bool ReleaseButtonB(string _jugador)
    {
        return Input.GetButtonUp(_jugador + "b Button");
    }

    public static Vector2 LeftJoystick(string _jugador)
    {
        float h = Input.GetAxis(_jugador + "Horizontal");
        float v = Input.GetAxis(_jugador + "Vertical");

        return new Vector2(h, v);
    }

    public static Vector2 RightJoystick(string _jugador)
    {
        float h = Input.GetAxis(_jugador + "Horizontal2");
        float v = Input.GetAxis(_jugador + "Vertical2");

        return new Vector2(h, v);
    }

    public static float PressRT(string _jugador)
    {
        return Input.GetAxis(_jugador + "RT");
    }
}
