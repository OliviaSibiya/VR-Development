using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TyreScenario : MonoBehaviour
{
    public static bool isDrift;
    public WheelCollider wheelCollider;
    public WheelCollider wheelColliderAutomatic;

    private int counter = 0;
    private float timer = 0f;
    private float countDown = 10f;
    private float incrementInterval = 1f;
   //public TextMeshProUGUI timeText;
    public GameObject flatTyre;
    public GameObject tyre;

    public ScenarioManager manager;
    public RCC_CarControllerV3 carController;

    void Start()
    {
        //UITyre.gameObject.SetActive(false);
        isDrift = false;
        MeshRenderer renderer = tyre.GetComponent<MeshRenderer>();

        if (renderer != null)
        {
            renderer.enabled = false;
        }
        else
        { 
            Debug.LogWarning("Mesh renderer component not found");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            isDrift= true;
            flatTyre.gameObject.SetActive(true);
            wheelCollider.radius = 0.6f;
            wheelColliderAutomatic.radius = 0.6f;
        }
    }
    private void OnTriggerStay(Collider col)
    {
        if (col.CompareTag("Player"))
        {
           // UITyre.gameObject.SetActive(true);
            isDrift = true;
            wheelCollider.radius = 0.78f;
            wheelColliderAutomatic.radius = 0.78f;
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
                //manager.passed = true;
                wheelCollider.radius = 0.4f;
                wheelColliderAutomatic.radius = 0.4f;
                wheelColliderAutomatic.radius = 0.4f;
            }
        }
    }
    private void OnTriggerExit(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            flatTyre.gameObject.SetActive(false);
            isDrift = false;
            
            wheelCollider.radius = 0.4f;
            wheelColliderAutomatic.radius = 0.4f;
            wheelColliderAutomatic.radius = 0.4f;
        }

        if (carController.speed > 5f)
        {
            //manager.failed = true;
            wheelCollider.radius = 0.4f;
            wheelColliderAutomatic.radius = 0.4f;
            wheelColliderAutomatic.radius = 0.4f;
        }
    }
}
