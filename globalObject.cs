using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class globalObject : MonoBehaviour
{
    public static globalObject Instance;

    public int TransferToScene;

    public string foodLoc = "world/";
    public string fightLoc = "world/";
    //Enemy
    public int eAttack;
    public Weapon Eweapon;
    public float eSpeed;
    public int enemyMaxHealth = 100;
    public float eDelay;
    public float eRange;

    public bool eBoss;

    //Player
    public int playerHunger;
    public Weapon pWeapon;
    public bool firstTime = true;

    public List<string> foodPlatforms;
    public List<string> fightPlatforms;
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
    private void Start()
    {
        StartCoroutine(equipDefaultWeapon());

        
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.U))
        {
            Debug.Log(foodPlatforms[0]);
        }



        ES3.Save<List<string>>("fightPlatforms", fightPlatforms);
        ES3.Save<List<string>>("foodPlatforms", foodPlatforms);
    }
    public void ChangeTagFight()
    {
        if (ES3.KeyExists("fightPlatforms"))
        {
            globalObject.Instance.foodPlatforms = ES3.Load<List<string>>("fightPlatforms");
        }
        foreach (string f in fightPlatforms)
        {
            if (GameObject.Find(fightLoc + f) != null)
            {
                GameObject.Find(fightLoc + f).tag = "fight";
            }
            
        }
    }
    public void ChangeTagFood()
    {
        if (ES3.KeyExists("foodPlatforms"))
        {
            globalObject.Instance.foodPlatforms = ES3.Load<List<string>>("foodPlatforms");
        }
        foreach (string f in foodPlatforms)
        {
            if (GameObject.Find(foodLoc + f) != null)
            {
                GameObject.Find(foodLoc + f).tag = "food";
            }

        }
    }
    IEnumerator equipDefaultWeapon()
    {
        yield return new WaitForSeconds(1);
        pWeapon = PlayerInOverWorld.equipWeapon;
        StopAllCoroutines();
    }
}
