using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomerLights : MonoBehaviour
{
    //What is needed in this script? The switch gameobjects. The lights. The animator. The animations.
    [SerializeField]
    private Animator animator;
    private Animation switchAnimation;
    private List<AnimationClip> animationClips;

    [SerializeField]
    private GameObject switchButton;

    [Header("Light Objects")]
    public List<Light> lights;

    private enum LightSwitchModes
    {
        Neutral, NormalBeamLights, HighBeamLights, AllLights
    }
    private LightSwitchModes lightingMode = LightSwitchModes.Neutral;

    [Header("Booleans")]
    private bool firstPosition;
    private bool secondPosition;
    private bool thirdPosition;
    private bool neutralPosition;

    public string currentSwitch;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //LightsOn();
        //LightsOff();
    }

    #region Lights_Functionality
    public void CarrierLights()
    {
        for (int i = 0; i < lights.Count; i++)
        {
            if (neutralPosition && currentSwitch == "Neutral")
            {
                lights[i].enabled = false;
            }

            if (firstPosition && currentSwitch == "Normal Beam")
            {
                lights[i].enabled = true;
                lights[i].intensity = 15;
            }

            if (secondPosition && currentSwitch == "High Beam")
            {
                lights[i].enabled = true;
                lights[i].intensity = 30;
            }

            if (thirdPosition && currentSwitch == "All Lights")
            {
                lights[i].enabled = true;
                lights[i].intensity = 40;
            }
        }
    }

    public void RoofMountedLights()
    {
        for (int j = 0; j < lights.Count; j++)
        {
            if (neutralPosition && currentSwitch == "Neutral")
            {
                lights[j].enabled = false;
            }

            if (firstPosition && currentSwitch == "Normal Beam")
            {
                lights[j].enabled = true;
                lights[j].intensity = 25;
            }

            if (secondPosition && currentSwitch == "High Beam")
            {
                lights[j].enabled = true;
                lights[j].intensity = 45;
            }

            if (thirdPosition && currentSwitch == "All Lights")
            {
                lights[j].enabled = true;
                lights[j].intensity = 55;
            }
        }
    }

    public void LightSwitch()
    {
        switch (lightingMode)
        {
            case LightSwitchModes.Neutral: //Lights switched off

                neutralPosition = true;
                firstPosition = false;
                secondPosition = false;
                thirdPosition = false;
                lightingMode = LightSwitchModes.Neutral;
                currentSwitch = "Neutral";
                break;

            case LightSwitchModes.NormalBeamLights:
                neutralPosition = false;
                firstPosition = true;
                secondPosition = false;
                thirdPosition = false;
                lightingMode = LightSwitchModes.NormalBeamLights;
                currentSwitch = "Normal Beam";
                break;

            case LightSwitchModes.HighBeamLights:
                neutralPosition = false;
                firstPosition = false;
                secondPosition = true;
                thirdPosition = false;
                lightingMode = LightSwitchModes.HighBeamLights;
                currentSwitch = "High Beam";
                break;

            case LightSwitchModes.AllLights:
                neutralPosition = false;
                firstPosition = false;
                secondPosition = false;
                thirdPosition = true;
                lightingMode = LightSwitchModes.AllLights;
                currentSwitch = "All Lights";
                break;
            default:
                Debug.Log("No Lights have been switched");
                break;
        }
    }

    #endregion

    #region Animation_Mechanic
    
    private void FirstPosition()
    {

    }

    private void SecondPosition()
    {

    }

    private void LastPosition()
    {

    }

    private void NeutralPosition()
    {

    }
    #endregion
}
