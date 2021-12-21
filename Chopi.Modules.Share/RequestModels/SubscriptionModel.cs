using System.Text.Json.Serialization;

namespace Chopi.Modules.Share.RequestModels
{
    public class SubscriptionModel
    {
        [JsonPropertyName("key")]
        public string Key { get; set; }
    }
}
