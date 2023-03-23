using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using TMPro;


public class AR_Raycast_Script : MonoBehaviour
{
    
    public GameObject topTextPanel;
    public GameObject bottomButtonPanel;
    public GameObject countDownTimer;
    // private Button tapButton;
    // public GameObject cubeToSpawn;
    // public GameObject testt;
    [HideInInspector]
    public GameObject spawnedCube;
    public GameObject tapTittle;
    [SerializeField] TMP_Text sampletext;
    // public GameObject test;
    // bool objectSpawned;
    // ARRaycastManager arRaycastManager;
    // List<ARRaycastHit> hits = new List<ARRaycastHit>();

    Animator topTextPanelAnim;
    Animator startcountdownplay;
    Animator bottomButtonPannelAnim;
    Automate automate;
    bool onlyonce;



    public GameObject qq;



    public ARRaycastManager raycastManager;
    public GameObject objectToPlace;
    public Camera arcamera;
    private List<ARRaycastHit> hittts = new List<ARRaycastHit>();
    private CubeRotationManager cubeRotationManager;
    private GetSliderValue getSliderValue;
    
    float changedHeight;
    // Start is called before the first frame update
    void Start()
    {
        onlyonce = false;
        // objectSpawned = false;
        // arRaycastManager = GetComponent<ARRaycastManager>();

        // tapButton = gameObject.GetComponent<Button>();
        topTextPanelAnim = topTextPanel.GetComponent<Animator>();
        bottomButtonPannelAnim = bottomButtonPanel.GetComponent<Animator>();
        automate = GameObject.FindObjectOfType<Automate>();
        startcountdownplay = countDownTimer.GetComponent<Animator>();
        cubeRotationManager = GameObject.FindObjectOfType<CubeRotationManager>();
        getSliderValue = GameObject.FindObjectOfType<GetSliderValue>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
       
        sampletext.text = getSliderValue.changedHeight.ToString();
                

        Ray ray = arcamera.ScreenPointToRay(Input.mousePosition);
        
        
        if(Input.GetMouseButton(0))
        {
           
            if(!onlyonce)
            {
                
                // StartCoroutine(automate.firstShuffle());
                
                if(raycastManager.Raycast(ray, hittts, TrackableType.Planes))
            {
                StartCoroutine(automate.firstShuffle());
                cubeRotationManager.HideArrows(5.5f);
                Pose hitpos = hittts[0].pose;
                spawnedCube =  Instantiate(objectToPlace, new Vector3(hitpos.position.x, hitpos.position.y, hitpos.position.z) , hitpos.rotation);
                topTextPanelAnim.SetTrigger("TopTextPanelUp");
                startcountdownplay.SetTrigger("PlayCountDown");
                bottomButtonPannelAnim.SetTrigger("PlayBottomButtonPanel");
                qq.transform.position =  spawnedCube.transform.position; 
                tapTittle.SetActive(false);

                //qq.SetActive(false);
                qq.transform.localScale = new Vector3(0.05f,0.05f,0.05f);
                tapTittle.SetActive(false);
                onlyonce = true;
            }
            }
            
        }

        qq.transform.position = new Vector3(spawnedCube.transform.position.x, spawnedCube.transform.position.y + getSliderValue.changedHeight, spawnedCube.transform.position.z); 
        
            
                
        

                

        
        
    }

    public void AddNew()
    {
        onlyonce = false;
        qq.SetActive(true);
    }

   
}
