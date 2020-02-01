using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorController : MonoBehaviour
{

    public Transform[] jugadores;
    public Color[] colores;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public Color SetColor(Colores _color)
    {
        switch (_color.ToString())
        {

            case "Rojo": return colores[0];
            case "Morado": return colores[1];
            case "Azul": return colores[2];
            case "Verde": return colores[3];
            case "Amarillo": return colores[4];
            default: return colores[5];
        }
    }
}

public enum Colores
{
    Rojo,
    Morado,
    Azul,
    Verde,
    Amarillo,
    Naranja
}
