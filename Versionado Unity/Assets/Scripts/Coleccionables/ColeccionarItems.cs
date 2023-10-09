using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColeccionarItems : MonoBehaviour
{
    //creo una lista para almacenar los items.
    [SerializeField] private List<GameObject> coleccionar;
    // creo un game object al cual voy a trasladar los items recolectados.
    [SerializeField] private GameObject invantarioJugador;


    private void Awake()
    {
        //inicializo la lista
        coleccionar = new List<GameObject>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        
       if (collision.gameObject.CompareTag("coleccionable"))
        {


        //obtengo la refencia del objeto que coliciona.
        GameObject nuevoItem = collision.gameObject;

        //desactivo el nuevo objeto (no se dibuja en pantalla)
        nuevoItem.SetActive(false);

        //lo agrego a la lista.
        coleccionar.Add(nuevoItem);

        //lo cambio de padre.
        nuevoItem.transform.SetParent(invantarioJugador.transform);

        }

        return;

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
