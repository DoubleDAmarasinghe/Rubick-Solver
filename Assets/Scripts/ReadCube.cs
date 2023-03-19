using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadCube : MonoBehaviour
{
    public Transform transformUp;
    public Transform transformDown;
    public Transform transformLeft;
    public Transform transformRight;
    public Transform transformFront;
    public Transform transformBack;

    private List<GameObject> frontRays = new List<GameObject>();
    private List<GameObject> backRays = new List<GameObject>();
    private List<GameObject> upRays = new List<GameObject>();
    private List<GameObject> downRays = new List<GameObject>();
    private List<GameObject> leftRays = new List<GameObject>();
    private List<GameObject> rightRays = new List<GameObject>();

    public GameObject emptyGameObject;
    private int layerMask = 1 << 6;
    CubeStatus cubeStatus;
    CubeMap cubemap;
    // Start is called before the first frame update
    void Start()
    {
        SetRayTransform();

        cubeStatus = GameObject.FindObjectOfType<CubeStatus>();
        cubemap = FindObjectOfType<CubeMap>(); 
        ReadState();
        CubeStatus.started = true;
    }

    // Update is called once per frame
    void Update()
    {
        //ReadState();
        
    }

    public void ReadState()
    {
        cubeStatus = FindObjectOfType<CubeStatus>();
        cubemap = FindObjectOfType<CubeMap>();

        cubeStatus.up = ReadFace(upRays, transformUp);
        cubeStatus.down = ReadFace(downRays, transformDown);
        cubeStatus.left = ReadFace(leftRays, transformLeft);
        cubeStatus.right = ReadFace(rightRays, transformRight);
        cubeStatus.front = ReadFace(frontRays, transformFront);
        cubeStatus.back = ReadFace(backRays, transformBack);
        cubemap.SetColor();
    }

    void SetRayTransform()
    {
        upRays = BuildRays(transformUp, new Vector3(90, 90, 0));
        downRays = BuildRays(transformDown, new Vector3(270, 90, 0));
        leftRays = BuildRays(transformLeft, new Vector3(0, 180, 0));
        rightRays = BuildRays(transformRight, new Vector3(0,0,0));
        frontRays = BuildRays(transformFront, new Vector3(0, 90, 0));
        backRays = BuildRays(transformBack, new Vector3(0, 270, 0));
    }

    List<GameObject> BuildRays(Transform rayTransform, Vector3 direction)
    {
        int rayCount = 0;
        List<GameObject> rays = new List<GameObject>();

        for(int y = 1; y > -2; y--)
        {
            for(int x = -1; x < 2; x++)
            {
                Vector3 startPosition = new Vector3(rayTransform.localPosition.x + x, rayTransform.localPosition.y + y, rayTransform.localPosition.z);
                GameObject rayStart = Instantiate(emptyGameObject, startPosition, Quaternion.identity, rayTransform);
                rayStart.name = rayCount.ToString();
                rays.Add(rayStart);
                rayCount++;
            }
        }
        rayTransform.localRotation = Quaternion.Euler(direction);
        return rays;

    }

    public List<GameObject> ReadFace(List<GameObject> rayStarts, Transform rayTransform)
    {
        List<GameObject> facesHit = new List<GameObject>();

        foreach(GameObject rayStart in rayStarts)
        {
            Vector3 ray = rayStart.transform.position;
            RaycastHit hit;

            if(Physics.Raycast(ray, rayTransform.forward, out hit, Mathf.Infinity, layerMask))
            {
                Debug.DrawRay(ray, rayTransform.forward * hit.distance, Color.yellow);
                facesHit.Add(hit.collider.gameObject);
                //print(hit.collider.gameObject.name);
                
            }

            else
            {
                Debug.DrawRay(ray, rayTransform.forward * 1000, Color.green);
            }
        }
        

        return facesHit;
    }
}
