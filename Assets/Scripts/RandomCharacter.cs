using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class RandomCharacter : MonoBehaviour //select character charasteristics randomly 
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


    public void Random()
    {
        GameObject characterList = transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;
        GameObject eyesList = transform.GetChild(2).gameObject.transform.GetChild(0).gameObject;
        GameObject mouthList = transform.GetChild(3).gameObject.transform.GetChild(0).gameObject;

        int character = UnityEngine.Random.Range(0, 5);
        int eyes = UnityEngine.Random.Range(0, 5);
        int mouth = UnityEngine.Random.Range(0, 4);

        //select a random characteristic from the lists
        Button rdmCharacter = characterList.transform.GetChild((character > 0 && character <= 4) ? character - 1 : 0).gameObject.GetComponent<Button>();
        Debug.Log(rdmCharacter.gameObject.name);
        Button rdmEyes = eyesList.transform.GetChild((eyes > 0 && eyes <= 4) ? eyes - 1 : 0).gameObject.GetComponent<Button>();
        Debug.Log(rdmEyes.gameObject.name);
        Button rdmMouth = mouthList.transform.GetChild((mouth > 0 && mouth <= 3) ? mouth - 1 : 0).gameObject.GetComponent<Button>();
        Debug.Log(rdmMouth.gameObject.name);

        //click on the button of the characteristic randomly chosen 
        rdmCharacter.onClick.Invoke();
        rdmEyes.onClick.Invoke();
        rdmMouth.onClick.Invoke();

        //to get one of the color randomly 
        float[] red = { 1, 0, 0 };
        float[] green = { 0.353333f, 0.7075472f, 0.1435119f };
        float[] blue = { 0.1390174f, 0.1939771f, 0.4150943f };
        float[] black = { 0, 0, 0 };
        float[] pink = { 0.9811321f, 0.3008188f, 0.716f };
        float[] white = { 1, 1, 1 };
        float[] orange = { 1, 0.5102247f, 0 };
        float[] lavender = { 0.6493772f, 0.3737985f, 0.754717f };
        float[] skyblue = { 0, 0.7673926f, 1 };
        float[] brown = { 0.4528302f, 0.08738429f, 0 };
        float[] yellow = { 0.9370375f, 1, 0.1556604f };
        float[] grey = { 0.3584906f, 0.3584906f, 0.3584906f };

        float[][] color = { red, green, blue, black, pink, white, orange, lavender, skyblue, brown, yellow, grey };

        float[] rdmColor = color[UnityEngine.Random.Range(0, 11)];

        redAmount = rdmColor[0];
        Debug.Log(redAmount);
        greenAmount = rdmColor[1];
        Debug.Log(greenAmount);
        blueAmount = rdmColor[2];
        Debug.Log(blueAmount);

        //set the color 
        if (selectColor == null)
        {
            Debug.Log("selectColor is null");
        }

        selectColor.redAmount = redAmount;
        selectColor.greenAmount = greenAmount;
        selectColor.blueAmount = blueAmount;
        selectColor.SetColor();
    }
}
