using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saltar : MonoBehaviour
{

    // Variables de uso interno en el script
    [SerializeField] float rayDistance;
    [SerializeField] LayerMask groundLayer;

    [SerializeField] float coyoteConfig = 0.1f;

    [SerializeField] float auxForce = 1f;
    [SerializeField] float auxForceMaxReset = 1f;
    [SerializeField] float jumpForceIncreaseSpeed = 2f;

    private Jugador jugador;
    private bool puedoSaltar = true;
    private bool saltando = false;
    //public bool puedosaltar2;
    private int saltoMask;
    private float coyoteTime;

    // Variable para referenciar otro componente del objeto
    private Rigidbody2D miRigidbody2D;
    private Animator miAnimator;
    private CircleCollider2D miCircleCollider2D;
    private AudioSource miAudioSource;
    
    // Codigo ejecutado cuando el objeto se activa en el nivel
    private void OnEnable()
    {
        miRigidbody2D = GetComponent<Rigidbody2D>();
        miAnimator = GetComponent<Animator>();
        miCircleCollider2D = GetComponent<CircleCollider2D>();
        saltoMask = LayerMask.GetMask("Piso", "Plataforma");
        miAudioSource = GetComponent<AudioSource>(); 
        jugador = GetComponent<Jugador>();  
    }

    // Codigo ejecutado en cada frame del juego (Intervalo variable)
    void Update()
    {
        puedoSaltar = ConectadoAlSuelo();

        if (puedoSaltar)
        {
            coyoteTime = Time.time + coyoteConfig;
        }

        if (Input.GetKey(KeyCode.Space) && ConectadoAlSuelo())
        {
            auxForce = Mathf.Min(auxForce + jumpForceIncreaseSpeed * Time.deltaTime, jugador.PerfilJugador.FuerzaSalto);
            Debug.Log(auxForce);

        }


        if (Input.GetKeyUp(KeyCode.Space) && (Time.time <= coyoteTime))
        {
            saltando = true;

            if(miAudioSource.isPlaying) { return;}
            miAudioSource.PlayOneShot(jugador.PerfilJugador.SaltarSFX);

        }

    }
    
    private void FixedUpdate()
    {
        if (saltando)
        {
            miRigidbody2D.AddForce(Vector2.up * Mathf.Min(jugador.PerfilJugador.FuerzaSalto, auxForce), ForceMode2D.Impulse);
            auxForce = auxForceMaxReset;
            saltando = false;
            
        }
        miAnimator.SetBool("enAire",!EncontancoPisoPlataforma() );
    }

    // Codigo ejecutado cuando el jugador colisiona con otro objeto
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // controlar la colicion con un tag ("plataforma")
       
       
        //ruido de caida.
        
    }

    private bool EncontancoPisoPlataforma()
    {
        return miCircleCollider2D.IsTouchingLayers(saltoMask);
    }

    private bool ConectadoAlSuelo()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, rayDistance, groundLayer);
        return hit.collider != null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, Vector2.down * rayDistance);
    }
}
