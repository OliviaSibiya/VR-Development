using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class QuestionsManagement : MonoBehaviour
{
    //This is for activating and deactivating the pop ups.

    public GameObject[] popups;
    public GameObject[] gardenQuestions;
    public GameObject[] kidsRoomQuestions;
    public GameObject[] loungeQuestions;
    public GameObject[] kitchenQuestions;
    public SubmittedAnswers submitted;

    public void KidsRoomQuestions()
    {
        //switch out the questions. (Create a switch system)
        //Within each switch statement, there will be a button that will activate once the correction question is answered
        popups[1].gameObject.SetActive(true);
        Debug.Log("Kids Room");
    }

    public void LoungeQuestions()
    {
        popups[2].gameObject.SetActive(true);
        Debug.Log("Lounge Room");
    }

    public void GardenQuestions()
    {
        popups[0].gameObject.SetActive(true);
        Debug.Log("Garden Room");
    }

    public void KitchenQuestions()
    {
        popups[3].gameObject.SetActive(true);
        Debug.Log("Kitchen Room");
    }

    public void OnCompletedAnswer()
    {
        popups[0].gameObject.SetActive(false);
        popups[1].gameObject.SetActive(false);
        popups[2].gameObject.SetActive(false);
        popups[3].gameObject.SetActive(false);
    }

    void OnCorrectAnswer()
    {

    }

    void OnIncorrectAnswer()
    {

    }
}
