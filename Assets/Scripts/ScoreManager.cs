using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI score;

    private void OnEnable()
    {
        SetScore();
    }

    public void SetScore()
    {
        score.text = PlayerPrefs.GetInt("HighScore").ToString();
    }
}
