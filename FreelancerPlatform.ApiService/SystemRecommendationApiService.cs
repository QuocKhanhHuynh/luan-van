using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace FreelancerPlatform.ApiService
{
    public class SystemRecommendationApiService : ISystemRecommendationApiService
    {
        private readonly IHttpClientFactory _httpContextFactory;
        private readonly IConfiguration _configuration;

        public SystemRecommendationApiService(IHttpClientFactory httpContextFactory, IConfiguration configuration)
        {
            _httpContextFactory = httpContextFactory;
            _configuration = configuration;
        }
        public async Task BuildSystemRecommendation()
        {
            var httpClient = _httpContextFactory.CreateClient();
            httpClient.BaseAddress = new Uri(_configuration["AIAddress"]);
            await httpClient.GetAsync($"/api/trainai");
        }

        public async Task<List<int>> GetRecommendation(int jobId)
        {
            var httpClient = _httpContextFactory.CreateClient();
            httpClient.BaseAddress = new Uri(_configuration["AIAddress"]);
            var response = await httpClient.GetAsync($"/api/recommend/{jobId}");

            return JsonConvert.DeserializeObject<List<int>>(await response.Content.ReadAsStringAsync());
        }
    }
}
