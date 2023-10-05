using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fox.Configs
{
    internal class UFC
    {
        public static void ufc()
        {
            string email = "zorbat5@gmail.com";
            string pass = "456gfeas";
            using (Leaf.xNet.HttpRequest req = new Leaf.xNet.HttpRequest())
            {
                req.IgnoreProtocolErrors = true;
                req.AddHeader("accept", "application/json, text/plain, */*");
                req.AddHeader("accept-encoding", "gzip, deflate, br");
                req.AddHeader("accept-language", "en-US");
                req.AddHeader("app", "dice");
                req.AddHeader("authorization", "Bearer null");
                req.AddHeader("content-length", "39");
                req.AddHeader("content-type", "application/json");
                req.AddHeader("origin", "https://ufcfightpass.com");
                req.AddHeader("realm", "dce.ufc");
                req.AddHeader("referer", "https://ufcfightpass.com/");
          
                req.AddHeader("sec-fetch-mode", "cors");
                req.AddHeader("sec-fetch-site", "cross-site");
                req.AddHeader("user-agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/100.0.4896.75 Safari/537.36 Edg/100.0.1185.36");
                req.AddHeader("x-api-key", "857a1e5d-e35e-4fdf-805b-a87b6f8364bf");
                req.AddHeader("x-app-var", "6.0.0");
                string payload = "{\"id\":\"<USER>\",\"secret\":\"<PASS>\"}";
                string send_data = req.Post("https://dce-frontoffice.imggaming.com/api/v2/login", payload, "application/json").ToString();
                Console.WriteLine(send_data);
             


            
            }

        
        }
    }
}
