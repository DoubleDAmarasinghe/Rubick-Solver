using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiviotRotation : MonoBehaviour
{
    private List<GameObject> activeSide;
    private Vector3 localForward;
    private Vector3 mouseRef;
    private bool dragging = false;

    private ReadCube readCube;
    private CubeStatus cubeStatus;

    private LayerRotateButtonManager layerRotateButtonManager;

    private float sesivity = 0.4f;
    private Vector3 rotation;

    private Quaternion targetRotation;
    

    // Start is called before the first frame update
    void Start()
    {
        readCube = GameObject.FindObjectOfType<ReadCube>();
        cubeStatus = GameObject.FindObjectOfType<CubeStatus>();
        layerRotateButtonManager = GameObject.FindObjectOfType<LayerRotateButtonManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(dragging)
        {
            SpinSide(activeSide);
            // if(Input.GetMouseButtonUp(0))
            // {
            //     dragging = false;
            // }
            
        }
        
    }

    private void SpinSide(List<GameObject> side)
    {
        rotation = Vector3.zero;
        //Vector3 mouseoffset = (Input.mousePosition - mouseRef);
        if(side == cubeStatus.front && layerRotateButtonManager.positiveDirection == true)
        {
            //rotation.x = 90;
            
            transform.Rotate(90, 0, 0, Space.World);
            dragging = false;
        }

        if(side == cubeStatus.front && layerRotateButtonManager.positiveDirection == false)
        {
            //rotation.x = (90) * sesivity * -1;
            transform.Rotate(-90, 0, 0, Space.World);
            dragging = false;
        }




        if(side == cubeStatus.back && layerRotateButtonManager.positiveDirection == true)
        {
            //rotation.x = (90) * sesivity * -1;
            transform.Rotate(90, 0, 0, Space.World);
            dragging = false;
        }

        if(side == cubeStatus.back && layerRotateButtonManager.positiveDirection == false)
        {
            //rotation.x = (90) * sesivity * -1;
            transform.Rotate(-90, 0, 0, Space.World);
            dragging = false;
        }




        if(side == cubeStatus.up && layerRotateButtonManager.positiveDirection == true)
        {
            //rotation.x = (90) * sesivity * -1;
            transform.Rotate(0, 90, 0, Space.World);
            dragging = false;
        }

        if(side == cubeStatus.up && layerRotateButtonManager.positiveDirection == false)
        {
            //rotation.x = (90) * sesivity * -1;
            transform.Rotate(0, -90, 0, Space.World);
            dragging = false;
        }



        if(side == cubeStatus.down && layerRotateButtonManager.positiveDirection == true)
        {
            //rotation.x = (90) * sesivity * -1;
            transform.Rotate(0, 90, 0, Space.World);
            dragging = false;
        }

        if(side == cubeStatus.down && layerRotateButtonManager.positiveDirection == false)
        {
            //rotation.x = (90) * sesivity * -1;
            transform.Rotate(0, -90, 0, Space.World);
            dragging = false;
        }

        //transform.Rotate(rotation, Space.Self);
        //mouseRef = Input.mousePosition;
    }

    public void Rotate(List<GameObject> side)
    {
        activeSide = side;
        //mouseRef = Input.mousePosition;
        dragging = true;
        localForward = Vector3.zero - side[4].transform.parent.transform.localPosition;
    }
}
