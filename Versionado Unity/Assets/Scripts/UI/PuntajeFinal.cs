using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PuntajeFinal : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI miPuntajeFinal;

    void Start()
    {
        miPuntajeFinal.text = "Puntaje final: " + GameManager.Instance.GetScore().ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
