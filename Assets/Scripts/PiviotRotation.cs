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
    private Automate automate;

    private LayerRotateButtonManager layerRotateButtonManager;

    private float sesivity = 0.4f;
    private Vector3 rotation;

    private Quaternion targetQuaternion;
    private bool autoRotating = false;

    // Start is called before the first frame update
    void Start()
    {
        readCube = GameObject.FindObjectOfType<ReadCube>();
        cubeStatus = GameObject.FindObjectOfType<CubeStatus>();
        automate = GameObject.FindObjectOfType<Automate>();
        layerRotateButtonManager = GameObject.FindObjectOfType<LayerRotateButtonManager>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(dragging && !autoRotating)
        {
            SpinSide(activeSide);
            
            //RotateToRightAngle();
            // if(Input.GetMouseButtonUp(0))
            // {
            //     dragging = false;
            // }
            
        }
        if(autoRotating)
        {
            AutoRotate();
        }
        
    }

    private void SpinSide(List<GameObject> side)
    {
        rotation = Vector3.zero;
        //Vector3 mouseoffset = (Input.mousePosition - mouseRef);
        if(side == cubeStatus.right && layerRotateButtonManager.positiveDirection == true)
        {
            //rotation.x = 90;
            //transform.Rotate(50, 0, 0, Space.World);
            //dragging = false;
            //automate.RotateSide(cubeStatus.front, -90);
            automate.DoMove("R");
            dragging = false;
    
        }

        if(side == cubeStatus.right && layerRotateButtonManager.positiveDirection == false)
        {
            //rotation.x = (90) * sesivity * -1;
            // automate.RotateSide(cubeStatus.front, 90);
            automate.DoMove("R'");
            dragging = false;
        }




        if(side == cubeStatus.left && layerRotateButtonManager.positiveDirection == true)
        {
            //rotation.x = (90) * sesivity * -1;
            // transform.Rotate(90, 0, 0, Space.World);
            // dragging = false;
            // automate.RotateSide(cubeStatus.back, 90);
            automate.DoMove("L'");
            dragging = false;
            
        }

        if(side == cubeStatus.left && layerRotateButtonManager.positiveDirection == false)
        {
            //rotation.x = (90) * sesivity * -1;
            // transform.Rotate(-90, 0, 0, Space.World);
            // dragging = false;
            // automate.RotateSide(cubeStatus.back, -90);
            automate.DoMove("L");
            dragging = false;
            
        }




        if(side == cubeStatus.up && layerRotateButtonManager.positiveDirection == true)
        {
            //rotation.x = (90) * sesivity * -1;
            // automate.RotateSide(cubeStatus.up, -90);
            automate.DoMove("U");
            dragging = false;
        }

        if(side == cubeStatus.up && layerRotateButtonManager.positiveDirection == false)
        {
            //rotation.x = (90) * sesivity * -1;
            // automate.RotateSide(cubeStatus.up, 90);
            automate.DoMove("U'");
            dragging = false;
        }



        if(side == cubeStatus.down && layerRotateButtonManager.positiveDirection == true)
        {
            //rotation.x = (90) * sesivity * -1;
            // automate.RotateSide(cubeStatus.down, 90);
            automate.DoMove("D'");
            dragging = false;
        }

        if(side == cubeStatus.down && layerRotateButtonManager.positiveDirection == false)
        {
            //rotation.x = (90) * sesivity * -1;
            // automate.RotateSide(cubeStatus.down, -90);
            automate.DoMove("D");
            dragging = false;
        }

        transform.Rotate(rotation, Space.Self);
        mouseRef = Input.mousePosition;
    }

    public void Rotate(List<GameObject> side)
    {
        activeSide = side;
        //mouseRef = Input.mousePosition;
        dragging = true;
        localForward = Vector3.zero - side[4].transform.parent.transform.localPosition;
    }

    public void StartAutoRotate(List<GameObject> side, float angle)
    {
        cubeStatus.PickUp(side);
        Vector3 localForward = Vector3.zero - side[4].transform.parent.transform.localPosition;
        targetQuaternion = Quaternion.AngleAxis(angle, localForward) * transform.localRotation;

        

        activeSide = side;
        autoRotating = true;
    }


    public void RotateToRightAngle()
    {
        Vector3 vec = transform.localEulerAngles;
        vec.x = Mathf.Round(vec.x/90) * 90;
        vec.y = Mathf.Round(vec.y/90) * 90;
        vec.z = Mathf.Round(vec.z/90) * 90;

        targetQuaternion.eulerAngles = vec;
        autoRotating = true;

    }

    private void AutoRotate()
    {
        dragging = false;
        transform.localRotation = Quaternion.RotateTowards(transform.localRotation, targetQuaternion, 300*Time.deltaTime);

        if(Quaternion.Angle(transform.localRotation, targetQuaternion) <= 1)
        {
            cubeStatus.PutDown(activeSide, transform.parent);
            readCube.ReadState();
            CubeStatus.autoRotating = false;
            autoRotating = false;
            dragging = false;
        }
    }
}
