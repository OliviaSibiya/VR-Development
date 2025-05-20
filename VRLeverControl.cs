using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRLeverControl : MonoBehaviour
{
    public enum LeverFunction
    {
        FeedExtension,
        BoomExtension,
        FeedRotation,
        Feedlookout
    }

    public LeverFunction function;

    public bool isLeft = true;

    public float threshold = 15f;
    public float multiplier = 1f;

    public BoomerJointControl _feedRotation;
    public BoomerJointControl _feedLookout;
    public BoomerSlide _feedExtension;
    public BoomerSlide _boomExtension;

    public Renderer leverVisual;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float angle = LeverAngle();
        int direction = 0;

        if (angle> threshold)
        {
            direction = 1;
        }
        else if (angle < -threshold)
        {
            direction = -1;
        }

        if (direction != 0 && IsArmValid())
        {
            ApplyValue(direction);
        }
    }

    private float LeverAngle()
    {
        float angle = transform.localEulerAngles.x;
        return (angle > 180) ? angle - 360 : angle;
    }

    void ApplyValue(int direction)
    {
        switch (function)
        {
            case LeverFunction.FeedExtension:
                if (_feedExtension)
                    _feedExtension.MoveZ(direction * multiplier);
                break;

            case LeverFunction.BoomExtension:
                if (_boomExtension)
                    _boomExtension.MoveZ(direction * multiplier);
                break;

            case LeverFunction.FeedRotation:
                if (_feedRotation)
                    _feedRotation.RotationY(direction * multiplier);
                break;

            case LeverFunction.Feedlookout:
                if (_feedLookout)
                    _feedLookout.RotationX(direction * multiplier);
                break;
        }
    }

    bool IsArmValid()
    {
        switch (function)
        {
            case LeverFunction.FeedExtension:
                return _feedExtension && (isLeft ? _feedExtension.leftArm : _feedExtension.rightArm);
            case LeverFunction.BoomExtension:
                return _boomExtension && (isLeft ? _boomExtension.leftArm : _boomExtension.rightArm);
            case LeverFunction.FeedRotation:
                return _feedRotation && (isLeft ? _feedRotation.leftArm : _feedRotation.rightArm);
            case LeverFunction.Feedlookout:
                return _feedLookout && (isLeft ? _feedLookout.leftArm : _feedLookout.rightArm);
            default:
                return false;
        }
    }
}
