using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerararObjetoLoopWithPool : MonoBehaviour
{
    //[SerializeField] GameObject ObjetoPrefab;
    //serializo los valores que utiliza el metodo invoke
    [SerializeField]
    [Range(0.5f, 5f)]
    private float tiempoEspera;

    [SerializeField]
    [Range(0.5f, 5f)]
    private float tiempoIntervalo;

    private ObjectPool objectPool;
    private void Awake()
    {
        objectPool = GetComponent<ObjectPool>();
    }
    void Start()
    {
       
    }

    //cuando esta en la vista del jugador, se invoca
    private void OnBecameVisible()
    {
        
        //metodo que se encarga de generar nuestro objeto en loop.
        Debug.Log("El sprite es visible por la camara, se generan objeto");
        InvokeRepeating(nameof(GenerarObjeto), tiempoEspera, tiempoIntervalo);
        
    }

    //si sale de la vista, para la invocasion
    private void OnBecameInvisible() 
    {
        Debug.Log("El sprite es Invisible por la camara, se detiene la generacion de objetos");
        CancelInvoke(nameof(GenerarObjeto));
    }

    //metodo encargado de instanciar al objeto a invocar.
    void GenerarObjeto()
    {
        // parametros: el objeto a generar, la posicion del objeto invocador, la rotacion.
        //Instantiate(ObjetoPrefab, transform.position, Quaternion.identity);

        GameObject pooledObject = objectPool.GetpooledObject();

        if (pooledObject != null)
        {
            pooledObject.transform.position = transform.position;
            pooledObject.transform.rotation = Quaternion.identity;
            pooledObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
