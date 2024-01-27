using UnityEngine;
using UnityEngine.UI;
public class LapTimeManager : MonoBehaviour
{
    public static int MinuteCount, MinuteCountP2;
    public static int SecondCount, SecondCountP2;
    public static float MilliCount, MilliCountP2;
    public static string MilliDisplay, MilliDisplayP2;
    public GameObject MinuteBox, MinuteBoxP2;
    public GameObject SecondBox, SecondBoxP2;
    public GameObject MilliBox, MilliBoxP2;
    void Update()
    {
        
        MilliCount += Time.deltaTime * 10;
        MilliDisplay = MilliCount.ToString("F0");
        MilliBox.GetComponent<Text>().text = "" + MilliDisplay;
        if (MilliCount >= 10)
        {
            MilliCount = 0;
            SecondCount += 1;
        }
        if (SecondCount <= 9)
        {
            SecondBox.GetComponent<Text>().text = "0" + SecondCount + ".";
        }
        else
        {
            SecondBox.GetComponent<Text>().text = "" + SecondCount + ".";
        }
        if (SecondCount >= 60)
        {
            SecondCount = 0;
            MinuteCount += 1;
        }
        if (MinuteCount <= 9)
        {
            MinuteBox.GetComponent<Text>().text = "0" + MinuteCount + ":";
        }
        else
        {
            MinuteBox.GetComponent<Text>().text = "" + MinuteCount + ":";
        }
       
    }
}