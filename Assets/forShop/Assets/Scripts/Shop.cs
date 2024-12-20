using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

public class Shop : MonoBehaviour
{
	#region Singlton:Shop

	public static Shop Instance;

	[SerializeField] TextMeshProUGUI[] allCoinsUIText;

	public int Coins;

	void Awake ()
	{
		if (Instance == null)
		{
			Instance = this;
		//	DontDestroyOnLoad(gameObject);
		}
		else
			Destroy(gameObject);
	}

	#endregion

	[System.Serializable] public class ShopItem
	{
		public Sprite Image;
		public int Price;
		public bool IsPurchased = false;
	}

	public List<ShopItem> ShopItemsList;
	Animator NoCoinsAnim;
 

	[SerializeField] GameObject ItemTemplate;
	GameObject g;
	[SerializeField] Transform ShopScrollView;
	[SerializeField] GameObject ShopPanel;
	[SerializeField] Button buyBtn;
	[SerializeField] Button setBtn;
	string purchased;

	public GameObject notEnoughCoinsPopup;
	public GameObject bouhgtSkinPopup;

	void Start ()
	{
		purchased = PlayerPrefs.GetString("bought");
		print("purchased " + PlayerPrefs.GetString("bought"));
		int len = ShopItemsList.Count;
		for (int i = 0; i < len; i++) {
			g = Instantiate (ItemTemplate, ShopScrollView);
			g.transform.GetChild (1).GetComponent <Image> ().sprite = ShopItemsList [i].Image;
			g.transform.GetChild (2).GetChild (1).GetComponent <TextMeshProUGUI> ().text = ShopItemsList [i].Price.ToString ();
			buyBtn = g.transform.GetChild (3).GetComponent <Button> ();
			setBtn = g.transform.GetChild(4).GetComponent<Button>();
			if (purchased.Contains(i.ToString()))
            {
				ShopItemsList[i].IsPurchased = true;
            }
			if (ShopItemsList[i].IsPurchased)
			{
				DisableBuyButton();
				EnableSetButton(i);
				if (!PlayerPrefs.GetString("bought").Contains(i.ToString()))
				{
					purchased += i.ToString();
					PlayerPrefs.SetString("bought", purchased);
				}
			}
			else
			{
				DisableSetButton();
			}
			buyBtn.AddEventListener (i, OnShopItemBtnClicked);
			setBtn.AddEventListener(i, OnSetSkinBtnClicked);
		}
		CheckSetSkin();

		UpdateAllCoinsUIText();

	}

	void OnShopItemBtnClicked (int itemIndex)
	{
		if (HasEnoughCoins (ShopItemsList [itemIndex].Price)) {
			UseCoins (ShopItemsList [itemIndex].Price);
			//purchase Item
			ShopItemsList [itemIndex].IsPurchased = true;

			//disable the button
			buyBtn = ShopScrollView.GetChild (itemIndex).GetChild (3).GetComponent <Button> ();
			DisableBuyButton ();
			EnableSetButton(itemIndex);
			//change UI text: coins
			UpdateAllCoinsUIText ();

			purchased += itemIndex.ToString();
			PlayerPrefs.SetString("bought", purchased);
			bouhgtSkinPopup.SetActive(true);
		} else {
			notEnoughCoinsPopup.SetActive(true);
		}
	}

	void CheckSetSkin()
    {
		int setSkin = PlayerPrefs.GetInt("skinIndex");
		if (ShopScrollView != null)
		{
			foreach (Transform item in ShopScrollView)
			{
				if (item.GetSiblingIndex() == setSkin)
				{
					item.GetChild(4).gameObject.SetActive(false);
				}
			}
		}
    }

	void OnSetSkinBtnClicked(int itemIndex)
    {
		ShopScrollView.GetChild(PlayerPrefs.GetInt("skinIndex")).GetChild(4).gameObject.SetActive(true);
		ShopScrollView.GetChild(itemIndex).GetChild(4).gameObject.SetActive(false);

		PlayerPrefs.SetInt("skinIndex", itemIndex);
    }

	void DisableBuyButton ()
	{
		buyBtn.interactable = false;
	}

	void EnableSetButton(int btnNumber)
	{
		ShopScrollView.GetChild(btnNumber).GetChild(4).GetComponent<Button>().interactable = true;
	}

	void DisableSetButton()
	{
		setBtn.interactable = false;
	}

	/*---------------------Open & Close shop--------------------------*/
	public void OpenShop ()
	{
		ShopPanel.SetActive (true);
	}

	public void CloseShop ()
	{
		ShopPanel.SetActive (false);
	}

	//coin

	public void UseCoins(int amount)
	{
		Coins -= amount;
		PlayerPrefs.SetInt("HighScore", Coins);
	}

	public bool HasEnoughCoins(int amount)
	{
		return (Coins >= amount);
	}

	public void UpdateAllCoinsUIText()
	{

		Coins = PlayerPrefs.GetInt("HighScore");
		print(Coins);
		for (int i = 0; i < allCoinsUIText.Length; i++)
		{
			allCoinsUIText[i].text = Coins.ToString();
		}
	}

}
