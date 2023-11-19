using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{

    // Start is called before the first frame update
    [SerializeField] private Slider mySlider;
    [SerializeField] private Toggle myToggle;
    [SerializeField] private TMP_InputField myImput;
    void Start()
    {
        mySlider.value = PersistenceManager.Instance.GetFloat(PersistenceManager.KeyVolume);
        myToggle.isOn = PersistenceManager.Instance.GetBool(PersistenceManager.KeyMusic);
        myImput.text = PersistenceManager.Instance.GetString(PersistenceManager.Keyuser);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDisable()
    {
        PersistenceManager.Instance.Save();
    }
}
