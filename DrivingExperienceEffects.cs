using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class DrivingExperienceEffects: MonoBehaviour
{
    //Head Nodding
    public GameObject CameraNeck;
    public float Speed = 0.1f;
    public float BlinkSpeed = 0.1f;
    public float AngleA = 0f, AngleB = 0f;
    public float MaxWeight = 1f;

    //Effects of Fatigue
    public GameObject FatigueVol, DUIVol;
    public bool LerpBackAndForth = false;
    public float LerpDuration;

    private float TimePassed = 0f;
    private bool ShouldLerp = true;
    public AudioSource YawnAudio;
    public ScoreManager ScoreManager;

    public RCC_CarControllerV3 carControl;
    public bool testHasStarted = false;

    private void Update()
    {
       // Debug.Log("Car Speed: " + carControl.speed);
        if (carControl.speed < 0.5f && testHasStarted == true)
        {
            Debug.Log("Before the function");
            stoppedCar();
            Debug.Log("After the function");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Start Head Nodding")
        {
            Debug.Log("Heading Nodding");
            NodHead();
            testHasStarted = true;
        }
        else if (other.tag == "Start Fatigue")
        {
            Debug.Log("Fatigue");
            Fatigue();
            testHasStarted = true;
        }
        else if (other.tag == "Start Impaired Vision")
        {
            Debug.Log("Impaired Vision");
            ImparedVision();
            testHasStarted = true;
        }
        else if (other.tag == "Start Slow Reaction Time")
        {
            Debug.Log("Slow Reaction");
            SlowReactionTime();
            testHasStarted = true;
        }
        else if (other.tag == "Start Yawning")
        {
            Debug.Log("Yawning");
            YawnAudio.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
       //Fatigue Scenario
        if (other.tag == "Start Head Nodding" || other.tag == "Start Fatigue")
        {
            
            FatigueVol.SetActive(false);
            CameraNeck.transform.localEulerAngles = new Vector3(0f, CameraNeck.transform.localEulerAngles.y, 0f);
            FatigueVol.GetComponent<Volume>().weight = 0f;

            //if (other.tag == "Start Fatigue")
            //    //ScoreManager.FatigueDidNotStopScore = 50;
            //else if (other.tag == "Start Head Nodding")
            //{
            //    //ScoreManager.FatigueDidNotStopScore = 100;
            //}
        }
        
        //DUI Scenario
        if(other.tag == "Start Impaired Vision" || other.tag == "Start Slow Reaction Time")
        {
            DUIVol.GetComponent<Volume>().weight = 0f;
            DUIVol.SetActive(false);
            Time.timeScale = 1f;

            //if (other.tag == "Start Impaired Vision")
            //   // ScoreManager.DUIDidNotStopScore = 50;
            //else if (other.tag == "Start Slow Reaction Time")
            //{
            //    //ScoreManager.DUIDidNotStopScore = 100;
            //}
        }
    }

    private void NodHead()
    {
            float t = Mathf.PingPong(Time.time * Speed, 1f);

            float CurrentAngle = Mathf.Lerp(AngleA, AngleB, t);
            CameraNeck.transform.localEulerAngles = new Vector3(CurrentAngle, CameraNeck.transform.localEulerAngles.y, 0f);
        Debug.Log("Rot y: " + CameraNeck.transform.localEulerAngles.y) ;

        FatigueVol.SetActive(true);
            FatigueVol.GetComponent<Volume>().weight = CurrentAngle / AngleB;
    }

    private void Fatigue()
    {
        if (ShouldLerp)
        {
            TimePassed += Time.deltaTime * BlinkSpeed;
            int counter = (int)TimePassed / (int)LerpDuration;

            ShouldLerp = (counter == 1) ? LerpBackAndForth : ShouldLerp;
            FatigueVol.SetActive(ShouldLerp);

            float t = Mathf.PingPong(TimePassed, LerpDuration) / LerpDuration;
            FatigueVol.GetComponent<Volume>().weight = Mathf.Lerp(0f, MaxWeight, t);

            //LogitechGSDK.LogiIsPlaying(0, LogitechGSDK.LOGI_FORCE_SPRING);
            //LogitechGSDK.LogiPlaySpringForce(0, 50, 50, 50);

            LogitechGSDK.LogiIsPlaying(0, LogitechGSDK.LOGI_FORCE_SOFTSTOP);
            LogitechGSDK.LogiPlaySoftstopForce(0, 20);
        }
    }

    private void ImparedVision()
    {
        if (ShouldLerp)
        {
            TimePassed += Time.deltaTime;
            int counter = (int)TimePassed / (int)LerpDuration;

            ShouldLerp = (counter == 1) ? LerpBackAndForth : ShouldLerp;
            DUIVol.SetActive(ShouldLerp);

            float t = Mathf.PingPong(TimePassed, LerpDuration) / LerpDuration;
            DUIVol.GetComponent<Volume>().weight = Mathf.Lerp(0f, 1f, t);

            LogitechGSDK.LogiIsPlaying(0, LogitechGSDK.LOGI_FORCE_SLIPPERY_ROAD);
            LogitechGSDK.LogiPlaySlipperyRoadEffect(0, 30);
        }
    }

    private void SlowReactionTime()
    {
        DUIVol.SetActive(true);
        DUIVol.GetComponent<Volume>().weight = 0.5f;
        Time.timeScale = 0.5f;

        LogitechGSDK.LogiIsPlaying(0, LogitechGSDK.LOGI_FORCE_SLIPPERY_ROAD);
        LogitechGSDK.LogiPlaySlipperyRoadEffect(0, 20);
    }

    private void stoppedCar()
    {
        CameraNeck.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
        DUIVol.SetActive(false);
        FatigueVol.SetActive(false);
        //ScoreManager.Finished();
    }
}
