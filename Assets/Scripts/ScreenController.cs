using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScreenController : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject infoScreen;
    public GameObject questionsScreen;
    public GameObject shopScreen;
    public GameObject soundScreen;
    public GameObject startButton;
    public int selectedLevel;

    private void Start()
    {
        selectedLevel = 0;
    }

    public void Update()
    {
        if (startButton != null)
        {
            if (selectedLevel == 0)
            {
                startButton.GetComponent<Button>().interactable = false;
            }
            else
            {
                startButton.GetComponent<Button>().interactable = true;
            }
        }
    }

    public void LoadMap()
    {
        SceneManager.LoadScene(7);
    }

    public void SwitchInfoScreen()
    {
        SceneManager.LoadScene(10);
    }

    public void SwitchQuestionScreen()
    {
        SceneManager.LoadScene(11);
    }

    public void SwitchShopScreen()
    {

        SceneManager.LoadScene(8);
    }

    public void SwitchDailyScreen()
    {
        SceneManager.LoadScene(9);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(selectedLevel);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }
     
    public void ExitGame()
    {
        Application.Quit();
    }
}
