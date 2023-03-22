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
    private SelectFace selectFace;
    private CameraRaycast cameraRaycast;

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
        selectFace = GameObject.FindObjectOfType<SelectFace>();
        cameraRaycast = GameObject.FindObjectOfType<CameraRaycast>();
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
        
    if(layerRotateButtonManager.rightUp)
    {
        // if(side == cubeStatus.right)
        // {
            if(cameraRaycast.orangeSide || cameraRaycast.greenSide || cameraRaycast.whiteSide || cameraRaycast.yellowSide)
            {
                automate.DoMove("R");
                dragging = false;
                Debug.Log("1");
                layerRotateButtonManager.rightUp = false;
            }

            if(cameraRaycast.redSide)
            {
                automate.DoMove("B");
                dragging = false;
                Debug.Log("1");
                layerRotateButtonManager.rightUp = false;
            }

            if(cameraRaycast.blueSide)
            {
                automate.DoMove("F'");
                dragging = false;
                Debug.Log("1");
                layerRotateButtonManager.rightUp = false;
            }
            
        // }

        if(side == cubeStatus.left)
        {
            automate.DoMove("L");
            dragging = false;
            Debug.Log("2");
            layerRotateButtonManager.rightUp = false;
        }

        if(side == cubeStatus.up)
        {
            automate.DoMove("U");
            dragging = false;
            Debug.Log("3");
            layerRotateButtonManager.rightUp = false;
        }

        if(side == cubeStatus.down)
        {
            automate.DoMove("D");
            dragging = false;
            Debug.Log("4");
            layerRotateButtonManager.rightUp = false;
        }

        if(side == cubeStatus.front)
        {
            automate.DoMove("F");
            dragging = false;
            Debug.Log("5");
            layerRotateButtonManager.rightUp = false;
        }

        if(side == cubeStatus.back)
        {
            automate.DoMove("B");
            dragging = false;
            Debug.Log("6");
            layerRotateButtonManager.rightUp = false;
        }

        
    }

    if(layerRotateButtonManager.rightDown)
    {
        if(side == cubeStatus.right)
        {
            automate.DoMove("R'");
            dragging = false;
            Debug.Log("11");
            layerRotateButtonManager.rightDown = false;
        }

        if(side == cubeStatus.left)
        {
            automate.DoMove("L'");
            dragging = false;
            Debug.Log("12");
            layerRotateButtonManager.rightDown = false;
        }

        if(side == cubeStatus.up)
        {
            automate.DoMove("U'");
            dragging = false;
            Debug.Log("13");
            layerRotateButtonManager.rightDown = false;
        }

        if(side == cubeStatus.down)
        {
            automate.DoMove("D'");
            dragging = false;
            Debug.Log("14");
            layerRotateButtonManager.rightDown = false;
        }

        if(side == cubeStatus.front)
        {
            automate.DoMove("F'");
            dragging = false;
            Debug.Log("15");
            layerRotateButtonManager.rightDown = false;
        }

        if(side == cubeStatus.back)
        {
            automate.DoMove("B'");
            dragging = false;
            Debug.Log("16");
            layerRotateButtonManager.rightDown = false;
        }

        
    }

    if(layerRotateButtonManager.rightUpRight)
    {
        if(side == cubeStatus.right)
        {
            automate.DoMove("R'");
            dragging = false;
            Debug.Log("11");
            layerRotateButtonManager.rightUpRight = false;
        }

        if(side == cubeStatus.left)
        {
            automate.DoMove("L'");
            dragging = false;
            Debug.Log("12");
            layerRotateButtonManager.rightUpRight = false;
        }

        if(side == cubeStatus.up)
        {
            automate.DoMove("U'");
            dragging = false;
            Debug.Log("13");
            layerRotateButtonManager.rightUpRight = false;
        }

        if(side == cubeStatus.down)
        {
            automate.DoMove("D'");
            dragging = false;
            Debug.Log("14");
            layerRotateButtonManager.rightUpRight = false;
        }

        if(side == cubeStatus.front)
        {
            automate.DoMove("F'");
            dragging = false;
            Debug.Log("15");
            layerRotateButtonManager.rightUpRight = false;
        }

        if(side == cubeStatus.back)
        {
            automate.DoMove("B'");
            dragging = false;
            Debug.Log("16");
            layerRotateButtonManager.rightUpRight = false;
        }

        
    }

    if(layerRotateButtonManager.rightDownRight)
    {
        if(side == cubeStatus.right)
        {
            automate.DoMove("R");
            dragging = false;
            Debug.Log("11");
            layerRotateButtonManager.rightDownRight = false;
        }

        if(side == cubeStatus.left)
        {
            automate.DoMove("L");
            dragging = false;
            Debug.Log("12");
            layerRotateButtonManager.rightDownRight = false;
        }

        if(side == cubeStatus.up)
        {
            automate.DoMove("U");
            dragging = false;
            Debug.Log("13");
            layerRotateButtonManager.rightDownRight = false;
        }

        if(side == cubeStatus.down)
        {
            automate.DoMove("D");
            dragging = false;
            Debug.Log("14");
            layerRotateButtonManager.rightDownRight = false;
        }

        if(side == cubeStatus.front)
        {
            automate.DoMove("F");
            dragging = false;
            Debug.Log("15");
            layerRotateButtonManager.rightDownRight = false;
        }

        if(side == cubeStatus.back)
        {
            automate.DoMove("B");
            dragging = false;
            Debug.Log("16");
            layerRotateButtonManager.rightDownRight = false;
        }

        
    }

    if(layerRotateButtonManager.leftUp)
    {
        if(side == cubeStatus.right)
        {
            automate.DoMove("R'");
            dragging = false;
            Debug.Log("11");
            layerRotateButtonManager.leftUp = false;
        }

        if(side == cubeStatus.left)
        {
            automate.DoMove("L'");
            dragging = false;
            Debug.Log("12");
            layerRotateButtonManager.leftUp = false;
        }

        if(side == cubeStatus.up)
        {
            automate.DoMove("U'");
            dragging = false;
            Debug.Log("13");
            layerRotateButtonManager.leftUp = false;
        }

        if(side == cubeStatus.down)
        {
            automate.DoMove("D'");
            dragging = false;
            Debug.Log("14");
            layerRotateButtonManager.leftUp = false;
        }

        if(side == cubeStatus.front)
        {
            automate.DoMove("F'");
            dragging = false;
            Debug.Log("15");
            layerRotateButtonManager.leftUp = false;
        }

        if(side == cubeStatus.back)
        {
            automate.DoMove("B'");
            dragging = false;
            Debug.Log("16");
            layerRotateButtonManager.leftUp = false;
        }


        

        
    }

    if(layerRotateButtonManager.leftDown)
    {
        if(side == cubeStatus.right)
        {
            automate.DoMove("R");
            dragging = false;
            Debug.Log("11");
            layerRotateButtonManager.leftDown = false;
        }

        if(side == cubeStatus.left)
        {
            automate.DoMove("L");
            dragging = false;
            Debug.Log("12");
            layerRotateButtonManager.leftDown = false;
        }

        if(side == cubeStatus.up)
        {
            automate.DoMove("U");
            dragging = false;
            Debug.Log("13");
            layerRotateButtonManager.leftDown = false;
        }

        if(side == cubeStatus.down)
        {
            automate.DoMove("D");
            dragging = false;
            Debug.Log("14");
            layerRotateButtonManager.leftDown = false;
        }

        if(side == cubeStatus.front)
        {
            automate.DoMove("F");
            dragging = false;
            Debug.Log("15");
            layerRotateButtonManager.leftDown = false;
        }

        if(side == cubeStatus.back)
        {
            automate.DoMove("B");
            dragging = false;
            Debug.Log("16");
            layerRotateButtonManager.leftDown = false;
        }

        
    }


    if(layerRotateButtonManager.leftUpLeft)
    {
        if(side == cubeStatus.right)
        {
            automate.DoMove("R");
            dragging = false;
            Debug.Log("11");
            layerRotateButtonManager.leftUpLeft = false;
        }

        if(side == cubeStatus.left)
        {
            automate.DoMove("L");
            dragging = false;
            Debug.Log("12");
            layerRotateButtonManager.leftUpLeft = false;
        }

        if(side == cubeStatus.up)
        {
            automate.DoMove("U");
            dragging = false;
            Debug.Log("13");
            layerRotateButtonManager.leftUpLeft = false;
        }

        if(side == cubeStatus.down)
        {
            automate.DoMove("D");
            dragging = false;
            Debug.Log("14");
            layerRotateButtonManager.leftUpLeft = false;
        }

        if(side == cubeStatus.front)
        {
            automate.DoMove("F");
            dragging = false;
            Debug.Log("15");
            layerRotateButtonManager.leftUpLeft = false;
        }

        if(side == cubeStatus.back)
        {
            automate.DoMove("B");
            dragging = false;
            Debug.Log("16");
            layerRotateButtonManager.leftUpLeft = false;
        }

        
    }


    if(layerRotateButtonManager.leftDownLeft)
    {
        if(side == cubeStatus.right)
        {
            automate.DoMove("R'");
            dragging = false;
            Debug.Log("11");
            layerRotateButtonManager.leftDownLeft = false;
        }

        if(side == cubeStatus.left)
        {
            automate.DoMove("L'");
            dragging = false;
            Debug.Log("12");
            layerRotateButtonManager.leftDownLeft = false;
        }

        if(side == cubeStatus.up)
        {
            automate.DoMove("U'");
            dragging = false;
            Debug.Log("13");
            layerRotateButtonManager.leftDownLeft = false;
        }

        if(side == cubeStatus.down)
        {
            automate.DoMove("D'");
            dragging = false;
            Debug.Log("14");
            layerRotateButtonManager.leftDownLeft = false;
        }

        if(side == cubeStatus.front)
        {
            automate.DoMove("F'");
            dragging = false;
            Debug.Log("15");
            layerRotateButtonManager.leftDownLeft = false;
        }

        if(side == cubeStatus.back)
        {
            automate.DoMove("B'");
            dragging = false;
            Debug.Log("16");
            layerRotateButtonManager.leftDownLeft = false;
        }


        

        
    }


    


    
        
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
