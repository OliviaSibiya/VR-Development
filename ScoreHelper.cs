using System;
using Oculus.Interaction;
using ScoreData;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreHelper : MonoBehaviour
{

    public static ScoreHelper Instance { get; private set; }
    public int restartCount;

    public string employeeName = "";
    private KeyboardManager keyboardManager;
    public TMP_Text placeholderText;

    public GameObject leaveCanvas;
    public GameObject scoreCanvas;
    public GameObject failCanvas;
    public GameObject speedingCanvas;

    [Header("Scripts")]
    public LMVControlMonitor controlMonitor;
    public RCC_CarControllerV3 carController;
    public ScoreTexts textItems;

    [Header("Private_Scripts")]
    public LogitechMechanic logitechMechanic;
    public Conditions condition;
    //public speedDetector speedDetector;
    public RestartScene restartedScene;
    public PDSSystem pdsSystem;
    public LMVControlMonitor lmvControlMonitor;
    public ScoreSaverCSV scoreSave;

    [Header("Ints")]
    public int scoreDeducted = 5;
    public int speeding, collision, stopStreet, momentum, blindSpot, harshBraking, overReving, correctGear;

    private int startedTime;
    private int endedTime;

    [Header("Private Ints")]
    private static int totalSpeed;
    private static int totalCollision;
    private static int totalStopStreet;
    private static int totalMomentum;
    private static int totalBlindSpot;
    private static int totalHarshBraking;
    private static int totalOverReving;
    private static int totalCorrectGear;
    private static int totalScore;

    [Header("Bools")]
    public bool scoreDeduct = false;
    private bool deduct = false;

    [Header("Private bools")]
    public bool speedDeduct = false;
    public bool collisionDeduct = false;
    public bool stopStreetDeduct = false;
    public bool momentumDeduct = false;
    public bool blindSpotDeduct = false;
    public bool harshBrakingDeduct = false;
    public bool overRevDeduct = false;
    public bool correctGearDeduct = false;
    public bool completed;
    public static bool failedOnce;
    public bool started = true;
    public bool restarted;
    public bool leaveCanvasUpdate;
    public bool speedingCanvasUpdate;
    public bool blindSpotUpdate;
    public bool hasCompleted = false;
    public bool activatedScoreCanvas = false;
    
    public float averageScore;

    private void Awake()
    {
        Debug.Log("SCORE HELPER AWAKE");
        // employeeName = PlayerPrefs.GetString("EmployeeName", keyboardManager.employeeName);
        // Debug.Log("Player Name Was Loaded From Previous Scene");
        
    }

    public void Start()
    {
        CurrentScores();
        scoreSave.ClearData();
        started = true;
        scoreSave.UpdateRecord(employeeName, "Start Time", true, 100);
        if (restarted == false)
        {
            restartCount = 0;
        }

        if (restartCount == 0)
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
                LoadData();
                CurrentScores();
            }
            else
            {
                Destroy(gameObject);
            }
        }

        if (restartCount > 0 && failedOnce == true)
        {
            failedOnce = PlayerPrefs.GetInt("FailedOnce",0) == 1;
            PlayerPrefs.GetInt("Collision", totalCollision);
            PlayerPrefs.GetInt("StopStreet", totalStopStreet);
            PlayerPrefs.GetInt("BlindSpot", totalBlindSpot);
            PlayerPrefs.GetInt("CorrectGear", totalCorrectGear);
            speeding = 1000;
            momentum = 100;
            overReving = 1000;
            harshBraking = 1000;
            restarted = true;
            scoreSave.UpdateRecord("User", "Start Time", true, 100);
        }
        ResetFlags();
        employeeName = KeyboardManager.employeeName;
    }

    public void Update()
    {
        if (!leaveCanvasUpdate && leaveCanvas.activeInHierarchy == true)
        {
            if (!activatedScoreCanvas)
            {
                scoreCanvas.SetActive(true);
           // scoreSave.enabled = true;
            //ScoreHolder();
            //scoreSave.UpdateRecord("User", "End Time", true, 0);
                completed = true;
                restartCount = 0;
                leaveCanvasUpdate = true;
                activatedScoreCanvas = true;
            }
            
        }

        if (leaveCanvasUpdate == true && completed == true)
        {
            if (!hasCompleted)
            {
                Completed();
                scoreSave.UpdateRecord("User", "End Time", true, 0);
                hasCompleted = true;
                ResetFlags();
                harshBrakingDeduct = false;
            }
        }

        if (completed == true)
        {
            UpdateScore();
            ResetFlags();
            //ScoreHolder();
        }

        if (!speedingCanvasUpdate && speedingCanvas.activeInHierarchy == true && carController.speed > 70f)
        {
            scoreDeduct = true;
            speedingCanvasUpdate = true;
            Speeding();
        }
        else
        {
            scoreDeduct = false;
            speedDeduct = false;
        }

        GameObject collisionObject = GameObject.FindGameObjectWithTag("fail");

        if (collisionObject && failCanvas.activeInHierarchy == true)
        {
            scoreDeduct = true;
            failedOnce = true;
            PlayerPrefs.SetInt("FailedOnce", 1);
            PlayerPrefs.Save();
            Collisions();
        }
        else
        {
            scoreDeduct = false;
            collisionDeduct = false;
        }
        PlayerPrefs.SetInt("Collision", totalCollision);
        PlayerPrefs.Save();

        GameObject stopStreetObject = GameObject.FindGameObjectWithTag("stoppoint");

        if (stopStreetObject && restartedScene.failedToStop == true && failCanvas.activeInHierarchy == true)
        {
            scoreDeduct = true;
            failedOnce = true;
            PlayerPrefs.SetInt("FailedOnce", 1);
            PlayerPrefs.Save();
            StopStreet();
        }
        else
        {
            scoreDeduct = false;
            stopStreetDeduct = false;
        }
        PlayerPrefs.SetInt("StopStreet", totalStopStreet);
        PlayerPrefs.Save();

        if (!blindSpotUpdate &&logitechMechanic.canHoot == true && logitechMechanic.hornDetector.isInsideHornDetector == false)
        {
            scoreDeduct = true;
            failedOnce = true;
            blindSpotUpdate = true;
            PlayerPrefs.SetInt("FailedOnce", 1);
            PlayerPrefs.Save();
            BlindSpot();
        }
        else
        {
            scoreDeduct = false;
            blindSpotDeduct = false;
        }
        PlayerPrefs.SetInt("BlindSpot", totalBlindSpot);
        PlayerPrefs.Save();

        if (carController.brakeInput >= .7f)
        {
            scoreDeduct = true;
            HarshBraking();
        }
        else
        {
            scoreDeduct = false;
            harshBrakingDeduct = false;
        }

        if (lmvControlMonitor.revWarning.activeInHierarchy == true)
        {
            scoreDeduct = true;
            OverReving();    
        }
        else
        {
            scoreDeduct = false;
            overRevDeduct = false;
        }

        GameObject lowRange = GameObject.FindGameObjectWithTag("Low Range");
        GameObject highRange = GameObject.FindGameObjectWithTag("High Range");

        if (lowRange && carController.currentGear != 3 && controlMonitor.range != 3 && failCanvas.activeInHierarchy == true || highRange && carController.currentGear != 1 && controlMonitor.range != 2 && failCanvas.activeInHierarchy == true)
        {
            scoreDeduct = true;
            failedOnce = true;
            PlayerPrefs.SetInt("FailedOnce", 1);
            PlayerPrefs.Save();
            CorrectGearAndRange();
        }
        else
        {
            scoreDeduct = false;
            correctGearDeduct = false;
        }
        PlayerPrefs.SetInt("CorrectGear", totalCorrectGear);
        PlayerPrefs.Save();

    }

    private void Speeding() // This is done
    {
        if (scoreDeduct)
        {
            DeductScore(scoreDeducted, ref speeding, ref speedDeduct);
            Debug.LogWarning("DEDUCT SPEED");
        }

        textItems.speedingScore.text = speeding.ToString();

        if (speeding <= 0) // To test this out
        {
            textItems.speedingScore.text = "Failed";
            speeding = 0;
        }
    }

    private void Collisions() // Figure out how to keep detection of collision
    {
        if (scoreDeduct)
        {
            DeductScore(scoreDeducted, ref collision, ref collisionDeduct);
            Debug.LogWarning("DEDUCT COLLISION");
        }

        textItems.collisionScore.text = collision.ToString();

        if (collision <= 0) // To test this out
        {
            textItems.collisionScore.text = "Failed";
            collision = 0;
            
        }
    }

    private void StopStreet()
    {
        if (scoreDeduct)
        {
            DeductScore(scoreDeducted, ref stopStreet, ref stopStreetDeduct);
            Debug.LogWarning("DEDUCT STOP STREET");
        }

        textItems.stopStreetScore.text = stopStreet.ToString();

        if (stopStreet <= 0) // To test this out
        {
            textItems.stopStreetScore.text = "Failed";
            stopStreet = 0;
        }
    }

    private void MomentumGained() //How will momentum gained be detected??
    {
        float playerSpeed = carController.rigid.velocity.magnitude;
        float thresholdSpeed = 20f;

        if (playerSpeed < thresholdSpeed)
        {
            scoreDeduct = true;
        }
        else
        {
            scoreDeduct = false;
            momentumDeduct = false;
        }

        if (scoreDeduct)
        {
            DeductScore(scoreDeducted, ref momentum, ref momentumDeduct);
            Debug.LogWarning("DEDUCT MOMENTUM");
        }

        textItems.momentumScore.text = momentum.ToString();

        if (momentum <= 0) // To test this out
        {
            textItems.momentumScore.text = "Failed";
            momentum = 0;
        }
    }

    private void BlindSpot()
    {
        if (scoreDeduct)
        {
            DeductScore(scoreDeducted, ref blindSpot, ref blindSpotDeduct);
            Debug.LogWarning("DEDUCT BLINDSPOT");
        }

        textItems.blindSpotScore.text = blindSpot.ToString();

        if (blindSpot <= 0) // To test this out
        {
            textItems.blindSpotScore.text = "Failed";
            blindSpot = 0;
        }

    }

    public void HarshBraking()
    {
        if (scoreDeduct)
        {
            DeductScore(scoreDeducted, ref harshBraking, ref harshBrakingDeduct);
            Debug.LogWarning("DEDUCT HARSH BRAKING");
        }

        textItems.harshBrakingScore.text = harshBraking.ToString();

        if (harshBraking <= 0) // To test this out
        {
            textItems.harshBrakingScore.text = "Failed";
            harshBraking = 0;
        }
    }

    private void OverReving()
    { //Have this detect when the gameobject goes on and off
        if (scoreDeduct)
        {
            DeductScore(scoreDeducted, ref overReving, ref overRevDeduct);
            Debug.LogWarning("DEDUCT OVER REVING");
        }
        else if (overReving <= 0)
        {
            scoreSave.AddRecord(employeeName,"OverReving", overReving);
        }

        textItems.overRevingScore.text = overReving.ToString();

        if (overReving < 0) // To test this out
        {
            textItems.overRevingScore.text = "Failed";
            overReving = 0;
        }
    }

    private void CorrectGearAndRange()
    {
        if (scoreDeduct)
        {
            DeductScore(scoreDeducted, ref correctGear, ref correctGearDeduct);
            Debug.LogWarning("DEDUCT CORRECT GEAR");
        }

        textItems.correctGearScore.text = correctGear.ToString();

        if (correctGear <= 0) // To test this out
        {
            textItems.correctGearScore.text = "Failed";
            correctGear = 0;
        }

    }

    public void CurrentScores()
    {
        speeding = 1000;
        collision = 100;
        stopStreet = 100;
        momentum = 100;
        blindSpot = 100;
        harshBraking = 1000;
        correctGear = 100;
        overReving = 1000;

        totalSpeed = speeding;
        textItems.speedingScore.text = speeding.ToString();

        totalMomentum = momentum;
        textItems.momentumScore.text = momentum.ToString();

        totalHarshBraking = harshBraking;
        textItems.harshBrakingScore.text = harshBraking.ToString();

        totalOverReving = overReving;
        textItems.overRevingScore.text = overReving.ToString();

        totalCollision = collision;
        textItems.collisionScore.text = collision.ToString();

        totalStopStreet = stopStreet;
        textItems.stopStreetScore.text = stopStreet.ToString();

        totalBlindSpot = blindSpot;
        textItems.blindSpotScore.text = blindSpot.ToString();

        totalCorrectGear = correctGear;
        textItems.correctGearScore.text = correctGear.ToString();
        
        if (failedOnce)
        {
            collision =  PlayerPrefs.GetInt("Collision", collision);
            textItems.collisionScore.text = collision.ToString();

            stopStreet = PlayerPrefs.GetInt("StopStreet", stopStreet);
            textItems.stopStreetScore.text = stopStreet.ToString();

            blindSpot = PlayerPrefs.GetInt("BlindSpot", blindSpot);
            textItems.blindSpotScore.text = blindSpot.ToString();

            correctGear = PlayerPrefs.GetInt("CorrectGear", correctGear);
            textItems.correctGearScore.text = correctGear.ToString();
        }

    }

    public void DeductScore(int amount, ref int scoreVariable, ref bool deduct)
    {
        if (!deduct)
        {
            scoreVariable -= amount;
            deduct = true;
            UpdateScore();
        }
        
    }

    public void ScoreHolder()
    {
        // 1. Have this track the previous score before the player has restarted the scene
        scoreSave.AddRecord(employeeName,"Speeding", speeding);
        scoreSave.AddRecord(employeeName,"OverReving", overReving);
        scoreSave.AddRecord(employeeName,"HarshBraking", harshBraking);
        scoreSave.AddRecord(employeeName,"CorrectGear", correctGear);
        scoreSave.AddRecord(employeeName,"BlindSpot", blindSpot);
        scoreSave.AddRecord(employeeName,"Momentum Gained", momentum);
        scoreSave.AddRecord(employeeName,"Collisions", collision);
        scoreSave.AddRecord(employeeName,"Stop Street", stopStreet);
        scoreSave.AddRecord(employeeName,"Restarted Scene", restartCount);
    }

    private void UpdateScore()
    {
        if (scoreDeducted == 5 && collisionDeduct == true) 
        {
            scoreSave.UpdateRecord(employeeName, "Collision", true, collision);
            Debug.LogWarning("COLLISION2");
        }

        if (scoreDeducted == 5 && overRevDeduct == true)
        {
            scoreSave.UpdateRecord(employeeName, "OverReving", true, overReving);
            Debug.LogWarning("OVER REVING2");
        }

        if (scoreDeducted == 5 && correctGearDeduct == true)
        {
            scoreSave.UpdateRecord(employeeName, "CorrectGear", true, correctGear);
            Debug.LogWarning("CORRECT GEAR2");
        }

        if (scoreDeducted == 5 && blindSpotDeduct == true)
        {
            scoreSave.UpdateRecord(employeeName, "BlindSpot", true, blindSpot);
            Debug.LogWarning("BLIND SPOT2");
            ResetFlags();
        }

        if (scoreDeducted == 5 && momentumDeduct == true)
        {
            scoreSave.UpdateRecord(employeeName, "Momentum Gained", true, momentum);
            Debug.LogWarning("MOMENTUM2");
        }

        if (scoreDeducted == 5 && stopStreetDeduct == true)
        {
            scoreSave.UpdateRecord(employeeName, "Stop Street", true, stopStreet);
            Debug.LogWarning("STOP STREET2");
        }   

        if (scoreDeducted == 5 && harshBrakingDeduct == true)
        {
            scoreSave.UpdateRecord(employeeName, "HarshBraking", true, harshBraking);
            Debug.LogWarning("HARSH BRAKING2");
        }

        if (scoreDeducted == 5 && speedDeduct == true)
        {
            scoreSave.UpdateRecord(employeeName, "Speeding", true, speeding);
            Debug.LogWarning("SPEEDING2");
            ResetFlags();
        }
    }

    public void SaveData()
    {
        PlayerPrefs.SetInt("RestartCount", restartCount);
        PlayerPrefs.SetInt("Collision", collision);
        PlayerPrefs.SetInt("StopStreet", stopStreet);
        PlayerPrefs.SetInt("BlindSpot", blindSpot);
        PlayerPrefs.SetInt("CorrectGear", correctGear);
        PlayerPrefs.SetInt("FailedOnce", failedOnce ? 1 : 0);
        PlayerPrefs.Save();
        OnApplicationQuit();
    }

    public void LoadData()
    {
        if (PlayerPrefs.HasKey("RestartCount"))
        {
            restartCount = PlayerPrefs.GetInt("RestartCount");
            //scoreSave.AddRecord("Restarted Scene", restartCount);
            textItems.restartedScene.text = restartCount.ToString();
        }

        totalCollision = PlayerPrefs.GetInt("Collision", collision);
        totalStopStreet = PlayerPrefs.GetInt("StopStreet", stopStreet);
        totalBlindSpot = PlayerPrefs.GetInt("BlindSpot", blindSpot);
        totalCorrectGear = PlayerPrefs.GetInt("CorrectGear", correctGear);

        textItems.collisionScore.text = totalCollision.ToString();
        textItems.stopStreetScore.text = totalStopStreet.ToString();
        textItems.blindSpotScore.text = totalBlindSpot.ToString();
        textItems.correctGearScore.text = totalCorrectGear.ToString();
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("RestartCount", restartCount);
        PlayerPrefs.Save();
    }

    void ResetFlags()
    {
        leaveCanvasUpdate = false;
        speedingCanvasUpdate = false;
        blindSpotUpdate = false;
    }

    public void Completed()
    {
        totalScore = speeding + collision + stopStreet + momentum + blindSpot + harshBraking + overReving + correctGear;
        averageScore = (totalScore / 800.0f) * 100.0f;
        ScoreHolder();
        scoreSave.enabled = true;
    }
}
