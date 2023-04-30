using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;

using PostNameSpace;
using PostAdminUser.Project;




namespace UserNamespace
{
    public class User : Interface1, Interface2
    {
        public User() { Id = Guid.NewGuid(); }
        public User(Guid id, string name, string surname, string email, string password, int year, int month, int day)
        {
            Id = id; Name = name; Surname = surname; Email = email; Password = password;
            _birthdate = new DateTime(year, month, day);
        }

        private DateTime _birthdate = new();
        private string _name = "", _surname = "", _email = "", _password = "";

        public Guid Id { get; set; }
        public string Name
        {
            get { return _name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value)) { throw new ArgumentNullException("Name cant be null !!!"); }
                if (value.Length < 3) { throw new ArgumentException("Not existed Name with this Length"); }
                foreach (var check_letter in _name)
                { if (!Char.IsLetter(check_letter)) { throw new Exception("Only Use Letters!"); } }
                _name = value;
            }
        }
        public string Surname
        {
            get { return _surname; }
            set
            {
                if (string.IsNullOrWhiteSpace(value)) { throw new ArgumentNullException("SurName cant be null !!!"); }
                if (value.Length < 3) { throw new ArgumentException("Not existed surName with this Length"); }
                foreach (var check_letter in _surname)
                { if (!Char.IsLetter(check_letter)) { throw new Exception("Only Use Letters!"); } }
                _surname = value;
            }
        }
        public string Email
        {
            get { return _email; }
            set
            {
                if (string.IsNullOrWhiteSpace(value)) { throw new ArgumentNullException("Email cant be null !!!"); }
                if (!value.EndsWith("@gmail.com")) { throw new ArgumentException("Gmail is Wrong !"); }
                _email = value;
            }
        }
        public string Password
        {
            get { return _password; }
            set
            {
                if (string.IsNullOrWhiteSpace(value)) { throw new ArgumentNullException("Password cant be null !!!"); }
                if (value.Length < 8) { throw new ArgumentException("Password may be consist of Min 8 character"); }
                if(value == value.ToUpper ()) { throw new ArgumentException("Must use Min 1 Lower character"); }
                if (value == value.ToLower()) { throw new ArgumentException("Must use Min 1 Upper character"); }
                bool check = true; bool check1 = true;
                foreach (var check_DigLet in value)
                {
                    if (Char.IsDigit(check_DigLet)) { check = false; }
                    if (Char.IsLetter(check_DigLet)) { check1 = false; }
                }
                if (check)   throw new Exception("Minimum 1 Number!");
                if (check1) throw new Exception("Minimum 1 Letter!");

                _password = value;
            }
        }
        public void BirthDate(int year, int month, int day)
        {
            int now_year = DateTime.Now.Year;
            if (now_year - year < 16) { throw new ArgumentException("You are child yet ..."); }
            if (month <= 0 || month > 12) { throw new ArgumentException("Wrong month data included..."); }
            if (day <= 0 || day > 31) { throw new ArgumentException("wrong day data included ..."); }
            _birthdate = new(year, month, day);
        }

        public DateTime Get_BirthDate() => _birthdate; 

        public void Print()
        {
            Console.WriteLine($@"Username: {Name}
            Surname: {Surname}
            Email: {Email} 
            Birthday : {_birthdate}
             ");

        }
    }
}
       