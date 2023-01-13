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
        colorImage = GetComponent<Image>();
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

