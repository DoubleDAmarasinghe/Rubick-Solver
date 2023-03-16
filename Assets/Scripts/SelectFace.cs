using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectFace : MonoBehaviour
{
    CubeStatus cubeStatus;
    ReadCube readCube;
int layerMask = 1 << 6;
    // Start is called before the first frame update
    void Start()
    {
        readCube = FindObjectOfType<ReadCube>();
        cubeStatus = FindObjectOfType<CubeStatus>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            // readCube.ReadState();
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out hit, 100.0f, layerMask))
            {
                GameObject face = hit.collider.gameObject;
                List<List<GameObject>> cubeSides = new List<List<GameObject>>()
                {
                    cubeStatus.up,
                    cubeStatus.down,
                    cubeStatus.left,
                    cubeStatus.right,
                    cubeStatus.front,
                    cubeStatus.back,
                };

                foreach(List<GameObject> cubeSide in cubeSides)
                {
                    if(cubeSide.Contains(face))
                    {
                        cubeStatus.PickUp(cubeSide);
                    }
                }
            }
        }
    }
}
