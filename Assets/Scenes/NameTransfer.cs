using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NameTransfer : MonoBehaviour
{
    public TextMeshProUGUI theName;
    public TMP_InputField inputField;
    public TextMeshProUGUI textDisplay;

    public void StoreName()
    {
        theName.text = inputField.text;
        textDisplay.text = "Welcome " + theName + " to MonsterLord!";
    }
}
