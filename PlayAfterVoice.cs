using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayAfterVoice : MonoBehaviour
{
    private AudioSource voice;

    public float startDelay;
    public DoverTest DT;

    void Start()
    {
        voice = GetComponent<AudioSource>();

        StartCoroutine(ActivateAfterVoiceCo());
    }

    private IEnumerator ActivateAfterVoiceCo()
    {
        yield return new WaitForSeconds(startDelay);

        voice.Play();

        yield return new WaitForSeconds(voice.clip.length + 0.5f);

        DT.StartExperience();
    }

    public void PlayVO(AudioClip ac, float delay)
    {
        StartCoroutine(PlayVOCo(ac, delay));
    }

    private IEnumerator PlayVOCo(AudioClip audioClip, float delay)
    {
        yield return new WaitForSeconds(delay);

        voice.clip = audioClip;
        voice.Play();

        yield return new WaitForSeconds(voice.clip.length + 0.5f);

        SceneManager.LoadScene("MenuLayout");
    }
}
