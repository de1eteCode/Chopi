using System;
using System.Text.Json.Serialization;

namespace Chopi.Modules.Share.Abstracts
{
    /// <summary>
    /// Класс, идентифицирующий объекты для кеширования на стороне клиента
    /// </summary>
    public abstract class CachedObject 
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }
    }
}
