using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class CharacterCustomData : MonoBehaviour
{
    public GameObject characterStyle;
    public int characterStyleID { private get; set; }

    public GameObject skinColor;

    public GameObject eyesStyle;
    public int eyesStyleID { private get; set; }

    public GameObject mouthStyle;
    public int mouthStyleID { private get; set; }

    public void OnClick()
    {
        Debug.Log(characterStyleID);
        Debug.Log(eyesStyleID);
        Debug.Log(mouthStyleID);
        //SavedData savedData = new SavedData();
        GlobalData.instance.data.characterStyle = characterStyleID;
        // Color is already saved 
        GlobalData.instance.data.eyesStyle = eyesStyleID;
        GlobalData.instance.data.mouthStyle = mouthStyleID;
        //GlobalData.instance.data = savedData;
        //DataSaver.Save();


    }
}



