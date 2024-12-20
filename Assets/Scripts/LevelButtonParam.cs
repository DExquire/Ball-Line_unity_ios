using UnityEngine;

public class LevelButtonParam : MonoBehaviour
{
    public int levelNum;
    public ScreenController screenController;

    public void LevelButtonPressed()
    {
        screenController.selectedLevel = levelNum;
    }
}
