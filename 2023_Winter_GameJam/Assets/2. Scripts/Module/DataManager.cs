using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]
public class PlayData
{
    //저장할 데이터 써주기
    public float sound = 0.5f;
}



public class DataManager : Singleton<DataManager>
{
    public PlayData playData = new PlayData();

    string path/* = Application.dataPath + "/6. Data"*/;
    private void Start()
    {
        path = Application.dataPath + "/8. Data";
        if (!File.Exists(path)) Directory.CreateDirectory(path);
    }

    public void Save()
    {
        string data = JsonUtility.ToJson(playData);
        File.WriteAllText(path + "/SaveData", data);
    }

    public void Load()
    {
        string data = File.ReadAllText(path + "/SaveData");
        playData = JsonUtility.FromJson<PlayData>(data);
    }
}
