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
    // private Button tapButton;
    // public GameObject cubeToSpawn;
    // public GameObject testt;
    [HideInInspector]
    public GameObject spawnedCube;
    public GameObject tapTittle;
    // public GameObject test;
    // bool objectSpawned;
    // ARRaycastManager arRaycastManager;
    // List<ARRaycastHit> hits = new List<ARRaycastHit>();

    Animator topTextPanelAnim;
    Animator bottomButtonPannelAnim;
    bool onlyonce;



    public GameObject qq;



    public ARRaycastManager raycastManager;
    public GameObject objectToPlace;
    public Camera arcamera;
    private List<ARRaycastHit> hittts = new List<ARRaycastHit>();
    // Start is called before the first frame update
    void Start()
    {
        onlyonce = false;
        // objectSpawned = false;
        // arRaycastManager = GetComponent<ARRaycastManager>();

        // tapButton = gameObject.GetComponent<Button>();
        topTextPanelAnim = topTextPanel.GetComponent<Animator>();
        bottomButtonPannelAnim = bottomButtonPanel.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
       
            
                

        Ray ray = arcamera.ScreenPointToRay(Input.mousePosition);
        
        
        if(Input.GetMouseButton(0))
        {
            if(!onlyonce)
            {
                if(raycastManager.Raycast(ray, hittts, TrackableType.Planes))
            {
                Pose hitpos = hittts[0].pose;
                spawnedCube =  Instantiate(objectToPlace, hitpos.position, hitpos.rotation);
                topTextPanelAnim.SetTrigger("TopTextPanelUp");
                bottomButtonPannelAnim.SetTrigger("PlayBottomButtonPanel");
                qq.transform.position = spawnedCube.transform.position; 
                //qq.SetActive(false);
                qq.transform.localScale = new Vector3(0.05f,0.05f,0.05f);
                tapTittle.SetActive(false);
                onlyonce = true;
            }
            }
            
        }
        
            
                
        

                

        
        
    }

    public void PlaceCubeOnGround()
    {
        spawnedCube.transform.Rotate(90, 0, 0, Space.World);
        
    }
}
