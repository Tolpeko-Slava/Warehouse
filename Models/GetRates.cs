using System.Linq;
using System;
using Microsoft.AspNetCore.Mvc;
using Warehouse.Models;
using System.Text.Json;
using System.Net.Http;
using System.Net;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Collections.Generic;
using Warehouse.Controllers;

namespace Warehouse.Models
{
    public class GetRates
    {
        public async Task<List<ExchangeRates>> GetRatesAsync(string path, HttpClient client)
        {
            HttpResponseMessage response = await client.GetAsync(path);
            string rates = String.Empty;
            if (response.IsSuccessStatusCode)
            {
                rates = await response.Content.ReadAsStringAsync();
            }
            
            return JsonSerializer.Deserialize<List<ExchangeRates>>(rates);
        }

    }
}
