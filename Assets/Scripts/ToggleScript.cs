using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class ToggleScript : MonoBehaviour
{
    [HideInInspector]
    public int switchStateAudio = 1;
    [HideInInspector]
    public int switchStateEffects = 1;
    [HideInInspector]
    public int switchStateVibrate = 1;
    public GameObject switchBtn;
    [HideInInspector]
    public bool toggleEnabledAudio;
    public bool toggleEnabledVibrate;
  
    private void start()
    {   
        
    }
    public void OnSwitchButtonClickedAudio()
    {
        switchBtn.transform.DOLocalMoveX(-switchBtn.transform.localPosition.x,0.2f);
        switchStateAudio = Math.Sign(-switchBtn.transform.localPosition.x);
        
        
    }

    public void OnSwitchButtonClickedEffect()
    {
        switchBtn.transform.DOLocalMoveX(-switchBtn.transform.localPosition.x,0.2f);
        switchStateEffects = Math.Sign(-switchBtn.transform.localPosition.x);
        
    }

    public void OnSwitchButtonClickedVibrate()
    {
        switchBtn.transform.DOLocalMoveX(-switchBtn.transform.localPosition.x,0.2f);
        switchStateVibrate = Math.Sign(-switchBtn.transform.localPosition.x);
        
    }
}
