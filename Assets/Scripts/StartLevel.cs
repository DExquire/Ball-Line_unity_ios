using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartLevel : MonoBehaviour
{
    public GameObject splashScreen;
    public List<GameObject> gameElements;
    public GameObject ball;

    void Start()
    {
        foreach (GameObject gameElem in gameElements)
        {
            gameElem.SetActive(false);
        }
        ball.GetComponent<Rigidbody2D>().gravityScale = 0;
        StartCoroutine("SwitchLoadingScreen");
    }

    private IEnumerator SwitchLoadingScreen()
    {
        yield return new WaitForSecondsRealtime(2);
        SwitchLoadingScreenOff();

    }

    void SwitchLoadingScreenOff()
    {
        splashScreen.SetActive(false);
        foreach(GameObject gameElem in gameElements)
        {
            gameElem.SetActive(true);
        }
        StartCoroutine("SwitchOnBallGravity");
    }

    private IEnumerator SwitchOnBallGravity()
    {
        yield return new WaitForSecondsRealtime(2);
        SwitchBallGravityOn();

    }

    void SwitchBallGravityOn()
    {
        ball.GetComponent<Rigidbody2D>().gravityScale = 0.4f;
    }
}
