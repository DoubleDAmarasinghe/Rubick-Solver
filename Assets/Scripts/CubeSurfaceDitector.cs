using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSurfaceDitector : MonoBehaviour
{
    public GameObject arrowSet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RotateArrows()
    {
        arrowSet.transform.Rotate(0,0,90,Space.World);
    }
}
