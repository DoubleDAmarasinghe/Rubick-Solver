using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    ToggleScript toggleScript;
    public AudioSource tapAudioSource;
    public AudioSource popupAudioSource;
    private void Start()
    {
        toggleScript = GameObject.FindGameObjectWithTag("Toggle1").GetComponent<ToggleScript>();
        toggleScript.OnSwitchButtonClickedAudio();
    }
    // Start is called before the first frame update
    public void PlayTapSound()
    {
        if(toggleScript.switchStateAudio == 1)
        {
            tapAudioSource.Play();
        }
        
    }

    public void PlayPopUpSound()
    {
        if(toggleScript.switchStateAudio == 1)
        {
            popupAudioSource.Play();
        }
        
    }
}
