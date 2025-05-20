using UnityEngine;
using TMPro;

public class ScenarioText : MonoBehaviour
{
    public TMP_Text scenarioText;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EngineFire"))
        {
            scenarioText.text = "Engine Fire"; 
        }

        if (other.CompareTag("BrakeFailure"))
        {
            scenarioText.text = "Brake Failure";
        }

        if (other.CompareTag("FlatTyre"))
        {
            scenarioText.text = "Flat Tyre";
        }

        if (other.CompareTag("Stay"))
        {
            scenarioText.text = "Stuck In Sand";
        }
    }
}
