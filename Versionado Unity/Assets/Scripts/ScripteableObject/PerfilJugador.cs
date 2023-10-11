using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NuevoPerfilJugador", menuName = "SO/perfil Jugador")]
public class PerfilJugador : ScriptableObject
{
    [Header("Configuracion de atributos ")]
    [Tooltip("Vida maxima")]
    [SerializeField] private float vida;

    public float Vida { get => vida; set => vida = value; }

    [Tooltip("Potencia de salto")]
    [SerializeField] private float fuerzaSalto = 5f;
    public float FuerzaSalto { get => fuerzaSalto;}

    [Tooltip("Velocidad de movimento horizontal")]
    [SerializeField] float velocidad = 5f;
    public float Velocidad { get => velocidad; }

    [Header("Configuracion SFX")]
    [SerializeField] private AudioClip recibirDanioSFX;
    [SerializeField] private AudioClip saltarSFX;

    public AudioClip RecibirDanioSFX { get => recibirDanioSFX;}
    public AudioClip SaltarSFX { get => saltarSFX; }

}
