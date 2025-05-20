using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TyrePressureManager : MonoBehaviour
{
    private void Update()
    {
        
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Processing Plant")
        {
            Debug.Log("PROCESSING PLANT HAS BEEN LOADED");
        }

        if (scene.name == "SandDunes backup")
        {
            Debug.Log("SAND DUNES HAS BEEN LOADED");
        }
    }
}
