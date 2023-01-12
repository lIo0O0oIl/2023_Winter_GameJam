using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Set();
    }

    public void Set()
    {
        int w= 1280;
        int h = 720;

        Screen.SetResolution(w, h, false);
    }
}
