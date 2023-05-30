using System;
using static UnityModManagerNet.UnityModManager.ModEntry;
using static UnityModManagerNet.UnityModManager;
using HarmonyLib;
using UnityEngine.UI;
using UnityEngine;
using System.Reflection;
using System.IO;
using System.Xml.Serialization;
using UnityModManagerNet;

namespace Overlayer
{
    public static class Main
    {
        public static Setting setting;
        public static ModEntry Mod { get; private set; }
        public static ModLogger Logger { get; private set; }
        public static Harmony harmony;
        public static void Setup(UnityModManager.ModEntry modEntry, bool value)
        {
            Logger = modEntry.Logger;
            modEntry.OnToggle = OnToggle;
            setting = new Setting();
            setting = UnityModManager.ModSettings.Load<Setting>(modEntry);
        }
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
            modEntry.OnGUI = OnGUI;
            modEntry.OnSaveGUI = OnSaveGUI;
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
            GUITest test = new GameObject().AddComponent<GUITest>();
            UnityEngine.Object.DontDestroyOnLoad(test);
            GUILayout.Label("Test GUI");
        }
        public static void OnSaveGUI(ModEntry modEntry)
        {
            setting.Save(modEntry);
        }
        public static void OnUpdate(ModEntry modEntry, float deltaTime)
        {
        }
    }
    
}
