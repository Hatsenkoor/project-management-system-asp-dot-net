using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace PCVM.Web.Helpers
{
    public class ApiClient : IDisposable
    {
        public HttpClient client { get; set; }
        private readonly AppSettings _appSettings;
        public StringContent stringContent { get; set; }
        public ApiClient(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
            client = new HttpClient();
            client.BaseAddress = new Uri(_appSettings.ApiUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public async Task<T> Get<T>(string URl, string value)
        {
           

    var response = await client.GetAsync(URl + value);

            var result = await response.Content.ReadAsAsync<T>();
            return result;



        }
        public async Task<T> Post<T>(string URL, StringContent stringContent,string id)

        {
           
            var response = await client.PostAsync(URL + id, stringContent);
            var result = await response.Content.ReadAsAsync<T>();
            return result;
        }
        public async Task<T> Delete<T>(string URL, string id)

        {

            var response = await client.DeleteAsync(URL + id);
            var result = await response.Content.ReadAsAsync<T>();
            return result;
        }



        public void Dispose()
        {
            client.Dispose();
        }

    }
}
