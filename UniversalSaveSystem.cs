using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniversalSaveSystem : MonoBehaviour
{
    [Header("Clear Variables")]
    public bool clearAll;

    public List<Variable> variableViewer = new List<Variable>();
    public static List<Variable> allVariables = new List<Variable>();

    private void OnValidate()
    {
        ValidateVariables();
    }

    private void Awake()
    {
        ValidateVariables();
    }

    private void ValidateVariables()
    {
        if (clearAll)
        {
            clearAll = false;
            ClearAll();
        }

        if (variableViewer.Count != allVariables.Count)
        {
            if (variableViewer.Count < allVariables.Count)
            {
                for (int i = 0; i < allVariables.Count; i++)
                {
                    bool found = false;
                    for (int c = 0; c < variableViewer.Count; c++)
                    {
                        if (allVariables[i].name == variableViewer[c].name && allVariables[i].type == variableViewer[c].type)
                        {
                            found = true;
                            c = variableViewer.Count;
                        }
                    }
                    if (found == false)
                    {
                        PlayerPrefs.DeleteKey(allVariables[i].name);
                        allVariables.RemoveAt(i);
                        i--;
                    }
                }
            }
            allVariables.Clear();
            for (int i = 0; i < variableViewer.Count; i++)
            {
                allVariables.Add(variableViewer[i]);
            }
        }
        LoadAll();
    }

    private void LoadAll()
    {
        if (allVariables.Count > 0)
        {
            for (int i = 0; i < allVariables.Count; i++)
            {
                if (allVariables[i].type == Variable.VarType.String)
                {
                    allVariables[i].sValue = PlayerPrefs.GetString(allVariables[i].name);
                    allVariables[i].value = allVariables[i].sValue;
                }
                else if (allVariables[i].type == Variable.VarType.Int)
                {
                    allVariables[i].iValue = PlayerPrefs.GetInt(allVariables[i].name);
                    allVariables[i].value = allVariables[i].iValue.ToString();
                }
                else if (allVariables[i].type == Variable.VarType.Float)
                {
                    allVariables[i].fValue = PlayerPrefs.GetFloat(allVariables[i].name);
                    allVariables[i].value = allVariables[i].fValue.ToString();
                }
                else if (allVariables[i].type == Variable.VarType.Bool)
                {
                    int val = PlayerPrefs.GetInt(allVariables[i].name);
                    allVariables[i].iValue = val;
                    if (val == 0)
                    {
                        allVariables[i].bValue = false;
                        allVariables[i].value = "false";
                    }
                    else
                    {
                        allVariables[i].bValue = true;
                        allVariables[i].value = "true";
                    }
                }

                if (variableViewer[i] != null)
                {
                    variableViewer[i] = allVariables[i];
                }
                else
                {
                    variableViewer.Add(allVariables[i]);
                }
            }
        }
    }

    public static void SetString(string varName, string val)
    {
        if (FindVariable(varName) != null && FindVariable(varName).type == Variable.VarType.String)
        {
            FindVariable(varName).sValue = val;
            FindVariable(varName).value = val;
            SaveAll();
        }
    }

    public static void SetInt(string varName, int val)
    {
        if (FindVariable(varName) != null && FindVariable(varName).type == Variable.VarType.Int)
        {
            FindVariable(varName).iValue = val;
            FindVariable(varName).value = val.ToString();
            SaveAll();
        }
    }

    public static void SetFloat(string varName, float val)
    {
        if (FindVariable(varName) != null && FindVariable(varName).type == Variable.VarType.Float)
        {
            FindVariable(varName).fValue = val;
            FindVariable(varName).value = val.ToString();
            SaveAll();
        }
    }

    public static void SetBool(string varName, bool val)
    {
        if (FindVariable(varName) != null && FindVariable(varName).type == Variable.VarType.Bool)
        {
            FindVariable(varName).bValue = val;
            if (val == true)
            {
                FindVariable(varName).iValue = 1;
                FindVariable(varName).value = "true";
            }
            else
            {
                FindVariable(varName).iValue = 0;
                FindVariable(varName).value = "false";
            }
            SaveAll();
        }
    }

    public static string GetString(string varName)
    {
        if (FindVariable(varName) != null && FindVariable(varName).type == Variable.VarType.String)
        {
            return FindVariable(varName).sValue;
        }
        return "";
    }

    public static int GetInt(string varName)
    {
        if (FindVariable(varName) != null && FindVariable(varName).type == Variable.VarType.Int)
        {
            return FindVariable(varName).iValue;
        }
        return 0;
    }

    public static float GetFloat(string varName)
    {
        if (FindVariable(varName) != null && FindVariable(varName).type == Variable.VarType.Float)
        {
            return FindVariable(varName).fValue;
        }
        return 0.0f;
    }

    public static bool GetBool(string varName)
    {
        if (FindVariable(varName) != null && FindVariable(varName).type == Variable.VarType.Bool)
        {
            return FindVariable(varName).bValue;
        }
        return false;
    }

    public static Variable FindVariable(string varName)
    {
        if (allVariables != null && allVariables.Count > 0)
        {
            for (int i = 0; i < allVariables.Count; i++)
            {
                if (allVariables[i].name == varName)
                {
                    return allVariables[i];
                }
            }
        }
        return null;
    }

    public static void SaveAll()
    {
        for (int i = 0; i < allVariables.Count; i++)
        {
            if (allVariables[i].type == Variable.VarType.String)
            {
                PlayerPrefs.SetString(allVariables[i].name, allVariables[i].sValue);
            }
            else if (allVariables[i].type == Variable.VarType.Int)
            {
                PlayerPrefs.SetInt(allVariables[i].name, allVariables[i].iValue);
            }
            else if (allVariables[i].type == Variable.VarType.Float)
            {
                PlayerPrefs.SetFloat(allVariables[i].name, allVariables[i].fValue);
            }
            else if (allVariables[i].type == Variable.VarType.Bool)
            {
                PlayerPrefs.SetInt(allVariables[i].name, allVariables[i].iValue);
            }
        }
    }

    public static void ClearAll()
    {
        for (int i = 0; i < allVariables.Count; i++)
        {
            allVariables[i].sValue = "";
            allVariables[i].iValue = 0;
            allVariables[i].fValue = 0.0f;
            allVariables[i].bValue = false;
            if (allVariables[i].type == Variable.VarType.String)
            {
                allVariables[i].value = "";
            }
            else if (allVariables[i].type == Variable.VarType.Int)
            {
                allVariables[i].value = "0";
            }
            else if (allVariables[i].type == Variable.VarType.Float)
            {
                allVariables[i].value = "0.0f";
            }
            else if (allVariables[i].type == Variable.VarType.Bool)
            {
                allVariables[i].value = "false";
            }
        }
        SaveAll();
    }
}

[System.Serializable]
public class Variable
{
    public enum VarType
    {
        String,
        Int,
        Float,
        Bool
    }

    public string name;
    public VarType type;
    public string value;

    [HideInInspector] public string sValue;
    [HideInInspector] public int iValue;
    [HideInInspector] public float fValue;
    [HideInInspector] public bool bValue;
}
