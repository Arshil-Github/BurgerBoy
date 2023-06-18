using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class takeFood : MonoBehaviour
{
    public int health;
    GameObject player;
    int currenthunger;
    int maxhunger;


    private void Awake()
    {
        player = GameObject.Find("Player");
        currenthunger = player.GetComponent<PlayerInOverWorld>().hunger;
        maxhunger = player.GetComponent<PlayerInOverWorld>().maxhunger;
    }
    public void Intake()
    {
        if (currenthunger < maxhunger)
        {
            player.GetComponent<PlayerInOverWorld>().Changehunger(health);
        }
    }
}