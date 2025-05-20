using JetBrains.Annotations;
using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnStay : MonoBehaviour
{
    public bool canContinue = false;
    
    public float timeRemaining, colliderOn;
    public GameObject colliderDestroy;
   // public CollisionManager collisionManager;

    private void Start()
    {
   
    }
    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(StayInside());
            Debug.Log("Waiting");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        StopCoroutine(StayInside());
        //StartCoroutine(ColliderOn());
    }
    private IEnumerator StayInside()
    {
        yield return new WaitForSeconds(timeRemaining);
        colliderDestroy.GetComponent<Collider>().enabled = false;
        canContinue = true;
        Debug.Log("StayedInside");

    }

    //private IEnumerator ColliderOn()
    //{
    //    yield return new WaitForSeconds(colliderOn);
    //    colliderDestroy.GetComponent<Collider>().enabled = true;

    //}
}
