using UnityEngine;

public class MobileGraphicsSettings : MonoBehaviour
{
    public static int xx = 800, yy = 450, graphicsQuality;
    public Camera cam;

    void Start()
    {
        if (SystemInfo.deviceType == DeviceType.Handheld)
        {
            if (PlayerPrefs.GetInt("FIRSTTIMEOPENING", 1) == 1)
            {
                PlayerPrefs.SetInt("FIRSTTIMEOPENING", 0);
                xx = 800;
                yy = 450;
                QualitySettings.SetQualityLevel(0, true);
            }
            else
            {
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
    public void eightXfourfifty()
    {
        Screen.SetResolution(800, 450, true);
        xx = 800;
        PlayerPrefs.SetInt("xResolution", xx);
        yy = 450;
        PlayerPrefs.SetInt("yResolution", yy);
    }
    public void twelveeightyXseventwenty()
    {
        Screen.SetResolution(1280, 720, true);
        xx = 1280;
        PlayerPrefs.SetInt("xResolution", xx);
        yy = 720;
        PlayerPrefs.SetInt("yResolution", yy);
    }
    public void sixteenXnine()
    {
        Screen.SetResolution(1600, 900, true);
        xx = 1600;
        PlayerPrefs.SetInt("xResolution", xx);
        yy = 900;
        PlayerPrefs.SetInt("yResolution", yy);
    }
    public void ninetwentyXteneighty()
    {
        Screen.SetResolution(1920, 1080, true);
        xx = 1920;
        PlayerPrefs.SetInt("xResolution", xx);
        yy = 1080;
        PlayerPrefs.SetInt("yResolution", yy);
    }

    public void Fastest()
    {
        graphicsQuality = 0;
        PlayerPrefs.SetInt("GraphicsQuality", graphicsQuality);
        QualitySettings.SetQualityLevel(0, true);
    }
    public void Normal()
    {
        graphicsQuality = 1;
        PlayerPrefs.SetInt("GraphicsQuality", graphicsQuality);
        QualitySettings.SetQualityLevel(2, true);
    }
    public void High()
    {
        graphicsQuality = 2;
        PlayerPrefs.SetInt("GraphicsQuality", graphicsQuality);
        QualitySettings.SetQualityLevel(3, true);
    }
    public void Fantastic()
    {
        graphicsQuality = 3;
        PlayerPrefs.SetInt("GraphicsQuality", graphicsQuality);
        QualitySettings.SetQualityLevel(5, true);
    }
}