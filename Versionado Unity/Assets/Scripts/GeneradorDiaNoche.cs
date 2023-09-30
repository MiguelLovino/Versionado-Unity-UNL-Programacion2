using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorDiaNoche : MonoBehaviour
{

    [SerializeField] private SpriteRenderer fondo;
    [SerializeField] private Color colorNoche;
    [SerializeField] private float segundos;

    private Color colorDia;


    // Start is called before the first frame update
    void Start()
    {
        //obtengo el color de la camara
        colorDia = fondo.color;
        InvokeRepeating(nameof(CambiarColor), segundos,segundos);

    }

    void CambiarColor()
    {
        //si es de dia, cambio a noche
        if (fondo.color == colorDia)
        {
            fondo.color = colorNoche;
        }
        else
        {
            fondo.color = colorDia;
        }   

    }

    // Update is called once per frame
    void Update()
    {
    
    }
}
