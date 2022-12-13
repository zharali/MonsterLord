﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

	public Slider slider;
	
	public void SetMaxHealth(long health)
	{
		slider.maxValue = health;
		slider.value = health;
	}
    
    public void SetHealth(long health)
    {
    	slider.value = health;
    }
}
