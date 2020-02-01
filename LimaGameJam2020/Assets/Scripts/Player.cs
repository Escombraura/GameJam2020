using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public Transform robot;
    public Transform eventoGiro;
    public string ID;
    public int score;
    private EventoGiro accesoGiro;
    public Transform eventoPresion;
    private EventoPresionar accesoPresion;
    public float velocidad;
    public bool background = false;
    private Transform hijo;
    public bool enRobot = false;
    // Start is called before the first frame update
    void Start () {
        if (eventoGiro) accesoGiro = eventoGiro.GetComponent<EventoGiro> ();
        if (eventoPresion) accesoPresion = eventoPresion.GetComponent<EventoPresionar> ();
    }

    // Update is called once per frame
    void Update () {
        //Pos te mueves
        if (background != true) transform.Translate (new Vector3 (ControladorMando.LeftJoystick (ID).x, ControladorMando.LeftJoystick (ID).y, 0) * Time.deltaTime * velocidad);

        //Soltar objeto
        if (ControladorMando.PressRT (ID) < 1 && hijo != null) {
            //Verficia si estas encima del robot y si ya hay un objeto soldado
            if (enRobot && robot.FindChild ("Pieza" + ID).childCount == 0) {
                hijo.parent = robot.FindChild ("Pieza" + ID);
                hijo.transform.localPosition = Vector3.zero;
                hijo.gameObject.name = "brazo";
                hijo = null;
                ComenzarPresionar ();
            } else if (enRobot && robot.FindChild ("Pieza" + ID).childCount == 0) {
                hijo.parent = robot.FindChild ("Pieza" + ID);
                hijo.transform.localPosition = Vector3.zero;
                hijo.gameObject.name = "pierna";
                hijo = null;
                ComenzarPresionar ();
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

    public void ComenzarPresionar () {
        background = true;
        eventoPresion.gameObject.SetActive (true);
        GetComponent<SpriteRenderer> ().enabled = false;
        StartCoroutine (FinalizarPresion ());
    }

    void OnTriggerStay2D (Collider2D other) {
        //Verifica que el objeto es agarrable xD
        if (other.tag == "Objeto") {
            if (ControladorMando.PressRT (ID) == 1 && hijo == null) {
                hijo = other.transform;
                hijo.parent = transform;
            }
        }
    }

    void OnTriggerEnter2D (Collider2D other) {
        if (other.tag == ("Jugador" + ID)) {
            enRobot = true;
        }
    }

    void OnTriggerExit2D (Collider2D other) {
        if (other.tag == "Jugador" + ID)
            enRobot = false;
    }

    IEnumerator FinalizarGiro () {
        do {
            yield return new WaitForSeconds (0.1f);
        } while (accesoGiro.vuelta != accesoGiro.objetivo);
        if (accesoGiro.falla) {
            eventoGiro.gameObject.SetActive (false);
            robot.FindChild ("Pieza"+ID).transform.Find ("brazo").gameObject.SetActive (false);
            robot.FindChild ("Pieza"+ID).transform.Find ("brazo").transform.parent = null;
        }
        eventoGiro.gameObject.SetActive (false);
        GetComponent<SpriteRenderer> ().enabled = true;
        background = false;
    }

    IEnumerator FinalizarPresion () {
        do {
            yield return new WaitForSeconds (0.1f);
        } while (accesoPresion.resta != 0);
        if (accesoPresion.falla) {
            eventoPresion.gameObject.SetActive (false);
            robot.FindChild ("Pieza"+ID).transform.Find ("pierna").gameObject.SetActive (false);
            robot.FindChild ("Pieza"+ID).transform.Find ("pierna").transform.parent = null;
        }
        eventoPresion.gameObject.SetActive (false);
        GetComponent<SpriteRenderer> ().enabled = true;
        background = false;
    }
}