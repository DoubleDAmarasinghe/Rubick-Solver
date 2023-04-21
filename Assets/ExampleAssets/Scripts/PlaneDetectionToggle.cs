using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARPlaneManager))]
public class PlaneDetectionToggle : MonoBehaviour
{
    public static PlaneDetectionToggle Instance;
    private ARPlaneManager planeManager;

    public TMP_Text toggleButtonText;
    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
        planeManager = GetComponent<ARPlaneManager>();
        toggleButtonText.text = "Disable";
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TogglePlaneDetection()
    {
        planeManager.enabled = !planeManager.enabled;
        string toggleButtonMessage = "";
        if (planeManager.enabled)
        {
            toggleButtonMessage = "Disable";
            SetAllPlanesActive(true);
        }
        else
        {
            toggleButtonMessage = "Enable";
            SetAllPlanesActive(false);
        }
        toggleButtonText.text = toggleButtonMessage;
    }

    public void SetAllPlanesActive(bool value)
    {
        foreach (var plane in planeManager.trackables)
        {
            plane.gameObject.SetActive(value);
        }
    }
}
