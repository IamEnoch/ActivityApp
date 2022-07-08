using ActivityApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace ActivityApp.Services
{
    public class ActivityService
    {
        HttpClient _httpClient;

        ActivityModel activityModel = new();
        public async Task<ActivityModel> GetActivityAsync()
        {
            _httpClient = new HttpClient();

            string url = "https://www.boredapi.com/api/activity";

            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                activityModel = await response.Content.ReadFromJsonAsync<ActivityModel>();
            }

            return activityModel;


        }
    }
}
