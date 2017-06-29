using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;


namespace SDK.Comm
{
    public class CRemoteDrone : CUnmanagedComm
    {
        //string host = "127.0.0.1";
        string host = "tesyst.ddns.net";
        string serverUrl;

        CZMQComm comm = new CZMQComm();


        public CRemoteDrone()
        {
            comm.OnPacket += comm_OnPacket;
            serverUrl = "http://" + host + "/";
        }
        ~CRemoteDrone()
        {
        }

        public override void Dispose()
        {
            comm.Dispose();
            Disconnect();
        }

        public bool Connect()
        {
            if (connected)
                return true;

            // Select the first drone
            List<string> drones = GetAvailableDrones();
            if (drones != null)
            {
                if (drones.Count == 0)
                    return false;

                int dronePort = GetDroneConnection(drones[0]);
                if (dronePort == 0)
                    return false;

                comm.Connect(host, dronePort);

                SetConnected(true);
                return connected;
            }
            return false;
        }
        public void Disconnect()
        {
            SetConnected(false);
            comm.Disconnect();
        }

        public int GetDroneConnection(string droneName)
        {
            string response = REST_GET("drones/" + droneName + "/start_connection", "");
            if (response != "")
                return int.Parse(response);

            return 0;
        }
        public List<string> GetAvailableDrones()
        {
            List<String> droneList = new List<string>();
            string response = REST_GET("drones/", "");
            var drones = JsonConvert.DeserializeObject<List<string>>(response);

            return drones;
        }
        public string GetDroneInfo()
        {
            return "";            
        }


        public override bool Write(byte[] bytes)
        {
            return comm.Write(bytes);
        }

        void comm_OnPacket(Stream stream)
        {
            CallOnPacket(stream);
        }

        void RefreshStatus_Thread()
        {

        }

        private string REST_GET(string url, string urlParameters)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(this.serverUrl + url);

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                // List data response.
                HttpResponseMessage response = client.GetAsync(urlParameters).Result;  // Blocking call!
                if (response.IsSuccessStatusCode)
                {
                    string responseString = response.Content.ReadAsStringAsync().Result;
                    return responseString;
                }
                else
                {
                    Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                }
            }
            catch (Exception e)
            {

            }

            return "";
        }
    }
}
