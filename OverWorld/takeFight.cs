using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class takeFight : MonoBehaviour
{
    public int BossLevelIndex;
    public int LevelIndex;

    public int enemySpeed;
    public int hungerSubtract;
    public int enemyattack;
    public Weapon enemyweapon;
    public int maxhealth;
    public float AttackRange;
    public float AttackDelay;

    public int TransferToScene;
    public string cutsceneLoc;


    int hunger;

    public void StartFight()
    {
        hunger = GameObject.Find("Player").GetComponent<PlayerInOverWorld>().hunger;

        if(GameObject.Find("CutSceneManager") != null)
        {
            if (cutsceneLoc != "")
            {
                CutSceneManager.Instance.pbName = cutsceneLoc;
                CutSceneManager.Instance.currentScene = SceneManager.GetActiveScene().buildIndex;
            }
            else
            {
                CutSceneManager.Instance.pb = null;
                CutSceneManager.Instance.currentScene = 0;
            }
        }


        if(hunger > 0)
        {
            GameObject.Find("Player").GetComponent<PlayerInOverWorld>().Changehunger(-hungerSubtract);
            //Change Scene
            GameObject.Find("Player").GetComponent<PlayerInOverWorld>().ChangeSceneFight();
        }

        globalObject.Instance.Eweapon = enemyweapon;
        globalObject.Instance.eSpeed = enemySpeed;
        globalObject.Instance.eAttack = enemyattack;
        globalObject.Instance.enemyMaxHealth = maxhealth;
        globalObject.Instance.eDelay = AttackDelay;
        globalObject.Instance.eRange = AttackRange;

        if(TransferToScene != 0)
        {
            globalObject.Instance.TransferToScene = TransferToScene;
            GameObject.Find("LevelLoader").GetComponent<levelloader>().LoadNextLevel(LevelIndex);
        }
        else
        {
            globalObject.Instance.TransferToScene = SceneManager.GetActiveScene().buildIndex;
            GameObject.Find("LevelLoader").GetComponent<levelloader>().LoadNextLevel(LevelIndex);
        }


        if (BossLevelIndex != 0)
        {
            globalObject.Instance.eBoss = true;
            
            GameObject.Find("LevelLoader").GetComponent<levelloader>().LoadNextLevel(BossLevelIndex);
        }
        else
        {
            GameObject.Find("LevelLoader").GetComponent<levelloader>().LoadNextLevel(LevelIndex);
        }
    }
}
