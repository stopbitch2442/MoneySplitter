using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MoneySplitterApi.Model
{
    public class User
    {

        public Guid guid;
        [Required]
        [StringLength(20, ErrorMessage = "Логин должен быть от 5 до 20 символов", MinimumLength = 5)]
        public string login;
        [Required]
        [JsonIgnore]
        [StringLength(20, ErrorMessage = "Пароль должен быть от 10 до 30 символов", MinimumLength = 10)]
        public string password;
        public DateTime dateBirthday;
        [EmailAddress]
        public string ?email;
        public string ?lastName;
        [Required]
        public string firstName;
        public string ?patronymic;
        public PersonalSettings ?personalSettings;
    }
}
