using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    //serializo el scripteable object
    [SerializeField]private PerfilJugador perfilJugador;
    
    //obtengo la referencia y les doy acceso a otros scripts
    public PerfilJugador PerfilJugador { get => perfilJugador; }

    private int puntaje;
    
    public void set_puntaje(int p)
    {
        puntaje += p;
        Debug.Log("el puntaje del jugador es: " +  puntaje);
    }
   
    private bool vidallena;
    //referencias
    private AudioSource miAudioSource;

    //items
    private bool TieneKeylv1 = false;

    //metodos
    public bool Get_vidallena() { return vidallena; }
    public void Dar_llave() { TieneKeylv1 = true; }
    public void ModificarVida(float puntos)
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
        miAudioSource = GetComponent<AudioSource>();    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Meta"))
        { 
            Debug.Log("GANASTE! tu puntaje final es: " + puntaje);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("enemigo"))
        {
            
            miAudioSource.PlayOneShot(perfilJugador.RecibirDanioSFX);
        }
    }

    private void Update()
    {
        //actualizo el estado de la vida
        if (PerfilJugador.Vida == 3) { vidallena = true; } else { vidallena = false; }

        //destruyo al jugador si la vida llega a 0
        if (PerfilJugador.Vida <= 0) 
        {
            Debug.Log("GameOver, Puntaje final: " + puntaje);
            Destroy(gameObject);
            //reestablesco la vida.
            PerfilJugador.Vida = 3; 
        }

    }

}