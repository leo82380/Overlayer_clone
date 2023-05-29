using System;
using static UnityModManagerNet.UnityModManager.ModEntry;
using static UnityModManagerNet.UnityModManager;
using HarmonyLib;
using System.Reflection;

namespace Overlayer
{
    public static class Main
    {
        public static ModEntry Mod { get; private set; }
        public static ModLogger Logger { get; private set; }
        public static Harmony harmony;
        public static void Load(ModEntry modEntry)
        {
            Mod = modEntry;
            Logger = modEntry.Logger;
            modEntry.OnToggle = OnToggle;
            modEntry.OnGUI = OnGUI;
            modEntry.OnSaveGUI = OnSaveGUI;
            modEntry.OnUpdate = OnUpdate;
        }
        public static bool OnToggle(ModEntry modEntry, bool value)
        {
            if (value)
            {
                harmony = new Harmony(modEntry.Info.Id);
                harmony.PatchAll(Assembly.GetExecutingAssembly());
            }
            else
            {
                harmony.UnpatchAll(modEntry.Info.Id);
            }
            return true;
        }
        public static void OnGUI(ModEntry modEntry)
        {
        }
        public static void OnSaveGUI(ModEntry modEntry)
        {
        }
        public static void OnUpdate(ModEntry modEntry, float deltaTime)
        {
        }
    }
}
