using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class CharacterCustomData : MonoBehaviour
{

    public GameObject skinColor;
    public GameObject eyesStyle;
    public GameObject mouthStyle;
    public GameObject characterStyle;
    CharacterCustomizationData customizationData = ScriptableObject.CreateInstance<CharacterCustomizationData>();


    public void SetCharacterStyle(GameObject character)
    {
        characterStyle = character;
        customizationData.characterStyle = characterStyle;
    }

    public GameObject SetSkinColor(GameObject skin)
    {
        skinColor = skin;
        return skin;
    }

    public GameObject SetEyesStyle(GameObject eyes)
    {
        eyesStyle = eyes;
        return eyes;
    }

    public GameObject SetMouthStyle(GameObject mouth)
    {
        mouthStyle = mouth;
        return mouth;
    }

    public void CreateData()
    {
       
        //customizationData.skinColor = skinColor;
        //customizationData.eyesStyle = eyesStyle;
        //customizationData.mouthStyle = mouthStyle;
        AssetDatabase.CreateAsset(customizationData, "Assets/CharacterCustomizationData.asset");
        AssetDatabase.SaveAssets();
    }
    
}
