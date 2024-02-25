﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using StocksTracker.WCFService.Models;
using System.Runtime.Remoting.Contexts;

namespace StocksTracker.WCFService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
        HttpClient client;
        public Service1()
        {
            client = new HttpClient();
        }
        public async Task<string> GetData()
        {
            HttpResponseMessage response = await client.GetAsync("https://api.polygon.io/v2/aggs/ticker/AAPL/range/1/day/2023-01-09/2023-01-09?apiKey=e3t6XTbelIa8VopuCjy6bHXDisf2ksAJ");

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    var stoksResp = await response.Content.ReadAsAsync<StocksAPIResponse>();
                    var stoksAsJson = Newtonsoft.Json.JsonConvert.SerializeObject(stoksResp.results.ToList());
                    var postCont = new StringContent(stoksAsJson, Encoding.UTF8, "application/json");
                    HttpResponseMessage savingStocksresponse = await client.PostAsync("http://localhost:5013/api/stock/createstocksList", postCont);
                    if(savingStocksresponse.IsSuccessStatusCode)
                    {
                        return "Stocks Add";
                    }

                }
                catch(Exception ex)
                {
                    return ex.Message;
                }
                //var stocks = JsonConvert.DeserializeObject<Stock>(stoksAsString);
            }

            return string.Format("Getting data");
        }

        public async Task<bool> GetStocks()
        {
            HttpResponseMessage response = await client.GetAsync("https://api.polygon.io/v2/aggs/ticker/AAPL/range/1/day/2023-01-09/2023-01-09?apiKey=e3t6XTbelIa8VopuCjy6bHXDisf2ksAJ");

            if(response.IsSuccessStatusCode)
            {
                var stoksAsString =  await response.Content.ReadAsStringAsync();
                //var stocks = JsonConvert.DeserializeObject<Stock>(stoksAsString);
            }

            return true;
        }

        //public CompositeType GetDataUsingDataContract(CompositeType composite)
        //{
        //    if (composite == null)
        //    {
        //        throw new ArgumentNullException("composite");
        //    }
        //    if (composite.BoolValue)
        //    {
        //        composite.StringValue += "Suffix";
        //    }
        //    return composite;
        //}
    }
}