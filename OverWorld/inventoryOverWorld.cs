using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class inventoryOverWorld : MonoBehaviour
{
    public static Weapon currentweapon;

    public Sprite greenButton;
    public Sprite blueButton;

    public void Awake()
    {
        currentweapon = PlayerInOverWorld.equipWeapon;
    }
    public void EquipWeapon(Weapon w)
    {
        PlayerInOverWorld.equipWeapon = w;
        currentweapon = PlayerInOverWorld.equipWeapon;
        globalObject.Instance.pWeapon = w;
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            SceneManager.LoadScene(1);
        }
    }
}
