using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface InterfaceBackroomsGamemode
{
    void OnStart();
    void LoadLevel(int level);
    void LoadSeed(int seed);
    void OnUpdate();
    void OnExit();
}
