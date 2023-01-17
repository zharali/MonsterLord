using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

	public Slider slider;
	public Text number;
	
	public void SetMaxHealth(long health)
	{
		slider.maxValue = health;
		slider.value = health;
    	number.text = "HP: " + ((int)health).ToString() + "/" + slider.maxValue.ToString();
	}
    
    public void SetHealth(long health)
    {
    	slider.value = health;
    	number.text = "HP: " + ((int)health).ToString() + "/" + slider.maxValue.ToString();
    }
}
