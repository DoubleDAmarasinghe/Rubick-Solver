using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Automate : MonoBehaviour
{
    public static List<string> moveList = new List<string>() {};
    private readonly List<string> allMoves = new List<string>()
        { "U", "D", "L", "R", "F", "B",
          "U2", "D2", "L2", "R2", "F2", "B2",
          "U'", "D'", "L'", "R'", "F'", "B'" 
        };
    private CubeStatus cubeStatus;
    private ReadCube readCube;
    [HideInInspector]
    public bool shuffle = false;

    public AudioSource source;
    
    
    // Start is called before the first frame update
    void Start()
    {
        cubeStatus = FindObjectOfType<CubeStatus>();
        readCube = FindObjectOfType<ReadCube>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if(moveList.Count > 0 && !CubeStatus.autoRotating && CubeStatus.started)
        {
            DoMove(moveList[0]);
            moveList.Remove(moveList[0]);
            //Debug.Log("gggggggggggggggggggggggggggggggg");
        }
    }

    public IEnumerator firstShuffle()
    {
        yield return new WaitForSeconds(1f);
        List<string> moves = new List<string>();
        // int ShuffleLength = Random.Range(10, 30);
        int ShuffleLength = 11;
        for(int i = 0; i < ShuffleLength; i++)
        {
            int randomMoves = Random.Range(0, allMoves.Count);
            moves.Add(allMoves[randomMoves]);
        }
        moveList = moves;
        shuffle = true;
    }

    public void Shuffle()
    {
        
        
        List<string> moves = new List<string>();
        // int ShuffleLength = Random.Range(10, 30);
        int ShuffleLength = 20;
        for(int i = 0; i < ShuffleLength; i++)
        {
            int randomMoves = Random.Range(0, allMoves.Count);
            moves.Add(allMoves[randomMoves]);
        }
        moveList = moves;
        shuffle = true;
        
    }

    public void DoMove(string move)
    {
        //source.Play();
        //Debug.Log("xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx");
        readCube.ReadState();
        CubeStatus.autoRotating = true;
        if (move == "U")
        {
            RotateSide(cubeStatus.up, -90);
        }
        if (move == "U'")
        {
            RotateSide(cubeStatus.up, 90);
        }
        if (move == "U2")
        {
            RotateSide(cubeStatus.up, -180);
        }
        if (move == "D")
        {
            RotateSide(cubeStatus.down, -90);
        }
        if (move == "D'")
        {
            RotateSide(cubeStatus.down, 90);
        }
        if (move == "D2")
        {
            RotateSide(cubeStatus.down, -180);
        }
        if (move == "L")
        {
            RotateSide(cubeStatus.left, -90);
        }
        if (move == "L'")
        {
            RotateSide(cubeStatus.left, 90);
        }
        if (move == "L2")
        {
            RotateSide(cubeStatus.left, -180);
        }
        if (move == "R")
        {
            RotateSide(cubeStatus.right, -90);
        }
        if (move == "R'")
        {
            RotateSide(cubeStatus.right, 90);
        }
        if (move == "R2")
        {
            RotateSide(cubeStatus.right, -180);
        }
        if (move == "F")
        {
            RotateSide(cubeStatus.front, -90);
        }
        if (move == "F'")
        {
            RotateSide(cubeStatus.front, 90);
        }
        if (move == "F2")
        {
            RotateSide(cubeStatus.front, -180);
        }
        if (move == "B")
        {
            RotateSide(cubeStatus.back, -90);
        }
        if (move == "B'")
        {
            RotateSide(cubeStatus.back, 90);
        }
        if (move == "B2")
        {
            RotateSide(cubeStatus.back, -180);
        }
    }

    public void RotateSide(List<GameObject> side, float angle)
    {
        PiviotRotation pr = side[4].transform.parent.GetComponent<PiviotRotation>();
        pr.StartAutoRotate(side, angle);
    }
}
