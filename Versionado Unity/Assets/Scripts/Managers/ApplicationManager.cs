using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplicationManager : MonoBehaviour
{
    public static ApplicationManager instance {  get; private set; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void GotoNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex; 
        int nextSceneIndex = currentSceneIndex + 1; 
                                    
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            Debug.Log(" ya no hay escenas despues de la actual");
        }
    }

    public void GotoPreviousScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex - 1;

        if (nextSceneIndex >=0)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            Debug.Log(" Ya no hay ascenas antes de la actual");
        }
    }

    public void GoToStartScene()
    {
        SceneManager.LoadScene(0);
        GameManager.Instance.ResetScore();
    }
}
