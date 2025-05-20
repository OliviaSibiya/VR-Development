using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chooseScenario : MonoBehaviour
{
    public GameObject fireParticles;

    public float spawnValue;
    private int spawnObjectValue = -1;

    //First GameObject
    public GameObject FireScenario;
    public GameObject BrakeScenario;
    public GameObject TyreScenario;
    public GameObject StuckInSand;

    //private void Awake()
    //{
        
    //    FireScenario.SetActive(false);
    //    BrakeScenario.SetActive(false);
    //    TyreScenario.SetActive(false);
    //}
     public void Start()
     {

        System.Random rnd = new System.Random();
        int randomScenario = rnd.Next(1, 5);
        switch (randomScenario)
        {
            case 1:
                FireScenario.SetActive(true);
                break;

            case 2:
                BrakeScenario.SetActive(true);
                break;

            case 3:
                TyreScenario.SetActive(true);
                break;

            case 4:
               StuckInSand.SetActive(true);
               break;

            default:
                Debug.LogError("Invalid spawnValue");
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //if (spawnValue == 2 || spawnValue == 3 || spawnValue == 4 || spawnValue == 5)
        //{
        //    fireParticles.SetActive(false);
        //}
        //else if (spawnValue == 1)
        //{
        //    fireParticles.SetActive(true);
        //}

        //if (spawnValue != 1)
        //{
        //    fireParticles.SetActive(false);
        //}
        //else
        //{
        //    fireParticles.SetActive(true);
        //}
    }

    public void OnTriggerEnter(Collider other)
    {
        //To initiate a scenario 
        if (other.CompareTag("Player"))
        {

        }
    }

    public void OnTriggerStay(Collider other)
    {
        //To test if the player has followed procedure 
    }

    public void OnTriggerExit(Collider other)
    {
        //To fail the player if the player didn't complete the procedure in time
    }
}
