using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Herir : MonoBehaviour
{
    // Variables a configurar desde el editor
    [Header("Configuracion")]
    [SerializeField] float puntos = 1f;
    [SerializeField] bool DestruirObjeto = true;
   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Jugador jugador = collision.gameObject.GetComponent<Jugador>();
            jugador.ModificarVida(-puntos);
            Debug.Log("Recibes " + puntos + " de danio." + "Vida restante: " + jugador.VidaActual());
            if (DestruirObjeto) 
            {
                Destroy(gameObject);
            }
        }
       
    }

}