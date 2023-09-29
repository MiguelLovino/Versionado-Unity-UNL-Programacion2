using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerararObjetoLoop : MonoBehaviour
{
    [SerializeField] GameObject ObjetoPrefab;
    //serializo los valores que utiliza el metodo invoke
    [SerializeField]
    [Range(0.5f, 5f)]
    private float tiempoEspera;

    [SerializeField]
    [Range(0.5f, 5f)]
    private float tiempoIntervalo;

    // Start is called before the first frame update
    void Start()
    {
        //metodo que se encarga de generar nuestro objeto en loop.
        InvokeRepeating(nameof(GenerarObjeto), tiempoEspera, tiempoIntervalo);
       
    }

    //metodo encargado de instanciar al objeto a invocar.
    void GenerarObjeto()
    {
        // parametros: el objeto a generar, la posicion del objeto invocador, la rotacion.
        Instantiate(ObjetoPrefab, transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
