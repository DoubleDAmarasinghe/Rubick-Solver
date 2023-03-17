using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class StopWatchTimer : MonoBehaviour
{
    public float timeStart;
    public TMP_Text timeText;
    // Start is called before the first frame update
    void Start()
    {
        timeText.text = timeStart.ToString("F2");
    }

    // Update is called once per frame
    void Update()
    {
        timeStart += Time.deltaTime;
        timeText.text = timeStart.ToString("F2");
    }
}
