using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDK.Drone
{
    public class CDatacenter
    {
        public static Dictionary<string, int> knownParametersIndex = new Dictionary<string, int>();       
        public static Dictionary<string, double> knownParameters = new Dictionary<string, double>();

        
        public static event Action<string, double> OnParamUpdate;

        public static void Initialize()
        {
            CDroneManager.OnParamUpdate += CDroneManager_OnParamUpdate;
        }

        static void CDroneManager_OnParamUpdate(string name, double paramValue, int paramIndex)
        {
            knownParameters[name] = paramValue;

            if (!knownParametersIndex.ContainsKey(name))
                knownParametersIndex[name] = paramIndex;

            if (OnParamUpdate != null)
                OnParamUpdate(name, paramValue);
        }
    }
}
