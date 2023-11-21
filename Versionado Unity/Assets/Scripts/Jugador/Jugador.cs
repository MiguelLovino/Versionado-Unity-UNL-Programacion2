using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Jugador : MonoBehaviour
{
    //serializo el scripteable object
    [SerializeField]private PerfilJugador perfilJugador;
    
    //obtengo la referencia y les doy acceso a otros scripts
    public PerfilJugador PerfilJugador { get => perfilJugador; }

    //--- Eventos del jugador ---//

    [SerializeField] private UnityEvent<int> OnLivesChanged;
    [SerializeField] private UnityEvent<string> OnTextChanged;
   
    private bool vidallena;
    //referencias
    private AudioSource miAudioSource;

    //items
    private bool TieneKeylv1 = false;

    //metodos
    public bool Get_vidallena() { return vidallena; }
    public void Dar_llave() { TieneKeylv1 = true; }
    public void ModificarVida(int puntos)
    {
        PerfilJugador.Vida += puntos;
        Debug.Log(EstasVivo());
    }
    public float Get_vida() { return PerfilJugador.Vida; }
    public string VidaActual()
    {
        return PerfilJugador.Vida.ToString();
    }

    private bool EstasVivo()
    {
        return PerfilJugador.Vida > 0;
    }
    public bool get_keylv1() { return TieneKeylv1; }

    private void OnEnable()
    {
        miAudioSource = GameObject.Find("AdministradorSonidos").gameObject.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Meta"))
        { 
            Debug.Log("GANASTE! tu puntaje final es: " + GameManager.Instance.GetScore().ToString());
            ApplicationManager.instance.GotoNextScene();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("enemigo"))
        {
            
            miAudioSource.PlayOneShot(perfilJugador.RecibirDanioSFX);
           
        }
    }

    private void Start()
    {
        //reestablesco la vida.
        PerfilJugador.Vida = 3;
        OnTextChanged.Invoke("Puntaje: " + GameManager.Instance.GetScore().ToString());
        OnLivesChanged.Invoke(perfilJugador.Vida);

    }
    private void Update()
    {
        //actualizo el estado de la vida
        if (PerfilJugador.Vida == 3) { vidallena = true; } else { vidallena = false; }

        //destruyo al jugador si la vida llega a 0
        if (PerfilJugador.Vida <= 0) 
        {
           
            Debug.Log("GameOver, Puntaje final: " + GameManager.Instance.GetScore().ToString());
            gameObject.SetActive(false);
            ApplicationManager.instance.GotoPreviousScene();
            GameManager.Instance.ResetScore();
        }
    }

    public void ActualizarVidaJugadorHUD()
    {
        OnLivesChanged.Invoke(perfilJugador.Vida);
    }
    
    public void ActualizarPuntaje()
    {
        OnTextChanged.Invoke("Puntaje: " + GameManager.Instance.GetScore().ToString());
    }



}