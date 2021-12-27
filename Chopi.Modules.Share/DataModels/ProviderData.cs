using Chopi.Modules.Share.Abstracts;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Chopi.Modules.Share.DataModels
{
    public class ProviderData : ObjectConteinered
    {
        [JsonIgnore]
        private string _brand;
        [JsonIgnore]
        private string _inn;
        [JsonIgnore]
        private string _address;
        [JsonIgnore]
        private string _phone;
        [JsonIgnore]
        private string _countryName;

        [JsonPropertyName("brand")]
        [Required(ErrorMessage = "Поле Бренд не может быть пустым")]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "Поле Бренд не соответствует критерию")]
        public string Brand
        {
            get { return _brand; }
            set
            {
                ValidateProperty(value);
                _brand = value;
                OnPropertyChanged();
            }
        }

        [JsonPropertyName("inn")]
        [Required(ErrorMessage = "Поле ИНН не может быть пустым")]
        public string INN
        {
            get { return _inn; }
            set
            {
                ValidateProperty(value);
                _inn = value;
                OnPropertyChanged();
            }
        }

        [JsonPropertyName("address")]
        [Required(ErrorMessage = "Поле Адрес не может быть пустым")]
        public string Address
        {
            get { return _address; }
            set
            {
                ValidateProperty(value);
                _address = value;
                OnPropertyChanged();
            }
        }

        [JsonPropertyName("phone")]
        [Required(ErrorMessage = "Поле Телефон не может быть пустым")]
        public string PhoneNumber
        {
            get { return _phone; }
            set
            {
                ValidateProperty(value);
                _phone = value;
                OnPropertyChanged();
            }
        }

        [JsonPropertyName("countryname")]
        [Required(ErrorMessage = "Поле Страна не может быть пустым")]
        public string CountryName
        {
            get { return _countryName; }
            set
            {
                ValidateProperty(value);
                _countryName = value;
                OnPropertyChanged();
            }
        }
    }
}
