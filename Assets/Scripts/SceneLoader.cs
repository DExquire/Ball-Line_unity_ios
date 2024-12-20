using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadLevel(int lvlNum)
    {
        SceneManager.LoadScene(lvlNum);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
