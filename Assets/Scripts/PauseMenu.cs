using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static PauseMenu instance;

    [Header("Pause menu elements")]
    public GameObject pauseScreen;

    [Header("Pause menu logic")]
    public bool allowdInput = false;
    public bool setPause;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (setPause)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void SwitchInputOn()
    {
        allowdInput = true;
    }
    
    public void SwitchInputOff()
    {
        allowdInput = false;
    }

    public void Resume()
    {
        setPause = false;
        Time.timeScale = 1;
        pauseScreen.SetActive(setPause);

    }

    public void Pause()
    {
        setPause = true;
        Time.timeScale = 0;
        pauseScreen.SetActive(setPause);
    }

    public void ReloadCurScene()
    {
        string curScene = SceneManager.GetActiveScene().name;

        SceneManager.LoadScene(curScene);
    }

    public void LoadMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }
}
