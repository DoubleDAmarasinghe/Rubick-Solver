using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kociemba;

public class SolveTwoPhase : MonoBehaviour
{
    
    public ReadCube readCube;
    public CubeStatus cubeStatus;
    private bool doOnce = true;
    [HideInInspector]
    public bool solvering = false;
    // Start is called before the first frame update
    void Start()
    {
        readCube = FindObjectOfType<ReadCube>();
        cubeStatus = FindObjectOfType<CubeStatus>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CubeStatus.started && doOnce)
        {
            doOnce = false;
            Solver();
        }
    }

    public void Solver()
    {
        
        readCube.ReadState();

        // get the state of the cube as a string
        string moveString = cubeStatus.GetStateString();
        print(moveString);

        // solve the cube
        string info = "";

        //First time build the tables
        //string solution = SearchRunTime.solution(moveString, out info, buildTables: true);

        //Every other time
        string solution = Search.solution(moveString, out info);

        // convert the solved moves from a string to a list
        List<string> solutionList = StringToList(solution);

        //Automate the list
        Automate.moveList = solutionList;
        //Automate.moveList = new List<string> {"U", "D", "L", "R", "F", "B"};
        print(info);
        // Debug.Log(Automate.moveList.Count);
        // Debug.Log(CubeStatus.autoRotating);
        // Debug.Log(CubeStatus.started);
        Debug.Log(solution);

    }

    List<string> StringToList(string solution)
    {
        List<string> solutionList = new List<string>(solution.Split(new string[] { " " }, System.StringSplitOptions.RemoveEmptyEntries));
        return solutionList;
    }

}
