using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Fox.Configs
{
    internal class marti
    {
        public static void martinmx()
        {
            using (Leaf.xNet.HttpRequest req = new Leaf.xNet.HttpRequest())
            {
                string email = "salvadorenriqu88eortega@hotmail.com";
                string pass = "Olimpiadas1";
                req.IgnoreProtocolErrors = true;
                req.ConnectTimeout = 5000;
                req.ReadWriteTimeout = 5000;
                req.AddHeader("Host", "www.marti.mx");
                req.AddHeader("Content-Type", "multipart/form-data; boundary=----WebKitFormBoundary4ztDgxyJ8bFIgsOI");
                req.AddHeader("sec-ch-ua", "\".Not/A)Brand\";v=\"99\", \"Google Chrome\";v=\"103\", \"Chromium\";v=\"103\"");
                req.AddHeader("DNT", "1");
                req.AddHeader("vtex-id-ui-version", "vtex.login@2.52.1/vtex.react-vtexid@4.49.0");
                req.AddHeader("sec-ch-ua-mobile", "?0");
                req.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.0.0 Safari/537.36";
                req.AddHeader("sec-ch-ua-platform", "\"Windows\"");
                req.AddHeader("Accept", "*/*");
                req.AddHeader("Origin", "https://www.marti.mx");
                req.AddHeader("Sec-Fetch-Site", "same-origin");
                req.AddHeader("Sec-Fetch-Mode", "cors");
                req.AddHeader("Sec-Fetch-Dest", "empty");
                req.Referer = "https://www.marti.mx/";
                req.AddHeader("Accept-Language", "es-US,es-419;q=0.9,es;q=0.8,en;q=0.7");
                req.AddHeader("Accept-Encoding", "gzip, deflate");
            
                string payload = "------WebKitFormBoundary4ztDgxyJ8bFIgsOI\nContent-Disposition: form-data; name=\"accountName\"\n\nmartimx\n------WebKitFormBoundary4ztDgxyJ8bFIgsOI\nContent-Disposition: form-data; name=\"scope\"\n\nmartimx\n------WebKitFormBoundary4ztDgxyJ8bFIgsOI\nContent-Disposition: form-data; name=\"returnUrl\"\n\nhttps://www.marti.mx/\n------WebKitFormBoundary4ztDgxyJ8bFIgsOI\nContent-Disposition: form-data; name=\"callbackUrl\"\n\nhttps://www.marti.mx/api/vtexid/oauth/finish?popup=false\n------WebKitFormBoundary4ztDgxyJ8bFIgsOI\nContent-Disposition: form-data; name=\"user\"\n\n" + email + "\n------WebKitFormBoundary4ztDgxyJ8bFIgsOI\nContent-Disposition: form-data; name=\"fingerprint\"\n\n\n------WebKitFormBoundary4ztDgxyJ8bFIgsOI--\n";
                string send_data = req.Post("https://www.marti.mx/api/vtexid/pub/authentication/startlogin", payload, "multipart/form-data; boundary=----WebKitFormBoundary4ztDgxyJ8bFIgsOI").ToString();
                
                Console.WriteLine(send_data);
           
                
            }

        }
    }
}
