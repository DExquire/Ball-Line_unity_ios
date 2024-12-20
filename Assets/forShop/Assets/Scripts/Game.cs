using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Game : MonoBehaviour
{
	#region Singleton:Game

	public static Game Instance;

	void Awake ()
	{
		if (Instance == null) {
			Instance = this;
			DontDestroyOnLoad (gameObject);
		} else {
			Destroy (gameObject);
		}
	}

	#endregion

	[SerializeField] TextMeshProUGUI[] allCoinsUIText;

	public int Coins;

	void Start ()
	{
		UpdateAllCoinsUIText ();
	}

	public void UseCoins (int amount)
	{
		Coins -= amount;
	//	PlayerPrefs.SetInt("coins", Coins);
		PlayerPrefs.SetInt("HighScore", Coins);
	}

	public bool HasEnoughCoins (int amount)
	{
		return (Coins >= amount);
	}

	public void UpdateAllCoinsUIText ()
	{

		Coins = PlayerPrefs.GetInt("HighScore");
		print(Coins);
		for (int i = 0; i < allCoinsUIText.Length; i++) {
			allCoinsUIText [i].text = Coins.ToString ();
		}
	}

}
