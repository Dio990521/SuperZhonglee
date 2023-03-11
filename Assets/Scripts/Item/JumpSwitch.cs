using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpSwitch : MonoBehaviour
{
    public static JumpSwitch instance { get; private set; }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            DestroyImmediate(gameObject);
        }
    }

}
