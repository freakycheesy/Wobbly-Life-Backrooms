using ModWobblyLife;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModBackroomsGamemode : ModFreemodeGamemode
{
    public static ModBackroomsGamemode Instance { get; private set; }
    public bool debug;
    private void Start()
    {
        Instance = this;
        BackroomsSave.Initialize();
    }
    public void LoadLevel(int level)
    {
        Backrooms.gamemode.LoadLevel(level);
    }
    public void Exit()
    {
        Backrooms.Exit();
    }
    public void LoadSeed(int seed)
    {
        Backrooms.gamemode.LoadSeed(seed);
    }
    protected override void OnSpawnedPlayerController(ModPlayerController playerController)
    {
        base.OnSpawnedPlayerController(playerController);

        playerController.ServerSetSandboxUIEnabled(debug);
    }
}