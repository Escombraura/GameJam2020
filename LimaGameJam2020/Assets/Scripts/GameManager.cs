using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
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
    public GameObject[] piezas;
    public GameObject[] ruta;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        if (!gm) gm = this;
        estado = GameState.setup;
        //Llamar timer
        Invoke("InitRobot", 5f);
    }
    // Update is called once per frame
    void Update()
    {
        if (estado == GameState.running)
        {
            if (RobotActual.transform.position != puntoFinal.position)
            {
                RobotActual.transform.position = Vector3.Lerp(RobotActual.transform.position, puntoFinal.position, Time.deltaTime);
            }
            for (int i = 0; i <= 11; i++)
            {
                if (faja[i].childCount == 0)
                {
                    Instantiate(partes[Random.Range(0, partes.Length)], faja[i].position, faja[i].rotation, faja[i]);
                }
            }
        }
    }
    void SetPlayer()
    {
        foreach (Player player in Jugadores)
        {
            player.robot = RobotActual.transform;
        }
    }

    void InitRobot()
    {
        RobotActual = Instantiate(Robots[Random.Range(0, Robots.Length)], puntoAparicion);
        RobotActual.transform.parent = null;
        SetPlayer();
        SoundController.PlayOtherSoundEfect(10);
        estado = GameState.running;
    }

}