using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandDunesScenarioManager : MonoBehaviour
{
    public NewFlatTyreScenario tyreScenario;
    public NewFireScenario fireScenario;
    public NewBrakeScenario brakeScenario;
    public StuckInSand stuckScenario;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (tyreScenario.manager.passed == true || tyreScenario.manager.failed == true)
        {
            tyreScenario.flatWheel.radius = 0.36f;
            tyreScenario.carController.driftingNow = false;
        }

        if (fireScenario.manager.passed == true || fireScenario.manager.failed == true)
        {
            fireScenario.particleObject.SetActive(false);
        }

        if (brakeScenario.scenarioManager.passed == true || brakeScenario.scenarioManager.failed == true)
        {
            for (int i = 0; i < brakeScenario.wheels.Length; i++)
            {
                if (brakeScenario.wheels[i])
                {
                    brakeScenario.wheels[i].canBrake = true;
                    brakeScenario.wheels[i].canPower = true;
                    brakeScenario.wheels[i].brakingMultiplier = 1;
                }
            }
        }

        if (stuckScenario.scenarioManager.passed == true || stuckScenario.scenarioManager.failed == true)
        {
            stuckScenario.rb.position = new Vector3(846.8f, 39.162f, 2294.8f);
            stuckScenario.rb.constraints = RigidbodyConstraints.None;
        }
    }
}
