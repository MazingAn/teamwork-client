using System.Net.Http;
using System.Threading.Tasks;

namespace TeamworkClient.DataSource
{
    class MyJsonDataSource
    {
        private string url;
        private HttpClient httpClient;

        public MyJsonDataSource(string url)
        {
            this.url = url;
            this.httpClient = new HttpClient();
        }

        public async Task<string> LoadJsonStrFromWebAsync()
        {
            HttpResponseMessage response = await httpClient.GetAsync(url);
            if(response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            return null;
        }
    }
}