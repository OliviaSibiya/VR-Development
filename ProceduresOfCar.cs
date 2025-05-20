using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduresOfCar : MonoBehaviour
{
    public GameObject playerCar;

    public RCC_CarControllerV3 carControl;
    public LogitechSteeringWheel logiMan;
    public LogitechMechanic logiMech;
   // public ScoreManager scoreManager;
    public LogitechAutomatic logiAuto;
    public bool proceduresCompleted;

    public float currentEngineHeat;
   // public bool proceduresCompleted;
    //float brakeInput = 10;

    // Start is called before the first frame update
    void Start()
    {
        carControl = GetComponent<RCC_CarControllerV3>();
        logiMan = GetComponent<LogitechSteeringWheel>();
        logiMech = GetComponent<LogitechMechanic>();
    }

    // Update is called once per frame
    void Update()
    {
        //currentEngineHeat = carControl.engineHeat;
        BrakePump();
        BreakFailure();
    }

    public int numberOfPumps = 0;
    public bool brakeIsPressed = false;
    public  int currentGear = 0;
    public int lowerGear ;

    public void BrakePump()
    {
        if (logiMech.BreakInput > 0.8f && !brakeIsPressed)
        {
            brakeIsPressed = true;
            numberOfPumps += 1;
        }
        else if(logiMech.BreakInput < 0.2f && brakeIsPressed)
        {
            brakeIsPressed = false;
        }

        if (logiMech.previousGear - logiMech.CurrentGear == 1 && numberOfPumps >= 6)
        {
            Debug.Log("Shifted down from: " + logiMech.previousGear + " to " + logiMech.CurrentGear);
            if (logiMech.CurrentGear == 0)
            {
                Debug.Log("Procedure Complete");
                 proceduresCompleted = true;
                //scoreManager.Finished();
                 proceduresCompleted = true;
            }
            else
            {
                numberOfPumps = 0;
                logiMech.previousGear = 0;
            }
        }

        if (logiAuto.BreakInput > 0.8f && !brakeIsPressed)
        {
            brakeIsPressed = true;
            numberOfPumps += 1;
            //scoreManager.Finished();
        }
        else if (logiAuto.BreakInput < 0.2f && brakeIsPressed)
        {
            brakeIsPressed = false;
            //scoreManager.Finished();
        }
    }

    public void EngineFaliure()
    {
        carControl.useEngineHeat = true;
        carControl.engineHeat = carControl.engineHeat * carControl.engineHeat;
    }

    public void BreakFailure()
    {
        if (logiMech.ClutchInput >= 0.5 && logiMech.BreakInput >= 0.5)
        {
            Debug.Log("Clutch and brake was activated");
        }
        //LogitechGSDK.LogiIsPlaying(0, LogitechGSDK.LOGI_FORCE_BUMPY_ROAD);
        //LogitechGSDK.LogiPlayBumpyRoadEffect(0, 20);
    }

}
