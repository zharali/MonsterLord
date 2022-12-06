using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class DataSaver : MonoBehaviour
{
    public static void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream fs = new FileStream(Application.persistentDataPath + "/PlayerData.dat", FileMode.Create);

        bf.Serialize(fs, GlobalData.instance.data);
        fs.Close();

        Debug.Log($"DataSaver : Saved data to {Application.persistentDataPath}/PlayerData.dat");
    }

    // Data is loaded on GlobalData creation
    public static void Load()
    {
        Debug.Log($"Loading data at {Application.persistentDataPath}/PlayerData.dat");
        if (File.Exists(Application.persistentDataPath + "/PlayerData.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = File.Open(Application.persistentDataPath + "/PlayerData.dat", FileMode.Open);
            GlobalData.instance.data = bf.Deserialize(fs) as SavedData;
            fs.Close();

            Debug.Log("Data loaded");

            if (GlobalData.instance != null)
            {
                Debug.Log("Level: " + GlobalData.instance.data.characterLevel);
                Debug.Log("Sprite Id: " + GlobalData.instance.data.spriteId);
                Debug.Log("Highscore: " + GlobalData.instance.data.highscore);
            }
        }
    }

    // Saving game data in three states : when the game is paused, when the game loses focus and when the game quits

    public void OnApplicationPause(bool pause)
    {
        Debug.Log("MonsterDebug: Pause");
        if (pause) Save();
    }

    public void OnApplicationFocus(bool hasFocus)
    {
        Debug.Log("MonsterDebug: Focus");
        if (!hasFocus) Save();
    }

    public void OnApplicationQuit() => Save();

}
