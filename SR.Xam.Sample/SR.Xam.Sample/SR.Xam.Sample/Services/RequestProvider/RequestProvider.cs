using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System;
using SR.Xam.Sample.Services;
using System.Collections.Generic;
using Microsoft.AppCenter.Crashes;

namespace SR.Xam.Sample.Services.RequestProvider
{
    public class RequestProvider : IRequestProvider
    {
        private static HttpClient instance;
        private IDialogService _dialogservice;

        public RequestProvider(IDialogService dialogservice)
        {
            _dialogservice = dialogservice;
        }

        public async Task<TResult> GetAsync<TResult>(string uri, string token = "")
        {
            try
            {
                HttpClient httpClient = new HttpClient();
                HttpResponseMessage response = await httpClient.GetAsync("https://reqres.in/api/users?per_page=20");

                string serialized = await response.Content.ReadAsStringAsync();

                TResult result = await Task.Run(() => JsonConvert.DeserializeObject<TResult>(serialized));

                return result;
            }
            catch (Exception ex)
            {
                await _dialogservice.ShowAlertAsync(uri + " " + ex.StackTrace, "Error", "Aceptar");
                var properties = new Dictionary<string, string> {
                    { "Url", uri },
                    { "Method", "Get" },
                };
                Crashes.TrackError(ex, properties);

                return default(TResult);
            }
        }

        private HttpClient CreateHttpClient(string token = "")
        {
            var httpClient = GetInstance();

            if (!string.IsNullOrEmpty(token))
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
            return httpClient;
        }

        private HttpClient GetInstance()
        {
            if (instance == null)
            {
                instance = new HttpClient();
                instance.Timeout = TimeSpan.FromSeconds(30);
                instance.MaxResponseContentBufferSize = 256000;
                instance.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            }

            return instance;
        }
    }
}
