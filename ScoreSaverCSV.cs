using System;
using System.IO;
using ScoreData;
using UnityEngine;


public class ScoreSaverCSV : MonoBehaviour
{
    private string documentsPath;
    private string directoryPath;
    private string filePath;
    public DateTime experienceStartTime;
    public DateTime endedExperience;
    private ScoreHelper scoreHelper;

    private void Awake()
    {
        Debug.Log("SCORE SAVER CSV AWAKE");
    }

    private void Start()
    {
        //scoreHelper.enabled = true;
    }
    public void AddRecord(string user, string taskName, int score)
    {
        string newDirectoryPath = Path.Combine(documentsPath, "Rio Tinto");
        documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        directoryPath = Path.Combine(documentsPath, "Rio Tinto");
        filePath = Path.Combine(directoryPath, "ScoreData.csv");

        if (!Directory.Exists(newDirectoryPath))
        {
            Directory.CreateDirectory(newDirectoryPath);
            Debug.Log($"Directory created at: {newDirectoryPath}");
        }

        bool fileExists = File.Exists(filePath);
        
        using (StreamWriter sw = new StreamWriter(filePath, append: true))
        {
            if (!fileExists)
            {
                sw.WriteLine("User, Date and Time, Task, Completed, Score");
            }

            sw.WriteLine($"{KeyboardManager.employeeName}, {DateTime.Now}, {taskName}, True, {score}");
            
            //sw.WriteLine($"{KeyboardManager.employeeName}, {DateTime.Now}, {taskName}, True, {score}");
        }

        Debug.Log($"Record added: {taskName}, {score}");
    }

    public void AddName(string name)
    {
        directoryPath = Path.Combine(Application.persistentDataPath, "Data");
        filePath = Path.Combine(directoryPath, name + " - RioTinto.csv");

        bool fileExists = File.Exists(filePath);

        if (!fileExists)
        {
            Directory.CreateDirectory(directoryPath);
            using (StreamWriter sw = new StreamWriter(filePath, append: true))
            {
                sw.WriteLine("EmployeeName, Date and Time, Task, Completed, Score");
            }

            using (StreamWriter sw = new StreamWriter(filePath, append: true))
            {
                sw.WriteLine($"{name}, {DateTime.Now}, True");
            }
        }
    }

    public void UpdateRecord(string user, string taskName, bool completed, int score) 
    {
        documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        directoryPath = Path.Combine(documentsPath, "Rio Tinto");
        filePath = Path.Combine(directoryPath, "ScoreData.csv");

        if (score >= 0)
        {
            using (StreamWriter sw = new StreamWriter(filePath, append: true))
            {  
                sw.WriteLine($"{KeyboardManager.employeeName}, {DateTime.Now}, {taskName}, {completed}, {score}"); 
            }

            Debug.LogWarning("RECORD IS BEING UPDATED");
        }
    }

    public void ClearData()
    {
        documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        directoryPath = Path.Combine(documentsPath, "Rio Tinto");
        filePath = Path.Combine(directoryPath, "ScoreData.csv");

        using (StreamWriter sw = new StreamWriter(filePath, append: false))
        {
            sw.WriteLine("User,Date and Time,Task,Completed,Score");
        }

        Debug.Log("CSV file cleared and header written.");
    }
}

