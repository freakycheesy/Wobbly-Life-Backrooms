using ModWobblyLife;
using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using UnityEngine;

public static class AntiCheat
{
    private static bool canLog = true;
    private static string[] cheats =
    {
        "UniverseLibBehaviour",
        "BepInEx_ThreadingHelper",
        "ExplorerBehaviour",
        "BepInEx_Manager"
    };
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSplashScreen)]
    public static void Check()
    {
        if (!Application.isPlaying) return;
        if (IsValid())
        {
            if (canLog) Debug.Log(":)");
        }
        else
        {
            if (canLog)
            {
                Debug.Log("To achieve meaning in this one-shot experience that goes on for a lifetime");
                if (!IsSinglePlayer()) Debug.Log("Independence makes you grow stronger, get rid of them");
            }
            if (HasCheats()) {
                if (canLog) Debug.Log("enhancements, cheats and modifications, you are weak, get rid of them");
                foreach (var cheat in cheats)
                {
                    if (GameObject.Find(cheat)) Destroy(GameObject.Find(cheat));
                    // Make it secret code
                    Application.ForceCrash(1);
                }
            }
            Leave();
        }
        canLog = false;
    }

    public static void Leave()
    {
        ModInstance.Instance.ServerReturnToLobby();
    }
    public static void Destroy(UnityEngine.Object obj) => UnityEngine.Object.Destroy(obj);
    public static bool HasCheats()
    {
        foreach(var cheat in cheats)
        {
            if (GameObject.Find(cheat)) return true;
        }
        return false;
    }
    public static bool IsValid() {
        return IsSinglePlayer() && !HasCheats();
    }

    public static bool IsSinglePlayer() {
        return ModInstance.Instance.GetModPlayerControllers().Length < 2;
    }
}
