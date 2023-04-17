using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.XR.ARSubsystems;
// using UnityEngine.XR.ARFoundation;
using UnityEngine.XR;
using UnityEngine.Subsystems;
using TMPro;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.XR.Management;

public class CheckARStatus : MonoBehaviour
{
    [SerializeField] TMP_Text text1;
    [SerializeField] TMP_Text text2;
   
    void Start()
    {
        
    }
   
public void CheckAR()
    {
        List<XRRaycastSubsystem> subsystems = new List<XRRaycastSubsystem>();
        SubsystemManager.GetInstances(subsystems);
        // if (XRSettings.supportsAR)
        if(subsystems.Count > 0)
        {
            text1.text = "AR not Supported";
            Application.LoadLevel(2);
        }
        else
        {
            text2.text = "AR Supported";
            Application.LoadLevel(1);
        }

    }

    // public void CheckAR2()
    // {
    //     if (SubsystemManager.supportsAR)
    //     {
    //         Debug.Log("Device hardware supports AR");
    //     }
    //     else
    //     {
    //         Debug.Log("Device hardware does not support AR");
    //     }

    // }

    public void CheckAR3()
    {
        // Get the current XR configuration
        XRGeneralSettings xrSettings = XRGeneralSettings.Instance;

        // Check if the current XR configuration supports AR
        if (xrSettings?.Manager?.activeLoader?.GetLoadedSubsystem<XRSessionSubsystem>() != null)
        {
            
            text1.text = "AR not Supported";
        }
        else
        {
            text2.text = "AR Supported";
            
        }
    }


    public void CheckAR4()
    {
        // Get the current XR configuration
        XRGeneralSettings xrSettings = XRGeneralSettings.Instance;

        // Check if the current XR configuration supports AR
        if (xrSettings?.Manager?.activeLoader != null)
        {
            var sessionSubsystem = xrSettings.Manager.activeLoader.GetLoadedSubsystem<XRSessionSubsystem>();
            if (sessionSubsystem != null)
            {
                Debug.Log("AR is supported on this device");
                text2.text = "AR Supported";
            }
            else
            {
                Debug.Log("AR is not supported on this device");
                text1.text = "AR not Supported";
            }
        }
        else
        {
            Debug.Log("No XR loader is active. AR may not be supported on this device.");
        }
    }
    void Update()
    {
        
    }
}
