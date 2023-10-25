using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorDiaNoche : MonoBehaviour
{

    [SerializeField] private SpriteRenderer fondo;
    [SerializeField] private Color colorNoche;

    [SerializeField][Range(1, 128)] private int duracionDia;

    private Color colorDia;


    // Start is called before the first frame update
    void Start()
    {
        //obtengo el color de la camara
        colorDia = fondo.color;

         StartCoroutine(CambiarColor(duracionDia));

    }

    IEnumerator CambiarColor(float tiempo)
    {
        //cambio el color del fondo, si es de dia, lo cambia a noche.
        Color colorDestinoFondo = fondo.color == colorDia ? colorNoche : colorDia;
        //por el momento no aplico luz.

        float duracionCiclo = tiempo * 0.6f;

        float duracionCambio = tiempo * 0.4f;

       while (true)
        { 

            yield return new WaitForSeconds(duracionCiclo);

            float tiempoTranscurrido = 0;

            while (tiempoTranscurrido < duracionCambio)
            {
                tiempoTranscurrido += Time.deltaTime;
                float t = tiempoTranscurrido / duracionCambio;

                float smothT = Mathf.SmoothStep(0f, 1f, t);

                fondo.color = Color.Lerp(fondo.color, colorDestinoFondo, smothT);
                yield return null;

            }

            colorDestinoFondo = fondo.color == colorDia ? colorNoche : colorDia;
        }
   
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
