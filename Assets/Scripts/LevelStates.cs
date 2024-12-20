using UnityEngine;

public class LevelStates : MonoBehaviour
{
    public GameObject soundButton;
    public GameObject pauseScreen;

    public void PauseGame()
    {
        Time.timeScale = 0;
        pauseScreen.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        pauseScreen.SetActive(false);
    }

    public void SwitchSound(bool trig)
    {
        Camera.main.GetComponent<AudioSource>().mute = !trig;

        if (Camera.main.GetComponent<AudioSource>().mute == false)
        {
            soundButton.transform.GetChild(1).gameObject.SetActive(false);
        }
        else
        {
            soundButton.transform.GetChild(1).gameObject.SetActive(true);
        }
        
    }
}
