using Chopi.Modules.Share.Abstracts;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Chopi.Modules.Share.DataModels
{
    public class CarData : ObjectConteinered
    {
        [JsonIgnore]
        private DateTime _date;
        [JsonIgnore]
        private string _color;
        [JsonIgnore]
        private double _price;
        [JsonIgnore]
        private string _modelname;
        [JsonIgnore]
        private string _brandname;
        [JsonIgnore]
        private string _cartype;

        [JsonPropertyName("date")]
        [Required(ErrorMessage = "Поле Дата не может быть пустым")]
        public DateTime Year
        {
            get { return _date; }
            set 
            {
                ValidateProperty(value);
                _date = value;
                OnPropertyChanged();
            }
        }

        [JsonPropertyName("color")]
        [Required(ErrorMessage = "Поле Цвет не может быть пустым")]
        public string Color
        {
            get { return _color; }
            set
            {
                ValidateProperty(value);
                _color = value;
                OnPropertyChanged();
            }
        }

        [JsonPropertyName("baseprice")]
        [Required(ErrorMessage = "Поле Базовая цена не может быть пустым")]
        [Range(0.0, Double.MaxValue, ErrorMessage = "Цена не может быть отрицательной")]
        public double BasePrice
        {
            get { return _price; }
            set
            {
                ValidateProperty(value);
                _price = value;
                OnPropertyChanged();
            }
        }

        [JsonPropertyName("model")]
        [Required(ErrorMessage = "Поле Модель не может быть пустым")]
        public string ModelName
        {
            get { return _modelname; }
            set
            {
                ValidateProperty(value);
                _modelname = value;
                OnPropertyChanged();
            }
        }

        [JsonPropertyName("barnd")]
        [Required(ErrorMessage = "Поле Бренд не может быть пустым")]
        public string BrandName
        {
            get { return _brandname; }
            set
            {
                ValidateProperty(value);
                _brandname = value;
                OnPropertyChanged();
            }
        }

        [JsonPropertyName("cartype")]
        public string CarType
        {
            get { return _cartype; }
            set
            {
                ValidateProperty(value);
                _cartype = value;
                OnPropertyChanged();
            }
        }
    }
}
