﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    public GameObject[] Robots;
    public GameObject RobotActual;
    public Player[] Jugadores;
    public Transform[] faja;
    public Transform puntoAparicion;
    public Transform puntoFinal;
    public static GameManager gm;
    public enum GameState { setup, running, finish }
    public GameState estado;
    public GameObject[] partes;
    public GameObject[] ruta;
    public Temporizador temporizador;
    public float speed;
    public float globalScore;

    public Nombre[] verificadorNombre;
    public string[] verificadorPiezas;
    public int[] verificadorColor;
    private float multiplicador;

    public Text texto;
    public GameObject panelGlobal;

    // Start is called before the first frame update
    void Start () {
        if (!gm) gm = this;
        estado = GameState.setup;

        Debug.Log ("llamar");
        temporizador.Activar (5f);
        for (int i = 0; i <= 11; i++) {
            if (faja[i].childCount == 1) {
                Instantiate (partes[Random.Range (0, partes.Length)], faja[i].position, faja[i].rotation, faja[i]);
            }
        }
    }
    // Update is called once per frame
    void Update () {
        if (temporizador.GetStage () == 0) {
            if (temporizador.Finish ()) {
                Debug.Log ("Robot Colocaldo");
                panelGlobal.SetActive (false);
                texto.gameObject.SetActive (false);
                ResetColorData ();
                InitRobot ();
            }
        }

        if (estado == GameState.running) {
            if (RobotActual.transform.position != puntoFinal.position) {
                RobotActual.transform.position = Vector3.Lerp (RobotActual.transform.position, puntoFinal.position, Time.deltaTime);
            }
            for (int i = 0; i <= 11; i++) {
                if (faja[i].childCount == 1 && faja[i].GetComponent<Faja> ().ruta == 10) {
                    Instantiate (partes[Random.Range (0, partes.Length)], faja[i].position, faja[i].rotation, faja[i]);
                }
            }

            //timer --
            if (temporizador.GetStage () == 1) {
                temporizador.Activar (15);
                if (temporizador.Finish ()) {
                    estado = GameState.finish;
                    SoundController.PlayOtherSoundEfect (12);
                    foreach (Player jugador in Jugadores) {
                        // Debug.Log (jugador.eventoActual);
                        if (jugador.eventoActual != null) jugador.MatarEvento ();
                    }

                }
            }

            // if timer.runsout estado cambia a finish
        }
        if (estado == GameState.finish) {
            if (RobotActual.transform.position != puntoAparicion.position) {
                RobotActual.transform.position = Vector3.Lerp (RobotActual.transform.position, puntoAparicion.position, Time.deltaTime);
                if (puntoAparicion.position.y - RobotActual.transform.position.y < 0.5) {
                    Destroy (RobotActual);
                    //llamar temporizador
                    //Invoke("InitRobot", 5f);
                    if (temporizador.GetStage () == 2) {
                        estado = GameState.setup;
                        temporizador.Activar (2f);
                        temporizador.SetStage (0);
                        BonusScore ();
                        panelGlobal.SetActive (true);
                        texto.gameObject.SetActive (true);
                    }
                }
            }
        }

    }
    void SetPlayer () {
        foreach (Player player in Jugadores) {
            player.robot = RobotActual.transform;
        }
    }

    public void AparecerPieza () {
        //   Instantiate (partes[Random.Range (0, partes.Length)], faja[i].position, faja[i].rotation, faja[i]);
    }

    void InitRobot () {
        RobotActual = Instantiate (Robots[Random.Range (0, Robots.Length)], puntoAparicion);
        RobotActual.transform.parent = null;
        SetPlayer ();
        SoundController.PlayOtherSoundEfect (10);
        estado = GameState.running;
        //llamado timer
    }

    public void AddGlobalScore (int _value) {
        globalScore += _value;
        texto.text = globalScore.ToString ();

    }

    public void AddPlayerData (string _ID, Nombre _nombre) {
        switch (_ID) {
            case "":
                verificadorNombre[0] = _nombre;
                break;
            case "2P":
                verificadorNombre[1] = _nombre;
                break;
            case "3P":
                verificadorNombre[2] = _nombre;
                break;
            case "4P":
                verificadorNombre[3] = _nombre;
                break;
        }
    }
    public void AddPlayerData (string _ID, string _piezaID) {
        switch (_ID) {
            case "":
                verificadorPiezas[0] = _piezaID;
                break;
            case "2P":
                verificadorPiezas[1] = _piezaID;
                break;
            case "3P":
                verificadorPiezas[2] = _piezaID;
                break;
            case "4P":
                verificadorPiezas[3] = _piezaID;
                break;
        }
    }

    public void AddPlayerData (string _ID, int _color) {
        switch (_ID) {
            case "":
                verificadorColor[0] = _color;
                break;
            case "2P":
                verificadorColor[1] = _color;
                break;
            case "3P":
                verificadorColor[2] = _color;
                break;
            case "4P":
                verificadorColor[3] = _color;
                break;
        }
    }

    public void ResetColorData () {
        for (int i = 0; i < verificadorNombre.Length; i++) {
            verificadorNombre[i] = Nombre.ninguno;
        }
    }

    public void BonusScore () {
        multiplicador = 0;
        for (int i = 0; i < 4; i++) {
            for (int j = 0; j < 4; j++) {
                if (i > j && verificadorNombre[i] != Nombre.ninguno) {
                    if (verificadorColor[i] == verificadorColor[j]) {
                        multiplicador++;
                        Debug.Log (i);
                        Debug.Log (j);
                    }
                    if (verificadorNombre[i] == verificadorNombre[j]) {
                        multiplicador++;
                        Debug.Log (i);
                        Debug.Log (j);
                    }
                    if (verificadorPiezas[i] == verificadorPiezas[j]) {
                        multiplicador++;
                        Debug.Log (i);
                        Debug.Log (j);
                    }
                }
            }
        }

        multiplicador = 1 + (multiplicador / 10f);
        Debug.Log (multiplicador);
        Debug.Log (globalScore);
        globalScore = globalScore * multiplicador;
        Debug.Log (globalScore);
        texto.text = globalScore.ToString ();
    }
}