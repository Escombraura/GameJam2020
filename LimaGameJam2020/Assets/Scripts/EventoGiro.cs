using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventoGiro : MonoBehaviour
{
    public int verificador;

    public int vuelta;

    private float anguloActual;
    private float angulocomparar;
    public float tiempoLimite;
    public bool falla;
    public float objetivo;

    public string ID;

    public Slider slider;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (tiempoLimite - Time.deltaTime > 0)
        {
            tiempoLimite -= Time.deltaTime;
            if (ControladorMando.RightJoystick(ID) == Vector2.zero) return;

            anguloActual = transform.eulerAngles.z;
            transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(-ControladorMando.RightJoystick(ID).x, ControladorMando.RightJoystick(ID).y) * 180 / Mathf.PI);
            angulocomparar = transform.eulerAngles.z;

            if (anguloActual > angulocomparar)
            {
                verificador++;
                if (verificador < -5) vuelta--;
                if (verificador < 0) verificador = 0;
            }
            else if (anguloActual < angulocomparar) //Giro opuesto
            {
                verificador--;
                if (verificador > 5) vuelta++;
                if (verificador > 0) verificador = 0;
            }
            slider.value = vuelta;
        }
        else { falla = true; vuelta = (int)objetivo; return; }
    }

    public void ReiniciarVeulta()
    {
        vuelta = 0;
    }
}