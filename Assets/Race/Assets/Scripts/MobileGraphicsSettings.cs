using UnityEngine;

public class MobileGraphicsSettings : MonoBehaviour
{
    //Default resolution when starting the game the first time: 800x450
    public static int xx = 800, yy = 450, graphicsQuality;
    public Camera cam;

    void Start()
    {
        if (SystemInfo.deviceType == DeviceType.Handheld)
        {
            //check if it's the first time opening the game
            if (PlayerPrefs.GetInt("FIRSTTIMEOPENING", 1) == 1)
            {
                //if it's the first time, then it will notice and uncheck it for the next time
                PlayerPrefs.SetInt("FIRSTTIMEOPENING", 0);
                //this is used because the first time in the game the resolution will be 800x450 and graphics quality will be fastest
                xx = 800;
                yy = 450;
                QualitySettings.SetQualityLevel(0, true);
                //Level 0 of graphics quality settings: Fastest
            }
            else
            {
                //if it's not your first time opening the game, the code will read your last selected resolution/graphics quality
                xx = PlayerPrefs.GetInt("xResolution");
                yy = PlayerPrefs.GetInt("yResolution");
                graphicsQuality = PlayerPrefs.GetInt("GraphicsQuality");
                if (graphicsQuality == 0)
                {
                    QualitySettings.SetQualityLevel(0, true);
                }
                if (graphicsQuality == 1)
                {
                    QualitySettings.SetQualityLevel(2, true);
                }
                if (graphicsQuality == 2)
                {
                    QualitySettings.SetQualityLevel(3, true);
                }
                if (graphicsQuality == 3)
                {
                    QualitySettings.SetQualityLevel(5, true);
                }
            }
            Screen.SetResolution(xx, yy, true);
        }
    }

    //change the screen resolution with the buttons in the settings menu
    public void eightXfourfifty()
    {
        Screen.SetResolution(800, 450, true);
        //Screen resolution 800x450
        xx = 800;
        PlayerPrefs.SetInt("xResolution", xx);
        yy = 450;
        PlayerPrefs.SetInt("yResolution", yy);
    }
    public void twelveeightyXseventwenty()
    {
        Screen.SetResolution(1280, 720, true);
        //Screen resolution 1280x720 (HD)
        xx = 1280;
        PlayerPrefs.SetInt("xResolution", xx);
        yy = 720;
        PlayerPrefs.SetInt("yResolution", yy);
    }
    public void sixteenXnine()
    {
        Screen.SetResolution(1600, 900, true);
        //Screen resolution 1600x900
        xx = 1600;
        PlayerPrefs.SetInt("xResolution", xx);
        yy = 900;
        PlayerPrefs.SetInt("yResolution", yy);
    }
    public void ninetwentyXteneighty()
    {
        Screen.SetResolution(1920, 1080, true);
        //Screen resolution 1920x1080 (FHD)
        xx = 1920;
        PlayerPrefs.SetInt("xResolution", xx);
        yy = 1080;
        PlayerPrefs.SetInt("yResolution", yy);
    }

    //change the graphics quality level with the buttons in the settings menu
    public void Fastest()
    {
        graphicsQuality = 0;
        PlayerPrefs.SetInt("GraphicsQuality", graphicsQuality);
        QualitySettings.SetQualityLevel(0, true);
        //Level 0 of graphics quality settings: Fastest   
    }
    public void Normal()
    {
        graphicsQuality = 1;
        PlayerPrefs.SetInt("GraphicsQuality", graphicsQuality);
        QualitySettings.SetQualityLevel(2, true);
        //Level 2 of graphics quality settings: Simple
    }
    public void High()
    {
        graphicsQuality = 2;
        PlayerPrefs.SetInt("GraphicsQuality", graphicsQuality);
        QualitySettings.SetQualityLevel(3, true);
        //Level 3 of graphics quality settings: Good
    }
    public void Fantastic()
    {
        graphicsQuality = 3;
        PlayerPrefs.SetInt("GraphicsQuality", graphicsQuality);
        QualitySettings.SetQualityLevel(5, true);
        //Level 5 of graphics quality settings: Fantastic
    }
}