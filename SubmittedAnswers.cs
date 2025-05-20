using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubmittedAnswers : MonoBehaviour
{
    //This script is for having the answers submitted.
    public QuestionsManagement questions;
    public List<string> totalAnswers;
    public List<string> correctAnswers;

    public void SubmitForGarden()
    {

    }

    public void SubmitForKidsroom()
    {

    }

    public void SubmitForLounge()
    {

    }

    public void SubmitForKitchen()
    {

    }

    void SetAnswer()
    {
        //void SetAnswers()
        //{
        //    for (int i = 0; i < options.Length; i++)
        //    {
        //        options[i].GetComponent<AnswerScript>().isCorrect = false;
        //        options[i].transform.GetChild(0).GetComponent<TMP_Text>().text = Scenarios[currentScenario].Answers[i];

        //        if (Scenarios[currentScenario].CorrectAnswer[7] == i + 1)
        //        {
        //            options[i].GetComponent<AnswerScript>().isCorrect = true;
        //        }
        //    }
        //}

        //public void wrong() // This void removes the scenario that was done and then generates the next scenario
        //{
        //    Scenarios.RemoveAt(currentScenario);
        //    generateScenario();
        //}

        //public void correct() // This void adds one number for the correct answer that was selected
        // It also removes the scenario that was completed and generates the next scenario
        //{
        //    total += 1;
        //    Scenarios.RemoveAt(currentScenario);
        //    generateScenario();
        //}

        //That's for the total amount to display
        //totalTxt.text = total + "/" + totalScenarios;
    }
}

public class Answers
{
    public string[] randomAnswers;
    public string[] correctAnswers;
    public int[] totalCorrect;
    public int[] totalIncorrect;
}
