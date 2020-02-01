using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Temporizador
{

    public static float time = 0f;
    public static bool active = false;
    public static bool ready = false;



    public static void Active(float _time)
    {
        if (ready == false) return;

        active = true;
        time = _time;
    }

    public static void Finish()
    {
        ready = false;
    }


    static IEnumerator Wait()
    {
        yield return new WaitForSeconds(time);
        ready = true;
    }

}
