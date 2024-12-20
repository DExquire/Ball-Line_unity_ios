using TMPro;
using UnityEngine;

public class CoinsUI : MonoBehaviour
{
    public void Start()
    {
        UpdateCoinsText();
    }

    public void UpdateCoinsText()
    {
        GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetInt("HighScore").ToString();
    }
}
