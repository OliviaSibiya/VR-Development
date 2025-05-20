using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickFunction : MonoBehaviour
{
    public Transform rayOrigin;

    public float rayDistance = 100f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            CheckRaycast(ray, "Left Click");
        }

        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            CheckRaycast(ray, "Right Click");
        }

        // === VR CONTROLLER INPUT ===
        //if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger)) // Change if needed
        //{
        //    if (rayOrigin != null)
        //    {
        //        Ray ray = new Ray(rayOrigin.position, rayOrigin.forward);
        //        CheckRaycast(ray, "VR Trigger");
        //    }
        //}
    }

    void CheckRaycast(Ray ray, string source)
    {
        if (Physics.Raycast(ray, out RaycastHit hit, rayDistance))
        {

            if (hit.transform.IsChildOf(transform))
            {
                Debug.Log($"{source} hit LEFT ARM LEVERS");
            }
        }
        else
        {
            Debug.Log($"{source} Raycast missed.");
        }
    }
}
