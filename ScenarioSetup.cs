using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using static UnityEditor.ShaderData;
using TMPro;

public class ScenarioSetup : MonoBehaviour
{
    public GameObject fatigue;
    public GameObject DUI;

    public float scenarioValue;

    public TMP_Text uiText;

    // Start is called before the first frame update
    void Start()
    {
        fatigue.SetActive(false);
        DUI.SetActive(false);

        scenarioValue = Random.Range(1, 3);

        switch (scenarioValue)
        {
            case 1:
                fatigue.SetActive(true);
                break;

            case 2:
                DUI.SetActive(true);
                break;

            default:
                Debug.Log("The sceanrios are invalid");
                break;
        }

        if (MainMenuManager.FatigueLMV == true)
        {
            fatigue.SetActive(true);
        }

        if (MainMenuManager.DUILMV == true)
        {
            DUI.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        //if (other.CompareTag("Player"))
        //{
        //    if (scenarioValue == 1)
        //    {
        //        uiText.text = "Fatigue";
        //    }

        //    if (scenarioValue == 2)
        //    {
        //        uiText.text = "D.U.I";
        //    }
        //}
    }
}