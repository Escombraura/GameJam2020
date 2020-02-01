using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestBehaviour : MonoBehaviour {
    Vector2 JoystickVector;
    public float angleCurrent = 0;
    public float anglePrevious = 0;
    float sign;
    int offset = 0;
    public Slider slider;
    public int roundCount;
    public bool canAdd = false;
    public int quadrant = 0;
    public int lastQuadrant = 0;
    public float decayRate = 1;
    // Start is called before the first frame update
    void Start () {

    }

    // Update is called once per frame
    void Update () {
        // if (ControladorMando.mando.LeftJoystick () != Vector2.zero) {
        //     sign = Mathf.Sign (ControladorMando.mando.LeftJoystick ().y);
        //     offset = sign == 1 ? 0 : 360;
        //     if (Mathf.Sign (ControladorMando.mando.LeftJoystick ().y) < 0) {
        //         if (Mathf.Sign (ControladorMando.mando.LeftJoystick ().x) < 0) {
        //             quadrant = 4;
        //         } else quadrant = 3;
        //     } else {
        //         if (Mathf.Sign (ControladorMando.mando.LeftJoystick ().x) < 0) {
        //             quadrant = 1;
        //         } else quadrant = 2;
        //     }
        //     JoystickVector = ControladorMando.mando.LeftJoystick ();
        //     if (Vector2.Angle (Vector2.left, JoystickVector) * sign + (offset) > anglePrevious) {
        //         if (lastQuadrant <= quadrant) {
        //             // angleCurrent = Vector2.Angle (Vector2.left, JoystickVector) * sign + offset;
        //             // transform.rotation = Quaternion.Euler (0, 0, angleCurrent);

        //             // slider.value = (angleCurrent / 360) + roundCount;

        //             lastQuadrant = quadrant;
        //         }
        //     } else if (lastQuadrant > quadrant) {
        //         anglePrevious=-1;
        //         roundCount++;
        //         lastQuadrant = quadrant;
        //     }
        // }
        // anglePrevious = angleCurrent;

        if (ControladorMando.mando.LeftJoystick () != Vector2.zero) {
            sign = Mathf.Sign (ControladorMando.mando.LeftJoystick ().y);
            offset = sign == 1 ? 0 : 360;
            JoystickVector = ControladorMando.mando.LeftJoystick ();
            angleCurrent = Vector2.Angle (Vector2.left, JoystickVector) * sign + offset;
            transform.rotation = Quaternion.Euler (0, 0, angleCurrent);

            if (angleCurrent > 29.95f && anglePrevious < 30) { roundCount++; }
            anglePrevious = angleCurrent;

            roundCount - 1 * Time.deltaTime * decayRate;
        }
    }
}