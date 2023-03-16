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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.rotation != cube.transform.rotation)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, cube.transform.rotation, speed * Time.deltaTime);
        }

        if(Input.GetMouseButtonDown(1))
        {
            Debug.Log("sdfsdfsdfsdfdsf");
        }
    }

    public void RotateLeft()
    {
        cube.transform.Rotate(0, 90, 0, Space.World);
    }

    public void RotateRight()
    {
        cube.transform.Rotate(0, -90, 0, Space.World);
    }

    public void RotateUp()
    {
        cube.transform.Rotate(90, 0, 0, Space.World);
    }

    public void RotateBottom()
    {
        cube.transform.Rotate(-90, 0, 0, Space.World);
    }
}