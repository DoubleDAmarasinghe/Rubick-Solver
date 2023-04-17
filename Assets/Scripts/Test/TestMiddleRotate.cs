using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMiddleRotate : MonoBehaviour
{
    Automate automate;
    // Start is called before the first frame update
    void Start()
    {
        automate = GameObject.FindObjectOfType<Automate>();
    }

    // Update is called once per frame
    public void DoMidRotate()
    {
        automate.DoMove("U");
    }
}
