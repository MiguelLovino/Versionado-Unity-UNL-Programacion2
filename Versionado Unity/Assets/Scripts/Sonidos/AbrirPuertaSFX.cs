using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbrirPuerta : MonoBehaviour
{

    private AdmSound admsound;
    private AudioSource miAudioSource;

    // Start is called before the first frame update
    void Start()
    {
        miAudioSource = GameObject.Find("AdministradorSonidos").gameObject.GetComponent<AudioSource>();
        admsound = GameObject.Find("AdministradorSonidos").GetComponent<AdmSound>();
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

            miAudioSource.PlayOneShot(admsound.PerfilSonido.OpenDoor);

            Destroy(collision.gameObject);
        }
    }
}
