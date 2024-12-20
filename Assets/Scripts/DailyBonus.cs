using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DailyBonus : MonoBehaviour
{
    public Transform character;
    [Header("UI")]
    public TextMeshProUGUI coinsText;
    public Button getBonus;
    public Button stopButton;
    

    private void Start()
    {
        if(PlayerPrefs.GetString("bonusTime") != DateTime.Now.Day.ToString() || PlayerPrefs.GetString("bonusTime") == null)
        {
            getBonus.gameObject.SetActive(true);
            stopButton.gameObject.SetActive(false);
            character.GetChild(0).gameObject.SetActive(false);
            character.GetChild(1).gameObject.SetActive(true);
        }
        else
        {
            getBonus.gameObject.SetActive(false);
            stopButton.gameObject.SetActive(true);
            character.GetChild(0).gameObject.SetActive(true);
            character.GetChild(1).gameObject.SetActive(false);
        }
    }

    public void GetBonusPressed()
    {
        PlayerPrefs.SetString("bonusTime", DateTime.Now.Day.ToString());
        
        getBonus.gameObject.SetActive(false);
        stopButton.gameObject.SetActive(true);
        character.GetChild(0).gameObject.SetActive(true);
        character.GetChild(1).gameObject.SetActive(false);

        int newScore = PlayerPrefs.GetInt("HighScore") + 50;
        PlayerPrefs.SetInt("HighScore", newScore);

        UpdateCoinsText();
    }

    public void UpdateCoinsText()
    {

        int coins = PlayerPrefs.GetInt("HighScore");
        //print(coins);
        coinsText.text = coins.ToString();
    }
}
