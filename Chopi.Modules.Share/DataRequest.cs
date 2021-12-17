using Chopi.Modules.Share.Abstracts;
using System;
using System.Text.Json.Serialization;

namespace Chopi.Modules.Share
{
    public class DataRequest<T> : IDataRequest<T>
        where T : class
    {
        [JsonPropertyName("start")]
        public int Start { get; set; }

        [JsonPropertyName("count")]
        public int Count { get; set; }

        [JsonPropertyName("predicate")]
        public Func<T, bool> Predicate { get; set; }

        [JsonConstructor]
        public DataRequest(int start, int count, Func<T, bool> predicate = null)
        {
            Predicate = predicate;
            Start = start;
            Count = count;
        }
    }
}
