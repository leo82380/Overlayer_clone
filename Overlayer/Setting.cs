using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using UnityModManagerNet;
using static UnityModManagerNet.UnityModManager;

namespace Overlayer
{
    public class Setting : UnityModManager.ModSettings
    {
        public string testSet = "set";
        public bool testSet2 = false;
        public int testSet3 = 3;

        public override void Save(UnityModManager.ModEntry modEntry)
        {
            var filepath = GetPath(modEntry);

            try
            {
                using (var writer = new StreamWriter(filepath))
                {
                    var serializer = new XmlSerializer(GetType());
                    serializer.Serialize(writer, this);
                }
            }
            catch
            {

            }
        }
        public override string GetPath(ModEntry modEntry)
        {
            return Path.Combine(modEntry.Path, GetType().Name + ".xml");
        }
    }
}
