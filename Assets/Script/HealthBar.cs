using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Text healthNum;
    public void setMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
        healthNum.text = slider.value.ToString() + "/" + slider.maxValue.ToString();
    }
    public void setHealth(int health)
    {
        if (health < 0) health = 0;
        slider.value = health;
        healthNum.text = slider.value.ToString() + "/" + slider.maxValue.ToString();
    }
}
