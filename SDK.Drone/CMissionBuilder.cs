using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDK.Drone
{
    public static class CMissionBuilder
    {
        public static Dictionary<string, SMission> Missions;


        public static List<SMissionItem> BuildGotoMission(double homeLat, double homeLng, double alt, double lat, double lng)
        {
            List<SMissionItem> mission = new List<SMissionItem>();
            mission.Add(CreateHome(homeLat, homeLng));
            mission.Add(CreateTakeoff(alt));
            mission.Add(CreateWaypoint(lat, lng, alt));
            mission.Add(CreateRTL());

            return mission;
        }

        private static SMissionItem CreateHome(double latitude, double longitude)
        {
            return new SMissionItem()
            {
                command = MAVLink.MAV_CMD.WAYPOINT,
                alt = 0,
                lat = latitude,
                lng = longitude
            };
        }
        private static SMissionItem CreateWaypoint(double latitude, double longitude, double altitude)
        {
            return new SMissionItem()
            {
                command = MAVLink.MAV_CMD.WAYPOINT,
                alt = altitude,
                lat = latitude,
                lng = longitude
            };
        }
        private static SMissionItem CreateTakeoff(double altitude)
        {
            return new SMissionItem() {
                command = MAVLink.MAV_CMD.TAKEOFF,
                alt = altitude
            };
        }
        private static SMissionItem CreateRTL()
        {
            return new SMissionItem() {
                command = MAVLink.MAV_CMD.RETURN_TO_LAUNCH
            };
        }


        public static bool LoadMissions(string folder)
        {
            DirectoryInfo d = new DirectoryInfo(folder);
            bool loaded = true;

            Missions = new Dictionary<string, SMission>();

            foreach (var file in d.GetFiles("*.waypoints"))
            {
                SMission  mission = new SMission(Path.GetFileNameWithoutExtension(file.Name));
                loaded = loaded && LoadMission(file.FullName, mission);
                if (loaded)                  
                    Missions.Add(mission.Name, mission);
            }

            return loaded;
        }
        public static bool LoadMission(string filename, SMission mission)
        {
            if (!File.Exists(filename))
                return false;

            StreamReader reader = new StreamReader(filename);
            string header = reader.ReadLine();
            // Ignore the first line
            if (header == null || !header.Contains("QGC WPL"))
                return false;

            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();

                // Ignore comments
                if (line.StartsWith("#"))
                    continue;

                string[] items = line.Split(new[] {'\t', ' ', ','}, StringSplitOptions.RemoveEmptyEntries);

                if (items.Length <= 9)
                    continue;

                try
                {
                    SMissionItem missionItem = new SMissionItem();

                    // First point is home
                    if (items[0] == "0")
                        missionItem.IsHome = true;

                    // I'm not sure why we do this, but this is what mission planner does
                    if (items[2] == "3")
                    {
                        // abs MAV_FRAME_GLOBAL_RELATIVE_ALT=3
                        missionItem.frame = (MAVLink.MAV_FRAME.LOCAL_NED);
                    }
                    else
                    {
                        missionItem.frame = (MAVLink.MAV_FRAME.GLOBAL);
                    }
                    missionItem.command = (MAVLink.MAV_CMD)Enum.Parse(typeof (MAVLink.MAV_CMD), items[3], false);
                    missionItem.p1 = float.Parse(items[4], new CultureInfo("en-US"));

                    missionItem.alt = (float) (double.Parse(items[10], new CultureInfo("en-US")));
                    missionItem.lat = (double.Parse(items[8], new CultureInfo("en-US")));
                    missionItem.lng = (double.Parse(items[9], new CultureInfo("en-US")));

                    missionItem.p2 = (float) (double.Parse(items[5], new CultureInfo("en-US")));
                    missionItem.p3 = (float) (double.Parse(items[6], new CultureInfo("en-US")));
                    missionItem.p4 = (float) (double.Parse(items[7], new CultureInfo("en-US")));

                    mission.Items.Add(missionItem);
                }
                catch
                {
                    return false;
                }
            }
            reader.Close();
            return true;
        }
    }
}
