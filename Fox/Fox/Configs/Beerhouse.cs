using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fox.Configs
{
    internal class Beerhouse
    {
        public static void beermx()
        {
            using (Leaf.xNet.HttpRequest req = new Leaf.xNet.HttpRequest())
            {
                string email = "yango93150@gmail.com"; // Replace with your email or username
                string pass = "Pepe@93150A";        // Replace with your password

                // Set general headers
                req.IgnoreProtocolErrors = true;
                req.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/117.0.0.0 Safari/537.36";
                req.AddHeader("Accept", "*/*");
                req.AddHeader("Content-Type", "application/x-amz-json-1.1");
                req.AddHeader("Cache-Control", "no-store");
                req.AddHeader("X-Amz-Target", "AWSCognitoIdentityProviderService.InitiateAuth");
                req.AddHeader("X-Amz-User-Agent", "aws-amplify/5.0.4 js");
                req.AddHeader("sec-ch-ua-platform", "Windows");
                req.AddHeader("Referer", "https://www.beerhouse.mx/");
                req.AddHeader("Accept-Language", "en-US,en;q=0.9,es;q=0.8");
                req.AddHeader("Accept-Encoding", "gzip, deflate");

                string postData = "{\"AuthFlow\":\"USER_PASSWORD_AUTH\",\"ClientId\":\"7gbkt71r23ge9nf86je3d8fkas\",\"AuthParameters\":{\"USERNAME\":\"" + email + "\",\"PASSWORD\":\"" + pass + "\"},\"ClientMetadata\":{}}";

                string responseData = req.Post("https://cognito-idp.us-east-1.amazonaws.com/", postData, "application/x-amz-json-1.1").ToString();

                // Check for response keys
                if (responseData.Contains("AccessToken"))
                {
                    Console.WriteLine("Success");
                }
                else if (responseData.Contains("User does not exist.") || responseData.Contains("Incorrect username or password."))
                {
                    Console.WriteLine("Failure");
                }
            }
        }
    }
}
