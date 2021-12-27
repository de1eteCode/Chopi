using Chopi.Modules.Share.Abstracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Chopi.Modules.Share.DataModels
{
    public class UserData : ObjectConteinered
    {
        [JsonIgnore]
        private string _username;
        [JsonIgnore]
        private string _email;
        [JsonIgnore]
        private string _firstname;
        [JsonIgnore]
        private string _secondname;
        [JsonIgnore]
        private string _middlename;
        [JsonIgnore]
        private string _series;
        [JsonIgnore]
        private string _number;
        [JsonIgnore]
        private string _residenceregistration;
        [JsonIgnore]
        private string _citizenship;
        [JsonIgnore]
        private DateTime _date;

        [JsonPropertyName("username")]
        [Required(ErrorMessage = "Поле Username не может быть пустым")]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "Минимум 4 символа")]
        public string UserName
        {
            get => _username;
            set
            {
                ValidateProperty(value, nameof(UserName));
                _username = value;
                OnPropertyChanged();
            }
        }

        [JsonPropertyName("email")]
        [Required(ErrorMessage = "Поле Email не может быть пустым")]
        [EmailAddress(ErrorMessage = "Email адрес")]
        public string Email
        {
            get => _email;
            set
            {
                ValidateProperty(value, nameof(Email));
                _email = value;
                OnPropertyChanged();
            }
        }

        [JsonPropertyName("firstname")]
        [Required(ErrorMessage = "Поле Имя не может быть пустым")]
        [MinLength(4, ErrorMessage = "Минимальная длина 4")]
        public string FirstName
        {
            get => _firstname;
            set
            {
                ValidateProperty(value, nameof(FirstName));
                _firstname = value;
                OnPropertyChanged();
            }
        }

        [JsonPropertyName("secondname")]
        [Required(ErrorMessage = "Поле Фамилия не может быть пустым")]
        [MinLength(4, ErrorMessage = "Минимальная длина 4")]
        public string SecondName
        {
            get => _secondname;
            set
            {
                ValidateProperty(value, nameof(SecondName));
                _secondname = value;
                OnPropertyChanged();
            }
        }

        [JsonPropertyName("middlename")]
        public string MiddleName
        {
            get => _middlename;
            set
            {
                ValidateProperty(value, nameof(MiddleName));
                _middlename = value;
                OnPropertyChanged();
            }
        }

        [JsonPropertyName("passportseria")]
        [MinLength(4, ErrorMessage = "Минимальная длина 4")]
        [MaxLength(4, ErrorMessage = "Максимальная длина 4")]
        [Required(ErrorMessage = "Поле Серия пасспорта не может быть пустым")]
        public string Series
        {
            get => _series;
            set
            {
                ValidateProperty(value, nameof(Series));
                _series = value;
                OnPropertyChanged();
            }
        }

        [JsonPropertyName("passportnumber")]
        [MinLength(6, ErrorMessage = "Минимальная длина 6")]
        [MaxLength(6, ErrorMessage = "Максимальная длина 6")]
        [Required(ErrorMessage = "Поле Номер пасспорта не может быть пустым")]
        public string Number
        {
            get => _number;
            set
            {
                ValidateProperty(value, nameof(Number));
                _number = value;
                OnPropertyChanged();
            }
        }

        [JsonPropertyName("passportregistration")]
        [Required(ErrorMessage = "Поле Регистрация не может быть пустым")]
        [MinLength(3, ErrorMessage = "Минимальная длина 3")]
        public string ResidenceRegistration
        {
            get => _residenceregistration;
            set
            {
                ValidateProperty(value, nameof(ResidenceRegistration));
                _residenceregistration = value;
                OnPropertyChanged();
            }
        }

        [JsonPropertyName("citizenship")]
        [Required(ErrorMessage = "Поле Гражданство не может быть пустым")]
        [MinLength(4, ErrorMessage = "Минимальная длина 4")]
        public string Citizenship
        {
            get => _citizenship;
            set
            {
                ValidateProperty(value, nameof(Citizenship));
                _citizenship = value;
                OnPropertyChanged();
            }
        }

        [JsonPropertyName("dateofbirth")]
        [Required(ErrorMessage = "Поле Дата не может быть пустой")]
        public DateTime DateOfBirth
        {
            get => _date;
            set
            {
                ValidateProperty(value, nameof(DateOfBirth));
                _date = value;
                OnPropertyChanged();
            }
        }

        [JsonPropertyName("roles")]
        public IEnumerable<string> Roles { get; set; }

        [JsonIgnore]
        public string FIO => $"{SecondName} {FirstName} {MiddleName}";

        [JsonIgnore]
        public string FullPassportNum => $"{Series} {Number}";

        [JsonIgnore]
        public string DateOfBirthStr => DateOfBirth.ToString("D");

        [JsonIgnore]
        public string RoleStr => string.Join(", ", Roles);

        public override bool Equals(object obj)
        {
            if (obj is UserData data)
            {
                bool state = true;

                state = data.Id == this.Id;
                state = data.UserName.Equals(this.UserName);
                state = data.Series.Equals(this.Series);
                state = data.Number.Equals(this.Number);

                return state;
            }
            else
            {
                return false;
            }
        }
    }
}
