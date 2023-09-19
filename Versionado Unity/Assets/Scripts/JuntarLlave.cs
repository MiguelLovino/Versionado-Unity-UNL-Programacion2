using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JuntarLlave : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private AudioClip juntarLLaveSFX;
    private AudioSource miAudiosource;
    void Start()
    {
        miAudiosource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Key"))
        {
                
           miAudiosource.PlayOneShot(juntarLLaveSFX);

           Debug.Log("Juntaste la llave de la puerta");

            //destruyo el objeto
           Destroy(collision.gameObject);   

           Jugador jugador = GetComponent<Jugador>();
           jugador.Dar_llave();
           Debug.Log(jugador.get_keylv1());
        }
    }

}
