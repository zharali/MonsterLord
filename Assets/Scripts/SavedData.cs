using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SavedData
{
    public string name = "";
    public uint characterLevel = 1;
    public ulong levelxp = 0;
    public ushort spriteId = 0;
    public ulong highscore = 0;

    public GameObject skinColor;
    public GameObject eyesStyle;
    public GameObject mouthStyle;
    public GameObject characterStyle;
}
