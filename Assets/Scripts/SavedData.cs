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

    public float skinColorR;
    public float skinColorG;
    public float skinColorB;

    public int eyesStyle;    // 1;2
    public int mouthStyle;   // 1;2;3
    public int characterStyle; // 1;2;3;4

}
