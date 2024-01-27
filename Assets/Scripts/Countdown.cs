using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class Countdown : MonoBehaviour
{
    public GameObject CountDown, LapTimer, CarControls;
    public AudioSource GetReady, GoAudio, LevelMusic;

    void Start()
    {
        StartCoroutine(CountStart());
    }

    IEnumerator CountStart()
    {
        LapTimeManager.MinuteCount = 0; LapTimeManager.SecondCount = 0; LapTimeManager.MilliCount = 0;
        yield return new WaitForSeconds(0.5f);
        CountDown.GetComponent<Text>().text = "3";
        GetReady.Play();
        CountDown.SetActive(true);
        yield return new WaitForSeconds(1);
        CountDown.SetActive(false);
        CountDown.GetComponent<Text>().text = "2";
        GetReady.Play();
        CountDown.SetActive(true);
        yield return new WaitForSeconds(1);
        CountDown.SetActive(false);
        CountDown.GetComponent<Text>().text = "1";
        GetReady.Play();
        CountDown.SetActive(true);
        yield return new WaitForSeconds(1);
        CountDown.SetActive(false);
        GoAudio.Play();
        LevelMusic.Play();
        LapTimer.SetActive(true);
        CarControls.SetActive(true);
        yield return null;
    }
}