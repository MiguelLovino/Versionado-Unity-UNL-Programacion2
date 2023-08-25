using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class MoverEnemigo1 : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Configuracion")]
    [SerializeField]
    private float velocidadVertical = 0.017f;
    [SerializeField]
    private float DistanciaRecorrido = 3.7f;

    //variable para guardar la posicion actual.
    Vector3 posInicial;

    void Start()
    {
       posInicial = transform.position;
    }

    // Update is called once per frame
  
    private void FixedUpdate()
    {

        if (transform.position.y >= posInicial.y)
        {
            velocidadVertical *= -1;
        }
        else if (transform.position.y <= posInicial.y - DistanciaRecorrido)
        {
            velocidadVertical *= -1;
        }

        transform.Translate(0, velocidadVertical, 0);
    }
}
