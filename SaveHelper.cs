using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class SaveHelper : MonoBehaviour
{
    public TextMeshProUGUI stringInput;
    public TextMeshProUGUI intInput;
    public TextMeshProUGUI boolInput;
    public TextMeshProUGUI floatInput;

    //public TextMeshProUGUI allVarTxt;
    public TMP_Text allVarTxt;

    private void Update()
    {
        if (allVarTxt != null)
        {
            allVarTxt.text = "";
            for (int i = 0; i < UniversalSaveSystem.allVariables.Count; i++)
            {
                string newLine = UniversalSaveSystem.allVariables[i].type.ToString() + ":\t" + UniversalSaveSystem.allVariables[i].name + "-\t" + UniversalSaveSystem.allVariables[i].value + "\n";
                allVarTxt.text += newLine;
            }
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void SetString()
    {
        UniversalSaveSystem.SetString("string", stringInput.text);
    }
    public void SetInt()
    {
        UniversalSaveSystem.SetInt("int", SceneManager.GetActiveScene().buildIndex);
    }

    public void SetBool()
    {
        bool val = UniversalSaveSystem.GetBool("bool");
        val = !val;
        UniversalSaveSystem.SetBool("bool", val);
    }

    public void SetFloat()
    {
        float newVal = SceneManager.GetActiveScene().buildIndex + 0.5f;
        UniversalSaveSystem.SetFloat("float", newVal);
    }

    public void SaveAll()
    {
        UniversalSaveSystem.SaveAll();
    }

    public void ChangeScene(int pos)
    {
        SceneManager.LoadScene(pos);
    }

    public void ClearAll()
    {
        UniversalSaveSystem.ClearAll();
    }
}
