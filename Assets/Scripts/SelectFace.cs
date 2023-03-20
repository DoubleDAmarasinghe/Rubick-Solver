using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.UI;

public class SelectFace : MonoBehaviour
{
    private CubeStatus cubeStatus;
    private  ReadCube readCube;
    private  int layerMask = 1 << 6;
    Camera arCamera;

    public GameObject frontFaceDitector;
    public GameObject backFaceDitector;
    public GameObject upFaceDitector;
    public GameObject downFaceDitector;
    [HideInInspector]
    public bool frontSelected;
    public Button btn;
    
    GameObject face;
    // Start is called before the first frame update
    void Start()
    {
        
        readCube = GameObject.FindObjectOfType<ReadCube>();
        cubeStatus = GameObject.FindObjectOfType<CubeStatus>();
        //createing reference for AR Camera
        arCamera = FindObjectOfType<ARSessionOrigin>().camera;
        readCube.ReadState();

        frontSelected = false;
    }

    // Update is called once per frame
    void Update()
    {

        
    
       
      
    }

    public void IdentifyFront()
    {
        readCube.ReadState();
        if(!CubeStatus.autoRotating)
        {
            frontSelected = true;
            RaycastHit hit;
        //var arCamera = FindObjectOfType<ARSessionOrigin>().camera;
        //Ray ray = arCamera.ScreenPointToRay(Input.mousePosition);
            Ray rayFromFront = new Ray(frontFaceDitector.transform.position, frontFaceDitector.transform.forward);
           
        
            if (Physics.Raycast(rayFromFront, out hit, 100.0f, layerMask))
            {   
                    face = hit.collider.gameObject;
                    Debug.Log(face.name + face);
                // Make a list of all the sides (lists of face GameObjects)
                List<List<GameObject>> cubeSides = new List<List<GameObject>>()
                {
                    cubeStatus.up,
                    cubeStatus.down,
                    cubeStatus.left,
                    cubeStatus.right,
                    cubeStatus.front,
                    cubeStatus.back
                };
                // If the face hit exists within a side
                foreach (List<GameObject> cubeSide in cubeSides)
                {
                    if (cubeSide.Contains(face))
                    {
                        //Pick it up
                        cubeStatus.PickUp(cubeSide);
                        //start the side rotation logic
                        //cubeSide[4].transform.parent.GetComponent<PiviotRotation>().Rotate(cubeSide);
                        cubeSide[4].transform.parent.GetComponent<PiviotRotation>().Rotate(cubeSide);
                    }
                    
                }
            }
            

        }
            // raycast from the mouse towards the cube to see if a face is hit  
            
            
    }

    public void IdentifyBack()
    {
        readCube.ReadState();
        if(!CubeStatus.autoRotating)
        {
        RaycastHit hit;
    //var arCamera = FindObjectOfType<ARSessionOrigin>().camera;
    //Ray ray = arCamera.ScreenPointToRay(Input.mousePosition);
        Ray rayFromBack = new Ray(backFaceDitector.transform.position, backFaceDitector.transform.forward);

            if (Physics.Raycast(rayFromBack, out hit, 100.0f, layerMask))
            {   
                face = hit.collider.gameObject;
                // Make a list of all the sides (lists of face GameObjects)
                List<List<GameObject>> cubeSides = new List<List<GameObject>>()
                {
                    cubeStatus.up,
                    cubeStatus.down,
                    cubeStatus.left,
                    cubeStatus.right,
                    cubeStatus.front,
                    cubeStatus.back
                };
                // If the face hit exists within a side
                foreach (List<GameObject> cubeSide in cubeSides)
                {
                    if (cubeSide.Contains(face))
                    {
                        //Pick it up
                        cubeStatus.PickUp(cubeSide);
                        //start the side rotation logic
                        //cubeSide[4].transform.parent.GetComponent<PiviotRotation>().Rotate(cubeSide);
                        cubeSide[4].transform.parent.GetComponent<PiviotRotation>().Rotate(cubeSide);
                    }
                }
            }
        }
            // raycast from the mouse towards the cube to see if a face is hit  
            
    }

    public void IdentifyUp()
    {
        readCube.ReadState();
        if(!CubeStatus.autoRotating)
        {
            RaycastHit hit;
            //var arCamera = FindObjectOfType<ARSessionOrigin>().camera;
            //Ray ray = arCamera.ScreenPointToRay(Input.mousePosition);
            Ray rayFromUp = new Ray(upFaceDitector.transform.position, upFaceDitector.transform.forward);
           
            if (Physics.Raycast(rayFromUp, out hit, 100.0f, layerMask))
            {   
                face = hit.collider.gameObject;
                // Make a list of all the sides (lists of face GameObjects)
                List<List<GameObject>> cubeSides = new List<List<GameObject>>()
                {
                    cubeStatus.up,
                    cubeStatus.down,
                    cubeStatus.left,
                    cubeStatus.right,
                    cubeStatus.front,
                    cubeStatus.back
                };
                // If the face hit exists within a side
                foreach (List<GameObject> cubeSide in cubeSides)
                {
                    if (cubeSide.Contains(face))
                    {
                        //Pick it up
                        cubeStatus.PickUp(cubeSide);
                        //start the side rotation logic
                        //cubeSide[4].transform.parent.GetComponent<PiviotRotation>().Rotate(cubeSide);
                        cubeSide[4].transform.parent.GetComponent<PiviotRotation>().Rotate(cubeSide);
                    }
                }
            }
        }
            // raycast from the mouse towards the cube to see if a face is hit  
            
    }

    public void IdentifyDown()
    {
        readCube.ReadState();
        if(!CubeStatus.autoRotating)
        {
            RaycastHit hit;
            //var arCamera = FindObjectOfType<ARSessionOrigin>().camera;
            //Ray ray = arCamera.ScreenPointToRay(Input.mousePosition);
            Ray rayFromDown = new Ray(downFaceDitector.transform.position, downFaceDitector.transform.forward);
           
            if (Physics.Raycast(rayFromDown, out hit, 100.0f, layerMask))
            {   
                face = hit.collider.gameObject;
                // Make a list of all the sides (lists of face GameObjects)
                List<List<GameObject>> cubeSides = new List<List<GameObject>>()
                {
                    cubeStatus.up,
                    cubeStatus.down,
                    cubeStatus.left,
                    cubeStatus.right,
                    cubeStatus.front,
                    cubeStatus.back
                };
                // If the face hit exists within a side
                foreach (List<GameObject> cubeSide in cubeSides)
                {
                    if (cubeSide.Contains(face))
                    {
                        //Pick it up
                        cubeStatus.PickUp(cubeSide);
                        //start the side rotation logic
                        //cubeSide[4].transform.parent.GetComponent<PiviotRotation>().Rotate(cubeSide);
                        cubeSide[4].transform.parent.GetComponent<PiviotRotation>().Rotate(cubeSide);
                    }
                }
            }
        }  
            // raycast from the mouse towards the cube to see if a face is hit  
            
    }

   

    
}
