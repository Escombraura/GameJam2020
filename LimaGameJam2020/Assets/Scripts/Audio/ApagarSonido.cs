using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApagarSonido : MonoBehaviour
{

    public AudioSource sonido;

    void Update()
    {
        if (!sonido.isPlaying)
        {
            gameObject.SetActive(false);
        }
    }
}
