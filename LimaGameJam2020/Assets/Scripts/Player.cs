using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public Transform robot;
    public GameObject[] eventos;
    public GameObject[] feedBack;
    public int eventID;
    public string ID;
    public int score;
    private Evento accesoEvento;
    private Transform objetoEvento;
    public float velocidad;
    public bool background = false;
    public Transform hijo;
    public bool enRobot = false;
    private GameManager gmManager;
    // Start is called before the first frame update
    void Start()
    {
        // if (eventoGiro) accesoGiro = eventoGiro.GetComponent<EventoGiro> ();
        // if (eventoPresion) accesoPresion = eventoPresion.GetComponent<EventoPresionar> ();

        if (!gmManager) gmManager = GameObject.Find("Manager").GetComponent<GameManager>();
        SetEvent();

    }

    // Update is called once per frame
    void Update()
    {
        //Pos te mueves
        if (background != true) transform.Translate(new Vector3(ControladorMando.LeftJoystick(ID).x, ControladorMando.LeftJoystick(ID).y, 0) * Time.deltaTime * velocidad);

        //Soltar objeto
        if (ControladorMando.PressRT(ID) < 1 && hijo != null)
        {
            //Verficia si estas encima del robot y si ya hay un objeto soldado
            if (enRobot && robot.Find("Pieza" + ID).childCount == 0)
            {
                SoundController.PlayOtherSoundEfect(Random.Range(4, 7));

                hijo.parent = robot.Find("Pieza" + ID);
                hijo.transform.GetChild(0).transform.localPosition = robot.Find("Pieza" + ID).transform.position;
                hijo.gameObject.name = ("Ext" + ID);
                hijo = null;
                objetoEvento = Instantiate(eventos[eventID]).transform;
                accesoEvento = objetoEvento.GetComponent<Evento>();
                ComenzarEvento(eventID);
            }
            else
            {
                hijo.parent = null;
                hijo = null;
            }
        }
    }

    public void SetEvent()
    {
        eventID = Random.Range(0, eventos.Length);
    }

    public void ComenzarEvento(int eventoID)
    {
        //SoundController.PlaySoundEfectLoop(Random.Range(4, 7));
        SoundController.PlayOtherSoundEfect(Random.Range(4, 7));
        background = true;
        objetoEvento.gameObject.SetActive(true);
        GetComponent<SpriteRenderer>().enabled = false;
        feedBack[eventID].transform.Find(ID + "FeedBack").gameObject.SetActive(true);
        StartCoroutine(FinalizarEvento(eventoID));
    }

    void OnTriggerStay2D(Collider2D other)
    {
        //Verifica que el objeto es agarrable xD
        if (other.tag == "Objeto")
        {
            if (ControladorMando.PressRT(ID) == 1 && hijo == null && other.transform.parent != robot)
            {
                SoundController.PlayOtherSoundEfect(9);
                hijo = other.transform;
                hijo.parent = transform;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == ("Jugador" + ID))
        {
            enRobot = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Jugador" + ID)
            enRobot = false;
    }

    IEnumerator FinalizarEvento(int eventoID)
    {
        switch (eventoID)
        {
            case 0:
                do
                {
                    yield return new WaitForSeconds(0.1f);
                } while (accesoEvento.gameObject.GetComponent<EventoGiro>().vuelta != accesoEvento.objetivo);
                if (accesoEvento.falla)
                {
                    SoundController.PlayOtherSoundEfect(7);
                    objetoEvento.gameObject.SetActive(false);
                    robot.Find("Pieza" + ID).transform.Find("Ext" + ID).gameObject.SetActive(false);
                    //robot.Find ("Pieza" + ID).transform.Find ("Ext" + ID).transform.parent = null;
                    Destroy(robot.Find("Pieza" + ID).transform.Find("Ext" + ID).gameObject);
                }
                else
                {
                    AddScore();
                    SoundController.PlayOtherSoundEfect(13);

                }
                feedBack[eventID].transform.Find(ID + "FeedBack").gameObject.SetActive(false);
                objetoEvento.gameObject.SetActive(false);
                GetComponent<SpriteRenderer>().enabled = true;
                background = false;
                break;
            case 1:
                do
                {
                    yield return new WaitForSeconds(0.1f);
                } while (accesoEvento.gameObject.GetComponent<EventoPresionar>().resta != 0);
                if (accesoEvento.falla)
                {
                    accesoEvento.gameObject.SetActive(false);
                    SoundController.PlayOtherSoundEfect(7);
                    robot.Find("Pieza" + ID).transform.Find("Ext" + ID).gameObject.SetActive(false);
                    robot.Find("Pieza" + ID).transform.Find("Ext" + ID).transform.parent = null;
                }
                else
                {
                    AddScore();
                    SoundController.PlayOtherSoundEfect(13);
                }
                feedBack[eventID].transform.Find(ID + "FeedBack").gameObject.SetActive(false);
                accesoEvento.gameObject.SetActive(false);
                GetComponent<SpriteRenderer>().enabled = true;
                background = false;
                break;
        }
        //SoundController.StopSoundEfectLoop();

        //AddScore ();

        feedBack[eventID].transform.Find(ID + "FeedBack").gameObject.SetActive(false);
        SetEvent();
    }

    private void AddScore()
    {
        score += 5;
        Pintador _piezaSeleccionada = robot.Find("Pieza" + ID).GetComponentInChildren<Pintador>();
        ColoScore(_piezaSeleccionada);
        RobotScore(_piezaSeleccionada);
        GameManager.gm.AddGlobalScore(score);
    }

    private void ColoScore(Pintador _piezaSeleccionada)
    {
        int _robotIndice = robot.GetComponent<Pintador>().indice;
        int _piezaIndice = 0;

        _piezaIndice = _piezaSeleccionada.indice;
        GameManager.gm.AddPlayerData(ID, _piezaIndice);
        /*

        switch (eventID)
        {
            case 0:
                break;
            case 1:
                _piezaIndice = robot.Find("Pieza" + ID).GetComponentInChildren<Pintador>().indice;
                break;
        }
        */

        int _resultado = Mathf.Abs(_robotIndice - _piezaIndice);

        switch (_resultado)
        {

            case 0:
                score += 5;
                break;
            case 1:
                score += 1;
                break;
            case 3:
                score += 3;
                break;
        }
    }
    private void RobotScore(Pintador _piezaSeleccionada)
    {
        Nombre _robot = robot.GetComponent<Pintador>().nombre;

        GameManager.gm.AddPlayerData(ID, _robot);
        GameManager.gm.AddPlayerData(ID, _piezaSeleccionada.jugadorID);


        if (_piezaSeleccionada.nombre == _robot)
            score += 5;

        Debug.Log(_piezaSeleccionada.jugadorID == "Brazo");
        Debug.Log(ID);

        if (_piezaSeleccionada.piezaSimetrica)
        {
            if (_piezaSeleccionada.jugadorID == "Brazo")
            {
                if (ID == "" || ID == "2P")
                    score += 5;
            }
            else if (_piezaSeleccionada.jugadorID == "Pierna")
            {
                if (ID == "3P" || ID == "4P")
                    score += 5;
            }
        }
        else if (_piezaSeleccionada.jugadorID == ID)
        {
            score += 5;
        }

    }
}