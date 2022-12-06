using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalData: MonoBehaviour
{
    // Character variables
    public SavedData data;

    private GlobalData() { }

    #region Singleton
    public static GlobalData instance;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
            DataSaver.Load();  // Loading data from saved file
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    #endregion
}
