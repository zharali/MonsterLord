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
        FileStream fs = File.Create(Application.persistentDataPath + "/PlayerData.dat");

        bf.Serialize(fs, GlobalData.instance.data);
        fs.Close();
    }

    public static void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/PlayerData.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = File.Open(Application.persistentDataPath + "/PlayerData.dat", FileMode.Open);
            GlobalData.instance.data = bf.Deserialize(fs) as SavedData;
            fs.Close();

            if (GlobalData.instance != null)
            {
                Debug.Log("Level: " + GlobalData.instance.data.characterLevel);
                Debug.Log("Sprite Id: " + GlobalData.instance.data.spriteId);
                Debug.Log("Highscore: " + GlobalData.instance.data.highscore);
            }
        }
    }
}
