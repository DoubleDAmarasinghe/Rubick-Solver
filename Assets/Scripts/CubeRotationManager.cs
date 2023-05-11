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
    StopWatchTimer stopWatchTimer;
    public Button sloveButton, shuffleButton;


    CameraRaycast cameraRaycast;

    [SerializeField]
    private GameObject[] AllLayerRotateButtons;

    // Start is called before the first frame update
    void Start()
    {
        readCube = GameObject.FindObjectOfType<ReadCube>();
        automate = GameObject.FindObjectOfType<Automate>();
        solveTwoPhase = GameObject.FindObjectOfType<SolveTwoPhase>();
        stopWatchTimer = GameObject.FindObjectOfType<StopWatchTimer>();
        cameraRaycast = GameObject.FindObjectOfType<CameraRaycast>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.rotation != cube.transform.rotation)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, cube.transform.rotation, speed * Time.deltaTime);
            readCube.ReadState();
        }
    }

    public void HideArrows(float showTimeDelay)
    {
        controllerArrowPanel.SetActive(false);
        wholeRotateArrowPanel.SetActive(false);
        shuffleButton.interactable = false;
        sloveButton.interactable = false;

        StartCoroutine(ShowArrows(showTimeDelay));
    }

    //delay for whole cube rotators
    IEnumerator ShowArrows(float showTimeDelay)
    {
        yield return new WaitForSeconds(showTimeDelay);
        controllerArrowPanel.SetActive(true);
        wholeRotateArrowPanel.SetActive(true);
        shuffleButton.interactable = true;
        sloveButton.interactable = true;
        stopWatchTimer.StartCounter();
    }


    public void HideLayerRotateArrows(GameObject layerRotateArrowSet)
    {
        layerRotateArrowSet.SetActive(false);
        StartCoroutine(ShowLayerRotateArrows(layerRotateArrowSet));
    }

    //delay for cube layer rotators
    IEnumerator ShowLayerRotateArrows(GameObject layerRotateArrowSet)
    {
        yield return new WaitForSeconds(0.5f);
        layerRotateArrowSet.SetActive(true);
        stopWatchTimer.StartCounter();
    }

    public void DisableLayerRotateWhenAutomation(float timeDelay)
    {
        foreach (GameObject button in AllLayerRotateButtons)
        {
            button.SetActive(false);
        }
        cameraRaycast.DeactivateAllArrows();
        StartCoroutine(EnableLayerRotationAfterAutomation(timeDelay));
    }

    IEnumerator EnableLayerRotationAfterAutomation(float timeDelay)
    {
        yield return new WaitForSeconds(timeDelay);
        foreach (GameObject button in AllLayerRotateButtons)
        {
            button.SetActive(true);
        }
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

    public void RotateRollLeft()
    {
        cube.transform.Rotate(90, 0, 0, Space.World);
        wholeCubeRotating = true;
    }

    public void RotateRollRight()
    {
        cube.transform.Rotate(-90, 0, 0, Space.World);
        wholeCubeRotating = true;
    }
}