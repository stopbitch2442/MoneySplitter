using System.Collections.Generic;

namespace MoneySplitterApi.Model
{
    public class User
    {
        public Guid guid;
        public string login;
        public string password;
        public DateTime dateBirthday;
        public string ?email;
        public string lastName;
        public string firstName;
        public string ?patronymic;
        public Dictionary<string, string> ?PersonalSettings;
    }
}
