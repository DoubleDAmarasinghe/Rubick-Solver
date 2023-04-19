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

    private CubeRotationManager cubeRotationManager;

    // Start is called before the first frame update
    void Start()
    {
        readCube = GameObject.FindObjectOfType<ReadCube>();
        cubeStatus = GameObject.FindObjectOfType<CubeStatus>();
        automate = GameObject.FindObjectOfType<Automate>();
        layerRotateButtonManager = GameObject.FindObjectOfType<LayerRotateButtonManager>();
        selectFace = GameObject.FindObjectOfType<SelectFace>();
        cameraRaycast = GameObject.FindObjectOfType<CameraRaycast>();
        cubeRotationManager = GameObject.FindObjectOfType<CubeRotationManager>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(dragging && !autoRotating)
        {
            SpinSide(activeSide);
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
        if(side == cubeStatus.right)
        {
            automate.DoMove("R");
            dragging = false;
            layerRotateButtonManager.rightUp = false;
        }

        // if(side == cubeStatus.left)
        // {
        //     automate.DoMove("L");
        //     dragging = false;
        //     Debug.Log("2");
        //     layerRotateButtonManager.rightUp = false;
        // }

        // if(side == cubeStatus.up)
        // {
        //     automate.DoMove("L");
        //     dragging = false;
        //     Debug.Log("3");
        //     layerRotateButtonManager.rightUp = false;
        // }

        // if(side == cubeStatus.down)
        // {
        //     automate.DoMove("L");
        //     dragging = false;
        //     Debug.Log("4");
        //     layerRotateButtonManager.rightUp = false;
        // }

        // if(side == cubeStatus.front)
        // {
        //     automate.DoMove("B");
        //     dragging = false;
        //     Debug.Log("5");
        //     layerRotateButtonManager.rightUp = false;
        // }

        // if(side == cubeStatus.back)
        // {
        //     automate.DoMove("F");
        //     dragging = false;
        //     Debug.Log("6");
        //     layerRotateButtonManager.rightUp = false;
        // }

        
    }

    if(layerRotateButtonManager.rightDown)
    {
        if(side == cubeStatus.right)
        {
            automate.DoMove("R'");
            dragging = false;
            layerRotateButtonManager.rightDown = false;
        }

        // if(side == cubeStatus.left)
        // {
        //     automate.DoMove("L'");
        //     dragging = false;
        //     Debug.Log("12");
        //     layerRotateButtonManager.rightDown = false;
        // }

        // if(side == cubeStatus.up)
        // {
        //     automate.DoMove("R'");
        //     dragging = false;
        //     Debug.Log("13");
        //     layerRotateButtonManager.rightDown = false;
        // }

        // if(side == cubeStatus.down)
        // {
        //     automate.DoMove("R'");
        //     dragging = false;
        //     Debug.Log("14");
        //     layerRotateButtonManager.rightDown = false;
        // }

        // if(side == cubeStatus.front)
        // {
        //     automate.DoMove("B'");
        //     dragging = false;
        //     Debug.Log("15");
        //     layerRotateButtonManager.rightDown = false;
        // }

        // if(side == cubeStatus.back)
        // {
        //     automate.DoMove("F'");
        //     dragging = false;
        //     Debug.Log("16");
        //     layerRotateButtonManager.rightDown = false;
        // }

        
    }

    if(layerRotateButtonManager.rightUpRight)
    {
        if(side == cubeStatus.right)
        {
            automate.DoMove("U'");
            dragging = false;
            layerRotateButtonManager.rightUpRight = false;
        }

        // if(side == cubeStatus.left)
        // {
        //     automate.DoMove("U'");
        //     dragging = false;
        //     Debug.Log("12");
        //     layerRotateButtonManager.rightUpRight = false;
        // }

        // if(side == cubeStatus.up)
        // {
        //     automate.DoMove("B'");
        //     dragging = false;
        //     Debug.Log("13");
        //     layerRotateButtonManager.rightUpRight = false;
        // }

        // if(side == cubeStatus.down)
        // {
        //     automate.DoMove("F'");
        //     dragging = false;
        //     Debug.Log("14");
        //     layerRotateButtonManager.rightUpRight = false;
        // }

        // if(side == cubeStatus.front)
        // {
        //     automate.DoMove("U'");
        //     dragging = false;
        //     Debug.Log("15");
        //     layerRotateButtonManager.rightUpRight = false;
        // }

        // if(side == cubeStatus.back)
        // {
        //     automate.DoMove("U'");
        //     dragging = false;
        //     Debug.Log("16");
        //     layerRotateButtonManager.rightUpRight = false;
        // }

        
    }

    if(layerRotateButtonManager.rightDownRight)
    {
        if(side == cubeStatus.right)
        {
            automate.DoMove("D");
            dragging = false;
            layerRotateButtonManager.rightDownRight = false;
        }

        // if(side == cubeStatus.left)
        // {
        //     automate.DoMove("D");
        //     dragging = false;
        //     Debug.Log("12");
        //     layerRotateButtonManager.rightDownRight = false;
        // }

        // if(side == cubeStatus.up)
        // {
        //     automate.DoMove("F");
        //     dragging = false;
        //     Debug.Log("13");
        //     layerRotateButtonManager.rightDownRight = false;
        // }

        // if(side == cubeStatus.down)
        // {
        //     automate.DoMove("B");
        //     dragging = false;
        //     Debug.Log("14");
        //     layerRotateButtonManager.rightDownRight = false;
        // }

        // if(side == cubeStatus.front)
        // {
        //     automate.DoMove("D");
        //     dragging = false;
        //     Debug.Log("15");
        //     layerRotateButtonManager.rightDownRight = false;
        // }

        // if(side == cubeStatus.back)
        // {
        //     automate.DoMove("D");
        //     dragging = false;
        //     Debug.Log("16");
        //     layerRotateButtonManager.rightDownRight = false;
        // }

        
    }

    if(layerRotateButtonManager.leftUp)
    {
        if(side == cubeStatus.right)
        {
            automate.DoMove("L'");
            dragging = false;
            layerRotateButtonManager.leftUp = false;
        }

        // if(side == cubeStatus.left)
        // {
        //     automate.DoMove("R'");
        //     dragging = false;
        //     Debug.Log("12");
        //     layerRotateButtonManager.leftUp = false;
        // }

        // if(side == cubeStatus.up)
        // {
        //     automate.DoMove("L'");
        //     dragging = false;
        //     Debug.Log("13");
        //     layerRotateButtonManager.leftUp = false;
        // }

        // if(side == cubeStatus.down)
        // {
        //     automate.DoMove("L'");
        //     dragging = false;
        //     Debug.Log("14");
        //     layerRotateButtonManager.leftUp = false;
        // }

        // if(side == cubeStatus.front)
        // {
        //     automate.DoMove("F'");
        //     dragging = false;
        //     Debug.Log("15");
        //     layerRotateButtonManager.leftUp = false;
        // }

        // if(side == cubeStatus.back)
        // {
        //     automate.DoMove("B'");
        //     dragging = false;
        //     Debug.Log("16");
        //     layerRotateButtonManager.leftUp = false;
        // }


        

        
    }

    if(layerRotateButtonManager.leftDown)
    {
        if(side == cubeStatus.right)
        {
            automate.DoMove("L");
            dragging = false;
            layerRotateButtonManager.leftDown = false;
        }

        // if(side == cubeStatus.left)
        // {
        //     automate.DoMove("R");
        //     dragging = false;
        //     Debug.Log("12");
        //     layerRotateButtonManager.leftDown = false;
        // }

        // if(side == cubeStatus.up)
        // {
        //     automate.DoMove("L");
        //     dragging = false;
        //     Debug.Log("13");
        //     layerRotateButtonManager.leftDown = false;
        // }

        // if(side == cubeStatus.down)
        // {
        //     automate.DoMove("L");
        //     dragging = false;
        //     Debug.Log("14");
        //     layerRotateButtonManager.leftDown = false;
        // }

        // if(side == cubeStatus.front)
        // {
        //     automate.DoMove("F");
        //     dragging = false;
        //     Debug.Log("15");
        //     layerRotateButtonManager.leftDown = false;
        // }

        // if(side == cubeStatus.back)
        // {
        //     automate.DoMove("B");
        //     dragging = false;
        //     Debug.Log("16");
        //     layerRotateButtonManager.leftDown = false;
        // }

        
    }


    if(layerRotateButtonManager.leftUpLeft)
    {
        if(side == cubeStatus.right)
        {
            automate.DoMove("U");
            dragging = false;
            layerRotateButtonManager.leftUpLeft = false;
        }

        // if(side == cubeStatus.left)
        // {
        //     automate.DoMove("U");
        //     dragging = false;
        //     Debug.Log("12");
        //     layerRotateButtonManager.leftUpLeft = false;
        // }

        // if(side == cubeStatus.up)
        // {
        //     automate.DoMove("B");
        //     dragging = false;
        //     Debug.Log("13");
        //     layerRotateButtonManager.leftUpLeft = false;
        // }

        // if(side == cubeStatus.down)
        // {
        //     automate.DoMove("F");
        //     dragging = false;
        //     Debug.Log("14");
        //     layerRotateButtonManager.leftUpLeft = false;
        // }

        // if(side == cubeStatus.front)
        // {
        //     automate.DoMove("U");
        //     dragging = false;
        //     Debug.Log("15");
        //     layerRotateButtonManager.leftUpLeft = false;
        // }

        // if(side == cubeStatus.back)
        // {
        //     automate.DoMove("U");
        //     dragging = false;
        //     Debug.Log("16");
        //     layerRotateButtonManager.leftUpLeft = false;
        // }

        
    }


    if(layerRotateButtonManager.leftDownLeft)
    {
        if(side == cubeStatus.right)
        {
            automate.DoMove("D'");
            dragging = false;
            layerRotateButtonManager.leftDownLeft = false;
        }

        // if(side == cubeStatus.left)
        // {
        //     automate.DoMove("D'");
        //     dragging = false;
        //     Debug.Log("12");
        //     layerRotateButtonManager.leftDownLeft = false;
        // }

        // if(side == cubeStatus.up)
        // {
        //     automate.DoMove("F'");
        //     dragging = false;
        //     Debug.Log("13");
        //     layerRotateButtonManager.leftDownLeft = false;
        // }

        // if(side == cubeStatus.down)
        // {
        //     automate.DoMove("B'");
        //     dragging = false;
        //     Debug.Log("14");
        //     layerRotateButtonManager.leftDownLeft = false;
        // }

        // if(side == cubeStatus.front)
        // {
        //     automate.DoMove("D'");
        //     dragging = false;
        //     Debug.Log("15");
        //     layerRotateButtonManager.leftDownLeft = false;
        // }

        // if(side == cubeStatus.back)
        // {
        //     automate.DoMove("D'");
        //     dragging = false;
        //     Debug.Log("16");
        //     layerRotateButtonManager.leftDownLeft = false;
        // }


        

        
    }
/////////////////////////////////////////////////////////////////////////////////////////////////
    if (layerRotateButtonManager.midUp)
    {
        if(side == cubeStatus.right)
        {
            
            cubeRotationManager.RotateUp();
            automate.DoMove("R'");
            automate.DoMove("L");
            dragging = false;
            layerRotateButtonManager.midUp = false;
        }

        // if(side == cubeStatus.left)
        // {
            
        //     cubeRotationManager.RotateBottom();
        //     automate.DoMove("R");
        //     automate.DoMove("L'");
        //     dragging = false;
        //     Debug.Log("12");
        //     layerRotateButtonManager.midUp = false;
        // }

        // if(side == cubeStatus.up)
        // {
            
        //     cubeRotationManager.RotateUp();
        //     automate.DoMove("R'");
        //     automate.DoMove("L");
        //     dragging = false;
        //     Debug.Log("13");
        //     layerRotateButtonManager.midUp = false;
        // }

        // if(side == cubeStatus.down)
        // {
            
        //     cubeRotationManager.RotateUp();
        //     automate.DoMove("R'");
        //     automate.DoMove("L");
        //     dragging = false;
        //     Debug.Log("14");
        //     layerRotateButtonManager.midUp = false;
        // }

        // if(side == cubeStatus.front)
        // {
           
        //     cubeRotationManager.RotateLeft();
        //     automate.DoMove("F");
        //     automate.DoMove("B'");
        //     dragging = false;
        //     Debug.Log("15");
        //     layerRotateButtonManager.midUp = false;
        // }

        // if(side == cubeStatus.back)
        // {
           
        //     cubeRotationManager.RotateRight();
        //     automate.DoMove("F'");
        //     automate.DoMove("B");
        //     dragging = false;
        //     Debug.Log("16");
        //     layerRotateButtonManager.midUp = false;
        // }
    }

///////////////////////////////////////////////////////////////////////////////////
if (layerRotateButtonManager.midDown)
    {
        if(side == cubeStatus.right)
        {
            
            cubeRotationManager.RotateBottom();
            automate.DoMove("R");
            automate.DoMove("L'");
            dragging = false;
            layerRotateButtonManager.midDown = false;
        }

        // if(side == cubeStatus.left)
        // {
            
        //     cubeRotationManager.RotateUp();
        //     automate.DoMove("R'");
        //     automate.DoMove("L");
        //     dragging = false;
        //     Debug.Log("11");
        //     layerRotateButtonManager.midDown = false;
        // }

        // if(side == cubeStatus.up)
        // {
            
        //     cubeRotationManager.RotateBottom();
        //     automate.DoMove("R");
        //     automate.DoMove("L'");
        //     dragging = false;
        //     Debug.Log("11");
        //     layerRotateButtonManager.midDown = false;
        // }

        // if(side == cubeStatus.down)
        // {
            
        //     cubeRotationManager.RotateBottom();
        //     automate.DoMove("R");
        //     automate.DoMove("L'");
        //     dragging = false;
        //     Debug.Log("11");
        //     layerRotateButtonManager.midDown = false;
        // }

        // if(side == cubeStatus.front)
        // {
           
        //     cubeRotationManager.RotateRight();
        //     automate.DoMove("F'");
        //     automate.DoMove("B");
        //     dragging = false;
        //     Debug.Log("11");
        //     layerRotateButtonManager.midDown = false;
        // }

        // if(side == cubeStatus.back)
        // {
           
        //     cubeRotationManager.RotateLeft();
        //     automate.DoMove("F");
        //     automate.DoMove("B'");
        //     dragging = false;
        //     Debug.Log("11");
        //     layerRotateButtonManager.midDown = false;
        // }
    }    

//////////////////////////////////////////////////////////////////////
if (layerRotateButtonManager.midRight)
    {
        if(side == cubeStatus.right)
        {
            
            cubeRotationManager.RotateRight();
            automate.DoMove("U");
            automate.DoMove("D'");
            dragging = false;
            layerRotateButtonManager.midRight = false;
        }

        // if(side == cubeStatus.left)
        // {
            
        //     cubeRotationManager.RotateRight();
        //     automate.DoMove("U");
        //     automate.DoMove("D'");
        //     dragging = false;
        //     Debug.Log("11");
        //     layerRotateButtonManager.midRight = false;
        // }

        // if(side == cubeStatus.up)
        // {
            
        //     cubeRotationManager.RotateRight();
        //     automate.DoMove("U");
        //     automate.DoMove("D'");
        //     dragging = false;
        //     Debug.Log("11");
        //     layerRotateButtonManager.midRight = false;
        // }

        // if(side == cubeStatus.down)
        // {
            
        //     cubeRotationManager.RotateRight();
        //     automate.DoMove("U");
        //     automate.DoMove("D'");
        //     dragging = false;
        //     Debug.Log("11");
        //     layerRotateButtonManager.midRight = false;
        // }

        // if(side == cubeStatus.front)
        // {
           
        //     cubeRotationManager.RotateRight();
        //     automate.DoMove("U");
        //     automate.DoMove("D'");
        //     dragging = false;
        //     Debug.Log("11");
        //     layerRotateButtonManager.midRight = false;
        // }

        // if(side == cubeStatus.back)
        // {
           
        //     cubeRotationManager.RotateRight();
        //     automate.DoMove("U");
        //     automate.DoMove("D'");
        //     dragging = false;
        //     Debug.Log("11");
        //     layerRotateButtonManager.midRight = false;
        // }
    }    
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////

    if (layerRotateButtonManager.midLeft)
    {
        if(side == cubeStatus.right)
        {
            
            cubeRotationManager.RotateLeft();
            automate.DoMove("U'");
            automate.DoMove("D");
            dragging = false;
            layerRotateButtonManager.midLeft = false;
        }

        // if(side == cubeStatus.left)
        // {
            
        //     cubeRotationManager.RotateLeft();
        //     automate.DoMove("U'");
        //     automate.DoMove("D");
        //     dragging = false;
        //     Debug.Log("11");
        //     layerRotateButtonManager.midLeft = false;
        // }

        // if(side == cubeStatus.up)
        // {
            
        //     cubeRotationManager.RotateLeft();
        //     automate.DoMove("U'");
        //     automate.DoMove("D");
        //     dragging = false;
        //     Debug.Log("11");
        //     layerRotateButtonManager.midLeft = false;
        // }

        // if(side == cubeStatus.down)
        // {
            
        //     cubeRotationManager.RotateLeft();
        //     automate.DoMove("U'");
        //     automate.DoMove("D");
        //     dragging = false;
        //     Debug.Log("11");
        //     layerRotateButtonManager.midLeft = false;
        // }

        // if(side == cubeStatus.front)
        // {
           
        //     cubeRotationManager.RotateLeft();
        //     automate.DoMove("U'");
        //     automate.DoMove("D");
        //     dragging = false;
        //     Debug.Log("11");
        //     layerRotateButtonManager.midLeft = false;
        // }

        // if(side == cubeStatus.back)
        // {
           
        //     cubeRotationManager.RotateLeft();
        //     automate.DoMove("U'");
        //     automate.DoMove("D");
        //     dragging = false;
        //     Debug.Log("11");
        //     layerRotateButtonManager.midLeft = false;
        // }
    }    
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
        
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
