using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pintador : MonoBehaviour
{
    public Transform[] jugadores;
    public Color[] colores;
    public Sprite[] listaSprite;
    public Colores miColor;
    public int indice;
    private SpriteRenderer miSprite;


    // Start is called before the first frame update
    void Start()
    {
        indice = Random.Range(0, 6);
        miSprite = GetComponent<SpriteRenderer>();
        //SetSprite(indice); //Cambiar al momento de usar sprites y no colores
        miSprite.color = SetColor(indice);
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

    public void SetSprite(int _value)
    {
        miSprite.sprite = listaSprite[_value];
    }

    public Color SetColor(int _value)
    {
        switch (_value)
        {
            case 0: miColor = Colores.Rojo; break;
            case 1: miColor = Colores.Morado; break;
            case 2: miColor = Colores.Azul; break;
            case 3: miColor = Colores.Verde; break;
            case 4: miColor = Colores.Amarillo; break;
            default: miColor = Colores.Naranja; break;
        }
        return colores[_value];
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
