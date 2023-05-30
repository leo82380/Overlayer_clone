using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using UnityEngine;

namespace Overlayer
{
    [HarmonyPatch(typeof(Class1), "Test")]
    class Class1
    {
        //PreFix
        public static void Prefix()
        {
            Debug.Log("hello world");
            return;
        }
    }
}
