using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FireScenario : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool OnFire;
    [SerializeField] public ParticleSystem particlSystem;
    [SerializeField] public ParticleSystem particleSystem2;


    private int counter = 0;
    private float timer = 0f;
    private float countDown = 10f;
    private float incrementInterval = 1f;
    //public TextMeshProUGUI timeText;
    //public GameObject UIFire;
    public ScenarioManager manager;
    public RCC_CarControllerV3 carController;

    void Start()
    {
        //UIFire.gameObject.SetActive(false);
        StopParticleEffect();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayParticleEffect()
    {
        particlSystem.Play();
        particleSystem2.Play();
    }
    public void StopParticleEffect()
    {
        particlSystem.Stop();
        particleSystem2.Stop();     
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            OnFire = true;
            //UIFire.gameObject.SetActive(true);
            PlayParticleEffect();
        }
    }
    private void OnTriggerStay(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            //UIFire.gameObject.SetActive(true);
            OnFire = true;
            timer += Time.deltaTime;
            if (timer >= incrementInterval)
            {

               // timeText.text = countDown-- + "s";
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
               // manager.passed = true;
                OnFire = false;
            }
        }
    }
    private void OnTriggerExit(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            OnFire = false;
            StopParticleEffect();
            //UIFire.gameObject.SetActive(false);
            timer = 0f;
            countDown = 0f;
            counter = 0;

            if (carController.speed > 5f)
            {
                //manager.failed = true;
                OnFire = false;
            }
        }
    }
}
