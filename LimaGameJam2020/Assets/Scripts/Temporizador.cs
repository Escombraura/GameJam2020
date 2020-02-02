using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Temporizador : MonoBehaviour
{
    public float time = 0f;
    public bool active = false;
    public bool ready = true;
    public int stage = 0;
    public int contador = 0;

    Coroutine corrutina;

    public void Activar(float _time)
    {
        if (ready == false) return;
        ready = false;
        active = true;
        time = _time;
        corrutina = StartCoroutine(Wait());
    }

    public bool Finish()
    {
        if (ready)
        {
            ready = true;
            stage++;
            contador = 0;
            return true;
        }
        else
        {
            return false;
        }
    }

    public int GetStage()
    {
        return stage;
    }

    public void SetStage(int _value)
    {
        stage = _value;
    }

    public void StopTimer()
    {
        ready = true;
        StopCoroutine(corrutina);

    }


    public IEnumerator Wait()
    {
        while (contador <= time)
        {
            yield return new WaitForSeconds(1);
            contador++;
        }
        ready = true;
    }
}
