using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace Chopi.Modules.Share.Abstracts
{
    /// <summary>
    /// Класс, идентифицирующий объекты для кеширования на стороне клиента
    /// </summary>
    public abstract class ObjectConteinered : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

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

        public void OnPropertyChanged([CallerMemberName] string propertyName = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        protected void ValidateProperty<T>(T value, [CallerMemberName] string name = "")
        {
            Validator.ValidateProperty(value, new ValidationContext(this, null, null)
            {
                MemberName = name
            });
        }

        public bool IsValid()
        {
            return Validator.TryValidateObject(this, new ValidationContext(this), new List<ValidationResult>(), true);
        }
    }
}
