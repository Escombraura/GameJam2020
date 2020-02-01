using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorMando : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (PressX())
            Debug.Log("X");

        if (PressY())
            Debug.Log("y");
        if (PressA())
            Debug.Log("A");
        if (PressB())
            Debug.Log("B");

        Debug.Log(LeftJoystick());

        Debug.Log(RightJoystick());


    }

    public bool PressX()
    {
        return Input.GetButtonDown("x Button");
    }
    public bool PressY()
    {
        return Input.GetButtonDown("y Button");
    }
    public bool PressA()
    {
        return Input.GetButtonDown("a Button");
    }
    public bool PressB()
    {
        return Input.GetButtonDown("b Button");
    }

    public Vector2 LeftJoystick()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        return new Vector2(h, v);
    }

    public Vector2 RightJoystick()
    {
        float h = Input.GetAxis("Horizontal2");
        float v = Input.GetAxis("Vertical2");

        return new Vector2(h, v);
    }
}
