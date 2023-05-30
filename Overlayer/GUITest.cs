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
                Debug.Log("button");
            }

            float val = 10;

            float newVal = GUI.HorizontalSlider(new Rect(10, 10, 10, 10), val, 0, 10);
            if(newVal != val)
            {
                val = newVal;
                Debug.Log("slider");
            }
        }
    }
}
