using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerBar : MonoBehaviour
{
    public Slider slider;
    public Text number;
    
    void Start()
    {
    	number.fontSize = 80;
    }

    public void SetMaxTime(int time)
    {
        slider.maxValue = time;
        slider.value = time;
        number.text = "TIMER: " + (time).ToString() + "/" + slider.maxValue.ToString() + " s";
    }

    public void SetTime(int time)
    {
        slider.value = time;
        number.text = "TIMER: " + (time).ToString() + "/" + slider.maxValue.ToString() + " s";
    }
}
