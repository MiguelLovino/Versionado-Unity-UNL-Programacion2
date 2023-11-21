using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Curar : MonoBehaviour
{
    [Header("Configuracion")]
    [SerializeField] int puntos = 1;
    [SerializeField] private AudioClip HealUpSFX;


    //referencia
    private AudioSource miAudioSource;
    //private AdmSound admsound;

    private void OnEnable()
    {

       miAudioSource = gameObject.AddComponent<AudioSource>();
      // admsound = GameObject.Find("AdministradorSonidos").gameObject.GetComponent<AdmSound>();
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("Player"))
        {
            Jugador jugador = other.GetComponent<Jugador>();
            if (jugador.Get_vida() >= 3) { return; }
            jugador.ModificarVida(puntos);
            jugador.ActualizarVidaJugadorHUD();
            Debug.Log("Te curas " + puntos + " de vida, tu vida actual es de: " + jugador.VidaActual());
            miAudioSource.PlayOneShot(HealUpSFX);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Jugador jugador = collision.gameObject.GetComponent<Jugador>();
            if (jugador.Get_vida() >= 3) { Destroy(gameObject);  return; }
            jugador.ModificarVida(puntos);
            jugador.ActualizarVidaJugadorHUD();
            Debug.Log("Te curas " + puntos + " de vida, tu vida actual es de: " + jugador.VidaActual());
            miAudioSource.PlayOneShot(HealUpSFX);
            Destroy(gameObject);
        }
    }
}