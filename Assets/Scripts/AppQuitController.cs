using UnityEngine;

public class AppQuitController : MonoBehaviour
{
    public static AppQuitController loading;

    private void Start()
    {
        if (loading != null)
        {
            Destroy(gameObject);
        }
        else
        {
            loading = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    
    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("loadingIsShown", 0);
    }
}
