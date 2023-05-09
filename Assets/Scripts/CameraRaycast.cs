using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRaycast : MonoBehaviour
{
    private  int layerMask_red = 1 << 7;
    private  int layerMask_blue = 1 << 8;
    private  int layerMask_green = 1 << 9;
    private  int layerMask_yellow = 1 << 10;
    private  int layerMask_white = 1 << 11;
    private  int layerMask_orange = 1 << 12;
    public GameObject arCamera;
    public GameObject controllerArrowsOrangeSide;
    public GameObject controllerArrowsBlueSide;
    public GameObject controllerArrowsRedSide;
    public GameObject controllerArrowsGreenSide;
    public GameObject controllerArrowsYellowSide;
    public GameObject controllerArrowsWhiteSide;

    public GameObject redSideMesh;
    public GameObject blueSideMesh;
    public GameObject greenSideMesh;
    public GameObject yellowSideMesh;
    public GameObject whiteSideMesh;
    public GameObject orangeSideMesh;
    public bool redSide = false;
    public bool blueSide = false;
    public bool greenSide = false;
    public bool yellowSide = false;
    public bool whiteSide = false;
    public bool orangeSide = false;

    public bool canRayCast;
    // Start is called before the first frame update
    void Start()
    {
        canRayCast = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (canRayCast)
        {
            Vector3 startPosition = arCamera.transform.position;
            RaycastHit hit;
            //startPosition.z = 100f;
            //startPosition = arCamera.ScreenToWorldPoint(startPosition);
            Ray rayFromFront = new Ray(arCamera.transform.position, arCamera.transform.forward);

            if (Physics.Raycast(rayFromFront, out hit, 0.05f, layerMask_red) && !redSide)
            {
                controllerArrowsRedSide.SetActive(true);
                controllerArrowsBlueSide.SetActive(false);
                controllerArrowsGreenSide.SetActive(false);
                controllerArrowsOrangeSide.SetActive(false);
                controllerArrowsWhiteSide.SetActive(false);
                controllerArrowsYellowSide.SetActive(false);
                // controllerArrows.transform.rotation = redSideMesh.transform.rotation;
                Debug.Log("RedSide");
                redSide = true;
                orangeSide = false;
                whiteSide = false;
                greenSide = false;
                blueSide = false;
                yellowSide = false;
            }

            if (Physics.Raycast(rayFromFront, out hit, 0.05f, layerMask_blue) && !blueSide)
            {
                controllerArrowsBlueSide.SetActive(true);
                controllerArrowsRedSide.SetActive(false);
                controllerArrowsGreenSide.SetActive(false);
                controllerArrowsOrangeSide.SetActive(false);
                controllerArrowsWhiteSide.SetActive(false);
                controllerArrowsYellowSide.SetActive(false);
                // controllerArrows.transform.rotation = blueSideMesh.transform.rotation;
                Debug.Log("BlueSide");
                blueSide = true;
                redSide = false;
                whiteSide = false;
                greenSide = false;
                orangeSide = false;
                yellowSide = false;
            }

            if (Physics.Raycast(rayFromFront, out hit, 0.05f, layerMask_green) && !greenSide)
            {
                controllerArrowsGreenSide.SetActive(true);
                controllerArrowsRedSide.SetActive(false);
                controllerArrowsBlueSide.SetActive(false);
                controllerArrowsOrangeSide.SetActive(false);
                controllerArrowsWhiteSide.SetActive(false);
                controllerArrowsYellowSide.SetActive(false);
                // controllerArrows.transform.rotation = greenSideMesh.transform.rotation;
                Debug.Log("GreenSide");
                greenSide = true;
                redSide = false;
                whiteSide = false;
                orangeSide = false;
                blueSide = false;
                yellowSide = false;
            }

            if (Physics.Raycast(rayFromFront, out hit, 0.05f, layerMask_yellow) && !yellowSide)
            {
                controllerArrowsYellowSide.SetActive(true);
                controllerArrowsRedSide.SetActive(false);
                controllerArrowsBlueSide.SetActive(false);
                controllerArrowsOrangeSide.SetActive(false);
                controllerArrowsWhiteSide.SetActive(false);
                controllerArrowsGreenSide.SetActive(false);
                // controllerArrows.transform.rotation = yellowSideMesh.transform.rotation;
                Debug.Log("YellowSide");
                yellowSide = true;
                redSide = false;
                whiteSide = false;
                greenSide = false;
                blueSide = false;
                orangeSide = false;
            }

            if (Physics.Raycast(rayFromFront, out hit, 0.05f, layerMask_white) && !whiteSide)
            {
                controllerArrowsWhiteSide.SetActive(true);
                controllerArrowsRedSide.SetActive(false);
                controllerArrowsBlueSide.SetActive(false);
                controllerArrowsOrangeSide.SetActive(false);
                controllerArrowsYellowSide.SetActive(false);
                controllerArrowsGreenSide.SetActive(false);
                // controllerArrows.transform.rotation = whiteSideMesh.transform.rotation;
                Debug.Log("WhiteSide");
                whiteSide = true;
                redSide = false;
                greenSide = false;
                blueSide = false;
                yellowSide = false;
                orangeSide = false;
            }

            if (Physics.Raycast(rayFromFront, out hit, 0.05f, layerMask_orange) && !orangeSide)
            {
                controllerArrowsOrangeSide.SetActive(true);
                controllerArrowsRedSide.SetActive(false);
                controllerArrowsBlueSide.SetActive(false);
                controllerArrowsWhiteSide.SetActive(false);
                controllerArrowsYellowSide.SetActive(false);
                controllerArrowsGreenSide.SetActive(false);
                // controllerArrows.transform.rotation = orangeSideMesh.transform.rotation;
                Debug.Log("OrangeSide");
                orangeSide = true;
                redSide = false;
                whiteSide = false;
                greenSide = false;
                blueSide = false;
                yellowSide = false;
            }

            Debug.DrawRay(arCamera.transform.position, arCamera.transform.forward, Color.green);
        }

        
        
        
        
        
        
    }

    public void DeactivateAllArrows()
    {
        controllerArrowsRedSide.SetActive(false);
        controllerArrowsBlueSide.SetActive(false);
        controllerArrowsWhiteSide.SetActive(false);
        controllerArrowsYellowSide.SetActive(false);
        controllerArrowsGreenSide.SetActive(false);
        controllerArrowsOrangeSide.SetActive(false);
    }
}
