using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoScenesGamemode : InterfaceBackroomsGamemode
{
    public string[] scenes = new string[] {
        "Assets/The Backrooms/Scenes/Custom/Demo-Levels/DrownZone.unity",
        "Assets/The Backrooms/Scenes/Custom/Demo-Levels/Strawberries.unity",
    };

    public void LoadLevel(int level)
    {
        Backrooms.ServerChangeScene(scenes[level]);
    }

    public void LoadSeed(int seed)
    {
    }

    public void OnExit()
    {
    }

    public void OnStart()
    {
        LoadLevel(0);
    }

    public void OnUpdate()
    {
    }
}
