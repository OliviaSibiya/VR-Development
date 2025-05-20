using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreTexts : MonoBehaviour
{
    [Header("Speeding")]
    public TMP_Text speedingScore;
    public Image speedingImage;

    [Header("Collision")]
    public TMP_Text collisionScore;
    public Image collisionImage;

    [Header("Pedestrian")]
    public TMP_Text pedestrianScore;
    public Image pedestrianImage;

    [Header("Stop Street")]
    public TMP_Text stopStreetScore;
    public Image stopStreetImage;

    [Header("Following Distance")]
    public TMP_Text followDistanceScore;
    public Image followDistanceImage;

    [Header("Fatigue")]
    public TMP_Text fatigueScore;
    public Image fatigueImage;

    [Header("Momentum")]
    public TMP_Text momentumScore;
    public Image momentumImage;

    [Header("Blind Spots")]
    public TMP_Text blindSpotScore;
    public Image blindSpotImage;

    [Header("Failed")]
    public TMP_Text failedTimes;
    public Image failedTimeImage;

    [Header("Harsh Braking")]
    public TMP_Text harshBrakingScore;
    public Image harshBrakingImage;

    [Header("Over Reving")]
    public TMP_Text overRevingScore;
    public Image overRevingImage;

    [Header("Correct Gear")]
    public TMP_Text correctGearScore;
    public Image correctGearImage;

    [Header("Restarted Scene")]
    public TMP_Text restartedScene;
    public Image restartedSceneImage;

}
