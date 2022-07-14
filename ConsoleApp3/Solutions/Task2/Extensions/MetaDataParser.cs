using ConsoleApp3.Solutions.Task2.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace ConsoleApp3.Solutions.Task2.Extensions
{
    public static class MetaDataParser
    {
        private const string MetaDataToken = "Meta Data";

        public static IDictionary<string, MetaData> ParseMetaData(this JsonDocument jsonDoc)
        {
            var result = new Dictionary<string, MetaData>();

            var jsonProps = jsonDoc.RootElement.EnumerateObject();
            
            if (jsonProps.Any(property => property.Name.Contains(MetaDataToken)) == false) 
                return result;

            var metaDataProperty = jsonProps.FirstOrDefault(property => property.Name.Contains(MetaDataToken));

            if (metaDataProperty.Name.Contains(MetaDataToken) == false)
                return result;

            foreach (var metaData in metaDataProperty.Value.EnumerateObject())
            {

                var dataPoint = new MetaData();
                var id = metaData.Name.Split(new[] { '.' })?[0].Trim();
                var name = metaData.Name.Split(new[] { '.' })?[1].Trim();

                if (int.TryParse(id, out int i))
                    dataPoint.Id = i;

                dataPoint.Name = name;
                dataPoint.Value = metaData.Value.ToString();

                result.Add(dataPoint.Name, dataPoint);
            }

            return result;
        }
    }
}