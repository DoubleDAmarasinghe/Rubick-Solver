using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VibrationManager : MonoBehaviour
{
    ToggleScript toggleScript;

    private void Start()
    {
        
        
        toggleScript = GameObject.FindGameObjectWithTag("Toggle3").GetComponent<ToggleScript>();
        toggleScript.OnSwitchButtonClickedVibrate();
        
    }
    public void InstantVibration()
    {
        if(toggleScript.switchStateVibrate == 1)
        {
            Vibration.Vibrate(10);
        }
        
    }
}
