using ConsoleApp3.Solutions.Task2.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.Json;

namespace ConsoleApp3.Solutions.Task2.Extensions
{
    public static class TimeSeriesParser
    {
        private const string TimeSeriesToken = "Time Series (Daily)";

        public static IEnumerable<TimeSeries> ParseTimeSeries(this JsonDocument jsonDoc)
        {
            var jsonProperties = jsonDoc.RootElement.EnumerateObject();
            if (jsonProperties.Any(property => property.Name.Contains(TimeSeriesToken)) == false)
                yield return null;

            var jsonElement = jsonProperties.Last().Value;

            foreach (var jsonTimeSeries in jsonElement.EnumerateObject())
            {
                var timeSeries = new TimeSeries();
                if (DateTime.TryParseExact(jsonTimeSeries.Name, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out var time))
                    timeSeries.TimeStamp = time;

                var jsonDataPointFields = jsonTimeSeries.Value;
                var dataPoints = PopulateFields(jsonDataPointFields);

                timeSeries.DataPoints = dataPoints;
                yield return timeSeries;
            }
        }
        private static IEnumerable<DataPoint> PopulateFields(JsonElement jsonDataPointFields)
        {
            foreach (var jsonField in jsonDataPointFields.EnumerateObject())
            {
                var dataPoint = new DataPoint();
                var id = jsonField.Name.Split(new[] { '.' })?[0].Trim();
                var name = jsonField.Name.Split(new[] { '.' })?[1].Trim();


                if (int.TryParse(id, out int i))
                    dataPoint.Id = i;

                dataPoint.Name = name;

                if (double.TryParse(jsonField.Value.ToString(), out double d))
                    dataPoint.Value = d;

                yield return dataPoint;
            }
        }
    }
}