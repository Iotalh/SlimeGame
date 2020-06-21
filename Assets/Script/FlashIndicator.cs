using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlashIndicator : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider slider;
    public void SetCd(float cd)
    {
        slider.maxValue = cd;
        slider.value = cd;
    }
    public void SetCdLeft(float cdLeft)
    {
        if (cdLeft < 0f)
        {
            cdLeft = 0f;
        }
        slider.value = slider.maxValue - cdLeft;
    }
}