using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class StopWatchTimer : MonoBehaviour
{
    public float timeStart;
    public float waitTime;
    public TMP_Text timeText;
    public bool startTimer = false;
    // Start is called before the first frame update
    void Start()
    {
        //timeText.text = timeStart.ToString("F2");
    }

    // Update is called once per frame
    void Update()
    {
        
        if(startTimer)
        {
            if(timeStart >= 0)
            {
                timeStart += Time.deltaTime;
                DisplayTime(timeStart);
            }
        }
        
    }

    public void StartCounter()
    {
        startTimer = true;
    }

    public void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minuits = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{00:00} : {01:00}", minuits, seconds);
    }

    public void PauseTimer()
    {
        startTimer = false;
    }

    public void ResumeTimer()
    {
        startTimer = true;
    }

    
}
