using ModWobblyLife;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackroomsGamemode : ModFreemodeGamemode
{
    public bool debug;
    protected override void OnSpawnedPlayerController(ModPlayerController playerController)
    {
        base.OnSpawnedPlayerController(playerController);

        playerController.ServerSetSandboxUIEnabled(debug);
    }
}