using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Futuristic.Services
{
    public class BaseService<T>
    {
        HttpClient _client;
        string _ListMethod = "List";
        const string _AddUpdateMethod = "Update";
        const string APIBaseUrl = "https://futuristicapi20200429024818.azurewebsites.net/api/";
        public BaseService(string apiName)
        {
            _client = new HttpClient();
            string className = string.Empty;
            if (!string.IsNullOrEmpty(apiName))
            {
                className = apiName;
            }
            else
            {
                className = typeof(T).Name;
            }
            _ListMethod = className + "/" + className + _ListMethod;
        }
        public BaseService()
        {

        }
        public async Task<List<T>> GetList(string filter = "")
        {

            List<T> list = new List<T>();
            try
            {
                var uri = APIBaseUrl + _ListMethod;
                if (!string.IsNullOrWhiteSpace(filter))
                {
                    uri += "?" + filter;
                }

                var response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    list = JsonConvert.DeserializeObject<List<T>>(content);
                }
                return list;
            }
            catch (Exception ex)
            {
                return list;
            }
        }
        public async Task<List<T>> AddUpdateEntity()
        {
            List<T> list = new List<T>();
            var uri = new Uri(string.Format(APIBaseUrl + "StoreList"));
            var response = await _client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                list = JsonConvert.DeserializeObject<List<T>>(content);
            }
            return list;
        }
        public async Task<List<T>> DeleteEntity()
        {
            List<T> list = new List<T>();
            var uri = new Uri(string.Format(APIBaseUrl + "StoreList"));
            var response = await _client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                list = JsonConvert.DeserializeObject<List<T>>(content);
            }
            return list;
        }
    }
}
