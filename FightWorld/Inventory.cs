using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public PlayerMovement player;
    public GameObject playerWeapon;
    public Weapon currentweapon;
    public GameObject firesword;

    public fightManager fm;
    [Header("Weapon Anim Controller")]
    public RuntimeAnimatorController swordCon;
    public RuntimeAnimatorController axeCon;
    public RuntimeAnimatorController fireCon;

    private void Start()
    {
        if(globalObject.Instance.pWeapon != null)
        {
            currentweapon = globalObject.Instance.pWeapon;
        }
        

        player.attackDamage = currentweapon.attack;
        playerWeapon.GetComponent<SpriteRenderer>().sprite = currentweapon.weaponImage;

        if(currentweapon.type == "sword")
        {
            player.GetComponent<Animator>().runtimeAnimatorController = swordCon;
            playerWeapon.SetActive(true);
            firesword.SetActive(false);
        }
        else if(currentweapon.type == "axe")
        {
            player.GetComponent<Animator>().runtimeAnimatorController = axeCon;
            playerWeapon.SetActive(true);
            firesword.SetActive(false);
        }
        else if (currentweapon.type == "fire")
        {
            player.GetComponent<Animator>().runtimeAnimatorController = fireCon;
            playerWeapon.SetActive(false);
            firesword.SetActive(true);
        }
    }

    public void Awake()
    {
    }
}
