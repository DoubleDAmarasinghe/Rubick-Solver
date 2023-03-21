using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class AR_Raycast_Script : MonoBehaviour
{
    public GameObject topTextPanel;
    public GameObject bottomButtonPanel;
    private Button tapButton;
    public GameObject cubeToSpawn;
    GameObject spawnedCube;
    bool objectSpawned;
    ARRaycastManager arRaycastManager;
    List<ARRaycastHit> hits = new List<ARRaycastHit>();

    Animator topTextPanelAnim;
    Animator bottomButtonPannelAnim;
    // Start is called before the first frame update
    void Start()
    {
        objectSpawned = false;
        arRaycastManager = GetComponent<ARRaycastManager>();

        tapButton = gameObject.GetComponent<Button>();
        topTextPanelAnim = topTextPanel.GetComponent<Animator>();
        bottomButtonPannelAnim = bottomButtonPanel.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaceCubeOnGround()
    {
        Debug.Log("Cube On Ground!");
        //deactivate tap button
        tapButton.gameObject.SetActive(false);
        //play top and bottom panel animations
        topTextPanelAnim.SetTrigger("TopTextPanelUp");
        bottomButtonPannelAnim.SetTrigger("PlayBottomButtonPanel");
        

        //activate and place cuube
        if(arRaycastManager.Raycast(Input.GetTouch(0).position, hits, TrackableType.PlaneWithinPolygon))
        {
            var hitPosition = hits[0].pose;
            if(!objectSpawned)
            {
                spawnedCube = Instantiate(cubeToSpawn, hitPosition.position, hitPosition.rotation);
                objectSpawned = true;
            }
            else
            {
                spawnedCube.transform.position = hitPosition.position;
            }
        }
        
        

    }
}
