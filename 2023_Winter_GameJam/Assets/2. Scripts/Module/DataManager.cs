using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]
public class PlayData
{
    //저장할 데이터 써주기
    public float sound = 0.5f;
    public bool landClear = false;
    public bool seaClear = false;
}

public class DataManager : Singleton<DataManager>
{
    public PlayData playData;

    string path/* = Application.dataPath + "/6. Data"*/;

    private void Awake()
    {
        playData = new PlayData();
    }

    private void Start()
    {
        path = Application.dataPath + "/8. Data";
        if (!File.Exists(path)) Directory.CreateDirectory(path);

        if (!File.Exists(Application.dataPath + "/8. Data/SaveData.txt")) Save();
    }

    public void Save()
    {
        string data = JsonUtility.ToJson(playData);
        File.WriteAllText(path + "/SaveData.txt", data);
    }

    public void Load()
    {
        string data = File.ReadAllText(Application.dataPath + "/8. Data/SaveData.txt");
        playData = JsonUtility.FromJson<PlayData>(data);
    }
}
