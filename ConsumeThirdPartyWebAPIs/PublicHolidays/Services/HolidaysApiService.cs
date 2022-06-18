using PublicHolidays.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace PublicHolidays.Services
{
    public class HolidaysApiService : IHolidaysApiService
    {
        private static readonly HttpClient _httpClient;

        static HolidaysApiService()
        {
            _httpClient = new HttpClient()
            {
                BaseAddress = new Uri("https://date.nager.at")
            };

        }

        public async Task<List<HolidayModel>> GetHolidaysAsync(string countryCode, int year)
        {
            var url = string.Format("/api/v2/PublicHolidays/{0}/{1}", year, countryCode);
            var result = new List<HolidayModel>();
            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var stringRespons = await response.Content.ReadAsStringAsync();

                result = JsonSerializer.Deserialize<List<HolidayModel>>(stringRespons,
                    new JsonSerializerOptions() {PropertyNamingPolicy = JsonNamingPolicy.CamelCase });


            }
            else
            {
                throw new HttpRequestException(response.ReasonPhrase);
            }

            return result;
        }
    }
}
