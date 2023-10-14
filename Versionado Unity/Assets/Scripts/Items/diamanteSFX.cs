using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class diamanteSFX : MonoBehaviour
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
            miAudioSource.PlayOneShot(admsound.PerfilSonido.DiamanteSFX);
            Debug.Log("CONTROL DE SONIDO");

            //si no tiene cuerpo, sale
            if (gameObject.GetComponent<Rigidbody2D>() == null) { return; }
            //de lo contrario, lo destruye
            Destroy(gameObject);
        }
    }
}
