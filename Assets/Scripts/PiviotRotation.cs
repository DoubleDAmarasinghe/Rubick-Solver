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
///////////////////////FIXING START////////////////////////////////////////

private void SpinSide(List<GameObject> side)
    {
        rotation = Vector3.zero;
/////////////Orange Side START///////////////////////////////////////
        if(layerRotateButtonManager.rightUpOrange)
        {
            automate.DoMove("R");
            dragging = false;
            Debug.Log("AAA");
            layerRotateButtonManager.rightUpOrange = false;
        }

        if(layerRotateButtonManager.rightDownOrange)
        {
            automate.DoMove("R'");
            dragging = false;
            Debug.Log("BBB");
            layerRotateButtonManager.rightDownOrange = false;
        }

        if(layerRotateButtonManager.rightUpRightOrange)
         {
            automate.DoMove("U'");
            dragging = false;
            Debug.Log("ZZZ");
            layerRotateButtonManager.rightUpRightOrange = false;
         }

         if(layerRotateButtonManager.rightDownRightOrange)
        {
            automate.DoMove("D");
            dragging = false;
            layerRotateButtonManager.rightDownRightOrange = false;
        }

        if(layerRotateButtonManager.leftUpOrange)
        {
            automate.DoMove("L'");
            dragging = false;
            layerRotateButtonManager.leftUpOrange = false;
        }
        
        if(layerRotateButtonManager.leftDownOrange)
        {
            automate.DoMove("L");
            dragging = false;
            layerRotateButtonManager.leftDownOrange = false;
        }

        if(layerRotateButtonManager.leftUpLeftOrange)
        {
            automate.DoMove("U");
            dragging = false;
            layerRotateButtonManager.leftUpLeftOrange = false;
        }

        if(layerRotateButtonManager.leftDownLeftOrange)
        {
            automate.DoMove("D'");
            dragging = false;
            layerRotateButtonManager.leftDownLeftOrange = false;
        }

        if (layerRotateButtonManager.midUpOrange)
        {
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            cubeRotationManager.RotateUp();
            automate.DoMove("R'");
            automate.DoMove("L");
            dragging = false;
            layerRotateButtonManager.midUpOrange = false;
            cameraRaycast.controllerArrowsOrangeSide.SetActive(false);
            cameraRaycast.controllerArrowsWhiteSide.SetActive(true);
        }

        if (layerRotateButtonManager.midDownOrange)
        {
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            cubeRotationManager.RotateBottom();
            automate.DoMove("R");
            automate.DoMove("L'");
            dragging = false;
            layerRotateButtonManager.midDownOrange = false;
            cameraRaycast.controllerArrowsOrangeSide.SetActive(false);
            cameraRaycast.controllerArrowsYellowSide.SetActive(true);
        }

        if (layerRotateButtonManager.midRightOrange)
        {  
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            cubeRotationManager.RotateRight();
            automate.DoMove("U");
            automate.DoMove("D'");
            dragging = false;
            layerRotateButtonManager.midRightOrange = false;
            cameraRaycast.controllerArrowsOrangeSide.SetActive(false);
            cameraRaycast.controllerArrowsGreenSide.SetActive(true);
        }

        if (layerRotateButtonManager.midLeftOrange)
        {
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            cubeRotationManager.RotateLeft();
            automate.DoMove("U'");
            automate.DoMove("D");
            dragging = false;
            layerRotateButtonManager.midLeftOrange = false;
            cameraRaycast.controllerArrowsOrangeSide.SetActive(false);
            cameraRaycast.controllerArrowsBlueSide.SetActive(true);
        }

        /////////////Orange Side END///////////////////////////////////////


        /////////////Blue Side START///////////////////////////////////////
        if(layerRotateButtonManager.rightUpBlue)
        {
            automate.DoMove("B");
            dragging = false;
            Debug.Log("AAA");
            layerRotateButtonManager.rightUpBlue = false;
        }

        if(layerRotateButtonManager.rightDownBlue)
        {
            automate.DoMove("B'");
            dragging = false;
            Debug.Log("BBB");
            layerRotateButtonManager.rightDownBlue = false;
        }

        if(layerRotateButtonManager.rightUpRightBlue)
         {
            automate.DoMove("U'");
            dragging = false;
            Debug.Log("ZZZ");
            layerRotateButtonManager.rightUpRightBlue = false;
         }

         if(layerRotateButtonManager.rightDownRightBlue)
        {
            automate.DoMove("D");
            dragging = false;
            layerRotateButtonManager.rightDownRightBlue = false;
        }

        if(layerRotateButtonManager.leftUpBlue)
        {
            automate.DoMove("F'");
            dragging = false;
            layerRotateButtonManager.leftUpBlue = false;
        }
        
        if(layerRotateButtonManager.leftDownBlue)
        {
            automate.DoMove("F");
            dragging = false;
            layerRotateButtonManager.leftDownBlue = false;
        }

        if(layerRotateButtonManager.leftUpLeftBlue)
        {
            automate.DoMove("U");
            dragging = false;
            layerRotateButtonManager.leftUpLeftBlue = false;
        }

        if(layerRotateButtonManager.leftDownLeftBlue)
        {
            automate.DoMove("D'");
            dragging = false;
            layerRotateButtonManager.leftDownLeftBlue = false;
        }

        if (layerRotateButtonManager.midUpBlue)
        {
            ////////////////////////////////////////////////////////////////////////////////////
            cubeRotationManager.RotateRollLeft();
            automate.DoMove("F");
            automate.DoMove("B'");
            dragging = false;
            layerRotateButtonManager.midUpBlue = false;
            cameraRaycast.controllerArrowsBlueSide.SetActive(false);
            cameraRaycast.controllerArrowsWhiteSide.SetActive(true);
        }

        if (layerRotateButtonManager.midDownBlue)
        {
            //////////////////////////////////////////////////////////////////////////////////
            cubeRotationManager.RotateRollRight();
            automate.DoMove("F'");
            automate.DoMove("B");
            dragging = false;
            layerRotateButtonManager.midDownBlue = false;
            cameraRaycast.controllerArrowsBlueSide.SetActive(false);
            cameraRaycast.controllerArrowsOrangeSide.SetActive(true);
        }

        if (layerRotateButtonManager.midRightBlue)
        {  
            ////////////////////////////////////////////////////////////////////////
            cubeRotationManager.RotateRight();
            automate.DoMove("U");
            automate.DoMove("D'");
            dragging = false;
            layerRotateButtonManager.midRightBlue = false;
            cameraRaycast.controllerArrowsBlueSide.SetActive(false);
            cameraRaycast.controllerArrowsOrangeSide.SetActive(true);
        }

        if (layerRotateButtonManager.midLeftBlue)
        {
            ////////////////////////////////////////////////////////////////////////////////////////////////
            cubeRotationManager.RotateLeft();
            automate.DoMove("U'");
            automate.DoMove("D");
            dragging = false;
            layerRotateButtonManager.midLeftBlue = false;
            cameraRaycast.controllerArrowsBlueSide.SetActive(false);
            cameraRaycast.controllerArrowsRedSide.SetActive(true);
        }

        /////////////Blue Side END///////////////////////////////////////



        /////////////Red Side START///////////////////////////////////////
        if(layerRotateButtonManager.rightUpRed)
        {
            automate.DoMove("L");
            dragging = false;
            Debug.Log("AAA");
            layerRotateButtonManager.rightUpRed = false;
        }

        if(layerRotateButtonManager.rightDownRed)
        {
            automate.DoMove("L'");
            dragging = false;
            Debug.Log("BBB");
            layerRotateButtonManager.rightDownRed = false;
        }

        if(layerRotateButtonManager.rightUpRightRed)
         {
            automate.DoMove("U'");
            dragging = false;
            Debug.Log("ZZZ");
            layerRotateButtonManager.rightUpRightRed = false;
         }

         if(layerRotateButtonManager.rightDownRightRed)
        {
            automate.DoMove("D");
            dragging = false;
            layerRotateButtonManager.rightDownRightRed = false;
        }

        if(layerRotateButtonManager.leftUpRed)
        {
            automate.DoMove("R'");
            dragging = false;
            layerRotateButtonManager.leftUpRed = false;
        }
        
        if(layerRotateButtonManager.leftDownRed)
        {
            automate.DoMove("R");
            dragging = false;
            layerRotateButtonManager.leftDownRed = false;
        }

        if(layerRotateButtonManager.leftUpLeftRed)
        {
            automate.DoMove("U");
            dragging = false;
            layerRotateButtonManager.leftUpLeftRed = false;
        }

        if(layerRotateButtonManager.leftDownLeftRed)
        {
            automate.DoMove("D'");
            dragging = false;
            layerRotateButtonManager.leftDownLeftRed = false;
        }

        if (layerRotateButtonManager.midUpRed)
        {
            //////////////////////////////////////////////////////////////////////////////////////
            cubeRotationManager.RotateBottom();
            automate.DoMove("L'");
            automate.DoMove("R");
            dragging = false;
            layerRotateButtonManager.midUpRed = false;
            cameraRaycast.controllerArrowsRedSide.SetActive(false);
            cameraRaycast.controllerArrowsWhiteSide.SetActive(true);
        }

        if (layerRotateButtonManager.midDownRed)
        {
            ////////////////////////////////////////////////////////////////////////////////////
            cubeRotationManager.RotateUp();
            automate.DoMove("L");
            automate.DoMove("R'");
            dragging = false;
            layerRotateButtonManager.midDownRed = false;
            cameraRaycast.controllerArrowsRedSide.SetActive(false);
            cameraRaycast.controllerArrowsOrangeSide.SetActive(true);
        }

        if (layerRotateButtonManager.midRightRed)
        {  
            ///////////////////////////////////////////////////////////////////////////////////////////
            cubeRotationManager.RotateRight();
            automate.DoMove("U");
            automate.DoMove("D'");
            dragging = false;
            layerRotateButtonManager.midRightRed = false;
            cameraRaycast.controllerArrowsRedSide.SetActive(false);
            cameraRaycast.controllerArrowsBlueSide.SetActive(true);
        }

        if (layerRotateButtonManager.midLeftRed)
        {
            ///////////////////////////////////////////////////////////////////////////////////////////
            cubeRotationManager.RotateLeft();
            automate.DoMove("U'");
            automate.DoMove("D");
            dragging = false;
            layerRotateButtonManager.midLeftRed = false;
            cameraRaycast.controllerArrowsRedSide.SetActive(false);
            cameraRaycast.controllerArrowsGreenSide.SetActive(true);
        }

        /////////////Red Side END///////////////////////////////////////


        /////////////Green Side START///////////////////////////////////////
        if(layerRotateButtonManager.rightUpGreen)
        {
            automate.DoMove("F");
            dragging = false;
            Debug.Log("AAA");
            layerRotateButtonManager.rightUpGreen = false;
        }

        if(layerRotateButtonManager.rightDownGreen)
        {
            automate.DoMove("F'");
            dragging = false;
            Debug.Log("BBB");
            layerRotateButtonManager.rightDownGreen = false;
        }

        if(layerRotateButtonManager.rightUpRightGreen)
         {
            automate.DoMove("U'");
            dragging = false;
            Debug.Log("ZZZ");
            layerRotateButtonManager.rightUpRightGreen = false;
         }

         if(layerRotateButtonManager.rightDownRightGreen)
        {
            automate.DoMove("D");
            dragging = false;
            layerRotateButtonManager.rightDownRightGreen = false;
        }

        if(layerRotateButtonManager.leftUpGreen)
        {
            automate.DoMove("B'");
            dragging = false;
            layerRotateButtonManager.leftUpGreen = false;
        }
        
        if(layerRotateButtonManager.leftDownGreen)
        {
            automate.DoMove("B");
            dragging = false;
            layerRotateButtonManager.leftDownGreen = false;
        }

        if(layerRotateButtonManager.leftUpLeftGreen)
        {
            automate.DoMove("U");
            dragging = false;
            layerRotateButtonManager.leftUpLeftGreen = false;
        }

        if(layerRotateButtonManager.leftDownLeftGreen)
        {
            automate.DoMove("D'");
            dragging = false;
            layerRotateButtonManager.leftDownLeftGreen = false;
        }

        if (layerRotateButtonManager.midUpGreen)
        {
            //////////////////////////////////////////////////////////////////////////////////////
            cubeRotationManager.RotateRollRight();
            automate.DoMove("F'");
            automate.DoMove("B");
            dragging = false;
            layerRotateButtonManager.midUpGreen = false;
            cameraRaycast.controllerArrowsGreenSide.SetActive(false);
            cameraRaycast.controllerArrowsWhiteSide.SetActive(true);
        }

        if (layerRotateButtonManager.midDownGreen)
        {
            ///////////////////////////////////////////////////////////////////////////////////////////////////////
            cubeRotationManager.RotateRollLeft();
            automate.DoMove("F");
            automate.DoMove("B'");
            dragging = false;
            layerRotateButtonManager.midDownGreen = false;
            cameraRaycast.controllerArrowsGreenSide.SetActive(false);
            cameraRaycast.controllerArrowsYellowSide.SetActive(true);
        }

        if (layerRotateButtonManager.midRightGreen)
        {  
            /////////////////////////////////////////////////////////////////////////////////////////////////////
            cubeRotationManager.RotateRight();
            automate.DoMove("U");
            automate.DoMove("D'");
            dragging = false;
            layerRotateButtonManager.midRightGreen = false;
            cameraRaycast.controllerArrowsGreenSide.SetActive(false);
            cameraRaycast.controllerArrowsRedSide.SetActive(true);
        }

        if (layerRotateButtonManager.midLeftGreen)
        {
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            cubeRotationManager.RotateLeft();
            automate.DoMove("U'");
            automate.DoMove("D");
            dragging = false;
            layerRotateButtonManager.midLeftGreen = false;
            cameraRaycast.controllerArrowsGreenSide.SetActive(false);
            cameraRaycast.controllerArrowsOrangeSide.SetActive(true);
        }

        /////////////Green Side END///////////////////////////////////////


        /////////////Yellow Side START///////////////////////////////////////
        if(layerRotateButtonManager.rightUpYellow)
        {
            automate.DoMove("R");
            dragging = false;
            Debug.Log("AAA");
            layerRotateButtonManager.rightUpYellow = false;
        }

        if(layerRotateButtonManager.rightDownYellow)
        {
            automate.DoMove("R'");
            dragging = false;
            Debug.Log("BBB");
            layerRotateButtonManager.rightDownYellow = false;
        }

        if(layerRotateButtonManager.rightUpRightYellow)
         {
            automate.DoMove("B'");
            dragging = false;
            Debug.Log("ZZZ");
            layerRotateButtonManager.rightUpRightYellow = false;
         }

         if(layerRotateButtonManager.rightDownRightYellow)
        {
            automate.DoMove("F");
            dragging = false;
            layerRotateButtonManager.rightDownRightYellow = false;
        }

        if(layerRotateButtonManager.leftUpYellow)
        {
            automate.DoMove("L'");
            dragging = false;
            layerRotateButtonManager.leftUpYellow = false;
        }
        
        if(layerRotateButtonManager.leftDownYellow)
        {
            automate.DoMove("L");
            dragging = false;
            layerRotateButtonManager.leftDownYellow = false;
        }

        if(layerRotateButtonManager.leftUpLeftYellow)
        {
            automate.DoMove("B");
            dragging = false;
            layerRotateButtonManager.leftUpLeftYellow = false;
        }

        if(layerRotateButtonManager.leftDownLeftYellow)
        {
            automate.DoMove("F'");
            dragging = false;
            layerRotateButtonManager.leftDownLeftYellow = false;
        }

        if (layerRotateButtonManager.midUpYellow)
        {
            /////////////////////////////////////////////////////////////////////////////////
            cubeRotationManager.RotateUp();
            automate.DoMove("R'");
            automate.DoMove("L");
            dragging = false;
            layerRotateButtonManager.midUpYellow = false;
            cameraRaycast.controllerArrowsYellowSide.SetActive(false);
            cameraRaycast.controllerArrowsOrangeSide.SetActive(true);
        }

        if (layerRotateButtonManager.midDownYellow)
        {
            /////////////////////////////////////////////////////////////////////////////////////////
            cubeRotationManager.RotateBottom();
            automate.DoMove("R");
            automate.DoMove("L'");
            dragging = false;
            layerRotateButtonManager.midDownYellow = false;
            cameraRaycast.controllerArrowsYellowSide.SetActive(false);
            cameraRaycast.controllerArrowsRedSide.SetActive(true);
        }

        if (layerRotateButtonManager.midRightYellow)
        {  
            ///////////////////////////////////////////////////////////////////////////////////
            cubeRotationManager.RotateRollRight();
            automate.DoMove("F'");
            automate.DoMove("B");
            dragging = false;
            layerRotateButtonManager.midRightYellow = false;
            cameraRaycast.controllerArrowsYellowSide.SetActive(false);
            cameraRaycast.controllerArrowsGreenSide.SetActive(true);
        }

        if (layerRotateButtonManager.midLeftYellow)
        {
            ////////////////////////////////////////////////////////////////////////////////
            cubeRotationManager.RotateRollLeft();
            automate.DoMove("F");
            automate.DoMove("B'");
            dragging = false;
            layerRotateButtonManager.midLeftYellow = false;
            cameraRaycast.controllerArrowsYellowSide.SetActive(false);
            cameraRaycast.controllerArrowsBlueSide.SetActive(true);
        }

        /////////////Yellow Side END///////////////////////////////////////


        /////////////White Side START///////////////////////////////////////
        if(layerRotateButtonManager.rightUpWhite)
        {
            automate.DoMove("R");
            dragging = false;
            Debug.Log("AAA");
            layerRotateButtonManager.rightUpWhite = false;
        }

        if(layerRotateButtonManager.rightDownWhite)
        {
            automate.DoMove("R'");
            dragging = false;
            Debug.Log("BBB");
            layerRotateButtonManager.rightDownWhite = false;
        }

        if(layerRotateButtonManager.rightUpRightWhite)
         {
            automate.DoMove("F'");
            dragging = false;
            Debug.Log("ZZZ");
            layerRotateButtonManager.rightUpRightWhite = false;
         }

         if(layerRotateButtonManager.rightDownRightWhite)
        {
            automate.DoMove("B");
            dragging = false;
            layerRotateButtonManager.rightDownRightWhite = false;
        }

        if(layerRotateButtonManager.leftUpWhite)
        {
            automate.DoMove("L'");
            dragging = false;
            layerRotateButtonManager.leftUpWhite = false;
        }
        
        if(layerRotateButtonManager.leftDownWhite)
        {
            automate.DoMove("L");
            dragging = false;
            layerRotateButtonManager.leftDownWhite = false;
        }

        if(layerRotateButtonManager.leftUpLeftWhite)
        {
            automate.DoMove("F");
            dragging = false;
            layerRotateButtonManager.leftUpLeftWhite = false;
        }

        if(layerRotateButtonManager.leftDownLeftWhite)
        {
            automate.DoMove("B'");
            dragging = false;
            layerRotateButtonManager.leftDownLeftWhite = false;
        }

        if (layerRotateButtonManager.midUpWhite)
        {
            ////////////////////////////////////////////////////////////////////////////////
            cubeRotationManager.RotateUp();
            automate.DoMove("R'");
            automate.DoMove("L");
            dragging = false;
            layerRotateButtonManager.midUpWhite = false;
            cameraRaycast.controllerArrowsWhiteSide.SetActive(false);
            cameraRaycast.controllerArrowsRedSide.SetActive(true);
        }

        if (layerRotateButtonManager.midDownWhite)
        {
            ///////////////////////////////////////////////////////////////////////////////////
            cubeRotationManager.RotateBottom();
            automate.DoMove("R");
            automate.DoMove("L'");
            dragging = false;
            layerRotateButtonManager.midDownWhite = false;
            cameraRaycast.controllerArrowsWhiteSide.SetActive(false);
            cameraRaycast.controllerArrowsOrangeSide.SetActive(true);
        }

        if (layerRotateButtonManager.midRightWhite)
        {  
            //////////////////////////////////////////////////////////////////////////////////////////////////
            cubeRotationManager.RotateRollLeft();
            automate.DoMove("F'");
            automate.DoMove("B");
            dragging = false;
            layerRotateButtonManager.midRightWhite = false;
            cameraRaycast.controllerArrowsWhiteSide.SetActive(false);
            cameraRaycast.controllerArrowsGreenSide.SetActive(true);
        }

        if (layerRotateButtonManager.midLeftWhite)
        {
            //////////////////////////////////////////////////////////////////
            cubeRotationManager.RotateRollRight();
            automate.DoMove("F");
            automate.DoMove("B'");
            dragging = false;
            layerRotateButtonManager.midLeftWhite = false;
            cameraRaycast.controllerArrowsWhiteSide.SetActive(false);
            cameraRaycast.controllerArrowsBlueSide.SetActive(true);
        }

        /////////////White Side END///////////////////////////////////////

    }

//////////////////////FIXING END////////////////////////////////////////////







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
