using System;
using UnityEngine;
using System.Text;
using Newtonsoft.Json;
using System.Net.Http;
using Unity_Utils_Lib;
using System.Collections;
using UnityEngine.Networking;

namespace API_Lib.Managers
{
    public sealed class APIManager : BaseSingleton<APIManager>
    {
        [SerializeField] private string url;
        public void SendAPI<TRequest>(string url, HttpMethod method, TRequest body, string bearer = "")
        {
            try
            {
                string data = JsonConvert.SerializeObject(body);
                StartCoroutine(Call(url, method, data, bearer));
            }
            catch (Exception ex)
            {
                APIEventManager.FireAPIException(ex.Message);
            }
        }
        private IEnumerator Call(string url, HttpMethod method, string data, string bearer)
        {
            using (UnityWebRequest www = new UnityWebRequest($"{this.url}/{url}", method.Method))
            {
                using (DownloadHandler dh = new DownloadHandlerBuffer())
                {
                    www.downloadHandler = dh;
                    // headers
                    www.SetRequestHeader("Content-Type", "application/json");
                    if (!string.IsNullOrEmpty(bearer))
                    {
                        www.SetRequestHeader("AUTHORIZATION", $"bearer {bearer}");
                    }
                    // body
                    if (!string.IsNullOrEmpty(data))
                    {
                        byte[] bodyRaw = Encoding.UTF8.GetBytes(data);
                        www.uploadHandler = new UploadHandlerRaw(bodyRaw);
                    }
                    yield return www.SendWebRequest();

                    if (www.isNetworkError || www.isHttpError)
                    {
                        APIEventManager.FireAPIError(url, (int)www.responseCode, www.error);
                    }
                    else
                    {
                        APIEventManager.FireAPIRecieved(url, www.downloadHandler.text);
                    }
                }
            }
        }
    }
}
