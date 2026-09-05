using ModWobblyLife.Network;
using System;
using TMPro;
using UnityEngine;

public class BackroomsHubVoteZone : ModNetworkBehaviour
{
    public TMP_Text text;
    public EnumBackroomsGamemode gamemode;
    protected override void ModNetworkStart(ModNetworkObject modNetworkObject)
    {
        BackroomsHub.Votes.TryAdd(gamemode, 0);
        OnUpdate();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            BackroomsHub.Votes[gamemode]++;
        }
        OnUpdate();
    }

    private void OnUpdate()
    {
        text.text = $"{BackroomsHub.Votes[gamemode]} / {BackroomsHub.GetPlayerCount()}";
        if (!IsServer()) return;
        BackroomsHub.UpdateVote(gamemode);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            BackroomsHub.Votes[gamemode]--;
        }
        OnUpdate();
    }
}
