using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerUI : MonoBehaviour
{
    //public GameObject uiPanel;
    public UnityEvent questionDisplay;
    private QuestionsManagement management;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //uiPanel.SetActive(true);
            questionDisplay.Invoke();
        }
    }
}
