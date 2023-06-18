using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerInOverWorld : MonoBehaviour
{
    public int hunger;
    public int maxhunger;

    public static int coins = 100;
    public static int diamonds = 50;

    public int coinsAdded;
    public int diamondsAdded;

    public Text diamondtext;
    public Text cointext;
    public Slider hungerbar;

    public static Weapon equipWeapon;
    public Weapon DefaultWeapon;

    [Header("UI SHOP")]
    public Text coinText;
    public Text diamondText;

    private void Start()
    {
        coins += coinsAdded;
        diamonds += diamondsAdded;
        ChangeText();
        hungerbar.maxValue = maxhunger;
        hungerbar.value = hunger;

        if (globalObject.Instance.firstTime == true)
        {
            equipWeapon = DefaultWeapon;
            globalObject.Instance.firstTime = false;
        }

        transform.position = ES3.Load<Vector3>("playerPos");
        if(ES3.KeyExists("foodPlatforms"))
        {
            Debug.Log(ES3.Load<List<string>>("foodPlatforms"));
        }    
        
    }
    public void ChangeSceneFight()
    {
        //Change Scene
    }
    public void ChangeText()
    {

        diamondtext.text = diamonds.ToString();
        cointext.text = coins.ToString();
    }
    public void Changehunger(int h)
    {
        hunger += h;
        globalObject.Instance.playerHunger = hunger;
        hungerbar.value = hunger;
    }

    public void Update()
    {
        if(coinText != null)
        {
            coinText.text = coins.ToString();
            diamondText.text = diamonds.ToString();
        }
        globalObject.Instance.playerHunger = hunger;
    }
}
