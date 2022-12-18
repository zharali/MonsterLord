using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu2Game : MonoBehaviour
{
    public void Move2Game(int sceneID){
        SceneManager.LoadScene(sceneID);
    }
}
