using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Temporizador
{

    public static float time = 0f;
    public static bool active = false;
    public static bool ready = false;
    public static int stage = 0;



    public static void Active(float _time)
    {
        if (ready == false) return;

        active = true;
        time = _time;
    }

    public static void Finish()
    {
        ready = false;
        stage++;
    }

    public static void EndMesh()
    {
        stage = 0;
    }


    static IEnumerator Wait()
    {
        yield return new WaitForSeconds(time);
        ready = true;
    }

}
