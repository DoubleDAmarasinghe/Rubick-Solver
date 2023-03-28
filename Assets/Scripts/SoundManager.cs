using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource tapAudioSource;
    public AudioSource popupAudioSource;
    // Start is called before the first frame update
    public void PlayTapSound()
    {
        tapAudioSource.Play();
    }

    public void PlayPopUpSound()
    {
        popupAudioSource.Play();
    }
}
