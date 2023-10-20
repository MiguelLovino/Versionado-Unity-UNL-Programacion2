using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class JuntarLlave : MonoBehaviour
{
    // Start is called before the first frame update
    private ADMSOUND admsound;
    private AudioSource miAudioSource;
    void Start()
    {
        miAudioSource = GameObject.Find("AdministradorSonidos").gameObject.GetComponent<AudioSource>();
        admsound = GameObject.Find("AdministradorSonidos").GetComponent<ADMSOUND>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
        {
        if (collision.gameObject.CompareTag("Key"))
        {

            miAudioSource.PlayOneShot(admsound.PerfilSonido.PickLlave);

            Debug.Log("Juntaste la llave de la puerta");

            //destruyo el objeto
            Destroy(collision.gameObject);

           Jugador jugador = GetComponent<Jugador>();
            jugador.Dar_llave();
            Debug.Log(jugador.get_keylv1());
        }
    }

}
