using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VibrationManager : MonoBehaviour
{
    public void InstantVibration()
    {
        Vibration.Vibrate(10);
    }
}
