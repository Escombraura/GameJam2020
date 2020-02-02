using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] Robots;
    public GameObject RobotActual;
    public Player[] Jugadores;
    public GameObject giritos;
    public GameObject presiona;
    public GameObject jugador;
    public Transform puntoAparicion;
    public Transform puntoFinal;
    public static GameManager gm;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        if (!gm) gm = this;
        RobotActual = Instantiate(Robots[Random.Range(0, Robots.Length)], puntoAparicion);
        RobotActual.transform.parent = null;
        SetPlayer();
        SoundController.PlayOtherSoundEfect(10);

    }
    // Update is called once per frame
    void Update()
    {
        if (RobotActual.transform.position != puntoFinal.position)
        {
            RobotActual.transform.position = Vector3.Lerp(RobotActual.transform.position, puntoFinal.position, Time.deltaTime);
        }

    }

    void SetPlayer()
    {
        foreach (Player player in Jugadores)
        {
            player.robot = RobotActual.transform;
        }
    }
}