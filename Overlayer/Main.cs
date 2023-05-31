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
        public static void Load(ModEntry modEntry)
        {
            Mod = modEntry;
            Logger = modEntry.Logger;
            modEntry.OnToggle = OnToggle;
            modEntry.OnGUI = OnGUI;
            modEntry.OnSaveGUI = OnSaveGUI;
            modEntry.OnUpdate = OnUpdate;
            Logger = modEntry.Logger;
            modEntry.OnToggle = OnToggle;
            setting = new Setting();
            setting = UnityModManager.ModSettings.Load<Setting>(modEntry);
        }
        public static bool OnToggle(ModEntry modEntry, bool value)
        {
            modEntry.OnGUI = OnGUI;
            modEntry.OnSaveGUI = OnSaveGUI;
            if (value)
            {
                harmony = new Harmony(modEntry.Info.Id);
                harmony.PatchAll(Assembly.GetExecutingAssembly());

                #region cls name
                Text text = new GameObject().AddComponent<Text>();
                text.gameObject.transform.position = Vector3.zero;
                ADOFAI.LevelData clsName = scnGame.instance.levelData;
                text.text = clsName.ToString();
                UnityEngine.Object.DontDestroyOnLoad(text);
                #endregion

                #region editor name
                Text text1 = new GameObject().AddComponent<Text>();
                text1.gameObject.transform.position = new Vector3(0.5f, 0.5f);
                ADOFAI.LevelData editorName = scnEditor.instance.levelData;
                text1.text = editorName.ToString();
                UnityEngine.Object.DontDestroyOnLoad(text1);
                #endregion
            }
            else
            {
                harmony.UnpatchAll(modEntry.Info.Id);
            }
            return true;
        }
        public static void OnGUI(ModEntry modEntry)
        {
            GUILayout.Label("Test GUI");
            float val = 10;

            float newVal = GUI.HorizontalSlider(new Rect(10, 10, 10, 10), val, 0, 10);
            if (newVal != val)
            {
                val = newVal;
                Debug.Log("slider");
            }
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
