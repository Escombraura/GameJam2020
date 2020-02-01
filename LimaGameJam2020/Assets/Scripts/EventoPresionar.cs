using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventoPresionar : MonoBehaviour {

    public float objetivo = 10;
    public float valorActual = 0;
    public float adicion;
    public float resta;
    // Start is called before the first frame update
    void Start () {

    }

    // Update is called once per frame
    void Update () {
        if (valorActual > 0) {
            valorActual -= resta * Time.deltaTime;
            valorActual = valorActual < 0 ? 0 : valorActual;
        }
        if (ControladorMando.PressA ()) { valorActual += adicion; }
    }
}