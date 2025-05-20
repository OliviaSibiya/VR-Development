using UnityEngine;

public class BoomerJointControl : MonoBehaviour
{
    public Transform rotationObject;
    //public ObjFunction _objFunction;
    public FunctionActivations activation;

    public int rotationSpeed;

    public GameObject pivot;

    public float minAngle = -180;
    public float maxAngle = 180;
    private float currentAngle = 0f;

    private Vector3 pivotPoint;
    private Vector3 axis;

    public bool yDir;
    public bool zDir;
    public bool xDir;
    public bool rightArm;
    public bool leftArm;

    private void Update()
    {
        if ((xDir || yDir || zDir) && (leftArm || rightArm))
        {
            //_objFunction.ButtonFunctions();
        }
    }

    public void RotationY(float direction)
    {
        float deltaAngle = rotationSpeed * Time.deltaTime * direction;
        float nextAngle = currentAngle + deltaAngle;

        if (nextAngle >= minAngle && nextAngle <= maxAngle)
        {
            Vector3 pivotWorldPos = pivot.transform.position + pivot.transform.TransformDirection(pivotPoint);
            rotationObject.RotateAround(pivotWorldPos, pivot.transform.up, deltaAngle);
            currentAngle = nextAngle;
        }
    }

    public void RotationX(float direction)
    {
        float deltaAngle = rotationSpeed * Time.deltaTime * direction;
        float nextAngle = currentAngle + deltaAngle;

        if (nextAngle >= minAngle && nextAngle <= maxAngle)
        {
            Vector3 pivotWorldPos = pivot.transform.position + pivot.transform.TransformDirection(pivotPoint);
            rotationObject.RotateAround(pivotWorldPos, pivot.transform.right, deltaAngle);
            currentAngle = nextAngle;
        }
    }

    public void RotationZ(float direction)
    {
        float deltaAngle = rotationSpeed * Time.deltaTime * direction;
        float nextAngle = currentAngle + deltaAngle;

        if (nextAngle >= minAngle && nextAngle <= maxAngle)
        {
            Vector3 pivotWorldPos = pivot.transform.position + pivot.transform.TransformDirection(pivotPoint);
            rotationObject.RotateAround(pivotWorldPos, pivot.transform.forward, deltaAngle);
            currentAngle = nextAngle;
        }
    }
}
