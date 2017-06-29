using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDK.Drone
{
    public static class ParametersUtils
    {
        private static double epsilon = 0.00001;

        public static bool Equals(double param1, double param2)
        {
            return (Math.Abs(param1 - param2) < epsilon);
        }
    }
}
