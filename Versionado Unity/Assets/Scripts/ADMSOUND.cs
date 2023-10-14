using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ADMSOUND : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private PerfilSonido perfilSonido;
    public PerfilSonido PerfilSonido { get => perfilSonido; }

    AudioSource miAudiosource;

    void Start()
    {
        miAudiosource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
