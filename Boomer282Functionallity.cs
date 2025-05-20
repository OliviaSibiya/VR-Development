//using Framework.GameFoundation;
//using HurricaneVR.Framework.Components;
//using HurricaneVR.Framework.Core;
//using HurricaneVR.Framework.Core.Grabbers;
//using UnityEngine;
//using UnityEngine.Events;

//public class Boomer282Functionallity : MonoBehaviour
//{
//    #region Public Variables
//    public LeveredSingleAxisJoint lever;
//    public LeveredSlidingJoint leverSlidingJoint;
//    public HVRRotationTracker leverTracker;

//    public UnityEvent BoomFunctionSelect;

//    public GameObject detectionObject;
//    public bool grabbed;

//    public float currentLinearValue;
//    public float currentLeverValue;
//    #endregion

//    #region Private Variables
//    private HVRGrabbable grabber;

//    private float minValue = 0f;
//    private float maxValue = 1f;
//    private float increment = 0.02f;
//    private float leverForward = 1f;
//    private float leverBackward = -1f;
//    private float leverNeutral = 0f;

//    private bool forward;
//    private bool neutral;
//    private bool backward;
//    #endregion

//    // Start is called before the first frame update
//    void Start()
//    {
//        grabber = GetComponent<HVRGrabbable>();
//        grabber.HandGrabbed.AddListener(OnGrabbed);
//        grabber.HandGrabbed.AddListener(OnReleased);
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        //RotationLeverLeft();
//        currentLinearValue = lever.linearValue;
//        if (grabbed)
//        {
//            BoomFunctionSelect.Invoke();
//        }
//    }

//    #region Grabbing Debug

//    void OnGrabbed(HVRGrabberBase hand, HVRGrabbable grabbedObject)
//    {
//        Debug.LogWarning($"{gameObject.name} has been grabbed by {hand.name}");
//        grabbed = true;
//    }

//    void OnReleased(HVRGrabberBase hand, HVRGrabbable grabbedObject)
//    {
//        Debug.LogWarning($"{gameObject.name} has been released by {hand.name}");
//        grabbed = false;
//    }

//    #endregion

//    #region Boomer Mechanics
//    public void SingleAxisJointFunctionLeft() 
//    {
//        if (leverTracker.Step >= 19) // When the lever goes forward
//        {
//            if (currentLeverValue == leverForward)
//            {
//                IncrementValue();
//                if (lever.linearValue == 0.7)
//                {
//                    leverForward = 0f;
//                    Debug.Log("Maximun Rotation value reached");
//                }
//                else
//                {
//                    currentLeverValue = leverForward;
//                }
//            }
//            currentLinearValue = lever.linearValue;
//        }

//        if (leverTracker.Step == 0) // When the lever is neutral
//        {
//            if (currentLeverValue == leverNeutral)
//            {
//                currentLinearValue = lever.linearValue;
//            }
//            currentLinearValue = lever.linearValue;
//        }

//        if (leverTracker.Step <= 1) // When the lever is backward
//        {
//            if (currentLeverValue == leverBackward)
//            {
//                DecrementValue();
//            }
//            currentLinearValue = lever.linearValue;
//        }
//    }

//    public void SingleAxisJointFunctionRight()
//    {
//        if (leverTracker.Step >= 19) // When the lever goes forward
//        {
//            if (currentLeverValue == leverForward)
//            {
//                DecrementValue();
//            }
//            currentLinearValue = lever.linearValue;
//        }

//        if (leverTracker.Step == 0) // When the lever is neutral
//        {
//            if (currentLeverValue == leverNeutral)
//            {
//                currentLinearValue = lever.linearValue;
//            }
//            currentLinearValue = lever.linearValue;
//        }

//        if (leverTracker.Step <= 1) // When the lever is backward
//        {
//            if (currentLeverValue == leverBackward)
//            {
//                IncrementValue();
//                if (lever.linearValue == 0.7)
//                {
//                    leverForward = 0f;
//                    Debug.Log("Maximun Rotation value reached Right Side of Boom");
//                }
//                else
//                {
//                    currentLeverValue = leverBackward;
//                }
//            }
//            currentLinearValue = lever.linearValue;
//        }
//    }

//    public void SlidingJointFunctionLeft()
//    {
//        if (leverTracker.Step >= 19)
//        {
//            if (currentLeverValue == leverForward)
//            {
//                IncrementValue();
//                if (leverSlidingJoint.linearValue == 1)
//                {
//                    leverForward = 0f;
//                    Debug.Log("Maximun Rotation value reached");
//                }
//                else
//                {
//                    currentLeverValue = leverForward;
//                }
//            }
//            currentLinearValue = leverSlidingJoint.linearValue;
//        }

//        if (leverTracker.Step == 0) // When the lever is neutral
//        {
//            if (currentLeverValue == leverNeutral)
//            {
//                currentLinearValue = leverSlidingJoint.linearValue;
//            }
//            currentLinearValue = leverSlidingJoint.linearValue;
//        }

//        if (leverTracker.Step <= 1) // When the lever is backward
//        {
//            if (currentLeverValue == leverBackward)
//            {
//                DecrementValue();
//            }
//            currentLinearValue = leverSlidingJoint.linearValue;
//        }
//    }

//    public void SlidingJointFunctionRight()
//    {
//        if (leverTracker.Step >= 19)
//        {
//            if (currentLeverValue == leverForward)
//            {
//                DecrementValue();
//            }
//            currentLinearValue = leverSlidingJoint.linearValue;
//        }

//        if (leverTracker.Step == 0) // When the lever is neutral
//        {
//            if (currentLeverValue == leverNeutral)
//            {
//                currentLinearValue = leverSlidingJoint.linearValue;
//            }
//            currentLinearValue = leverSlidingJoint.linearValue;
//        }

//        if (leverTracker.Step <= 1) // When the lever is backward
//        {
//            if (currentLeverValue == leverBackward)
//            {
//                IncrementValue();
//                if (leverSlidingJoint.linearValue == 1)
//                {
//                    leverForward = 0f;
//                    Debug.Log("Maximun Rotation value reached");
//                }
//                else
//                {
//                    currentLeverValue = leverBackward;
//                }
//            }
//            currentLinearValue = leverSlidingJoint.linearValue;
//        }
//    }

//    #endregion

//    #region Linear_Value_Incrementation

//    void IncrementValue()
//    {
//        lever.linearValue = Mathf.Min(lever.linearValue + increment * Time.deltaTime, maxValue);
//        leverSlidingJoint.linearValue = Mathf.Min(leverSlidingJoint.linearValue + increment * Time.deltaTime, maxValue);
//        Debug.LogWarning("Adding the value");
//    }


//    void DecrementValue()
//    {
//        lever.linearValue = Mathf.Max(lever.linearValue - increment * Time.deltaTime, minValue);
//        leverSlidingJoint.linearValue = Mathf.Max(leverSlidingJoint.linearValue - increment * Time.deltaTime, maxValue);
//        Debug.LogWarning("Subtracting the value");
//    }

//    private float SnapToValue(float value, float snapInterval)
//    {
//        return Mathf.Round(value / snapInterval) * snapInterval;
//    }
//    #endregion

//    #region Detection_Of_Lever

//    public void OnTriggerEnter(Collider other)
//    {
//        float snapInterval = 1f;

//        if (other.gameObject.name == "Neautral Detector")
//        {
//            neutral = true;
//            currentLeverValue = SnapToValue(leverNeutral, snapInterval);
//            currentLeverValue = leverNeutral;
//            Debug.Log("Neutral was detected.");
//        }
//        else
//        {
//            neutral = false;
//            //currentLinearValue = lever.linearValue;
//            Debug.Log("No longer at neutral.");
//        }
//    }

//    public void OnCollisionEnter(Collision collision)
//    {
//        float snapInterval = 1f;

//        if (collision.gameObject.name == "Forward Position")
//        {
//            forward = true;
//            currentLeverValue = SnapToValue(leverForward, snapInterval);
//            currentLeverValue = leverForward;
//            Debug.Log("Object hit forwards");
//        }
//        else
//        {
//            forward = false;
//            //currentLinearValue = lever.linearValue;
//            Debug.Log("No longer forward");
//        }

//        if (collision.gameObject.name == "Backward Position")
//        {
//            backward = true;
//            currentLeverValue = SnapToValue(leverBackward, snapInterval);
//            currentLeverValue = leverBackward;
//            Debug.Log("Object hit backwards");
//        }
//        else
//        {
//            backward = false;
//            //currentLinearValue = lever.linearValue;
//            Debug.Log("No longer backwards");
//        }
//    }

//    #endregion
//}



