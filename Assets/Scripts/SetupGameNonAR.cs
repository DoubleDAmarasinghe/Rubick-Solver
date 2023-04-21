using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupGameNonAR : MonoBehaviour
{
    Automate automate;
    CubeRotationManager cubeRotationManager;

    Animator topTextPanelAnim;
    Animator startcountdownplay;
    Animator bottomButtonPannelAnim;
    PiviotRotation piviotRotation;

    public GameObject topTextPanel;
    public GameObject countDownTimer;
    public GameObject bottomButtonPanel;
    // Start is called before the first frame update
    void Start()
    {
        automate = GameObject.FindObjectOfType<Automate>();
        cubeRotationManager = GameObject.FindObjectOfType<CubeRotationManager>();
        topTextPanelAnim = topTextPanel.GetComponent<Animator>();
        startcountdownplay = countDownTimer.GetComponent<Animator>();
        bottomButtonPannelAnim = bottomButtonPanel.GetComponent<Animator>();
        piviotRotation = GameObject.FindObjectOfType<PiviotRotation>();


        StartCoroutine(automate.firstShuffle());
        cubeRotationManager.HideArrows(5.5f);
        topTextPanelAnim.SetTrigger("TopTextPanelUp");
        startcountdownplay.SetTrigger("PlayCountDown");
        bottomButtonPannelAnim.SetTrigger("PlayBottomButtonPanel");
        Debug.Log(FindObjectOfType<PiviotRotation>().name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
