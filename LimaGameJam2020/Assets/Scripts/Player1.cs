using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour {

    public Transform robot;
    public Transform eventoGiro;
    private EventoGiro accesoGiro;
    public float velocidad;
    public bool background = false;
    private Transform hijo;
    private bool enRobot = false;
    // Start is called before the first frame update
    void Start () {
        if (eventoGiro) accesoGiro = eventoGiro.GetComponent<EventoGiro> ();
    }

    // Update is called once per frame
    void Update () {
        //Pos te mueves
        if (background != true) transform.Translate (new Vector3 (ControladorMando.LeftJoystick ().x, ControladorMando.LeftJoystick ().y, 0) * Time.deltaTime * velocidad);

        //Soltar objeto
        if (ControladorMando.ReleaseButtonA () && hijo != null) {
            //Verficia si estas encima del robot y si ya hay un objeto soldado
            if (enRobot && robot.GetChild (0).childCount == 0) {
                hijo.parent = robot.GetChild (0);
                hijo.transform.localPosition = Vector3.zero;
                hijo = null;
                ComenzarGirar ();
            } else {
                hijo.parent = null;
                hijo = null;
            }
        }
    }

    public void ComenzarGirar () {
        // if (!eventoGiro.gameObject.activeSelf) {
        background = true;
        eventoGiro.gameObject.SetActive (true);
        GetComponent<SpriteRenderer> ().enabled = false;
        StartCoroutine (FinalizarGiro ());
        // }
    }

    void OnTriggerStay2D (Collider2D other) {
        //Verifica que el objeto es agarrable xD
        if (other.tag == "Objeto" && ControladorMando.PressA () && hijo == null) {
            hijo = other.transform;
            hijo.parent = transform;
        }
    }

    void OnTriggerEnter2D (Collider2D other) {
        if (other.tag == "Robot")
            enRobot = true;
    }

    void OnTriggerExit2D (Collider2D other) {
        if (other.tag == "Robot")
            enRobot = false;
    }

    IEnumerator FinalizarGiro () {
        do {
            yield return new WaitForSeconds (0.1f);
        } while (accesoGiro.vuelta != accesoGiro.objetivo);
        if (accesoGiro.falla) {
            eventoGiro.gameObject.SetActive (false);
            robot.GetChild (0).gameObject.SetActive (false);
            robot.GetChild (0).transform.parent = null;
        }
        eventoGiro.gameObject.SetActive (false);
        GetComponent<SpriteRenderer> ().enabled = true;
        background = false;
    }
}