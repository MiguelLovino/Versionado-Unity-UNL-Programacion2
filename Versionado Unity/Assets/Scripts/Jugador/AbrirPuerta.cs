using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbrirPuerta : MonoBehaviour
{
    [SerializeField] private AudioClip abrirPuertaSFX;

    private AudioSource miAudiosource;

    // Start is called before the first frame update
    void Start()
    {
        miAudiosource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Jugador jugador = GetComponent<Jugador>();

        if (collision.gameObject.CompareTag("puerta1") && jugador.get_keylv1())
        {
            Debug.Log("abriste la puerta");

            miAudiosource.PlayOneShot(abrirPuertaSFX);

            Destroy(collision.gameObject);
        }
    }
}
