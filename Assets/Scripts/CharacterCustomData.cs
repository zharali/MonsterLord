using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class CharacterCustomData : MonoBehaviour
{
    public GameObject characterStyle;
    public GameObject skinColor;
    public GameObject eyesStyle;
    public GameObject mouthStyle;

    public void OnClick()
    {
        SavedData savedData = new SavedData();
        savedData.characterStyle = characterStyle;
        savedData.skinColor = skinColor;
        savedData.eyesStyle = eyesStyle;
        savedData.mouthStyle = mouthStyle;
        GlobalData.instance.data = savedData;
        DataSaver.Save();
    }


}



