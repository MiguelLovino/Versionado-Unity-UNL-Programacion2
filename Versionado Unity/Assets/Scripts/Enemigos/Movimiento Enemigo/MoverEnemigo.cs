using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MoverEnemigo : MonoBehaviour
{

    // Start is called before the first frame update
    [Header("Configuracion")]
    [SerializeField]
    protected float velocidad = 0.017f;
    [SerializeField]
    protected float DistanciaRecorrido = 3.7f;

    //variable para guardar la posicion actual.
    [SerializeField]
    protected Vector3 posInicial;
    private void Start()
    {
        posInicial = transform.position;
    }

    // Update is called once per frame
    private void OnEnable()
    {
        Mover();

    }

    protected abstract void Mover();
}
