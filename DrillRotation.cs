using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrillRotation : MonoBehaviour
{
    public GameObject DrillBit;

    [Header("Drill Movement Settings")]
    public float MinY = 0.2f;
    public float MaxY = 1.0f;
    public float MoveSpeed = 0.5f;

    public KeyCode DrillDownKey = KeyCode.S;
    public KeyCode DrillUpKey = KeyCode.W;

    private float targetY;

    void Start()
    {
        // Start at current Y position
        targetY = DrillBit.transform.localPosition.y;
    }

    void Update()
    {
        // Adjust target position based on input
        if (Input.GetKey(DrillDownKey))
        {
            targetY -= MoveSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(DrillUpKey))
        {
            targetY += MoveSpeed * Time.deltaTime;
        }

        // Clamp targetY to stay between min and max
        targetY = Mathf.Clamp(targetY, MinY, MaxY);

        // Apply the position smoothly
        Vector3 localPos = DrillBit.transform.localPosition;
        localPos.y = Mathf.Lerp(localPos.y, targetY, 0.1f); // smooth movement
        DrillBit.transform.localPosition = localPos;
    }
}
