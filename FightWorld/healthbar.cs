using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthbar : MonoBehaviour
{
    public Slider slider;
    public Gradient colorgradient;
    public Image fill;
    public void SetHealth(int health)
    {
        slider.value = health;

        fill.color = colorgradient.Evaluate(slider.normalizedValue);
    }
    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        fill.color = colorgradient.Evaluate(1f);
    }
}
