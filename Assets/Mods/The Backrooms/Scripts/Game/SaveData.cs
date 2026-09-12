using System;
using UnityEngine;

[Serializable]
public struct SaveData
{
    public int level;
    public int seed;
    public float playTime;

    public string ToJson()
    {
        return JsonUtility.ToJson(this);
    }
    public static SaveData FromJson(string json)
    {
        return JsonUtility.FromJson<SaveData>(json);
    }
}
