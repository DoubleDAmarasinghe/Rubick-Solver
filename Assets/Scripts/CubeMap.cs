using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubeMap : MonoBehaviour
{
    CubeStatus cubeStatus;
    public Transform up;
    public Transform down;
    public Transform left;
    public Transform right;
    public Transform front;
    public Transform back;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetColor()
    {
        cubeStatus = GameObject.FindObjectOfType<CubeStatus>();
        UpdateMap(cubeStatus.left, left);
        UpdateMap(cubeStatus.right, right);
        UpdateMap(cubeStatus.up, up);
        UpdateMap(cubeStatus.down, down);
        UpdateMap(cubeStatus.front, front);
        UpdateMap(cubeStatus.back, back);
    }

    void UpdateMap(List<GameObject> face, Transform side)
    {
        Debug.Log(face[1].name[0]);
        
        int i = 0;
        foreach (Transform map in side)
        {
            if (face[i].name[0] == 'F')
            {
                map.GetComponent<Image>().color = new Color(1, 0.5f, 0, 1);
            }
            if (face[i].name[0] == 'B')
            {
                map.GetComponent<Image>().color = Color.red;
            }
            if (face[i].name[0] == 'U')
            {
                map.GetComponent<Image>().color = Color.yellow;
            }
            if (face[i].name[0] == 'D')
            {
                map.GetComponent<Image>().color = Color.white;
            }
            if (face[i].name[0] == 'L')
            {
                map.GetComponent<Image>().color = Color.green;
            }
            if (face[i].name[0] == 'R')
            {
                map.GetComponent<Image>().color = Color.blue;
            }
            i++;


        }
    }
}
