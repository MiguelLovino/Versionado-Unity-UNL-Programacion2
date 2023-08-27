using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saltar : MonoBehaviour
{

    // Variables a configurar desde el editor
    [Header("Configuracion")]
    [SerializeField] private float fuerzaSalto = 5f;


    // Variables de uso interno en el script
    private bool puedoSaltar = true;
    private bool saltando = false;
    public bool puedosaltar2;

    // Variable para referenciar otro componente del objeto
    private Rigidbody2D miRigidbody2D;
    private Animator miAnimator;
    
    // Codigo ejecutado cuando el objeto se activa en el nivel
    private void OnEnable()
    {
        miRigidbody2D = GetComponent<Rigidbody2D>();
        miAnimator = GetComponent<Animator>();
    }

    // Codigo ejecutado en cada frame del juego (Intervalo variable)
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) && puedoSaltar)
        {

            miRigidbody2D.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
            puedoSaltar = false;

        }

    }
    
    private void FixedUpdate()
    {
        if (!puedoSaltar && !saltando)
        {
            saltando = true;
            
        }
        miAnimator.SetBool("enAire", saltando);
    }

    // Codigo ejecutado cuando el jugador colisiona con otro objeto
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // controlar la colicion con un tag ("plataforma")
        puedoSaltar = true;
        saltando = false;
    }

}
