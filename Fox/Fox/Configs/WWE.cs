using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fox.Configs
{
    internal class WWE
    {
        public static void wwe()
        {
            string email = "fabospider@gmail.com";
            string pass = "Rulfmx2015";
            using (Leaf.xNet.HttpRequest req = new Leaf.xNet.HttpRequest())
            {
                req.IgnoreProtocolErrors = true;
                req.AddHeader("Accept", "*/*");
                req.AddHeader("Accept-Encoding", "gzip, deflate, br");
                req.AddHeader("Accept-Language", "en-US,en;q=0.9");
                req.AddHeader("Connection", "keep-alive");
                req.AddHeader("Content-Length", "54");
                req.AddHeader("Content-Type", "application/json");
                req.AddHeader("DNT", "1");
                req.AddHeader("Host", "dce-frontoffice.imggaming.com");
                req.AddHeader("Origin", "https://www.wwe.com");
                req.AddHeader("Referer", "https://www.wwe.com/");
                req.AddHeader("Sec-Fetch-Dest", "empty");
                req.AddHeader("Sec-Fetch-Mode", "cors");
                req.AddHeader("Sec-Fetch-Site", "cross-site");
                req.AddHeader("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/114.0.0.0 Safari/537.36");
                req.AddHeader("app", "dice");
                req.AddHeader("realm", "dce.wwe");
                req.AddHeader("sec-ch-ua", "Not.A/Brand\";v=\"8\", \"Chromium\";v=\"114\", \"Google Chrome\";v=\"114\"");
                req.AddHeader("sec-ch-ua-mobile", "?0");
                req.AddHeader("sec-ch-ua-platform", "Windows\"");
                req.AddHeader("x-api-key", "857a1e5d-e35e-4fdf-805b-a87b6f8364bf");
                string payload = "{\"id\":\"" + email + "\",\"secret\":\"" + pass + "\"}";
                string send_data = req.Post("https://dce-frontoffice.imggaming.com/api/v2/login", payload, "application/json").ToString();
                Console.WriteLine(send_data);

            }


        }
    }
}
