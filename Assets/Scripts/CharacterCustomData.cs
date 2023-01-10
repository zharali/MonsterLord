using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class CharacterCustomData : MonoBehaviour
{

    public void SetCharacterStyle(GameObject character)
    {
        GlobalData.instance.data.characterStyle = character;
    }

    public void SetSkinColor(GameObject skin)
    {
        GlobalData.instance.data.skinColor = skin;
    }

    public void SetEyesStyle(GameObject eyes)
    {
        GlobalData.instance.data.eyesStyle = eyes;
    }

    public void SetMouthStyle(GameObject mouth)
    {
        GlobalData.instance.data.mouthStyle = mouth;
    }
 
}
