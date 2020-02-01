﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventoGiro : MonoBehaviour
{
    public int verificador;

    public int vuelta;

    private float anguloActual;
    private float angulocomparar;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (ControladorMando.LeftJoystick() == Vector2.zero) return;

        anguloActual = transform.eulerAngles.z;
        transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(-ControladorMando.LeftJoystick().x, ControladorMando.LeftJoystick().y) * 180 / Mathf.PI);
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

    }

    public void ReiniciarVeulta()
    {
        vuelta = 0;
    }
}