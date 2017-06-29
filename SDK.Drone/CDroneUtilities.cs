using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDK.Drone
{
    public class CDroneUtilities
    {
        public static List<SMissionItem> ReadWaypointFile(string file, bool append = false)
        {
            // ReadQGC110wpfile
            int wp_count = 0;
            bool error = false;
            List<SMissionItem> cmds = new List<SMissionItem>();

            try
            {
                StreamReader reader = new StreamReader(file); //"defines.h"
                string header = reader.ReadLine();
                if (header == null || !header.Contains("QGC WPL"))
                {
                    return null;
                }

                while (!error && !reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    
                    // Waypoints
                    if (line.StartsWith("#"))
                        continue;


                    // Waypoint file format:
                    // <INDEX> <CURRENT WP> <COORD FRAME> <COMMAND> <PARAM1> <PARAM2> <PARAM3> <PARAM4> <PARAM5/X/LONGITUDE> <PARAM6/Y/LATITUDE> <PARAM7/Z/ALTITUDE> <AUTOCONTINUE>
                    string[] items = line.Split(new[] { '\t', ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

                    if (items.Length <= 9)
                        continue;

                    try
                    {

                        SMissionItem temp = new SMissionItem();
                        if (items[2] == "3")
                        { // abs MAV_FRAME_GLOBAL_RELATIVE_ALT=3
                            temp.frame = MAVLink.MAV_FRAME.LOCAL_NED;
                        }
                        else
                        {
                            temp.frame = MAVLink.MAV_FRAME.GLOBAL;
                        }
                        temp.command = (MAVLink.MAV_CMD)Enum.Parse(typeof(MAVLink.MAV_CMD), items[3], false);
                        temp.p1 = float.Parse(items[4], new CultureInfo("en-US"));

                        if ((byte)temp.command == 99)
                            temp.command = 0;

                        temp.alt = (float)(double.Parse(items[10], new CultureInfo("en-US")));
                        temp.lat = (double.Parse(items[8], new CultureInfo("en-US")));
                        temp.lng = (double.Parse(items[9], new CultureInfo("en-US")));

                        temp.p2 = (float)(double.Parse(items[5], new CultureInfo("en-US")));
                        temp.p3 = (float)(double.Parse(items[6], new CultureInfo("en-US")));
                        temp.p4 = (float)(double.Parse(items[7], new CultureInfo("en-US")));

                        cmds.Add(temp);

                        wp_count++;

                    }
                    catch 
                    {
                        return null;
                    }
                }

                reader.Close();
            }
            catch //(Exception ex)
            {
                return null;
            }

            return cmds;
        }

        public static double GPSPointsDistance(double lat1, double lng1, double lat2, double lng2)
        {
            double earthRadius = 6371000; //meters

            double dLat = earthRadius * (lat1 - lat2) * Math.PI / 180;
            double dLng = earthRadius * (lng1 - lng2) * Math.PI / 180;

            return Math.Sqrt(Math.Pow(dLat, 2) + Math.Pow(dLng, 2));
        }

        public static double LatLongDistance(double lat1, double lat2)
        {
            double earthRadius = 6371000; // Meters
            return earthRadius * (lat1 - lat2) * Math.PI / 180;
        }
    }
}
