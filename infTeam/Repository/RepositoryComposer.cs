using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace Repository
{
    public class RepositoryComposer<T> where T : class
    {
        public String Uri { get; set; }
        public String Path { get; set; }

        public RepositoryComposer(String uri)
        {
            Uri = uri;
        }

        private JsonSerializerSettings getJsonSettings()
        {
            return new JsonSerializerSettings{TypeNameHandling = TypeNameHandling.All};
        }

        private HttpClient getInfTeamApiClient()
        {
            HttpClient infTeamApiClient = new HttpClient();
            infTeamApiClient.BaseAddress = new Uri(Uri);
            infTeamApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return infTeamApiClient;
        }

        public IEnumerable<T> GetAll()
        {
            HttpClient infTeamApiClient = getInfTeamApiClient();
            var response = infTeamApiClient.GetAsync(Path).Result;
            if (response.IsSuccessStatusCode)
            {

                var res = response.Content.ReadAsStringAsync().Result;

                var obj = JsonConvert.DeserializeObject<IEnumerable<T>>(res, getJsonSettings());


                return obj;
            }
            else
            {
                IEnumerable<T> resp = new List<T>();
                return resp;
            }
        }

        public bool Add(T entity)
        {
            HttpClient infTeamApiClient = getInfTeamApiClient();

            var stringContent = new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json");

            var response = infTeamApiClient.PostAsync(Path, stringContent);

            if (response.Result.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public void Find(Expression<Func<T, bool>> predicate)
        {
        }

        public T Get()
        {
            HttpClient infTeamApiClient = getInfTeamApiClient();

            var response = infTeamApiClient.GetAsync(Path).Result;
            if (response.IsSuccessStatusCode)
            {

                var res = response.Content.ReadAsStringAsync().Result;

                var obj = JsonConvert.DeserializeObject<T>(res, getJsonSettings());

                return obj;
            }
            else
            {
                return null;
            }
        }

        public void Update(T entity)
        {
        }

        public void Remove(T entity)
        {
        }
    }
}
