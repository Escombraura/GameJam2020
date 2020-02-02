using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Faja : MonoBehaviour
{
    public int ruta;
    public Transform llegada;
    public float velocidad = 0.5f;
    public Transform direccion;




    void Update()
    {
        //transform.Translate(Vector3.right * Time.deltaTime * velocidad);
        if (!direccion) return;

        transform.Translate(direccion.right * Time.deltaTime * velocidad);

        if (transform.childCount >= 2)
        {
            transform.GetChild(1).transform.eulerAngles = Vector3.zero;
        }
        //ChildLookAt2D();
        if (!llegada) return;
        LookAt2D();

        if (Vector3.Distance(transform.position, llegada.position) <= 0.5f)
        {
            CambioDireccion();
        }
        //GameManager.gm.DireccionFaja(ref transform);
    }

    private void LookAt2D()
    {
        Vector3 dir = llegada.position - transform.position;
        float angulo = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        direccion.rotation = Quaternion.AngleAxis(angulo, Vector3.forward);
    }

    private void ChildLookAt2D()
    {
        if (transform.childCount <= 0) return;
        Vector3 dir = transform.parent.position - transform.GetChild(0).transform.position;
        float angulo = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.GetChild(0).transform.rotation = Quaternion.AngleAxis(angulo, Vector3.forward);
    }

    private void CambioDireccion()
    {
        ruta++;
        if (ruta >= GameManager.gm.ruta.Length)
            ruta = 0;

        llegada = GameManager.gm.ruta[ruta].transform;
    }

}
