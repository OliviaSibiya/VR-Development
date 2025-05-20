using System.Collections;
using System.Collections.Generic;
using Oculus.Interaction;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class KeyboardManager : MonoBehaviour
{

    public static string idNumber = "";
    public static string firstName = "";
    public static string lastName = "";

    public  static string employeeName;
    public TMP_Text placeHolder;
    public string placeHolderText;
    public static float totalHours = 0f;

    public TMP_InputField inputValue;
    public GameObject lowerCases;
    public GameObject upperCases;

    private void Awake()
    {
        totalHours = 0f;
    }

    public void AddChar(string newChar)
    {
        if (inputValue != null)
        {
            inputValue.text += newChar;
        }
    }

    public void Backspace()
    {
        if (inputValue != null && inputValue.text.Length > 0)
        {
            inputValue.text = inputValue.text.Remove(inputValue.text.Length - 1, 1);
        }
    }

    public void ToggleCaps()
    {
        if (lowerCases != null && upperCases != null)
        {
            if (lowerCases.activeSelf)
            {
                lowerCases.SetActive(false);
                upperCases.SetActive(true);
            }
            else if (upperCases.activeSelf)
            {
                lowerCases.SetActive(true);
                upperCases.SetActive(false);
            }
        }
    }

    public void SubmitText(string type)
    {
        if (inputValue == null || inputValue.text.Length == 0)
        {
            return;
        }
        if (type == "id")
        {
            idNumber = inputValue.text;
        }
        else if (type == "first name")
        {
            firstName = inputValue.text;
        }
        else if (type == "last name")
        {
            lastName = inputValue.text;
        }
        inputValue.text = "";
    }

    public void Enter()
    {
       // Debug.Log("The name is: " + inputValue.text);
        employeeName = inputValue.text;
        Debug.Log("The name is: " +employeeName);
        placeHolder.text = employeeName;
        placeHolderText = employeeName; 
        //PlayerPrefs.SetString("Name", inputValue.text);
        PlayerPrefs.SetString("EmployeeName",employeeName);
        PlayerPrefs.Save();

        SceneManager.LoadScene("Controller Configure");
      
    }
}
