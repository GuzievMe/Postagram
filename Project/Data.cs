using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AdminNamespace;
using PostNameSpace;
using UserNamespace;

namespace Namespace_Database
{
    class DataBase
    {
        private List<User> _users = new();
        private List<Admin> _admins = new();
        private List<Post> _posts = new();

        public DataBase() { }

        //Get Methods
        public List<User> GetUsers() { return _users; }
        public List<Admin> GetAdmins() { return _admins; }
        public List<Post> GetPosts() { return _posts; }

        // Add Methods
        public void AddUser(User new_userr)      //Registra aiddir.  Sign Up ederek sonda AddUser olunur  ve ya defoult yaradilmish userin databaseya add olmasiycun
        {
            
            _users.Add(new_userr);
        }
        public void AddAdmin(Admin new_admin)      // bu il once defoult yaradilmish adminin databaseya add olunmasi uchun kullanir  
        {
            _admins.Add(new_admin);
        }
        public void AddPost(Post new_post)     // Admin Log in olarak Addpost ede bilir 
        {
            _posts.Add(new_post);
        }

        // Check Mail if This Mail already have throw Excptions.
        public void Check_Mail(string mail)    //////Burada registrasiya zamani gmailin movcud oldugunu yoxlanir
        {
            foreach (User user in _users)
            {
                if (user.Email == mail)
                    throw new Exception("This Mail Already Existed!");
            }
        }
        
        public void Find_Mail_User(string mail)     //Log in zamani mevcudlug yoxlanir
        {
            foreach (User user in _users)
            {
                if (user.Email == mail) {  return ; }
            }
            throw new Exception("This Mail Cannot Find!");
        }

        public void Find_Mail_Admin(string mail)     //Log in zamani mevcudlug yoxlanir
        { 
            foreach (Admin admin in _admins)
            {
                if (admin.Email == mail)  {  return ; }
            }
            throw new Exception("This Mail Cannot Find!");  
        }

       
        public void Find_Password_User(string mail, string password) //User tapildigdan sonra password -u check olunur
        {
            foreach (User user in _users)
            {
                if (user.Email == mail && user.Password != password)
                      throw new Exception("Wrong Password!");
            }
        }

        public void Find_Password_Admin(string mail, string password)  //Admin tapildigdan sonra password -u check olunur
        {
            foreach (Admin admin in _admins)
            {
                if (admin.Email == mail && admin.Password != password)
                        throw new Exception("Wrong Password!");
            }
        }
        public void Print_All_Users()
        {
            foreach (User user in _users)
            {
                user.Print();
            }
        }
        ////////////////////////////////
        //Post Functions
        public void Print_All_Posts()
        {   
            foreach (Post post in _posts)
            {
                post.Increment_View();
                post.Print_Post();
            }
        }

        public void Add_Like(string id)
        {
            foreach (Post post in _posts)
            {
                if (post.Id.ToString() == id)
                    post.Incerement_Like();
            }
        }

        public bool Delete_Post(string guid)
        {
            for (int i = 0; i < _posts.Count; i++)
            {
                if (_posts[i].Id.ToString() == guid)
                {
                    _posts.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }
    }
}



