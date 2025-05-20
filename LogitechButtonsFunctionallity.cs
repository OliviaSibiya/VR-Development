using UnityEngine;
using UnityEngine.InputSystem;

public class LogitechButtonsFunctionallity : MonoBehaviour
{
    public InputActionAsset actionAsset;

    public InputAction normalRangeAction;
    public InputAction highRangeAction;
    public InputAction lowRangeAction;
    public InputAction middleButtonAction;

    [SerializeField] private InputActionReference middleKnob;

    public bool middleKnobState;

    public bool leftTurnOn;
    public bool rightTurnOn;
    public bool middleButtonOn;
    public bool highRangeOn;
    public bool lowRangeOn;
    public bool normalRangeOn;

    public bool turnedROnce;
    public bool turnedRTwice;
    public bool turnedLOnce;
    public bool turnedLTwice;

    public LMVControlMonitor controlMonitor;

    private void OnEnable()
    {
        middleKnob.action.Enable();
    }

    private void OnDisable()
    {
        middleKnob.action.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        normalRangeAction = actionAsset.FindAction("NormalRange");
        normalRangeAction.Enable();
        normalRangeAction.performed += ctx => NormalRangeSelected(engaged: true);

        highRangeAction = actionAsset.FindAction("HighRange");
        highRangeAction.Enable();
        highRangeAction.performed += ctx => HighRangeSelected(engaged: true);

        lowRangeAction = actionAsset.FindAction("LowRange");
        lowRangeAction.Enable();
        lowRangeAction.performed += ctx => LowRangeSelector(engaged: true);

        middleButtonAction = actionAsset.FindAction("MiddleButton");
        middleButtonAction.Enable();
        highRangeAction.performed += ctx => MiddleButtonSelected(engaged: true);

    }
    // Update is called once per frame
    void Update()
    {
        middleKnobState = middleKnob.action.ReadValue<float>() == 1;

        if (middleKnobState)
        {
            middleButtonOn = true;
            Debug.LogWarning("Middle Knobe works");
        }
        else
        {
            middleButtonOn = false;
            Debug.LogWarning("Middle button off");
        }

        //if (controlMonitor.currentRange == 1 && controlMonitor.driveMode == LMVControlMonitor.DriveModes.modeNormal && controlMonitor.rang == LMVControlMonitor.RangeModes.Standard2H)
        //{

        //}

        //if (controlMonitor.currentRange == 2 && controlMonitor.driveMode == LMVControlMonitor.DriveModes.modeHigh && controlMonitor.rang == LMVControlMonitor.RangeModes.HighRange4H)
        //{

        //}

        //if (controlMonitor.currentRange == 3 && controlMonitor.driveMode == LMVControlMonitor.DriveModes.modeLow && controlMonitor.rang == LMVControlMonitor.RangeModes.LowRange4L)
        //{

        //}
    }

    void NormalRangeSelected(bool engaged)
    {
        normalRangeOn = !normalRangeOn;

        if (engaged)
        {
            normalRangeOn = true;
            Debug.Log("Normal range");
        }
        if (!engaged)
        {
            normalRangeOn = false;
            Debug.Log("Normal range off");
        }

        if (controlMonitor.driveMode == LMVControlMonitor.DriveModes.modeNormal && controlMonitor.rang == LMVControlMonitor.RangeModes.Standard2H && controlMonitor.currentRange == 1)
        {
            controlMonitor.canSwitch = true;
            controlMonitor.range = 1;
            controlMonitor.driveMode = LMVControlMonitor.DriveModes.modeNormal;
        }
    }

    void HighRangeSelected(bool engaged)
    {
        highRangeOn = !highRangeOn;

        if (engaged)
        {
            highRangeOn = true;
            controlMonitor.canSwitch = true;
            controlMonitor.range = 2;
            controlMonitor.driveMode = LMVControlMonitor.DriveModes.modeHigh;
            controlMonitor.rang = LMVControlMonitor.RangeModes.HighRange4H;
        }

        if (controlMonitor.range == 2)
        {
            highRangeOn = false;
            turnedROnce = true;
        }

        if (engaged && middleButtonOn && turnedROnce == true)
        {
            turnedRTwice = true;
            controlMonitor.canSwitch = true;
            controlMonitor.range = 3;
            controlMonitor.driveMode = LMVControlMonitor.DriveModes.modeLow;
            controlMonitor.rang = LMVControlMonitor.RangeModes.LowRange4L;
        }

        if (controlMonitor.range == 3)
        {
            highRangeOn = false;
            middleButtonOn = false;
        }

        if (!engaged)
        {
            highRangeOn = false;
            Debug.Log("High range off");
        }
    }

    void LowRangeSelector(bool engaged)
    {
        lowRangeOn = !lowRangeOn;

        if (engaged && middleButtonOn && turnedROnce == true && turnedRTwice == true)
        {
            lowRangeOn = true;
            turnedLOnce = true;
            controlMonitor.canSwitch = true;
            controlMonitor.range = 3;
            controlMonitor.driveMode = LMVControlMonitor.DriveModes.modeLow;
            controlMonitor.rang = LMVControlMonitor.RangeModes.LowRange4L;
            Debug.Log("Low range");
        }

        if (controlMonitor.range == 2 || controlMonitor.range == 3)
        {
            lowRangeOn = false;
            turnedROnce = false;
            turnedRTwice = false;
            normalRangeOn = false;
           // turnedLTwice = true;
        }

        if (turnedLTwice == true)
        {
            lowRangeOn = true;
            controlMonitor.canSwitch = true;
            controlMonitor.range = 1;
            controlMonitor.driveMode = LMVControlMonitor.DriveModes.modeNormal;
        }

        if (engaged && middleButtonOn && turnedLOnce)
        {
            turnedLTwice = true;
            controlMonitor.range = 2;
            controlMonitor.driveMode = LMVControlMonitor.DriveModes.modeHigh;
            controlMonitor.rang = LMVControlMonitor.RangeModes.HighRange4H;
        }
    }

    void MiddleButtonSelected(bool engaged)
    {
        middleButtonOn = !middleButtonOn;

        if (middleButtonOn)
        {
            middleButtonOn = true;
            Debug.Log("Middle Button");
        }
        else
        {
            middleButtonOn = false;
            Debug.Log("Middle Button off");
        }
    }
}
