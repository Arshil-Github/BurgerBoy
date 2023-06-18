using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class weaponCard : MonoBehaviour
{
    public Weapon weapon;

    Transform weaponImage;
    Transform weaponName;
    Transform equipButton;
    Transform attackText;
    bool IsEquipped;
    Weapon currentWeapon;

    private void Start()
    {
        weaponImage = gameObject.transform.GetChild(2);
        weaponImage.GetComponent<Image>().sprite = weapon.weaponImage;

        weaponName = gameObject.transform.GetChild(0);
        weaponName.GetComponent<Text>().text = weapon.weaponName;

        equipButton = gameObject.transform.GetChild(1);
        
        attackText = gameObject.transform.GetChild(3);

        currentWeapon = inventoryOverWorld.currentweapon;
    }
    private void Update()
    {
        currentWeapon = inventoryOverWorld.currentweapon;
        if (currentWeapon == weapon)
        {
            equipButton.transform.GetChild(0).GetComponent<Text>().text = "EQUIPPED";
            equipButton.GetComponent<Image>().sprite = GameObject.Find("manager").GetComponent<inventoryOverWorld>().greenButton;
        }
        else
        {
            equipButton.transform.GetChild(0).GetComponent<Text>().text = "EQUIP";
            equipButton.GetComponent<Image>().sprite = GameObject.Find("manager").GetComponent<inventoryOverWorld>().blueButton;
        }

        if (weapon.isPurchased == false)
        {
            equipButton.GetComponent<Button>().interactable = false;
        }
        else
        {
            equipButton.GetComponent<Button>().interactable = true;
        }
        attackText.GetComponent<Text>().text = "Attack - " + weapon.attack.ToString();

    }
}
