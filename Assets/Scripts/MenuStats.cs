using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class MenuStats : MonoBehaviour
{
	public Text highScore;
	public Text playerLevel;
    // Start is called before the first frame update
    void Start()
    {
    	highScore.text = "HIGH SCORE: " + ((int)GlobalData.instance.data.highscore).ToString();
    	playerLevel.text = "PLAYER LEVEL: " + ((int)GlobalData.instance.data.characterLevel).ToString();
    }
}
