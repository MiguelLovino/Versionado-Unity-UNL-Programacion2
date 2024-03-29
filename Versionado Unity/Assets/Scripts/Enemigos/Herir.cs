using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Herir : MonoBehaviour
{
    // Variables a configurar desde el editor
    [Header("Configuracion")]
    [SerializeField] int puntos;
    [SerializeField] bool DestruirObjeto = true;
    [SerializeField] bool desactivarObjeto = false;
   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Jugador jugador = collision.gameObject.GetComponent<Jugador>();
            jugador.ModificarVida(-puntos);
            jugador.ActualizarVidaJugadorHUD();
            Debug.Log("Recibes " + puntos + " de danio." + "Vida restante: " + jugador.VidaActual());
            if (desactivarObjeto) { gameObject.SetActive(false); return; }
            if (DestruirObjeto) { Destroy(gameObject); }
           
        }
       
    }

}