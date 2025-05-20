using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu_Manager : MonoBehaviour
{
    public GameObject menuItem;
    public GameObject completedAudio;
    public ActivateMenu menuActivator;
    private bool menuOff;
    // Start is called before the first frame update
    void Start()
    {
        if (menuItem != null)
        {
            menuItem.SetActive(false);
            menuOff = true;
        }

    }

    // Update is called once per frame
    void Update()
    {
        //if (completedAudio.activeInHierarchy == false)
        //{
        //    menuItem.SetActive(true);
        //}

        if (menuActivator.hasPlayed && menuOff)
        {
            menuItem.SetActive(true);
            menuOff = false;
        }
    }

    
}
