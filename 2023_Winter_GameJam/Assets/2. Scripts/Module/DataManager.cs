using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

class PlayData
{
    //저장할 데이터 써주기
}

public class DataManager : Singleton<DataManager>
{
    PlayData playData = new PlayData();

    string path = Application.dataPath + "6. Data";

    public void Save()
    {
        string data = JsonUtility.ToJson(playData);
        File.WriteAllText(path + "/SaveData", data);
    }

    public void Load()
    {
        string data = File.ReadAllText(path);
        playData = JsonUtility.FromJson<PlayData>(data);
    }
}
