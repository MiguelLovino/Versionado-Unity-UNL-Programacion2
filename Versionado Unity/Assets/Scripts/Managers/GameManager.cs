using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {  get; private set; }
    private int score;

    private void Start()
    {
        
    }
    private void Awake()
    {
        //Para que exista 1 solo singleto se hace la siguiente validacion.
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            if(Time.timeScale != 0)
            {
                GameEvents.TriggerPause();
            }
            else
            {
                GameEvents.TriggerResume(); 
            }
        }
    }
    private void OnEnable()
    {
        //suscripcion al evento
        GameEvents.OnPause += Pausar;
        GameEvents.OnResume += Reanudar;
    }

    private void OnDisable()
    {
        //desuscripcion al evento
        GameEvents.OnPause -= Pausar;
        GameEvents.OnResume -= Reanudar;
        
    }

    private void Pausar()
    {
        Time.timeScale = 0;

    }
    private void Reanudar()
    {
        Time.timeScale = 1;
    }
    public void AddScore(int points)
    {
        score += points;
    }

    public void ResetScore()
    {
        score = 0;
    }

    public int GetScore()
    {
        return score;
    }
}
