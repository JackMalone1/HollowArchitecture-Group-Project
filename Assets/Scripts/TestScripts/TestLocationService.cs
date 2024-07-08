using System.Collections;
using UnityEngine;

//written with the help of this guide: https://nosuchstudio.medium.com/how-to-access-gps-location-in-unity-521f1371a7e3
namespace TestScripts
{
    public class TestLocationService : MonoBehaviour
    {
        IEnumerator LocationCoroutine()
        {
#if UNITY_EDITOR
            yield return new WaitWhile(() => !UnityEditor.EditorApplication.isRemoteConnected);
            yield return new WaitForSecondsRealtime(5f);
#endif
#if UNITY_EDITOR
            //no permission handling in the editor is needed
#elif UNITY_ANDROID
            if (!UnityEngine.Android.Permission.HasUserAuthorizedPermission(UnityEngine.Android.Permission.CoarseLocation)) {
            UnityEngine.Android.Permission.RequestUserPermission(UnityEngine.Android.Permission.CoarseLocation);
            }

            // First, check if user has location service enabled
            if (!UnityEngine.Input.location.isEnabledByUser) {
                // TODO Failure
                Debug.LogFormat("Android and Location not enabled");
                yield break;
            }
#elif UNITY_IOS
            if (!UnityEngine.Input.location.isEnabledByUser) {
                // TODO Failure
                Debug.LogFormat("IOS and Location not enabled");
                yield break;
            }
#endif
            UnityEngine.Input.location.Start(250f,250f);

            int maxWait = 15;
            while (UnityEngine.Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
            {
                yield return new WaitForSecondsRealtime(1f);
                maxWait--;
            }
            
#if UNITY_EDITOR
            int editorMaxWait = 15;
            while (UnityEngine.Input.location.status == LocationServiceStatus.Stopped && editorMaxWait > 0) {
                yield return new WaitForSecondsRealtime(1);
                editorMaxWait--;
            }
#endif
            if (maxWait < 1)
            {
                Debug.LogFormat("Timed out");
                yield break;
            }

            if (UnityEngine.Input.location.status != LocationServiceStatus.Running)
            {
                Debug.LogFormat("Unable to determine device location");
            }
            else
            {
                Debug.LogFormat("Location service live. status {0}", UnityEngine.Input.location.status);
                // Access granted and location value could be retrieved
                Debug.LogFormat("Location: " 
                                + UnityEngine.Input.location.lastData.latitude + " " 
                                + UnityEngine.Input.location.lastData.longitude + " " 
                                + UnityEngine.Input.location.lastData.altitude + " " 
                                + UnityEngine.Input.location.lastData.horizontalAccuracy + " " 
                                + UnityEngine.Input.location.lastData.timestamp);

                var _latitude = UnityEngine.Input.location.lastData.latitude;
                var _longitude = UnityEngine.Input.location.lastData.longitude;
            }
        }
    }
}