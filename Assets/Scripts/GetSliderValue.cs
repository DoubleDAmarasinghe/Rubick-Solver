using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GetSliderValue : MonoBehaviour
{
    [SerializeField] Slider heightSlider;
    [SerializeField] TMP_Text sampleText;
    public float changedHeight;
    // Start is called before the first frame update
    void Start()
    {
        heightSlider.onValueChanged.AddListener((height) => {
            changedHeight = height;
        });
    }

    // Update is called once per frame
    void Update()
    {
        sampleText.text = changedHeight.ToString();
    }
}
