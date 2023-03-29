using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using TMPro;


public class AR_Raycast_Script : MonoBehaviour
{
    [SerializeField] GameObject tapToPlace;
    [SerializeField] GameObject mainTittle;
    public GameObject topTextPanel;
    public GameObject bottomButtonPanel;
    public GameObject countDownTimer;
    // private Button tapButton;
    // public GameObject cubeToSpawn;
    // public GameObject testt;
    [HideInInspector]
    public GameObject spawnedCube;
    [HideInInspector]
    //public GameObject cubeShadow;
    public GameObject tapTittle;
    public GameObject heightSlider;
    [SerializeField] TMP_Text sampletext;
    // public GameObject test;
    // bool objectSpawned;
    // ARRaycastManager arRaycastManager;
    // List<ARRaycastHit> hits = new List<ARRaycastHit>();

    Animator topTextPanelAnim;
    Animator tapToPlaceAnim;
    Animator SliderUp;
    Animator SliderDown;
    Animator startcountdownplay;
    Animator bottomButtonPannelAnim;
    Animator mainTittleDown;
    Automate automate;
    bool onlyonce;
    bool canSetHeight;
    bool canStart;


    public GameObject qq;
    //public GameObject rubikShadow;



    public ARRaycastManager raycastManager;
    public GameObject objectToPlace;
    public Camera arcamera;
    private List<ARRaycastHit> hittts = new List<ARRaycastHit>();
    private CubeRotationManager cubeRotationManager;
    private GetSliderValue getSliderValue;
    private SoundManager soundManager;
    
    float changedHeight;
    // Start is called before the first frame update
    void Start()
    {
        onlyonce = true;
        canSetHeight = false;
        canStart = false;
        // objectSpawned = false;
        // arRaycastManager = GetComponent<ARRaycastManager>();

        // tapButton = gameObject.GetComponent<Button>();
        topTextPanelAnim = topTextPanel.GetComponent<Animator>();
        bottomButtonPannelAnim = bottomButtonPanel.GetComponent<Animator>();
        SliderUp = heightSlider.GetComponent<Animator>();
        SliderDown = heightSlider.GetComponent<Animator>();
        automate = GameObject.FindObjectOfType<Automate>();
        startcountdownplay = countDownTimer.GetComponent<Animator>();
        cubeRotationManager = GameObject.FindObjectOfType<CubeRotationManager>();
        getSliderValue = GameObject.FindObjectOfType<GetSliderValue>();
        soundManager = GameObject.FindObjectOfType<SoundManager>();
        mainTittleDown = mainTittle.GetComponent<Animator>();
        tapToPlaceAnim = tapToPlace.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // if(getSliderValue.changedHeight > 0.8)
        // {
        //     rubikShadow.SetActive(false);
        // }
        // if(getSliderValue.changedHeight < 0.8)
        // {
        //     rubikShadow.SetActive(true);
        // }

        
       
        
        sampletext.text = getSliderValue.changedHeight.ToString();     

        Ray ray = arcamera.ScreenPointToRay(Input.mousePosition);
        
        
        if(Input.GetMouseButton(0))
        {
           
            if(!onlyonce)
            {
                
               
                soundManager.PlayPopUpSound();
                if(raycastManager.Raycast(ray, hittts, TrackableType.Planes))
            {
                //StartCoroutine(automate.firstShuffle());
                //cubeRotationManager.HideArrows(5.5f);
                Pose hitpos = hittts[0].pose;
                spawnedCube =  Instantiate(objectToPlace, new Vector3(hitpos.position.x, hitpos.position.y, hitpos.position.z) , hitpos.rotation);
                //cubeShadow = Instantiate(objectToPlace, new Vector3(hitpos.position.x, hitpos.position.y, hitpos.position.z) , hitpos.rotation);
                //topTextPanelAnim.SetTrigger("TopTextPanelUp");
                //startcountdownplay.SetTrigger("PlayCountDown");
                //bottomButtonPannelAnim.SetTrigger("PlayBottomButtonPanel");
                qq.transform.position =  spawnedCube.transform.position; 
                // rubikShadow.transform.position = spawnedCube.transform.position; 
                tapTittle.SetActive(false);

                //qq.SetActive(false);
                qq.transform.localScale = new Vector3(0.05f,0.05f,0.05f);
                // rubikShadow.transform.localScale = new Vector3(0.05f,0.05f,0.05f);
                tapTittle.SetActive(false);
                onlyonce = true;
                canSetHeight = true;
                SliderUp.SetTrigger("SliderUp");
                
                //heightSlider.SetActive(true);
            }
            }
            
        }

        if(canSetHeight)
        {
            
            qq.transform.position = new Vector3(spawnedCube.transform.position.x, spawnedCube.transform.position.y + getSliderValue.changedHeight, spawnedCube.transform.position.z); 
        }

        if(canStart)
        {
            StartCoroutine(automate.firstShuffle());
            cubeRotationManager.HideArrows(5.5f);
            topTextPanelAnim.SetTrigger("TopTextPanelUp");
            startcountdownplay.SetTrigger("PlayCountDown");
            bottomButtonPannelAnim.SetTrigger("PlayBottomButtonPanel");
            canStart = false;
            canSetHeight = false;
            //heightSlider.SetActive(false);
            SliderUp.SetTrigger("SliderDown");
        }

        
       
    

    } 

    public void  GamePlayButton()
    {
        tapToPlace.SetActive(true);
        tapToPlaceAnim.SetTrigger("TapToPlaceUp");
        //mainTittle.SetActive(false);
        mainTittleDown.SetTrigger("MainTittleOut");
        onlyonce = false;
        
    }       
                
      public void GameStart()
    {  
        canStart = true;
 
    }

    public void AddNew()
    {
        onlyonce = false;
        qq.SetActive(true);
    }

   
}
