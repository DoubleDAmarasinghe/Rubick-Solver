using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerRotateButtonManager : MonoBehaviour
{
    //start with capital is arrow direction
    public bool rightUp;
    public bool rightDown;
    public bool rightUpRight;
    public bool rightDownRight;

    public bool leftUp;
    public bool leftDown;
    public bool leftUpLeft;
    public bool leftDownLeft;

    public bool midUp;
    public bool midDown;

    public bool midRight;

    public bool midLeft;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetRightUp()
    {
        rightUp = true;
    }

    public void SetRightDown()
    {
        rightDown = true;
    }

    public void SetRightUpRight()
    {
        rightUpRight = true;
    }

    public void SetRightDownRight()
    {
        rightDownRight = true;
    }



    public void SetLeftUp()
    {
        leftUp = true;
    }
    public void SetLeftDown()
    {
        leftDown = true;
    }
    public void SetLeftUpLeft()
    {
        leftUpLeft = true;
    }
    public void SetLeftDownLeft()
    {
        leftDownLeft = true;
    }

    public void SetMidUp()
    {
        midUp = true;
    }

    public void SetMidDown()
    {
        midDown = true;
    }

    public void SetMidRight()
    {
        midRight = true;
    }

    public void SetMidLeft()
    {
        midLeft = true;
    }
}
