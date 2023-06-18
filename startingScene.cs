using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class startingScene : MonoBehaviour
{
    public int tutIndex;
    public int OverWorldIndex;

    private void Start()
    {
    }
    public void LoadNextScene()
    {
        if (PlayerPrefs.GetInt("Stage") == 0)
        {
            GameObject.Find("LevelLoader").GetComponent<levelloader>().LoadNextLevel(OverWorldIndex);
            PlayerPrefs.SetInt("Stage", 1);
        }
        else if(PlayerPrefs.GetInt("Stage") == 1)
        {
            GameObject.Find("LevelLoader").GetComponent<levelloader>().LoadNextLevel(OverWorldIndex);
        }

    }
}
