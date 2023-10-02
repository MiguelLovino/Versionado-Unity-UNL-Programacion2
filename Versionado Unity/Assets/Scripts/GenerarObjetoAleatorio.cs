using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerarObjetoAleatorio : MonoBehaviour
{
    [SerializeField] private GameObject[] ObjetosPrefabs;
    [SerializeField] private float fuerzaImpulso;
    [SerializeField] private bool destruirGenerador = true;
    private int contadorUsos = 0;
    [SerializeField] private int usosTotal;
    [SerializeField] private float desplazamientoVertical;

    // Start is called before the first frame update
    void Start()
    {
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && contadorUsos < usosTotal)
        {
            Invoke(nameof(GenerarObjetoRandom), 0);

            //aplicar sonido.
            contadorUsos++;

            if (contadorUsos == usosTotal)
            {
                if (destruirGenerador)
                {
                    Destroy(gameObject);
                }
            }

        }
    }

    void GenerarObjetoRandom()
    {
        //obtengo un numero random y lo alojo en una variable para luego generar dicho prefab del array.
        int indexAleatorio = Random.Range(0, ObjetosPrefabs.Length);

        //creo un nuevo objeto segun el numero random
        GameObject prefabAletorio = ObjetosPrefabs[indexAleatorio];


        Vector3 newTP = transform.position;
        newTP.y = newTP.y + desplazamientoVertical;

        //instancio el objeto random y lo ubico en la posicion del objeto generador y obtengo una referencia para impul;
        GameObject ObjetoiInstaciado = Instantiate(prefabAletorio, newTP, Quaternion.identity);

        //cambio la direccion horizontal aleatoreamente
        Vector2 direccion;
        direccion.y = 0;
        int rand = Random.Range(0, 2);
        if (rand == 0) { direccion.x = -1; } else { direccion.x = 1; }

        //impulso
        ObjetoiInstaciado.GetComponent<Rigidbody2D>().AddForce(direccion * fuerzaImpulso,ForceMode2D.Impulse);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
