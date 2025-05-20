using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChosenScenario : MonoBehaviour
{
    //public GameObject fireParticle;

    //public float spawnValue;

    //public GameObject fireScenario;
    //public GameObject brakeScenario;
    //public GameObject tyreScenario;

    //public Conditions conditions;

    //// Start is called before the first frame update
    //void Start()
    //{
    //    fireScenario.SetActive(false);
    //    brakeScenario.SetActive(false);
    //    tyreScenario.SetActive(false);


    //    spawnValue = Random.Range(1, 4);

    //    switch (spawnValue)
    //    {
    //        case 1:
    //            fireScenario.SetActive(true);
    //            conditions.isOnTrack = true;
    //            break;

    //        case 2:
    //            brakeScenario.SetActive(true);
    //            conditions.isOnTrack = true;
    //            break;

    //        case 3:
    //            tyreScenario.SetActive(true);
    //            conditions.isOnTrack = true;
    //            break;

    //        default:
    //            Debug.LogError("Invalid spwanValue");
    //            break;
    //    }
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    if (spawnValue == 2 || spawnValue == 3)
    //    {
    //        fireParticle.SetActive(false);
    //    }
    //    else if (spawnValue == 1)
    //    {
    //        fireParticle.SetActive(true);
    //    }
    //}

    public GameObject FireScenario;
    public GameObject BrakeScenario;
    public GameObject TyreScenario;

    void Start()
    {
        //System.Random rnd = new System.Random();
        //int randomScenario = rnd.Next(1, 4);
        //switch (randomScenario)
        //{
        //    case 1:
        //        FireScenario.SetActive(true);
        //        break;

        //    case 2:
        //        BrakeScenario.SetActive(true);
        //        break;

        //    case 3:
        //        TyreScenario.SetActive(true);
        //        break;

        //    default:
        //        Debug.LogError("Invalid spawnValue");
        //        break;
        //}

        System.Random rnd = new System.Random();
        int randomScenario = rnd.Next(1, 4);
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

            default:
                Debug.LogError("Invalid spawnValue");
                break;
        }
    }
}
