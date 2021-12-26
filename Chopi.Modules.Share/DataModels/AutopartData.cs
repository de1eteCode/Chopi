using Chopi.Modules.Share.Abstracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Chopi.Modules.Share.DataModels
{
    public class AutopartData : ObjectConteinered
    {
        [JsonIgnore]
        private string _article;
        [JsonIgnore]
        private string _name;
        [JsonIgnore]
        private string _description;
        [JsonIgnore]
        private double _price;
        [JsonIgnore]
        private string _manufacturename;

        [JsonPropertyName("article")]
        [Required(ErrorMessage = "Поле Артикль не может быть пустым")]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "Минимум 6 символов")]
        public string Article
        {
            get { return _article; }
            set
            {
                ValidateProperty(value);
                _article = value;
                OnPropertyChanged();
            }
        }

        [JsonPropertyName("name")]
        [Required(ErrorMessage = "Поле Имя не может быть пустым")]
        [StringLength(100, MinimumLength = 4, ErrorMessage = "Минимум 4 символа")]
        public string Name
        {
            get { return _name; }
            set
            {
                ValidateProperty(value);
                _name = value;
                OnPropertyChanged();
            }
        }

        [JsonPropertyName("desc")]
        [Required(ErrorMessage = "Поле Описание не может быть пустым")]
        [StringLength(500)]
        public string Description
        {
            get { return _description; }
            set
            {
                ValidateProperty(value);
                _description = value;
                OnPropertyChanged();
            }
        }

        [JsonPropertyName("price")]
        [Required(ErrorMessage = "Поле Цена не может быть пустым")]
        [Range(0.0, Double.MaxValue, ErrorMessage = "Цена не может быть отрицательной")]
        public double Price
        {
            get { return _price; }
            set
            {
                ValidateProperty(value);
                _price = value;
                OnPropertyChanged();
            }
        }


        [JsonPropertyName("manufacture")]
        [Required(ErrorMessage = "Поле Цена не может быть пустым")]
        public string ManufactureName
        {
            get { return _manufacturename; }
            set
            {
                ValidateProperty(value);
                _manufacturename = value;
                OnPropertyChanged();
            }
        }

        [JsonPropertyName("formodels")]
        [MinLength(1, ErrorMessage = "Как минимум для 1 модели")]
        public IEnumerable<string> ForModels { get; set; }

        [JsonIgnore]
        public string ForModelsStr => string.Join(", ", ForModels);
    }
}
