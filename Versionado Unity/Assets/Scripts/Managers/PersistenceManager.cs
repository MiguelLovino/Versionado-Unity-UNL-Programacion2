using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistenceManager : MonoBehaviour
{
    public static PersistenceManager Instance { get; private set; }

    public static string KeyMusic { get => Instance.keyMusic; }
    public static string KeyVolume { get => Instance.keyVolume; }
    public static string Keyuser { get => Instance.keyuser; }   
    public static string KeyScore { get => Instance.keyScore; }


    [SerializeField] private string keyMusic, keyVolume, keyuser, keyScore;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetInt(string key, int value)
    {
        PlayerPrefs.SetInt(key, value);
    }

    public int GetInt(string key, int defaultValue = 0)
    {
        return PlayerPrefs.GetInt(key, defaultValue);
    }

    public void SetFloat(string keu, float value)
    {
        PlayerPrefs.SetFloat(keu, value);
    }

    public float GetFloat(string key, float defaultvalue = 0.0f)
    { 
        return PlayerPrefs.GetFloat(key, defaultvalue); 
    }

    public void SetString(string key, string value)
    {
        PlayerPrefs.SetString(key, value);
    }

    public string GetString(string key, string defaultValue = "")
    {
        return PlayerPrefs.GetString(key, defaultValue);    
    }

    public void SetBool(string key, bool state)
    {
        PlayerPrefs.SetInt(key, state? 1 : 0);
    }

    public bool GetBool(string key, bool defaultValue = false)
    {
        int value = PlayerPrefs.GetInt(key, defaultValue ? 1 : 0);  
        return value == 1;
    }

    public void Save()
    {
        PlayerPrefs.Save(); 
    }

    public void DeleteKey(string key)
    {
        PlayerPrefs.DeleteKey(key);
    }

    public void DeleteAll()
    {
        PlayerPrefs.DeleteAll();    
    }

    public void SaveMusicConfig(bool status)
    {
        SetBool(keyMusic, status);
        Debug.Log("el jugado preciono " + status);
    }

    public void SaveVolumenconfig(float volume)
    {
        SetFloat(keyVolume, volume);
        Debug.Log("el volumen elegio es de " + volume);
    }

    public void SaveUserNave(string value)
    {
        SetString(keyuser, value);
        Debug.Log(" el nombre es " + value);
    }
}
