using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerarObjetoAleatorio : MonoBehaviour
{
    [SerializeField] private GameObject[] ObjetosPrefabs;


    [SerializeField]
    [Range(0.5f, 5f)]
    private float TiempoIntervalo;


    [SerializeField]
    [Range(0.5f, 5f)]
    private float TiempoEspera;

    // Start is called before the first frame update
    void Start()
    {
          
    }
    //cuando el personajeesta en la zona de la camara, se activa la generacion de mob
    private void OnBecameVisible()
    {
        //metodo encargado de generar objetos en repeticion.
        // parametros: el objeto a generar, la posicion del objeto invocador, la rotacion.
        InvokeRepeating(nameof(GenerarObjetoRandom), TiempoEspera, TiempoIntervalo);
    }

    //cuando el personaje no esta en la zona de la camara, se desactiva la generacion de mob
    private void OnBecameInvisible()
    { 
        CancelInvoke(nameof(GenerarObjetoRandom));
    }
    void GenerarObjetoRandom()
    {
        //obtengo un numero random y lo alojo en una variable para luego generar dicho prefab del array.
        int indexAleatorio = Random.Range(0, ObjetosPrefabs.Length);

        //creo un nuevo objeto segun el numero random
        GameObject prefabAletorio = ObjetosPrefabs[indexAleatorio];

        //instancio el objeto random y lo ubico en la posicion del objeto generador.
        Instantiate(prefabAletorio, transform.position, Quaternion.identity);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
