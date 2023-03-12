using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GayaProject
{
    class CalcApiClient
    {
        private readonly HttpClient httpClient;

        public CalcApiClient()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://localhost:4024/api/");
        }

        public async Task<double> CalculateDoubleAsync(double input1, double input2, string operation)
        {
            string url = $"calculator/{input1}/{input2}/{operation}";
            HttpResponseMessage response = await httpClient.GetAsync(url);
            var res = response.EnsureSuccessStatusCode();

            if (res.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                double result = JsonConvert.DeserializeObject<double>(json);

                return result;
            }

            return 0;


        }
    }
}
