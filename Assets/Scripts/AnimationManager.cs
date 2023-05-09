using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    public GameObject topTextPanel;
    public GameObject bottomButtonPanel;
    Animator topTextPanelAnim;
    Animator bottomButtonPannelAnim;
    // Start is called before the first frame update
    void Start()
    {
        topTextPanelAnim = topTextPanel.GetComponent<Animator>();
        bottomButtonPannelAnim = bottomButtonPanel.GetComponent<Animator>();

        StartCoroutine(StartAnimations());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator StartAnimations()
    {
        yield return new WaitForSeconds(5);
        topTextPanelAnim.SetTrigger("TopTextPanelUp");
        bottomButtonPannelAnim.SetTrigger("PlayBottomButtonPanel");
    }
}
