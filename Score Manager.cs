using UnityEngine;
using System;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;

public class ScoreManager : MonoBehaviour
{
   private string connectionString = "Server=localhost;Database=myDatabase;Trusted_Connection=True;";

   public void AddRecord(string taskName, int score, bool useDatabase = false)
   {
        if (useDatabase)
        {
            AddRecordToDatabase(taskName, score);
        }
        else
        {
            AddRecordToCsv(taskName, score);
        }
   }

   private void AddRecordToCsv(string taskName, int score)
   {
        string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        string directoryPath = Path.Combine(documentsPath, "Rio Tinto");
        string filePath = Path.Combine(directoryPath, "ScoreData.csv");

        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
            //Debug.Log($"Directory created at: {directoryPath}");
        }

        bool fileExists = File.Exists(filePath);
        using (StreamWriter sw = new StreamWriter(filePath, append: true))
            {
                sw.WriteLine("User, Date and Time, Task, Completed, Score");
                //Debug.Log(sw.ToString() + directoryPath + filePath);
            }
            using (StreamWriter sw = new StreamWriter(filePath, append: true))
            {
                sw.WriteLine("User" + "," + DateTime.Now.ToString() + "," + taskName + "," + true + "," + score);
            }
   }

   public void AddRecordToDatabase(string taskName, int score)
   {
        using (var connection = new SqlConnection(connectionString))
        {
            connection.Open();

            var command = new SqlCommand("INSERT INTO TaskRecords (User, DateTime, Task, Completed, Score) VALUES (@User, @DateTime, @Task, @Completed, @Score)", connection);
            command.Parameters.AddWithValue("@User", "User");
            command.Parameters.AddWithValue("@DateTime", DateTime.Now);
            command.Parameters.AddWithValue("@Task", taskName);
            command.Parameters.AddWithValue("@Completed", true);
            command.Parameters.AddWithValue("@Score", score);

            command.ExecuteNonQuery();
        }
   }

   //public void UpdateRecord()
}
