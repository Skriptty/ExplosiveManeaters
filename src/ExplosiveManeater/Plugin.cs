using BepInEx;
using BepInEx.Logging;
using HarmonyLib;

namespace ExplosiveManeater;

[BepInPlugin(MyPluginInfo.Id, MyPluginInfo.Name, MyPluginInfo.Version)]
[BepInProcess("Lethal Company.exe")]
public class Plugin : BaseUnityPlugin
{
    internal static ManualLogSource Log { get; private set; } = null!;

    private void Awake()
    {
        var harmony = new Harmony("com.sagtag.ExplosiveManeater");
        harmony.PatchAll();
        Log = Logger;
        Log.LogInfo($"{MyPluginInfo.Name} {MyPluginInfo.Version} loaded");
    }
}
