using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    public static BallController instance;
    private bool isTimerRunning = true; 
    private int coinsAmount = 0;
    public int livesCount;

    public GameObject winScreen;
    public GameObject loseScreen;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timerText;
    public int currentTime = 60;

    private Image ballSkin;
    public Sprite defaultSprite;

    public List<Sprite> ballSkins;

    public float startPos;
    public float finishYPos;

    public PhysicsMaterial2D physicsMaterial;

    public bool isWin;
    public bool isLose;

    public void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        if (scoreText != null)
        {
            coinsAmount = PlayerPrefs.GetInt("HighScore", 0);
            scoreText.text = coinsAmount.ToString();
        }

        ballSkin = transform.GetChild(0).GetComponent<Image>();
        int buyValue = PlayerPrefs.GetInt("skinIndex", 0);


        ballSkin.sprite = ballSkins[buyValue];

        BeginTimer();
    }

    private void Update()
    {
        FreezeYPos();
        if(currentTime == 0 && !isWin)
        {
            GetComponent<Rigidbody2D>().gravityScale = 0;
            GetComponent<Rigidbody2D>().isKinematic = true;
            isLose = true;
            loseScreen.SetActive(true);
        }
    }

    public void FreezeYPos()
    {
        if (transform.GetComponent<RectTransform>().anchoredPosition.y >= startPos)
        {
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        }

        if (transform.GetComponent<RectTransform>().anchoredPosition.y <= finishYPos)
        {
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;
        }
    }

    void BeginTimer()
    {
        StartCoroutine(CountdownTime());
    }

    IEnumerator CountdownTime()
    {
        while (currentTime > 0 && isTimerRunning && !isWin && !isLose)
        {
            yield return new WaitForSeconds(1f);
            timerText.text = currentTime.ToString();
            
            currentTime--;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Obstacle" && isTimerRunning)
        {
            PlayerPrefs.SetInt("lastLevel", SceneManager.GetActiveScene().buildIndex);
            livesCount-=1;

            if(livesCount == 0 && !isWin)
            {
                GetComponent<Rigidbody2D>().gravityScale = 0;
                isLose = true;
                loseScreen.SetActive(true);
            }
        }

        if (collision.gameObject.tag == "Gates" && isTimerRunning)
        {
            isTimerRunning = false;

            PlayerPrefs.SetInt("HighScore", coinsAmount);
            PlayerPrefs.Save();
            Debug.Log("HighScore: " + coinsAmount);

            coinsAmount = PlayerPrefs.GetInt("HighScore");
            coinsAmount += Mathf.FloorToInt(currentTime);
            if (!isLose)
            {
                WinScreenOpen();
            }
        }
    }

    void WinScreenOpen()
    {
        isWin = true;
        int newScore = PlayerPrefs.GetInt("HighScore") + 30;
        PlayerPrefs.SetInt("HighScore", newScore);
        scoreText.text = PlayerPrefs.GetInt("HighScore").ToString();
        GetComponent<Rigidbody2D>().gravityScale = 0;
        GetComponent<Rigidbody2D>().isKinematic = true;
        winScreen.SetActive(true);
    }
}