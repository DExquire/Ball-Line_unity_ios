using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundButtons : MonoBehaviour
{
    public List<Button> soundButtons;

    public void SwitchAllButtons()
    {
        foreach (Button soundBtn in soundButtons)
        {
            soundBtn.transform.GetChild(1).gameObject.SetActive(Camera.main.GetComponent<AudioListener>().isActiveAndEnabled);
        }
    }
}
