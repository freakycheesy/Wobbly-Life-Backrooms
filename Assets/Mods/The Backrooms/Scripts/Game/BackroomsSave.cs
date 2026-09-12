using UnityEngine;

public static class BackroomsSave
{
    public static SaveData data;
    public static int slot { get; set; } = 0;
    private static string GetSaveKey() => "WobblyLifeBackrooms" + slot.ToString();

    public static void Initialize()
    {
        slot = PlayerPrefs.GetInt("WobblyLifeBackroomsSlot", 0);
        Load();
    }
    public static void Save()
    {
        PlayerPrefs.SetString(GetSaveKey(), data.ToJson());
    }

    public static void Load()
    {
        data = SaveData.FromJson(PlayerPrefs.GetString(GetSaveKey(), new SaveData().ToJson()));
    }
}
