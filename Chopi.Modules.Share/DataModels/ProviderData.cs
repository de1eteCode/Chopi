using Chopi.Modules.Share.Abstracts;
using System.Text.Json.Serialization;

namespace Chopi.Modules.Share.DataModels
{
    public class ProviderData : ObjectConteinered
    {
        [JsonPropertyName("brand")]
        public string Brand { get; set; }

        [JsonPropertyName("inn")]
        public string INN { get; set; }

        [JsonPropertyName("address")]
        public string Address { get; set; }

        [JsonPropertyName("phone")]
        public string PhoneNumber { get; set; }

        [JsonPropertyName("countryname")]
        public string CountryName { get; set; }
    }
}
