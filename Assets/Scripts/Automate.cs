using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Automate : MonoBehaviour
{
    public static List<string> moveList = new List<string>() {"U", "U"};
    private CubeStatus cubeStatus;
    // Start is called before the first frame update
    void Start()
    {
        cubeStatus = FindObjectOfType<CubeStatus>();
    }

    // Update is called once per frame
    void Update()
    {
        if(moveList.Count > 0 && !CubeStatus.autoRotating && CubeStatus.started)
        {
            DoMove(moveList[0]);
            moveList.Remove(moveList[0]);
            //Debug.Log("gggggggggggggggggggggggggggggggg");
        }
    }

    void DoMove(string move)
    {
        CubeStatus.autoRotating = true;
        if(move == "U")
        {
            RotateSide(cubeStatus.up, -90);
            Debug.Log("gggggggggggggggggggggggggggggggg");
        }
    }

    public void RotateSide(List<GameObject> side, float angle)
    {
        PiviotRotation pr = side[4].transform.parent.GetComponent<PiviotRotation>();
        pr.StartAutoRotate(side, angle);
    }
}
