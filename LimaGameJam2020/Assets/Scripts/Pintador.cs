using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pintador : MonoBehaviour
{
    public Transform[] jugadores;
    public Color[] colores;
    public Colores miColor;
    public int indice;


    // Start is called before the first frame update
    void Start()
    {
        indice = Random.Range(0, 6);
        GetComponent<SpriteRenderer>().color = SetColor(indice);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public Color SetColor(Colores _color)
    {
        switch (_color.ToString())
        {
            case "Rojo": miColor = Colores.Rojo; return colores[0];
            case "Morado": miColor = Colores.Morado; return colores[1];
            case "Azul": miColor = Colores.Azul; return colores[2];
            case "Verde": miColor = Colores.Verde; return colores[3];
            case "Amarillo": miColor = Colores.Amarillo; return colores[4];
            default: miColor = Colores.Naranja; return colores[5];
        }
    }

    public Color SetColor(int _color)
    {
        switch (_color)
        {
            case 0: miColor = Colores.Rojo; break;
            case 1: miColor = Colores.Morado; break;
            case 2: miColor = Colores.Azul; break;
            case 3: miColor = Colores.Verde; break;
            case 4: miColor = Colores.Amarillo; break;
            default: miColor = Colores.Naranja; break;
        }

        return colores[_color];
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
