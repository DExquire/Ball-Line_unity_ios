using TMPro;
using UnityEngine;

public class CoinsText : MonoBehaviour
{
    public TextMeshProUGUI coinsText;

    private void Start()
    {
        UpdateCoinsText();
    }

    public void UpdateCoinsText()
    {
        int coins = PlayerPrefs.GetInt("HighScore");
        coinsText.text = coins.ToString();
    }
}
