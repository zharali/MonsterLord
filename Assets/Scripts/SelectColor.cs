using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//to use if we want sliders to select the color 
public class SelectColor : MonoBehaviour 
{
    [Header("Color Values")]
    public float redAmount;
    public float greenAmount;
    public float blueAmount;

    [Header("Color Sliders")]
    public Slider redSlider;
    public Slider greenSlider;
    public Slider blueSlider;

    private Color currentColor;

    //grab the material from the renderer and change the color properties of the material
    public List<Renderer> rendererList = new List<Renderer>();


    //if we want to customize the color, dont need it here 
    public void UpdateSliders()
    {
        redAmount = redSlider.value;
        greenAmount = greenSlider.value;
        blueAmount = blueSlider.value;
        SetColor(); 
    }

    public void SetColor()
    {
        currentColor = new Color(redAmount, greenAmount, blueAmount);

        for (int i=0; i < rendererList.Count; i++)
        {
            rendererList[i].material.SetColor("_Color", currentColor);
        }
    }

    public void SaveSkinColor()
    {
        GlobalData.instance.data.skinColorR = redAmount;
        GlobalData.instance.data.skinColorG = greenAmount;
        GlobalData.instance.data.skinColorB = blueAmount;
    }


}
