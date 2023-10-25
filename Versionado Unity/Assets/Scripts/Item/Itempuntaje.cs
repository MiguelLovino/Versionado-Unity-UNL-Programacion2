using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Itempuntaje : MonoBehaviour
{
    [SerializeField] private int puntaje;
    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Jugador jugador = GameObject.Find("Jugador").gameObject.GetComponent<Jugador>();

        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.AddScore(puntaje);
            jugador.ActualizarPuntaje();
        }
    }
 

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Jugador jugador = GameObject.Find("Jugador").gameObject.GetComponent<Jugador>();

        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.AddScore(puntaje);
            jugador.ActualizarPuntaje();
        }
    }
}
