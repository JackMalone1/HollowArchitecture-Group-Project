using System;
using UnityEngine;

namespace TestScripts
{
    [Serializable]
    public class IpApiData
    {
        public string country_name;

        public static IpApiData CreateFromJson(string jsonString)
        {
            return JsonUtility.FromJson<IpApiData>(jsonString);
        }
    }
}