using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    GameObject[] Robots;
    GameObject RobotActual;
    Player[] Jugadores;
    public GameObject giritos;
    public static GameManager gm;
    // Start is called before the first frame update
    void Start () {
        if (!gm) gm = this;

        // RobotActual = 
    }
    // Update is called once per frame
    void Update () {

    }
}