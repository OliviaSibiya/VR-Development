using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class RioTintoTest : MonoBehaviour
{
    #region Messed_Up_Random_Range
    //LogitechGSDK.LogiControllerPropertiesData properties;
    ////---------LOGITECH CONFIGURE---------------//
    ////INDEX NAMES
    //int a, b, c, d;
    ////---------------end of logitech-----------//

    //// Circle Colour Group
    //[SerializeField]
    //private int colourCycleLength = 0;
    //[SerializeField]
    //private Transform[] circleList;
    //[SerializeField]
    //private Transform[] circleColourList;
    //private int colourCycleIncrement;
    //public UnityEvent OnCircleActive;
    //public UnityEvent OnCircleInactive;

    //// Audio Group
    //[SerializeField]
    //private int audioCycleLength = 0;
    //[SerializeField]
    //private AudioSource audioSource;
    //[SerializeField]
    //private AudioClip[] audioList;
    //private bool left;
    //private bool right;
    //private int audioCycleIncrement;

    //// Pedal Group
    //[SerializeField]
    //private int pedalCycleLength = 0;
    //[SerializeField]
    //private Transform[] pedalList;
    //[SerializeField]
    //private Transform pedalColour;
    //private bool pedalRight;
    //private bool pedalWait;
    //private int pedalCycleIncrement;
    //public UnityEvent OnPedalActive;
    //public UnityEvent OnPedalInactive;

    //// All Tests group
    //public int allTestsCycleLength = 0;
    //private int allTestsCycleIncrement;
    //private bool canIncrementAllTests;
    //private bool allTestsCheck;

    //public bool firstTestEnded = false;
    //public bool secondTestBegin = false;

    //// Start is called before the first frame update
    //void Start()
    //{
    //    //---------LOGITECH CONFIGURE---------------//
    //    //Steering Wheel
    //    if (Joystick.all[0].name == "Logitech G29 Driving Force Racing Wheel")
    //    {
    //        a = 0;
    //    }
    //    else if (Joystick.all[1].name == "Logitech G29 Driving Force Racing Wheel")
    //    {
    //        a = 1;
    //    }
    //    else if (Joystick.all[2].name == "Logitech G29 Driving Force Racing Wheel")
    //    {
    //        a = 2;
    //    }
    //    else if (Joystick.all[3].name == "Logitech G29 Driving Force Racing Wheel")
    //    {
    //        a = 3;
    //    }

    //    LogitechGSDK.LogiSteeringInitialize(false);
    //    //RandomColours();

    //    colourCycleIncrement = 0;
    //    pedalCycleIncrement = 0;
    //    pedalWait = false;
    //    allTestsCycleIncrement = 0;
    //    canIncrementAllTests = false;
    //    allTestsCheck = false;
    //    //audioCheck = false;
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    if (LogitechGSDK.LogiUpdate() && LogitechGSDK.LogiIsConnected(a))
    //    {
    //        LogitechGSDK.DIJOYSTATE2ENGINES rec;
    //        rec = LogitechGSDK.LogiGetStateUnity(a);

    //        ButtonSelect(rec);

    //        //if (rec.rglSlider[0] < 0 && farLeft) // This is the clutch 
    //        //{
    //        //    PedalSelect();
    //        //    Debug.Log("Clutch");
    //        //}

    //        //if (rec.lY < 0 && farRight) // This is the throttle
    //        //{
    //        //    PedalSelect();
    //        //    Debug.Log("Throttle");
    //        //}
    //    }

    //    if (Input.GetKeyDown(KeyCode.P))
    //    {
    //        colourCycleIncrement = 1000;
    //    }

    //    if (Input.GetKeyDown(KeyCode.L))
    //    {
    //        audioCycleIncrement = 1000;
    //    }

    //}

    //public void ButtonSelect(LogitechGSDK.DIJOYSTATE2ENGINES rec)
    //{
    //    if (rec.rglSlider[0] < 0 && !pedalRight) // This is the clutch 
    //    {
    //        if (pedalList[0].gameObject.activeInHierarchy && !canIncrementAllTests && !pedalWait)
    //        {
    //            OnPedalInactive?.Invoke();
    //        }

    //        if (canIncrementAllTests && allTestsCheck)
    //        {
    //            allTestsCheck = false;
    //            IncrementAllTests();
    //        }

    //        //PedalSelect();
    //        Debug.Log("Clutch");
    //    }

    //    if (rec.lY < 0 && pedalRight) // This is the throttle
    //    {
    //        if (pedalList[1].gameObject.activeInHierarchy && !canIncrementAllTests && !pedalWait)
    //        {
    //            OnPedalInactive?.Invoke();
    //        }

    //        if (canIncrementAllTests && allTestsCheck)
    //        {
    //            allTestsCheck = false;
    //            IncrementAllTests();
    //        }

    //        //PedalSelect();
    //        Debug.Log("Throttle");
    //    }

    //    for (int i = 0; i < 128; i++)
    //    {
    //        if (rec.rgbButtons[i] == 128)// Access to Logitech Steeringwheel
    //        {
    //            if (i == 0 && circleColourList[3].gameObject.activeSelf) // This is for the colour red.(This is X)
    //            {
    //                if (circleColourList[3].gameObject.activeInHierarchy && !canIncrementAllTests)
    //                {                        
    //                    OnCircleInactive?.Invoke();
    //                }

    //                if (canIncrementAllTests && allTestsCheck)
    //                {
    //                    allTestsCheck = false;
    //                    IncrementAllTests();
    //                }

    //                Debug.Log("OH");
    //            }

    //            if (i == 1 && circleColourList[1].gameObject.activeSelf) // This is for the colour green. (This is square)
    //            {
    //                if (circleColourList[1].gameObject.activeInHierarchy && !canIncrementAllTests)
    //                {
    //                    colourCycleIncrement++;
    //                    OnCircleInactive?.Invoke();
    //                }

    //                if (canIncrementAllTests && allTestsCheck)
    //                {
    //                    allTestsCheck = false;
    //                    IncrementAllTests();
    //                }

    //                Debug.Log("NO");
    //            }

    //            if (i == 2 && circleColourList[2].gameObject.activeSelf) // This is for the colour blue. (This is O)
    //            {
    //                if (circleColourList[2].gameObject.activeInHierarchy && !canIncrementAllTests)
    //                {
    //                    colourCycleIncrement++;
    //                    OnCircleInactive?.Invoke();
    //                }

    //                if (canIncrementAllTests && allTestsCheck)
    //                {
    //                    allTestsCheck = false;
    //                    IncrementAllTests();
    //                }

    //                Debug.Log("DON'T");
    //            }

    //            if (i == 3 && circleColourList[4].gameObject.activeSelf) // This is for the colour orange. (This is triangle)
    //            {
    //                if (circleColourList[4].gameObject.activeInHierarchy && !canIncrementAllTests)
    //                {
    //                    colourCycleIncrement++;
    //                    OnCircleInactive?.Invoke();
    //                }

    //                if (canIncrementAllTests && allTestsCheck)
    //                {
    //                    allTestsCheck = false;
    //                    IncrementAllTests();
    //                }

    //                Debug.Log("KNOW");
    //            }

    //            if (i == 6 && right) // This is the R2 on the steering wheel. This is for the sound indicators.
    //            {                    
    //                //audioCycleIncrement++;

    //                AudioSelect();

    //                Debug.Log("WHAT'S");
    //            }

    //            if (i == 7 && left) // This is the L2 on the steering wheel. This is for the sound indicators.
    //            {
    //                //audioCycleIncrement++;

    //                AudioSelect();                    

    //                Debug.Log("HAPPENING");
    //            }

    //            if (i == 23 && circleColourList[0].gameObject.activeSelf) // This is for the colour white.(This is the button in red turner)
    //            {
    //                if (circleColourList[0].gameObject.activeInHierarchy && !canIncrementAllTests)
    //                {
    //                    colourCycleIncrement++;
    //                    OnCircleInactive?.Invoke();
    //                }

    //                if (canIncrementAllTests && allTestsCheck)
    //                {
    //                    allTestsCheck = false;
    //                    IncrementAllTests();
    //                }

    //                Debug.Log("HERE");
    //            }
    //        }
    //    }
    //}

    //public void FirstTest()// This happens when the player is suppose to press each button while being instructed to.
    //{

    //}

    //public void SecondTest()// This is to test the player without being instructed.
    //{

    //}

    //private void RandomCircleSelection()
    //{
    //    int circleIndex = Random.Range(0, 10);
    //    int colourIndex = Random.Range(0, 5);

    //    //circle.position =  new Vector3(circleList[index].position.x, circleList[index].position.y, circleList[index].position.z - 0.2f);
    //    circleColourList[colourIndex].position = circleList[circleIndex].position;
    //    circleColourList[colourIndex].gameObject.SetActive(true);
    //}

    //public void ActivateCircle()
    //{
    //    if (colourCycleIncrement <= colourCycleLength)
    //    {
    //        RandomCircleSelection();       
    //    }
    //    else
    //    {
    //        // Activate next sequence -> Audio
    //        AudioSelect();
    //    }

    //}

    //private void ActivatePedals()
    //{
    //    if (pedalCycleIncrement <= pedalCycleLength)
    //    {            
    //        StartCoroutine(PedalSelectCo());
    //    }
    //    else
    //    {
    //        pedalColour.gameObject.SetActive(false);

    //        // Activate final phase to fire all tests
    //        allTestsCheck = true;
    //        AllTests();
    //    }
    //}

    ////private void PedalSelect()
    ////{
    ////    int index = Random.Range(0, 2);

    ////    pedalColour.position = pedalList[index].transform.position;
    ////    pedalColour.gameObject.SetActive(true);

    ////    pedalRight = index == 1;
    ////    //StartCoroutine(CyclePedals());        
    ////}

    //private IEnumerator PedalSelectCo()
    //{
    //    int index = Random.Range(0, 2);

    //    pedalColour.position = pedalList[index].transform.position;
    //    pedalColour.gameObject.SetActive(true);

    //    pedalRight = index == 1;

    //    if (pedalWait)
    //    {
    //        pedalCycleIncrement++;
    //    }

    //    yield return new WaitForSeconds(1.0f);

    //    pedalWait = false;
    //}

    //private void AllTests()
    //{
    //    if (!allTestsCheck)
    //    {
    //        return;
    //    }

    //    //colourCycleIncrement = 0;
    //    //audioCycleIncrement = 0;
    //    //pedalCycleIncrement = 0;

    //    Debug.Log("All Tests");

    //    //allTestsCheck = true;

    //    //int index = Random.Range(0, 4);

    //    //if (allTestsCycleIncrement <= allTestsCycleLength)
    //    //{
    //    //    switch (index)
    //    //    {
    //    //        case 0:
    //    //            // Circles
    //    //            RandomCircleSelection();
    //    //            break;
    //    //        case 1:
    //    //            // Audio
    //    //            StartCoroutine(AudioCheckDelayCo());
    //    //            break;
    //    //        case 2:
    //    //            // Pedals
    //    //            StartCoroutine(PedalSelectCo());
    //    //            break;
    //    //        default:
    //    //            break;
    //    //    }
    //    //}
    //    //
    //    allTestsCheck = false;
    //}

    //private IEnumerator AllTestsCo()
    //{
    //    yield return new WaitForSeconds(1);

    //    allTestsCycleIncrement++;

    //    AllTests();
    //}

    //private void IncrementAllTests()
    //{        
    //    AllTestsCo();
    //}

    //public void DeactivateCircle()
    //{
    //    foreach (Transform circle in circleColourList)
    //    {
    //        circle.gameObject.SetActive(false);
    //    }

    //    if (!canIncrementAllTests)
    //    {
    //        ActivateCircle();
    //    }
    //}

    //public void DeactivatePedals()
    //{
    //    foreach (Transform pedal in pedalList)
    //    {
    //        pedalColour.gameObject.SetActive(false);
    //        pedalWait = true;
    //    }

    //    if (!canIncrementAllTests)
    //    {
    //        ActivatePedals();
    //    }
    //}

    //private void AudioSelect()
    //{
    //    if (audioCycleIncrement <= audioCycleLength)
    //    {
    //        StartCoroutine(AudioCheckDelayCo());
    //    }
    //    else
    //    {
    //        // Activate next sequence -> Pedals
    //        //StartCoroutine(CyclePedals());
    //        ActivatePedals();
    //    }
    //}

    //private IEnumerator AudioCheckDelayCo()
    //{
    //    //yield return new WaitForSeconds(1.0f);

    //    int index = Random.Range(0, 2);
    //    //left = index == 1;           

    //    audioSource.clip = audioList[index];
    //    audioSource.Play();

    //    if (left || right) // Was the button pressed?
    //    {
    //        left = false;
    //        right = false;
    //        audioCycleIncrement++;
    //    }

    //    yield return new WaitForSeconds(1.0f);

    //    if (index == 0)
    //    {
    //        left = true;
    //        right = false;
    //    }
    //    else
    //    {
    //        left = false;
    //        right = true;
    //    }
    //}

    ////private IEnumerator CyclePedals()
    ////{
    //    //int pedal = Random.Range(0, 2);

    //    //pedalColour.position = pedalList[pedal].transform.position;
    //    //pedalColour.gameObject.SetActive(true);

    //    //if (farLeft || farRight)
    //    //{
    //    //    farLeft = false;
    //    //    farRight = false;
    //    //    pedalCycleIncrement++;
    //    //}

    //    //yield return new WaitForSeconds(2.0f);

    //    //if (pedal == 0)
    //    //{
    //    //    farLeft = true;
    //    //    farRight = false;
    //    //}
    //    //else
    //    //{
    //    //    farLeft = false;
    //    //    farRight = true;
    //    //}
    ////}
    #endregion

   // public AudioSource audioPlay;
    public AudioClip[] audioList;
    public DoverTest DT;

    public void Update()
    {
        VoiceOverUpdate();
    }

    void VoiceOverUpdate()
    {
        DT.NextDelay = 3.0f;

        if (DT.test2Active == true && DT.phase1Active == true)
        {
            DT.audioSource.clip = audioList[0];
            DT.audioSource.Play();

            //audioPlay.clip = audioList[0];
            //audioPlay.Play();
        }
        DT.NextDelay = 1.0f;

        if (DT.test3Active == true && DT.phase1Active == true)
        {
            DT.NextDelay = 3.0f;
            DT.audioSource.clip = audioList[1];
            DT.audioSource.Play();

            //audioPlay.clip = audioList[1];
            //audioPlay.Play();
        }
        DT.NextDelay = 1.0f;

        if (DT.test3Active == false && DT.phase2Active == true)
        {
            DT.NextDelay = 3.0f;
            DT.audioSource.clip = audioList[2];
            DT.audioSource.Play();

            //audioPlay.clip = audioList[2];
            //audioPlay.Play();
        }
        DT.NextDelay = 1.0f;
    }
}
