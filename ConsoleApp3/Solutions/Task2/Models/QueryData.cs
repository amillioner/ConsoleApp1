using System;
using System.Collections.Generic;

namespace ConsoleApp3.Solutions.Task2.Models
{
    public class QueryData
    {
        public IDictionary<string, MetaData> MetaData { get; set; }
        public IEnumerable<TimeSeries> TimeSeries { get; set; }
    }

    public class MetaData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }

    public class TimeSeries
    {
        public DateTime TimeStamp { get; set; }
        public IEnumerable<DataPoint> DataPoints { get; set; }
    }
    public class DataPoint
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Value { get; set; }
    }
}
