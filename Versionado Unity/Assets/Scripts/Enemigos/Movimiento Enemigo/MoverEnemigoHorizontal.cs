using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverEnemigoHorizontal : MoverEnemigo
{

    protected override void Mover()
    {
        if (transform.position.x > posInicial.x)
        {
            velocidad *= -1;
        }
        else if (transform.position.x < posInicial.x - DistanciaRecorrido)
        {
            velocidad *= -1;
        }
        Debug.Log("funciona el script mover");
        transform.Translate(velocidad,0, 0);
    }

    private void FixedUpdate()
    {
        Mover();
    }
}
