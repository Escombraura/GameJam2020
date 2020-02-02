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
    public GameObject[] ruta;
    public Temporizador temporizador;
    public float speed;
    public float globalScore;

    public Nombre[] verificadorNombre;
    public string[] verificadorPiezas;
    public int[] verificadorColor;
    private float multiplicador;



    // Start is called before the first frame update
    void Start()
    {
        if (!gm) gm = this;
        estado = GameState.setup;

        Debug.Log("llamar");
        temporizador.Activar(5f);
    }
    // Update is called once per frame
    void Update()
    {
        if (temporizador.GetStage() == 0)
        {
            if (temporizador.Finish())
            {
                Debug.Log("Robot Colocaldo");
                InitRobot();
            }
        }

        if (estado == GameState.running)
        {
            if (RobotActual.transform.position != puntoFinal.position)
            {
                RobotActual.transform.position = Vector3.Lerp(RobotActual.transform.position, puntoFinal.position, Time.deltaTime);
            }
            for (int i = 0; i <= 11; i++)
            {
                if (faja[i].childCount == 1)
                {
                    Instantiate(partes[Random.Range(0, partes.Length)], faja[i].position, faja[i].rotation, faja[i]);
                }
            }

            //timer --
            if (temporizador.GetStage() == 1)
            {
                temporizador.Activar(15);
                if (temporizador.Finish())
                {
                    estado = GameState.finish;
                    SoundController.PlayOtherSoundEfect(12);
                }
            }

            // if timer.runsout estado cambia a finish
        }
        if (estado == GameState.finish)
        {
            if (RobotActual.transform.position != puntoAparicion.position)
            {
                RobotActual.transform.position = Vector3.Lerp(RobotActual.transform.position, puntoAparicion.position, Time.deltaTime);
                if (puntoAparicion.position.y - RobotActual.transform.position.y < 0.5)
                {
                    RobotActual = null;
                    //llamar temporizador
                    //Invoke("InitRobot", 5f);
                    if (temporizador.GetStage() == 2)
                    {
                        estado = GameState.setup;
                        temporizador.Activar(2f);
                        temporizador.SetStage(0);
                    }
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
        //llamado timer
    }

    public void AddGlobalScore(int _value)
    {
        globalScore += _value;
    }

    public void AddPlayerData(string _ID, Nombre _nombre)
    {
        switch (_ID)
        {
            case "": verificadorNombre[0] = _nombre; break;
            case "2P": verificadorNombre[1] = _nombre; break;
            case "3P": verificadorNombre[2] = _nombre; break;
            case "4P": verificadorNombre[3] = _nombre; break;
        }
    }
    public void AddPlayerData(string _ID, string _piezaID)
    {
        switch (_ID)
        {
            case "": verificadorPiezas[0] = _piezaID; break;
            case "2P": verificadorPiezas[1] = _piezaID; break;
            case "3P": verificadorPiezas[2] = _piezaID; break;
            case "4P": verificadorPiezas[3] = _piezaID; break;
        }
    }

    public void AddPlayerData(string _ID, int _color)
    {
        switch (_ID)
        {
            case "": verificadorColor[0] = _color; break;
            case "2P": verificadorColor[1] = _color; break;
            case "3P": verificadorColor[2] = _color; break;
            case "4P": verificadorColor[3] = _color; break;
        }
    }


    public void BonusScore()
    {
        multiplicador = 1;
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 5; i++)
            {
                if (i != j)
                {
                    if (verificadorColor[i] == verificadorColor[j])
                        multiplicador++;
                    if (verificadorNombre[i] == verificadorNombre[j])
                        multiplicador++;
                    if (verificadorPiezas[i] == verificadorPiezas[j])
                        multiplicador++;
                }
            }
        }
        multiplicador = multiplicador / 10f;
        Debug.Log(globalScore);
        globalScore = globalScore * multiplicador;
        Debug.Log(globalScore);
    }
}