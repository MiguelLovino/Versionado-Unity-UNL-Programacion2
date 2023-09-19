using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Curar : MonoBehaviour
{
    [Header("Configuracion")]
    [SerializeField] float puntos = 1f;
    [SerializeField] private AudioClip HealUpSFX;

    //referencia
    private AudioSource miAudioSource;

    private void OnEnable()
    {
        miAudioSource = GetComponent<AudioSource>();
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("Player"))
        {
            Jugador jugador = other.GetComponent<Jugador>();
            if (jugador.Get_vida() >= 3) { return; }
            jugador.ModificarVida(puntos);
            Debug.Log("Te curas " + puntos + " de vida, tu vida actual es de: " + jugador.VidaActual());
            miAudioSource.PlayOneShot(HealUpSFX);
        }
    }
}