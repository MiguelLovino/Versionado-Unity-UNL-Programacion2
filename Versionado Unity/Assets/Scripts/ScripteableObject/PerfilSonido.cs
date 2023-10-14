using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NuevoPerfilSonido", menuName = "SO/Perfil sonido")]

public class PerfilSonido : ScriptableObject
{
    [Header("Configuracion de sonidos")]
    [Header("Sonidos de items")]
    [SerializeField] private AudioClip monedaSFX;
    public AudioClip MonedaSFX { get => monedaSFX; }
    [SerializeField] private AudioClip corazonSFX;
    public AudioClip CorazonSFX { get => CorazonSFX; }
    [SerializeField] private AudioClip diamanteSFX;
    public AudioClip DiamanteSFX { get => diamanteSFX; }
    [SerializeField] private AudioClip pickLlaveSFX;
    public AudioClip PickLlave { get => pickLlaveSFX; }
    [SerializeField] private AudioClip openDoorSFX;
    public AudioClip OpenDoor { get =>  openDoorSFX; }


    [Header("Sonidos del jugador")]
    [SerializeField] private AudioClip saltarSFX;
    public AudioClip SaltarSFX { get => SaltarSFX; }
    [SerializeField] private AudioClip recibirDanioSFX;
    public AudioClip RecibirdanioSFX { get => RecibirdanioSFX; }


}
