using ConsoleApp3.Solutions.Task2.Extensions;
using ConsoleApp3.Solutions.Task2.Models;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace ConsoleApp3.Solutions.Task2
{
    //Using C# and any .NET libraries you’d like, connect to this REST-based API
    //and retrieve the prices into a list of strongly typed objects.
    public class Solution2
    {
        private readonly HttpClient _client = new HttpClient();

        private readonly string Url = "https://www.alphavantage.co/query?function=TIME_SERIES_DAILY&symbol=IBM&apikey=demo";
        public async Task<QueryData> ProcessData()
        {
            var stream = await _client.GetStreamAsync(Url).ConfigureAwait(false);
            var jsonDoc = await JsonDocument.ParseAsync(stream);
            var res = ParseApiResponse(jsonDoc);

            return res;
        }

        private QueryData ParseApiResponse(JsonDocument jsonDoc)
        {
            var result = new QueryData();
            try
            {
                result.MetaData = jsonDoc.ParseMetaData();
                result.TimeSeries = jsonDoc.ParseTimeSeries();

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error occured while parsing api response", ex);
            }
        }
    }
}