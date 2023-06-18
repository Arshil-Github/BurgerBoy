using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class CutSceneManager : MonoBehaviour
{
    public static CutSceneManager Instance;

    public int currentScene;

    public string pbName;
    public GameObject pb;

    void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

    }






    public void PlayAfterFightCutScene()
    {
        // Called from Manager
        if(GameObject.Find(pbName) != null)
        {
            pb = GameObject.Find(pbName);
            if (SceneManager.GetActiveScene().buildIndex == currentScene)
            {
                pb.GetComponent<PlayableDirector>().Play();
            }
        }
    }
}
