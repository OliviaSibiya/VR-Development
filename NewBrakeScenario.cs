using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBrakeScenario : MonoBehaviour
{
    public RCC_WheelCollider[] wheels;
    public RCC_CarControllerV3 carControl;
    public NewScenario scenarioManager;
    public LogitechMechanic logitechMechanic;

    public bool completedProcedure;
    public bool brakesPressed = false;
    public bool brakesOff;

    public int currentGear;
    public int numberOfPumps;
    public int lowerGear;

    // Start is called before the first frame update
    void Start()
    {
        // scenarioManager.failed = false;
        // scenarioManager.passed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (completedProcedure)
        {
            scenarioManager.passed = true;
            scenarioManager.UIPopup();

            if (scenarioManager.scenarioItems.activeInHierarchy == false)
            {
                for (int i = 0; i < wheels.Length; i++)
                {
                    if (wheels[i])
                    {
                        wheels[i].canBrake = true;
                        wheels[i].canPower = true;
                        wheels[i].brakingMultiplier = 1;
                    }
                }
            }
        }
        else if (!completedProcedure)
        {
            scenarioManager.failed = true;

            if (scenarioManager.scenarioItems.activeInHierarchy == false)
            {
                for (int i = 0; i < wheels.Length; i++)
                {
                    if (wheels[i])
                    {
                        wheels[i].canBrake = true;
                        wheels[i].canPower = true;
                        wheels[i].brakingMultiplier = 1;
                    }
                }
            }
        }

        if (brakesOff == true)
        {
            PumpingBrakes();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            for (int i = 0; i < wheels.Length; i++)
            {
                if (wheels[i])
                {
                    wheels[i].canBrake = false;
                    wheels[i].canPower = false;
                    wheels[i].brakingMultiplier = 0;
                }
            }
            Debug.Log("BRAKE FAILURE HAS BEGUN");

            brakesOff = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (scenarioManager.passed || scenarioManager.failed)
            {
                for (int i = 0; i < wheels.Length; i++)
                {
                    if (wheels[i])
                    {
                        wheels[i].canBrake = true;
                        wheels[i].canPower = true;
                        wheels[i].brakingMultiplier = 1;
                    }
                }
                Debug.Log("BRAKE FAILURE HAS ENDED OUTSIDE COLLIDER");
            }
        }
    }

    public void PumpingBrakes()
    {
        scenarioManager.failed = false;
        if (logitechMechanic.controller_Inputs.brakeInput > 0.8f && !brakesPressed)
        {
            brakesPressed = true;
            numberOfPumps += 1;
        }
        else if (logitechMechanic.controller_Inputs.brakeInput < 0.2f && brakesPressed)
        {
            brakesPressed = false;
        }

        if (logitechMechanic.controller_Inputs.gearInput == 1 && numberOfPumps > 3)
        {
            scenarioManager.passed = true;
            completedProcedure = true;
            brakesOff = false;
            Debug.Log("PROCEDURE MUST BE COMPLETE");
        }
    }
}
