using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    GameObject[] Robots;
    GameObject RobotActual;
    public Player[] Jugadores;
    public GameObject giritos;
    public GameObject presiona;
    public GameObject jugador;
    public static GameManager gm;
    // Start is called before the first frame update
    void Start () {
        if (!gm) gm = this;

    }
    // Update is called once per frame
    void Update () {

    }
}