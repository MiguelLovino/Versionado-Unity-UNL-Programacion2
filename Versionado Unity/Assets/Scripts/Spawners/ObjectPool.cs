using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    // se crean 2 serializaciones, el objeto a utilizar y la cantidad del pool
    [SerializeField] private GameObject objectPrefab;
    [SerializeField] private int poolSize = 2;

    //se crea una lista para administrar los objetos del pool
    private List<GameObject> pooledObjects;

    // Start is called before the first frame update
    void Start()
    {
        //inicializo la lista
        pooledObjects = new List<GameObject>();

        //recorro la lista
        for (int i = 0; i < poolSize; i++)
        {
            //obtengo una referencia del objeto a utilizar, previamente serializado
            GameObject obj = Instantiate(objectPrefab);
            //lo desactivo
            obj.SetActive(false);
            //lo agrego a la lista
            pooledObjects.Add(obj);
            //asigno nuevo padre para mejor visualizacion en el engine
            obj.transform.SetParent(transform);
            
            Debug.Log("Se llena el pool con los objetos");
        }
    }


    public GameObject GetpooledObject()
    {
        foreach (GameObject obj in pooledObjects)
        {
            if (!obj.activeInHierarchy)
            {
                return obj;
            }
          
        }

        return null;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
