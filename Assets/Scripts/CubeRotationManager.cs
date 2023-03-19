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
    // Start is called before the first frame update
    void Start()
    {
        readCube = GameObject.FindObjectOfType<ReadCube>();
        automate = GameObject.FindObjectOfType<Automate>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.rotation != cube.transform.rotation)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, cube.transform.rotation, speed * Time.deltaTime);
            readCube.ReadState();
            //wholeCubeRotating = false;
        }

        if(Input.GetMouseButtonDown(1))
        {
            Debug.Log("sdfsdfsdfsdfdsf");
        }
       
        if(wholeCubeRotating)
        {
            StartCoroutine(HideArrows());
        }
        
       
        if(automate.shuffle)
        {
            //controllerArrowPanel.SetActive(true);
            StartCoroutine(ShowArrows());
            automate.shuffle = false;
        }
    }

    IEnumerator HideArrows()
    {
        yield return new WaitForSeconds(0.3f);
        controllerArrowPanel.SetActive(true);
        wholeCubeRotating = false;
    }

    IEnumerator ShowArrows()
    {
        yield return new WaitForSeconds(8.2f);
        controllerArrowPanel.SetActive(true);
        wholeRotateArrowPanel.SetActive(true);
        
    }

    public void RotateLeft()
    {
        cube.transform.Rotate(0, 90, 0, Space.World);
        wholeCubeRotating = true;
        controllerArrowPanel.SetActive(false);
    }

    public void RotateRight()
    {
        cube.transform.Rotate(0, -90, 0, Space.World);
        wholeCubeRotating = true;
        controllerArrowPanel.SetActive(false);
    }

    public void RotateUp()
    {
        cube.transform.Rotate(90, 0, 0, Space.World);
        wholeCubeRotating = true;
        controllerArrowPanel.SetActive(false);
    }

    public void RotateBottom()
    {
        cube.transform.Rotate(-90, 0, 0, Space.World);
        wholeCubeRotating = true;
        controllerArrowPanel.SetActive(false);
    }
}