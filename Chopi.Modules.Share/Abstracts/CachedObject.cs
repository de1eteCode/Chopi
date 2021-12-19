using System;
using System.Text.Json.Serialization;

namespace Chopi.Modules.Share.Abstracts
{
    /// <summary>
    /// Класс, идентифицирующий объекты для кеширования на стороне клиента
    /// </summary>
    public abstract class CachedObject 
    {
        [JsonIgnore]
        public object this[string propertyName]
        {
            get
            {
                var propInfo = GetType().GetProperty(propertyName);
                return propInfo?.GetValue(this, null);
            }
        }

        [JsonPropertyName("id")]
        public Guid Id { get; set; }
    }
}
