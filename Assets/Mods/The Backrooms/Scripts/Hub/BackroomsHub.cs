using ModWobblyLife;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BackroomsHub
{
    public static Dictionary<EnumBackroomsGamemode, int> Votes = new Dictionary<EnumBackroomsGamemode, int>();
    public static int GetPlayerCount()
    {
        return ModInstance.Instance.GetModPlayerControllers().Length;
    }
    public static void UpdateVote(EnumBackroomsGamemode gamemode)
    {
        if (!Votes.TryGetValue(gamemode, out int currentVotes)) return;
        if (currentVotes >= GetPlayerCount())
        {
            Backrooms.StartGame(gamemode);
        }
    }
}
