using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletIndicator : MonoBehaviour
{
    public Slider slider;
    public Text bulletCount;
    public void SetBulletCount(int _bulletCount)
    {
        bulletCount.text = _bulletCount.ToString();
    }
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