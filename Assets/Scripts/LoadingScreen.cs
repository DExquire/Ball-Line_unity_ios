using System.Collections;
using UnityEngine;

public class LoadingScreen : MonoBehaviour
{
    private static LoadingScreen loading;
    private int isShown;
    public GameObject loadingScreen;

    void Start()
    {
        isShown = PlayerPrefs.GetInt("loadingIsShown");
        if (isShown == 0)
        {
            StartCoroutine(nameof(SwitchLoadingScreen));
        }
        
        if(isShown == 1)
        {
            SwitchLoadingScrnOff();
        }
    }

    void SwitchLoadingScrnOff()
    {
        loadingScreen.SetActive(false);
        PlayerPrefs.SetInt("loadingIsShown", 1);
        isShown = 1;
    }

    private IEnumerator SwitchLoadingScreen()
    {
        yield return new WaitForSecondsRealtime(2);
        SwitchLoadingScrnOff();   
    }
}
