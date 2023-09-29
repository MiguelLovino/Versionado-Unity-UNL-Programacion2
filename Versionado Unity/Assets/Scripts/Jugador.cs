using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    [Header("Configuracion")]
    [SerializeField] private float vida = 3f;
    [SerializeField] private AudioClip recibirDañoSFX;
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
        vida += puntos;
        Debug.Log(EstasVivo());
    }
    public float Get_vida() { return vida; }
    public string VidaActual()
    {
        return vida.ToString();
    }

    private bool EstasVivo()
    {
        return vida > 0;
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
            Debug.Log("GANASTE");
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("enemigo"))
        {
            miAudioSource.PlayOneShot(recibirDañoSFX);
        }
    }

    private void Update()
    {
        //destruyo al jugador si la vida llega a 0
        if (vida <= 0) { Debug.Log("GameOver"); Destroy(gameObject); }

        //actualizo el estado de la vida
        if (vida == 3) { vidallena = true; } else { vidallena = false; }

    }

}