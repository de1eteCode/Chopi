using System.Text.Json.Serialization;

namespace Chopi.Modules.Share.RequestModels
{
    public class SubscribeModel
    {
        [JsonPropertyName("key")]
        public string Key { get; set; }

        [JsonConstructor]
        public SubscribeModel(string key)
        {
            Key = key;
        }
    }
}
