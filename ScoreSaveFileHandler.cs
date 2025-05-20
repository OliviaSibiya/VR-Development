using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScoreData;
using System.IO;
using System;

public class ScoreSaveFileHandler : MonoBehaviour
{
    static string fileName = "RioTintoScoreData.csv";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static List<ScoreDataHandler.ScoreData> GetScoreData()
    {
        List<ScoreDataHandler.ScoreData> scoreDataList = new List<ScoreDataHandler.ScoreData>();
        string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        string directoryPath = Path.Combine(documentsPath, "Rio Tinto");
        string filePath = Path.Combine(directoryPath, fileName);
        FileStream fs = File.Open(filePath, FileMode.Open, FileAccess.Read);
        StreamReader reader = new StreamReader(fs);

        if (File.Exists(filePath))
        {
            using (reader)
            {
                string line = reader.ReadLine();
                while(line != null)
                {
                    string[] data = line.Split('#');
                    scoreDataList.Add(new ScoreDataHandler.ScoreData(data[0], bool.Parse(data[1]), int.Parse(data[2]), float.Parse(data[3])));
                    line = reader.ReadLine();
                }
            }
        }
        else
        {
            Debug.Log("File does not exist");
        }

        return scoreDataList;
    }
}

