
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using PostAdminUser.Project;
using PostNameSpace;
using UserNamespace;




namespace AdminNamespace
{
    public class Admin : Interface1, Interface2
    {
       
        
        public Guid  Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        private DateTime _birthDate = new();
        public void BirthDate(int year, int  month, int  day)
        {
            //minimum 16 yashi ola bilir !
            int now_year = DateTime.Now.Year;
            if(now_year - year < 16) { throw new ArgumentOutOfRangeException("You are child yet..."); }
            if(month <= 0 || month > 12) { throw new ArgumentOutOfRangeException("Wrong month data included ..."); }
            if(day <= 0 || day > 31) { throw new ArgumentOutOfRangeException("Wrong Day included ..."); }
            _birthDate = new DateTime(year, month, day);
        }
        public DateTime Get_BirthDate()  => _birthDate; 
        

        public Admin (Guid id, string username,string surname,  string email, string password,short year, short month, short day  )
        {
            Id = id; Name = username; Surname = surname; Email = email; Password = password;
            BirthDate(year, month, day);
        }




        private void SendEmail(string toEmail, string subject)
        {
            {
                var fromAddress = new MailAddress("mahamguziyev@gmail.com", "maham1902");
                var toAddress = new MailAddress(toEmail );
                const string fromPassword = "ynxwoxlhgjpwcjsc";
                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword),
                    Timeout = 20000
                };

                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    
                })
                {
                    smtp.Send(message);
                }
                // Send email to the specified email address
                //Burada SMTP kodlarini filan yazib maili elave etmeyi filan edeceyem...
            }
        }
        

    }





}

/*
 
namespace Namespace_Admin
{
    class Admin
    {
        private string _name = "";
        private string _surname = "";
        private string _email = "";
        private string _password = "";
        private DateTime _Birthday = new();


        //Constructors
        public Admin(string name_g, string surname_g, string email_g, string password_g, int year_g, int month_g, int day_g)
        {
            //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            //======================================================================================================
            // Adminler Register bolmesinden qeydiyyatdan kecmediyi ucun yoxlanislara ehtiyac yoxdur.
            // Program baslayan zaman default olaraq 2 Admin Yaradillir ve Bu Bele davam edir....
            //======================================================================================================
            //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            _name = name_g;
            _surname = surname_g;
            _email = email_g;
            _password = password_g;
            SetBirthday(year_g, month_g, day_g);
        }
        //Get Methods
        public string GetName() { return _name; }
        public string GetSurname() { return _surname; }
        public string GetEmail() { return _email; }
        public string GetPassword() { return _password; }
        public DateTime GetBirthday() { return _Birthday; }
        
        
        // Set Birthday
        public void SetBirthday(int year_g, int month_g, int day_g)
        {
            // Minumum Age Must Be 15 Years Old

            int year_now = DateTime.Now.Year;
            if (year_now - 15 < year_g)
            {
                throw new Exception("Minumum Age Must Be 15 Years Old!");
            }
            if (0 > month_g || month_g > 12)
            {
                throw new Exception("Wrong Month!");
            }
            if (0 > day_g || day_g > 31)
            {
                throw new Exception("Wrong Day!");
            }
            _Birthday = new DateTime(year_g, month_g, day_g);

        }



    }
}






 */
