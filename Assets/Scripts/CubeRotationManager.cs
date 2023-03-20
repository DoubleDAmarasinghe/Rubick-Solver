using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CubeRotationManager : MonoBehaviour
{
    Vector2 startPosition;
    Vector2 endPosition;
    Vector2 currentSwipe;
    public GameObject cube;
    public float speed;
    bool wholeCubeRotating = false;
    public GameObject controllerArrowPanel;
    public GameObject wholeRotateArrowPanel;
    ReadCube readCube;
    Automate automate;
    SolveTwoPhase solveTwoPhase;
    // Start is called before the first frame update
    void Start()
    {
        readCube = GameObject.FindObjectOfType<ReadCube>();
        automate = GameObject.FindObjectOfType<Automate>();
        solveTwoPhase = GameObject.FindObjectOfType<SolveTwoPhase>();
        HideArrows(5.5f);
        // cube.transform.Rotate(0, 90, 0, Space.World);
    }

    // Update is called once per frame
    void Update()
    {

        

        //Swipe();
        //Drag();
        if(transform.rotation != cube.transform.rotation)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, cube.transform.rotation, speed * Time.deltaTime);
            readCube.ReadState();
            //wholeCubeRotating = false;
        }

        // if(Input.GetMouseButtonDown(1))
        // {
        //     Debug.Log("sdfsdfsdfsdfdsf");
        // }
       
        
    }

    public void HideArrows(float showTimeDelay)
    {
        
        controllerArrowPanel.SetActive(false);
        wholeRotateArrowPanel.SetActive(false);

        StartCoroutine(ShowArrows(showTimeDelay));
        
    }

    IEnumerator ShowArrows(float showTimeDelay)
    {
        yield return new WaitForSeconds(showTimeDelay);
        controllerArrowPanel.SetActive(true);
        wholeRotateArrowPanel.SetActive(true);
        
        
    }

    public void RotateLeft()
    {
        cube.transform.Rotate(0, 90, 0, Space.World);
        wholeCubeRotating = true;
        
    }

    public void RotateRight()
    {
        cube.transform.Rotate(0, -90, 0, Space.World);
        wholeCubeRotating = true;
       
    }

    public void RotateUp()
    {
        cube.transform.Rotate(0, 0, -90, Space.World);
        wholeCubeRotating = true;
        
    }

    public void RotateBottom()
    {
        cube.transform.Rotate(0, 0, 90, Space.World);
        wholeCubeRotating = true;
        
    }

    // void Drag()
    // {
    //     // if (Input.GetMouseButton(1))
    //     // {
    //     //     // while the mouse is held down the cube can be moved around its central axis to provide visual feedback
    //     //     mouseDelta = Input.mousePosition - previousMousePosition;
    //     //     mouseDelta *= 0.1f; // reduction of rotation speed
    //     //     transform.rotation = Quaternion.Euler(mouseDelta.y, -mouseDelta.x, 0) * transform.rotation;
    //     // }
    //     // else
    //     // {
    //         // automatically move to the target position
    //         if (transform.rotation != cube.transform.rotation)
    //         {
    //             var step = speed * Time.deltaTime;
    //             transform.rotation = Quaternion.RotateTowards(transform.rotation, cube.transform.rotation, step);
    //         }
    // }

    // public void WholeRotateLeft()
    // {
    //     cube.transform.Rotate(0, 90, 0, Space.World);
    // }

    // public void WholeRotateRight()
    // {
    //     cube.transform.Rotate(0, -90, 0, Space.World);
    // }

    // public void WholeRotateUp()
    // {
    //     cube.transform.Rotate(0, 0, -90, Space.World);
    // }

    // public void WholeRotateDown()
    // {
    //     cube.transform.Rotate(0, 0, 90, Space.World);
    // }
}