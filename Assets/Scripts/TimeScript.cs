using UnityEngine;

public class TimeScript : MonoBehaviour
{
    public GameObject PauseMenu;
    public bool Paused;

    public void TimeScale0()
    {
        Time.timeScale = 0;
    }
    public void TimeScale1()
    {
        AudioListener.volume = 1f;
        Time.timeScale = 1;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ChangeState();
        }
        if (Input.GetKeyDown("tab"))
        {
            Time.timeScale = 3;
        }
    }
    public void Pause()
    {
        ChangeState();
    }
    private void ChangeState()
    {
        Paused = !Paused;
        if (Paused)
        {
           
            AudioListener.volume = 0f;
            Time.timeScale = 0;
            PauseMenu.SetActive(true); 
        }
        else
        {
            AudioListener.volume = 1f;
            Time.timeScale = 1;
            PauseMenu.SetActive(false); 
        }
    }
}
