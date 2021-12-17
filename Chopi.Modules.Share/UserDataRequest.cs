using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Chopi.Modules.Share
{
    public class UserDataRequest
    {
        [JsonPropertyName("predicate")]
        public Func<UserData, bool> Predicate { get; set; }

        [JsonPropertyName("start")]
        [Required]
        public int Start { get; set; }

        [Required]
        [JsonPropertyName("count")]
        public int Count { get; set; }

        public UserDataRequest(int start, int count)
        {
            Start = start;
            Count = count;
        }

        [JsonConstructor]
        public UserDataRequest(Func<UserData, bool> predicate, int start, int count) : this(start, count)
        {
            Predicate = predicate;
        }
    }
}
