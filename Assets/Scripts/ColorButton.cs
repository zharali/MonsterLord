using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorButton : MonoBehaviour
{
    public SelectColor selectColor; 

    [Header("Color Values")]
    public float redAmount;
    public float greenAmount;
    public float blueAmount;

    [Header("Color Sliders")]
    public Slider redSlider;
    public Slider greenSlider;
    public Slider blueSlider;

    public Image colorImage;

    private void Awake()
    {
        /* GameObject colorImageGO = GameObject.Find("ColorImage");
         if (colorImageGO != null)
         {
             colorImage = colorImageGO.GetComponent<Image>();
             if (colorImage == null)
             {
                 Debug.LogError("No Image component on the GameObject with name 'ColorImage'");
             }
         }
         else
         {
             Debug.LogError("GameObject with name 'ColorImage' not found in scene.");
         }*/

        colorImage = GetComponent<Image>();
        redAmount = colorImage.color.r;
        greenAmount = colorImage.color.g;
        blueAmount = colorImage.color.b;

    /*    if (colorImage != null)
        {
            if (colorImage.color.r == null)
            {
                redAmount = 0;
            }
            else
            {
                redAmount = colorImage.color.r;
            }

            if (colorImage.color.g == null)
            {
                greenAmount = 0;
            }
            else
            {
                greenAmount = colorImage.color.g;
            }

            if (colorImage.color.b == null)
            {
                blueAmount = 0;
            }
            else
            {
                blueAmount = colorImage.color.b;
            }
        }
        else
        {
            Debug.LogError("colorImage object is not assigned!");
        }*/
    }


    public void SetSliderValuesToImageColor()
    {
        redSlider.value = redAmount;
        greenSlider.value = greenAmount;
        blueSlider.value = blueAmount;

        selectColor.redAmount = redAmount;
        selectColor.greenAmount = greenAmount;
        selectColor.blueAmount = blueAmount;
        selectColor.SetColor();
    }
}

