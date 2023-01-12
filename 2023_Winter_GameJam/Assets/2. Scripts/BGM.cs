using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM : Singleton<BGM>
{
    public AudioSource BBB;
    private void Update()
    {
        BBB.volume = DataManager.Instance.playData.sound;
    }
}
