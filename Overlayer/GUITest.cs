using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Overlayer
{
    class GUITest : MonoBehaviour
    {
        public void OnGUI()
        {
            //GUI
            GUI.Label(new Rect(10, 10, 10, 10), "Hello World");
            //GUILayout
            GUILayout.Label("Hello world Layout");
            //button
            if(GUI.Button(new Rect(10,10,10,10), "hello button"))
            {
                Console.WriteLine("button click!");
            }

            float val = 10;

            float newVal = GUI.HorizontalSlider(new Rect(10, 10, 10, 10), val, 0, 10);
            if(newVal != val)
            {
                val = newVal;
                Console.WriteLine("slider");
            }

            //GUIStyle
            GUIStyle textStyle = new GUIStyle();
            textStyle.fontSize = 50;
            textStyle.alignment = TextAnchor.UpperCenter;
            textStyle.normal.textColor = Color.white;

            //GUI 생성
            GUITest test = new GameObject().AddComponent<GUITest>();
            UnityEngine.Object.DontDestroyOnLoad(test);
        }
    }
}
