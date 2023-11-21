using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainUIController : MonoBehaviour
{
    public void CargarSiguenteEscena()
    {
       ApplicationManager.instance.GotoNextScene();
    }

    public void CagarEscenaInicial()
    {
        ApplicationManager.instance.GoToStartScene();
    }
        
}
