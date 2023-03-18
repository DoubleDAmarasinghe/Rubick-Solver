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
    // Start is called before the first frame update
    void Start()
    {
        timeText.text = timeStart.ToString("F2");
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(TimeCounter());
    }

    IEnumerator TimeCounter()
    {
        yield return new WaitForSeconds(waitTime);
        timeStart += Time.deltaTime;
        timeText.text = timeStart.ToString("F2");
    }
}
