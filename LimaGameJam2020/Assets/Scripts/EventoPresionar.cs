using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventoPresionar : Evento
{
    public float valorActual = 0;
    public float adicion;
    public float resta;

    //public Slider slider;
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
            if (valorActual > 0)
            {
                valorActual -= resta * Time.deltaTime;
                valorActual = valorActual < 0 ? 0 : valorActual;
            }
            if (ControladorMando.PressB(ID))
            {
                valorActual += adicion;
                SoundController.PlayOtherSoundEfect(11);

                resta = valorActual >= 10 ? 0 : resta;
            }
            //  slider.value = valorActual;
        }
        else { falla = true; resta = 0; return; }
    }
}