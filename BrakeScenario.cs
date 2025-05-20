using UnityEngine;
using UnityEngine.InputSystem;
//using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class BrakeScenario : MonoBehaviour
{
    public static bool brakeScenario;
    // Start is called before the first frame update

    public LogitechMechanic logiMech;
    public RCC_CarControllerV3 carControl;
    public LogitechSteeringWheel logiWheel;
    public ProceduresOfCar procedures;

    public WheelCollider[] wheelColliders;
    public RCC_WheelCollider[] wheelCollider;

    private int counter = 0;
    private float timer = 0f;
    private float countDown = 10f;
    private float incrementInterval = 1f;
    //public TextMeshProUGUI timeText;
    //public GameObject UIBrake;

    public ScenarioManager manager;
    public RCC_CarControllerV3 carController;

    //---------LOGITECH CONFIGURE---------------//
    //INDEX NAMES
    int a, b, c, d;
    //---------------end of logitech-----------//


    void Start()
    {
        //---------LOGITECH CONFIGURE---------------//
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


        brakeScenario = false;
        //UIBrake.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (LogitechGSDK.LogiUpdate() && LogitechGSDK.LogiIsConnected(a))
        {
            LogitechGSDK.DIJOYSTATE2ENGINES rec;
            rec = LogitechGSDK.LogiGetStateUnity(a);

            LogiButton(rec);
        }
    }

    public void LogiButton(LogitechGSDK.DIJOYSTATE2ENGINES rec)
    {
        for (int i = 0; i < 128; i++)
        {
            if (rec.rgbButtons[i] == 128)
            {
                if (i == 3)
                {
                    carControl.brakeTorque = 4000;
                    carControl.brakeInput = 4000;
                    this.gameObject.SetActive(false);

                    for (int j = 0; j < wheelCollider.Length; j++)
                    {
                        if (wheelCollider[i])
                        {
                            wheelCollider[i].canBrake = true;
                            wheelCollider[i].brakingMultiplier = 0.5f;
                            wheelCollider[i].canPower = true;
                        }
                    }
                }
            }
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            brakeScenario = true;
            //UIBrake.gameObject.SetActive(true);
            BrakesFailed();
        }

        //if (other.CompareTag("Player"))
        //{

        //}

        Debug.LogWarning("The brake scenario is active");
    }

    private void OnTriggerStay(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            //UIBrake.gameObject.SetActive(true);
            brakeScenario = true;
            timer += Time.deltaTime;
            if (timer >= incrementInterval)
            {

                //timeText.text = countDown-- + "s";
                counter++;
                timer = 0f;

                if (countDown < 0)
                {
                    timer = 0f;
                    countDown = 0f;
                    counter = 0;
                }
            }

            if (carController.speed < 5f)
            {
                brakeScenario = false;
                BrakesFailed();
                //manager.passed = true;
                logiMech.BreakInput = 1;
                carControl.brakeTorque = 1;
                carControl.brakeInput = 1;
            }

            carControl.brakeTorque = 0;
            carControl.brakeInput = 0;
            BrakesFailed();
        }
    }
    private void OnTriggerExit(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            //UIBrake.gameObject.SetActive(false);
            brakeScenario = false;
        }

        if (carController.speed > 5f)
        {
            brakeScenario = false;
            BrakesFailed();
            //manager.failed = true;
            logiMech.BreakInput = 1;
            carControl.brakeTorque = 1;
            carControl.brakeInput = 1;
        }
        logiMech.BreakInput = 1;
    }

    public void BrakesFailed()
    {
        if (brakeScenario == true)
        {
            for (int i = 0; i < wheelCollider.Length; i++)
            {
                if (wheelCollider[i])
                {
                    wheelCollider[i].canBrake = false;
                    wheelCollider[i].brakingMultiplier = 0;
                    wheelCollider[i].canPower = false;
                }
            }
        }
        else if (brakeScenario == false)
        {
            for (int i = 0; i < wheelCollider.Length; i++)
            {
                if (wheelCollider[i])
                {
                    wheelCollider[i].canBrake = true;
                    wheelCollider[i].brakingMultiplier = 0.5f;
                    wheelCollider[i].canPower = true;
                }
            }
        }
    }
}
