using UnityEngine;
using UnityEngine.UI;
//this script makes the race time work for player 1 (and player 2 in split-screen mode)
public class LapTimeManager : MonoBehaviour
{
    public static int MinuteCount, MinuteCountP2;//minutes are ints
    public static int SecondCount, SecondCountP2;//seconds are ints too
    public static float MilliCount, MilliCountP2;//milliseconds are floats
    public static string MilliDisplay, MilliDisplayP2;//milliseconds are also stated as strings to show less numbers after the comma (,)
    //and we need 6 game objects in the canvas to show the values in race UI
    public GameObject MinuteBox, MinuteBoxP2;//minutes UI objects (for player 1 and 2 in split-screen)
    public GameObject SecondBox, SecondBoxP2;//seconds UI objects (for player 1 and 2 in split-screen)
    public GameObject MilliBox, MilliBoxP2;//and milliseconds UI objects (for player 1 and 2 in split-screen)
    //this void will make the clock timer of the race work
    void Update()
    {
        //player 1 lap time
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
        //player 2 lap time in split-screen mode
        MilliCountP2 += Time.deltaTime * 10;
        MilliDisplayP2 = MilliCountP2.ToString("F0");
        MilliBoxP2.GetComponent<Text>().text = "" + MilliDisplayP2;
        if (MilliCountP2 >= 10)
        {
            MilliCountP2 = 0;
            SecondCountP2 += 1;
        }
        if (SecondCountP2 <= 9)
        {
            SecondBoxP2.GetComponent<Text>().text = "0" + SecondCountP2 + ".";
        }
        else
        {
            SecondBoxP2.GetComponent<Text>().text = "" + SecondCountP2 + ".";
        }
        if (SecondCountP2 >= 60)
        {
            SecondCountP2 = 0;
            MinuteCountP2 += 1;
        }
        if (MinuteCountP2 <= 9)
        {
            MinuteBoxP2.GetComponent<Text>().text = "0" + MinuteCountP2 + ":";
        }
        else
        {
            MinuteBoxP2.GetComponent<Text>().text = "" + MinuteCountP2 + ":";
        }
    }
}