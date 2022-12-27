using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPersistent : MonoBehaviour
{
    public bool keepObjectPersistent = true;

    void Awake()
    {
        if (keepObjectPersistent)
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
