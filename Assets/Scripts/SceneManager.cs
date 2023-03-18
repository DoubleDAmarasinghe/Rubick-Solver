using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    //[System.Obsolete]
    public void LoadPlaceCubeLevel()
    {
        Application.LoadLevel(1);
    }

    public void LoadGameLevel()
    {
        Application.LoadLevel(2);
    }
}
