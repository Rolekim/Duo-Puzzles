using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyScript : MonoBehaviour
{
    public static DontDestroyScript dontDestroyScript;

    public float sliderValue;

    void Awake()
    {
        if (dontDestroyScript == null)
        {
            dontDestroyScript = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
