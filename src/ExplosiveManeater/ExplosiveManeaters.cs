using HarmonyLib;
using UnityEngine;

namespace ExplosiveManeater;

[HarmonyPatch(typeof(CaveDwellerAI))]
public class NuclearManeater
{
    [HarmonyPatch("TurnIntoAdultClientRpc")]
    [HarmonyPrefix]
    private static void Detect(CaveDwellerAI __instance)
    {

        {
            GameNetworkManager.Instance.localPlayerController.KillPlayer(UnityEngine.Vector3.up, true);
        }
    }

    [HarmonyPatch("Start")]
    [HarmonyPostfix]
    //HUD Message if a maneater spawns (duh)
    private static void HumanEraserSpawned(CaveDwellerAI __instance)
    {
        HUDManager.Instance.DisplayTip("Baby spawned", "A Baby has spawned somewhere");
    }

    [HarmonyPatch("SetCryingLocalClient")]
    [HarmonyPostfix]
    //HUD Message if the maneater is crying
    private static void HumanEraserIsCrying(CaveDwellerAI __instance, bool setCrying)
    {
        if(setCrying)
        {
            HUDManager.Instance.DisplayTip("Baby crying", "THE BABY IS CRYING!!!!");
            return;
        }
        HUDManager.Instance.DisplayTip("Baby stopped crying", "The baby has stopped crying :3");
    }

    [HarmonyPatch("SetBabyNearTransformingClientRpc")]
    [HarmonyPostfix]
    //HUD Message if the maneater is about to transform
    private static void HumanEraserAboutToErase()
    {
        HUDManager.Instance.DisplayTip("THE BABY IS ABOUT TO KILL EVEROYNE", "Feed it scrap to reset it ");
    }
    [HarmonyPatch("ClearBabyObservingClientRpc")]
    [HarmonyPostfix]
    //when maneater eats, transformation meter goes down, makes it take longer to transform
    private static void HumanEraserAteScrap(CaveDwellerAI __instance)
    {
        __instance.growthMeter = 0;
    }

}
