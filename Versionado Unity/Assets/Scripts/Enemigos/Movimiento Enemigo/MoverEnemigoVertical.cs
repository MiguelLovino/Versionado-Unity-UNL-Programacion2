using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class MoverEnemigo1 : MoverEnemigo
{
  
    protected override void Mover()
    {
        if (transform.position.y > posInicial.y)
        {
            velocidad *= -1;
        }
        else if (transform.position.y < posInicial.y - DistanciaRecorrido)
        {
            velocidad *= -1;
        }
        Debug.Log("funciona el script mover");
        transform.Translate(0, velocidad, 0);
    }

    private void FixedUpdate()
    {
        Mover();
    }
}
