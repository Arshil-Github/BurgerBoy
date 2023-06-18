using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon")]
public class Weapon : ScriptableObject
{
    public Sprite weaponImage;
    public int attack;
    public int price;
    public string weaponName;

    public bool isPurchased;

    public string type;
}
