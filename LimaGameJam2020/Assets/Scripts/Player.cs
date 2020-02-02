using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public Transform robot;
    public GameObject[] eventos;
    public string ID;
    public int score;
    private Evento accesoEvento;
    private Transform objetoEvento;
    public float velocidad;
    public bool background = false;
    private Transform hijo;
    public bool enRobot = false;
    private GameManager gmManager;
    // Start is called before the first frame update
    void Start () {
        // if (eventoGiro) accesoGiro = eventoGiro.GetComponent<EventoGiro> ();
        // if (eventoPresion) accesoPresion = eventoPresion.GetComponent<EventoPresionar> ();

        if (!gmManager) gmManager = GameObject.Find ("Manager").GetComponent<GameManager> ();
    }

    // Update is called once per frame
    void Update () {
        //Pos te mueves
        if (background != true) transform.Translate (new Vector3 (ControladorMando.LeftJoystick (ID).x, ControladorMando.LeftJoystick (ID).y, 0) * Time.deltaTime * velocidad);

        //Soltar objeto
        if (ControladorMando.PressRT (ID) < 1 && hijo != null) {
            //Verficia si estas encima del robot y si ya hay un objeto soldado
            if (enRobot && robot.Find ("Pieza" + ID).childCount == 0) {
                hijo.parent = robot.Find ("Pieza" + ID);
                hijo.transform.localPosition = Vector3.zero;
                hijo.gameObject.name = ("Ext" + ID);
                hijo = null;
                int temp = Random.Range (0, eventos.Length);
                objetoEvento = Instantiate (eventos[temp]).transform;
                accesoEvento = objetoEvento.GetComponent<Evento> ();
                ComenzarEvento (temp);
            } else {
                hijo.parent = null;
                hijo = null;
            }
        }
    }

    public void ComenzarEvento (int eventoID) {
        background = true;
        objetoEvento.gameObject.SetActive (true);
        GetComponent<SpriteRenderer> ().enabled = false;
        StartCoroutine (FinalizarEvento (eventoID));
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

    IEnumerator FinalizarEvento (int eventoID) {
        switch (eventoID) {
            case 0:
                do {
                    yield return new WaitForSeconds (0.1f);
                } while (accesoEvento.gameObject.GetComponent<EventoGiro> ().vuelta != accesoEvento.objetivo);
                if (accesoEvento.falla) {
                    objetoEvento.gameObject.SetActive (false);
                    robot.Find ("Pieza" + ID).transform.Find ("brazo").gameObject.SetActive (false);
                    robot.Find ("Pieza" + ID).transform.Find ("brazo").transform.parent = null;
                }
                objetoEvento.gameObject.SetActive (false);
                GetComponent<SpriteRenderer> ().enabled = true;
                background = false;
                break;
        }
    }

    // IEnumerator FinalizarPresion () {
    //     do {
    //         yield return new WaitForSeconds (0.1f);
    //     } while (accesoPresion.resta != 0);
    //     if (accesoPresion.falla) {
    //         eventoPresion.gameObject.SetActive (false);
    //         robot.Find ("Pieza" + ID).transform.Find ("pierna").gameObject.SetActive (false);
    //         robot.Find ("Pieza" + ID).transform.Find ("pierna").transform.parent = null;
    //     }
    //     eventoPresion.gameObject.SetActive (false);
    //     GetComponent<SpriteRenderer> ().enabled = true;
    //     background = false;
    // }
}