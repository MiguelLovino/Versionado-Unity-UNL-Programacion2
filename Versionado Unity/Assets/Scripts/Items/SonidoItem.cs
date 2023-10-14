using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonidoItem : MonoBehaviour
{
    [Tooltip("Clip a reproducir")]
    [SerializeField] private AudioClip miAudioclip;

    private AudioSource miAudioSource;
    
    void Start()
    {
        //busco el objeto "administrador de sonidos"
        miAudioSource = GameObject.Find("AdministradorSonidos").gameObject.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            miAudioSource.PlayOneShot(miAudioclip);
            Debug.Log("CONTROL DE SONIDO");

            //si no tiene cuerpo, sale
            if (gameObject.GetComponent<Rigidbody2D>() == null) { return; }
            //de lo contrario, lo destruye
            Destroy(gameObject);
        }
    }
}
