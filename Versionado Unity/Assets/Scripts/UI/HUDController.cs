using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUDController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI miTexto;
    [SerializeField] GameObject iconoVida;
    [SerializeField] GameObject contenedorVida;


    public void ActualizarTextoHUD(string nuevoTexto)
    {
        Debug.Log("Mi puntaje es " + nuevoTexto);
        miTexto.text = nuevoTexto;
    }

  public void ActualizarVidasHud(int vidas)
    {
        Debug.Log("se produce una actualizacion de vidas");
        //carga inicial del contenedor
        if (EstaVacioContenedor())
        {
            CargarContenedorVidas(vidas);
            return;
        }

       if(CantidadIconosVidas() > vidas)
        {
            EliminarUltimoIcono();  
        }
       else
        {
            CrearIcono();   
        }
        
       

    }
    private bool EstaVacioContenedor()
    {
        return contenedorVida.transform.childCount == 0;
    }

    private int CantidadIconosVidas()
    {
        return contenedorVida.transform.childCount;
    }
    private void CargarContenedorVidas(int cantidadIconos)
    {
        for (int i = 0; i < cantidadIconos; i++)
        {
            CrearIcono();
        }
    }

    private void CrearIcono()
    {
        Instantiate(iconoVida, contenedorVida.transform);
    }
    private void EliminarUltimoIcono()
    {
        Transform contenedor = contenedorVida.transform;
        GameObject.Destroy(contenedor.GetChild(contenedor.childCount - 1).gameObject);
    }
      
}
