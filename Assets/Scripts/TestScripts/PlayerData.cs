using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

namespace TestScripts
{
    public class PlayerData
    {
        public static IEnumerator SetCountry()
        {
            string ip = new System.Net.WebClient().DownloadString("https://api.ipify.org");
            string uri = $"https://ipapi.co/{ip}/json/";

            using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
            {
                yield return webRequest.SendWebRequest();

                string[] pages = uri.Split('/');
                int page = pages.Length - 1;

                IpApiData ipApiData = IpApiData.CreateFromJson(webRequest.downloadHandler.text);
                
                Debug.Log(ipApiData.country_name);
            }
        }
    }
}