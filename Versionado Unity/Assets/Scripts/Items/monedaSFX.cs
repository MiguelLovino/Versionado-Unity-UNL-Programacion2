using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monedaSFX : MonoBehaviour
{
    private AudioSource miAudioSource;
    private ADMSOUND admsound;
    void Start()
    {
        //busco el objeto "administrador de sonidos"
        miAudioSource = GameObject.Find("AdministradorSonidos").gameObject.GetComponent<AudioSource>();
        admsound = GameObject.Find("AdministradorSonidos").GetComponent<ADMSOUND>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            miAudioSource.PlayOneShot(admsound.PerfilSonido.MonedaSFX);
            Debug.Log("CONTROL DE SONIDO");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            miAudioSource.PlayOneShot(admsound.PerfilSonido.MonedaSFX);
            Debug.Log("CONTROL DE SONIDO");
        }
    }
}
