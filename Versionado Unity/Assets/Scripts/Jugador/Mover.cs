
using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.EventSystems;

public class Mover : MonoBehaviour
{
    
    
    // Variables de uso interno en el script
    private float moverHorizontal;
    private Vector2 direccion;

    // Variable para referenciar otro componente del objeto
    private Rigidbody2D miRigidbody2D;
    private SpriteRenderer miSpriterenderer;
    private Animator miAnimator;
    private Jugador jugador;

    // Codigo ejecutado cuando el objeto se activa en el nivel
    private void OnEnable()
    {
        miRigidbody2D = GetComponent<Rigidbody2D>();
        miSpriterenderer = GetComponent<SpriteRenderer>();  
        miAnimator = GetComponent<Animator>();  
        jugador = GetComponent<Jugador>();
    }
    // Codigo ejecutado en cada frame del juego (Intervalo variable)
    private void Update()
    {
        moverHorizontal = Input.GetAxis("Horizontal");
        direccion = new Vector2(moverHorizontal, 0);
      
        //volteo sprite
       if(moverHorizontal > 0 ) { miSpriterenderer.flipX = true; }
       if(moverHorizontal < 0 ) { miSpriterenderer.flipX = false; }
        miAnimator.SetInteger("velocidad", (int)moverHorizontal);
 
    }
    private void FixedUpdate()
    {
        miRigidbody2D.AddForce(direccion * jugador.PerfilJugador.Velocidad);
    }


}
 
