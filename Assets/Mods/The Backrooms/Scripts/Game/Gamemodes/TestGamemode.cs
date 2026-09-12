using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGamemode : InterfaceBackroomsGamemode
{
    public void LoadLevel(int level)
    {
        Backrooms.ServerChangeScene("Assets/The Backrooms/Scenes/Custom/Test-Levels/Test.unity");
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
