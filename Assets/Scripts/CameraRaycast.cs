using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRaycast : MonoBehaviour
{
    private  int layerMask_red = 1 << 7;
    private  int layerMask_blue = 1 << 8;
    public GameObject arCamera;
    public GameObject controllerArrows;

    public GameObject redSideMesh;
    public GameObject blueSideMesh;
    bool redSide = false;
    bool blueSide = false;
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 startPosition = arCamera.transform.position;
        RaycastHit hit;
        //startPosition.z = 100f;
        //startPosition = arCamera.ScreenToWorldPoint(startPosition);
        Ray rayFromFront = new Ray(arCamera.transform.position, arCamera.transform.forward);
        if(Physics.Raycast(rayFromFront, out hit, 10000f, layerMask_red) && !redSide)
        {
            //controllerArrows.transform.position = redSideMesh.transform.position;
            //controllerArrows.transform.rotation = redSideMesh.transform.rotation;
            controllerArrows.transform.rotation = redSideMesh.transform.rotation;
            //controllerArrows.transform.Rotate(0,90,0,Space.World);
            Debug.Log("RedSide");
            //controllerArrows.transform.Rotate(0,90,0,Space.World);
            redSide = true;
            blueSide = false;
        }

        if(Physics.Raycast(rayFromFront, out hit, 10000f, layerMask_blue) && !blueSide)
        {
            //controllerArrows.transform.Rotate(0,-90,0,Space.World);
            controllerArrows.transform.rotation = blueSideMesh.transform.rotation;
            //controllerArrows.transform.Rotate(0,-90,0,Space.World);
            Debug.Log("BlueSide");
            blueSide = true;
            redSide = false;
        }

        Debug.DrawRay(arCamera.transform.position, arCamera.transform.forward,Color.green);
    }
}
