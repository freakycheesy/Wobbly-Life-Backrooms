using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ModWobblyLife.Network;
using UMod;
using ModWobblyLife;

public class ClassicGamemode : InterfaceBackroomsGamemode
{
    public int CurrentLevel { get; private set; }
    public string[] scenes = new string[] { "Level 0", "Level 1", "Level 2", "Level 3", "Level 4", "Level 5", "Level 6", "Level 7", "Level 8", "Level 9" };
    public void LoadLevel(int level)
    {
        ModInstance.Instance.ServerReturnToLobby();
        return;
        CurrentLevel = level;
        Save();
        Backrooms.ServerChangeScene(scenes[level]);
    }

    private void Save()
    {
        BackroomsSave.data.level = CurrentLevel;
        BackroomsSave.Save();
    }
    private void Load()
    {
        BackroomsSave.Load();
        CurrentLevel = BackroomsSave.data.level;
    }
    public void LoadSeed(int seed)
    {
    }

    public void OnExit()
    {
        Save();
    }

    public void OnStart()
    {
        Load();
        LoadLevel(CurrentLevel);
    }

    public void OnUpdate()
    {
        BackroomsSave.data.playTime += Time.unscaledDeltaTime;
    }
}
