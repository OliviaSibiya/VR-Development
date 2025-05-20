using Framework.Utilities.Managers;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CollisionManager : MonoBehaviour
{
    [Header("Player Components")]
    public GameObject player;
    public Rigidbody playerRigid;
   // public float currentSpeed;

    [Header("Respawn Components")]
    public Vector3 respawnPoint;

    [Header("Hazard CountDown")]
    public GameObject hitHazard, StopCanvas;
    public Text countdownText;
    public int currCountdownValue;
  //  private int ScoreNum;

    public bool isHit;
    public AudioListener audList;
    public ScoreManager ScoreManager;
    private bool gameOverState = false;
    private Coroutine hitHazardCoroutine;
    private OnStay onStayScript;
    // Start is called before the first frame update
    void Start()
    {
       // player.GetComponent<Collider>();    
        respawnPoint = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Checkpoint"))
        { 
            Checkpoint();
            Debug.Log("Checkpoint");
        }

        if (collision.gameObject.CompareTag("Hazard"))
        {
            //isHit = true;
            //collision.gameObject.SetActive(false);
            //InitializeHitHazardCoroutine(currCountdownValue);
            //Debug.Log("Hazard");
            //gameOverState = true;
            //ScoreManager.hittingWallsScore += 10;
            HitVehicle();
        }
        if (collision.gameObject.CompareTag("Pedestrian"))
        {
           HitPedestrian();
        }
        if (collision.gameObject.CompareTag("Vehicle"))
        {
            HitVehicle();
        
        }
        //if (collision.gameObject.CompareTag("StopStreet"))
        //{
        //    StopStreet();
        //}
    }

    #region  Respawn
    public void Checkpoint()
    {
        respawnPoint = gameObject.transform.position;
    }
    #endregion


    #region Collisions

    public void InitializeHitHazardCoroutine(int countdownValue)
    {
        if (hitHazardCoroutine != null)
        {
            StopCoroutine(hitHazardCoroutine);
        }
        hitHazardCoroutine = StartCoroutine(StartCountdown(countdownValue));
    }


    public IEnumerator StartCountdown(int countdownValue)
    {
        int _countdownValue = countdownValue;
        while (_countdownValue > 0)
        {
            hitHazard.SetActive(true);
            AudioListener.pause = true;
            Time.timeScale = 0;
            countdownText.text = _countdownValue.ToString();

            Debug.Log("Countdown: " + _countdownValue);
            yield return new WaitForSecondsRealtime(1.0f);
            _countdownValue--;
        }
        HitHazard();
    }

    public void HitHazard()
    {
        player.transform.position = respawnPoint;
        player.transform.eulerAngles = new Vector3(0, 0, 0);
       // currentSpeed = 0f;
        hitHazard.SetActive(false);
        Time.timeScale = 1;
        AudioListener.pause = false;
        isHit = false;
        gameOverState = false;
    }

    public void HitPedestrian()
    {
        Debug.Log("Pedestrian Hit");
        //ScoreManager.pedestrainScore += 100;
        audList.enabled = false;
    }

    public void HitVehicle()
    {
        //ScoreManager.hittingWallsScore += 100;
        audList.enabled = false;

    }

    public void MainMenuLoadScene()
    {
        SceneManager.LoadScene("MainMenu");
    }
    #endregion

    //public void StopStreet()
    //{
    //    StartCoroutine(CanvasCountDown());
    //    ScoreManager.stopStreetScore += 1;
    //   // Debug.Log("You Failed");
    //    onStayScript.canContinue = false;
    //}

    //private IEnumerator CanvasCountDown()
    //{
    //    yield return new WaitForSeconds(3);

    //    StopCanvas.SetActive(false);
    //}
}
