using StocksTracker.Domain.Models;
using StocksTracker.Repository.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace StocksTracker.Infrastructure.Services
{
    public class NationalityService : INationalityService
    {
        public async Task<IEnumerable<Nationality>> GetAll()
        {
            return await GetNationalitiesListFromApi();
        }

        private async Task<IEnumerable<Nationality>> GetNationalitiesListFromApi()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://restcountries.com/v3.1/all");
            if(response.IsSuccessStatusCode)
            {
                var nationalities = await response.Content.ReadAsAsync<IEnumerable<Nationality>>();
                return nationalities;
            }
            return null;
            //throw new Exception(response.StatusCode.ToString());
        }
    }
}
