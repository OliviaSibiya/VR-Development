using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class NewScenario : MonoBehaviour
{
    public RCC_CarControllerV3 carControl;
    public NewFlatTyreScenario tyreScenario;
    public StuckInSand sandScenario;
    public NewBrakeScenario brakeScenario;

    public GameObject uiCanvas;
    public GameObject scenarioItems;
    public GameObject fireParticle;

    public bool passed = false;
    public bool failed = false;

    public TMP_Text outcomeText;
    public TMP_Text messageText;

    //---------LOGITECH CONFIGURE---------------//
    //INDEX NAMES
    int a, b, c, d;
    //---------------end of logitech-----------//

    // Start is called before the first frame update
    void Start()
    {  //---------LOGITECH CONFIGURE---------------//
        //Steering Wheel
        if (Joystick.all[0].name == "Logitech G29 Driving Force Racing Wheel")
        {
            a = 0;
        }
        else if (Joystick.all[1].name == "Logitech G29 Driving Force Racing Wheel")
        {
            a = 1;
        }
        else if (Joystick.all[2].name == "Logitech G29 Driving Force Racing Wheel")
        {
            a = 2;
        }
        else if (Joystick.all[3].name == "Logitech G29 Driving Force Racing Wheel")
        {
            a = 3;
        }
        ////Extreme 3D PRO 
        //if (Joystick.all[0].name == "Logitech Extreme 3D pro")
        //{
        //    b = 0;
        //}
        //else if (Joystick.all[1].name == "Logitech Extreme 3D pro")
        //{
        //    b = 1;
        //}
        //else if (Joystick.all[2].name == "Logitech Extreme 3D pro")
        //{
        //    b = 2;
        //}
        //else if (Joystick.all[3].name == "Logitech Extreme 3D pro")
        //{
        //    b = 3;
        //}

        ////Extreme 3D PRO 1
        //if (Joystick.all[0].name == "Logitech Extreme 3D pro1")
        //{
        //    c = 0;
        //}
        //else if (Joystick.all[1].name == "Logitech Extreme 3D pro1")
        //{
        //    c = 1;
        //}
        //else if (Joystick.all[2].name == "Logitech Extreme 3D pro1")
        //{
        //    c = 2;
        //}
        //else if (Joystick.all[3].name == "Logitech Extreme 3D pro1")
        //{
        //    c = 3;
        //}

        ////HandBrake
        //if (Joystick.all[0].name == "Logitech Logitech Attack 3")
        //{
        //    d = 0;
        //}
        //else if (Joystick.all[1].name == "Logitech Logitech Attack 3")
        //{
        //    d = 1;
        //}
        //else if (Joystick.all[2].name == "Logitech Logitech Attack 3")
        //{
        //    d = 2;
        //}
        //else if (Joystick.all[3].name == "Logitech Logitech Attack 3")
        //{
        //    d = 3;
        //}
        //---------------end of logitech-----------//

        fireParticle.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (LogitechGSDK.LogiUpdate() && LogitechGSDK.LogiIsConnected(a))
        {
            LogitechGSDK.LogiSteeringInitialize(true);
            LogitechGSDK.DIJOYSTATE2ENGINES rec;
            rec = LogitechGSDK.LogiGetStateUnity(a);

            Button(rec);
        }

        if (Input.GetButton("Fire1"))
        {
            uiCanvas.SetActive(false);
            Time.timeScale = 1;
            scenarioItems.SetActive(false);
            sandScenario.uiPopup.SetActive(false);
            fireParticle.SetActive(false);
            tyreScenario.flatWheel.radius = 0.36f;
            carControl.brakeInput = 1;
            Debug.Log("FIRE 1");
        }
    }

    public void UIPopup()
    {
        if (passed == true)
        {
            outcomeText.text = "Congratulations";
            messageText.text = "You were able to observe your surroundings and stopped successfully. Press the triangle on the steering wheel to continue";
            uiCanvas.SetActive(true);
            Time.timeScale = 0;
        }

        if (failed == true)
        {
            outcomeText.text = "Unfortunatly,";
            messageText.text = "You are no longer able to observe your surroundings. Press the triangle on the steering wheel to continue.";
            uiCanvas.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void Button(LogitechGSDK.DIJOYSTATE2ENGINES rec)
    {
        for (int i = 0; i < 128; i++)
        {
            if (rec.rgbButtons[i] == 128)
            {
                if (i == 3)
                {
                    uiCanvas.SetActive(false);
                    Time.timeScale = 1;
                    scenarioItems.SetActive(false);
                    sandScenario.uiPopup.SetActive(false);
                    fireParticle.SetActive(false);
                    tyreScenario.flatWheel.radius = 0.4f;
                    carControl.brakeInput = 1;
                    Debug.Log("Button3");

                    for (int j = 0; j < brakeScenario.wheels.Length; j++)
                    {
                        if (brakeScenario.wheels[j])
                        {
                            brakeScenario.wheels[j].canBrake = true;
                            brakeScenario.wheels[j].canPower = true;
                            brakeScenario.wheels[j].brakingMultiplier = 1;
                        }
                    }

                }
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && carControl.speed < 4)
        {
            passed = true;
            UIPopup();
            if (brakeScenario.completedProcedure == true)
            {
                passed = true;
                UIPopup();
            }
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && carControl.speed > 4)
        {
            failed = true;
            UIPopup();
        }

        if (other.CompareTag("Player") && carControl.speed > 4 && brakeScenario.completedProcedure == true)
        {
            failed = false;
            UIPopup();
        }
    }
}
