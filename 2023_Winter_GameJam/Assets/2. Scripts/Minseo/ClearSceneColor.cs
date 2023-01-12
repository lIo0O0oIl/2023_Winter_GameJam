using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearSceneColor : MonoBehaviour
{
    SpriteRenderer spriteRenderer;

    public List<Color> colors = new List<Color>();
    
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Color()
    { 
        return null;
    }
}
