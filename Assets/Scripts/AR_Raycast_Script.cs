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
    [SerializeField] Button playButton;
    [SerializeField] GameObject mainTittle;
    public GameObject topTextPanel;
    public GameObject bottomButtonPanel;
    public GameObject countDownTimer;
    public GameObject ARPlaneMesh;
    [HideInInspector]
    public GameObject spawnedCube;
    public GameObject tapTittle;
    public GameObject heightSlider;
    [SerializeField] TMP_Text sampletext;

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
    public ARRaycastManager raycastManager;
    public GameObject objectToPlace;
    public Camera arcamera;

    private List<ARRaycastHit> hittts = new List<ARRaycastHit>();
    private CubeRotationManager cubeRotationManager;
    private GetSliderValue getSliderValue;
    private SoundManager soundManager;
    private PlaceIndicator placeIndicator;
    private ARPlaneManager aRPlaneManager;
    private float changedHeight;
    // Start is called before the first frame update
    void Start()
    {
        onlyonce = true;
        canSetHeight = false;
        canStart = false;
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
        placeIndicator = GameObject.FindObjectOfType<PlaceIndicator>();
        aRPlaneManager = GameObject.FindObjectOfType<ARPlaneManager>();
    }

    // Update is called once per frame
    void Update()
    {
        sampletext.text = getSliderValue.changedHeight.ToString();
        Ray ray = arcamera.ScreenPointToRay(Input.mousePosition);

        if (Input.GetMouseButton(0))
        {

            if (!onlyonce)
            {
                soundManager.PlayPopUpSound();
                placeIndicator.showIndicator = false;
                if (raycastManager.Raycast(ray, hittts, TrackableType.Planes))
                {
                    Pose hitpos = hittts[0].pose;
                    spawnedCube = Instantiate(objectToPlace, new Vector3(hitpos.position.x, hitpos.position.y, hitpos.position.z), hitpos.rotation);
                    qq.transform.position = spawnedCube.transform.position;
                    tapTittle.SetActive(false);
                    qq.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
                    tapTittle.SetActive(false);
                    onlyonce = true;
                    canSetHeight = true;
                    SliderUp.SetTrigger("SliderUp");
                }
            }
        }

        if (canSetHeight)
        {
            qq.transform.position = new Vector3(spawnedCube.transform.position.x, spawnedCube.transform.position.y + getSliderValue.changedHeight, spawnedCube.transform.position.z);
        }

        if (canStart)
        {
            StartCoroutine(automate.firstShuffle());
            cubeRotationManager.HideArrows(5.5f);
            topTextPanelAnim.SetTrigger("TopTextPanelUp");
            startcountdownplay.SetTrigger("PlayCountDown");
            bottomButtonPannelAnim.SetTrigger("PlayBottomButtonPanel");
            canStart = false;
            canSetHeight = false;
            SliderUp.SetTrigger("SliderDown");
        }
    }

    public void GamePlayButton()
    {
        tapToPlace.SetActive(true);
        tapToPlaceAnim.SetTrigger("TapToPlaceUp");
        mainTittleDown.SetTrigger("MainTittleOut");
        onlyonce = false;
        playButton.gameObject.SetActive(false);
        placeIndicator.showIndicator = true;
    }

    public void GameStart()
    {
        canStart = true;
        placeIndicator.gameObject.SetActive(false);
        PlaneDetectionToggle.Instance.TogglePlaneDetection();
    }

    public void AddNew()
    {
        onlyonce = false;
        qq.SetActive(true);
    }
}
