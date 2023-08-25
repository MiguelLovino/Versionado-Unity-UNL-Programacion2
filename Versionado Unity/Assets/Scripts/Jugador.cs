using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    [Header("Configuracion")]
    [SerializeField] private float vida = 5f;

    private bool TieneKeylv1 = false;
    public void ModificarVida(float puntos)
    {
        vida += puntos;
        Debug.Log(EstasVivo());
    }
    public string VidaActual()
    {
        return vida.ToString();
    }

    private bool EstasVivo()
    {
        return vida > 0;
    }
    public bool get_keylv1() { return TieneKeylv1; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Meta"))
        { 
            Debug.Log("GANASTE");
        }
        if (collision.gameObject.CompareTag("Key"))
        {
            Debug.Log("Juntaste la llave de la puerta");
            //destruyo el objeto
            Destroy(collision.gameObject);
            //obtengo la llave
            TieneKeylv1 = true;
        }
       
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("puerta1") && get_keylv1())
        {
            Destroy(collision.gameObject);
            Debug.Log("abriste la puerta");
        }
        if (collision.gameObject.CompareTag("enemigo"))
        {
            Destroy(collision.gameObject);
        }
    }

}