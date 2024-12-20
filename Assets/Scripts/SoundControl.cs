using UnityEngine;

public class SoundControl : MonoBehaviour
{
    public void Start()
    {
        CheckSound();
    }

    private void Update()
    {
        SwitchSoundButton();
    }

    public void SwitchOnSound()
    {
        Camera.main.GetComponent<AudioListener>().enabled = !Camera.main.GetComponent<AudioListener>().isActiveAndEnabled;
        int isSoundOn = PlayerPrefs.GetInt("isSoundOn");
        if (isSoundOn == 1)
        {
            PlayerPrefs.SetInt("isSoundOn", 0);
        }
        else
        {
            PlayerPrefs.SetInt("isSoundOn", 1);

        }
    }

    public void SwitchSoundButton()
    {
        if (Camera.main.GetComponent<AudioListener>().isActiveAndEnabled)
        {
            transform.GetChild(1).gameObject.SetActive(false);
        }
        else
        {
            transform.GetChild(1).gameObject.SetActive(true);
        }
    }

    public void SoundOn()
    {
        Camera.main.GetComponent<AudioListener>().enabled = true;
        if (Camera.main.GetComponent<AudioListener>().isActiveAndEnabled)
        {
            transform.GetChild(1).gameObject.SetActive(false);
        }
        else
        {
            transform.GetChild(1).gameObject.SetActive(true);
        }
    }

    public void CheckSound()
    {
        int isSoundOn = PlayerPrefs.GetInt("isSoundOn");
        if (isSoundOn == 1)
        {
            Camera.main.GetComponent<AudioListener>().enabled = true;
            transform.GetChild(1).gameObject.SetActive(false);
        }
        else
        {
            Camera.main.GetComponent<AudioListener>().enabled = false;
            transform.GetChild(1).gameObject.SetActive(true);
        }
    }

}
