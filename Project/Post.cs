using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace PostNameSpace
{
    public class Post
    {
        
        private string _writer = "";  //field
        //properties
        public Guid Id { get; set; }
        public string Content { get; set; }
        public string Writer { get { return _writer; } 
            set {
                if (string.IsNullOrWhiteSpace(value)) { throw new Exception("Writer Empty!"); }
                if (value.Length < 3) { throw new ArgumentOutOfRangeException("not existed name with this length.."); }
                foreach (var letter in value )
                {
                    if (!Char.IsLetter(letter))
                    {
                        throw new Exception("You can use only Letters!!!");
                    }
                }

            } 
        }
        public int LikeCount { get; set; }
        public int ViewCount { get; set; }
        public DateTime CreationDateTime { get; set; }

        public Post() { LikeCount = 0; ViewCount = 0; }
        public Post(Guid guid, string content, string writer)
        {
            Id = guid;
            Content  = content ;
            Writer = writer;
            LikeCount  = 0;
            ViewCount = 0;
            CreationDateTime = DateTime.Now;
        }
        public void Print_Post()
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.ResetColor();
            Console.WriteLine($@"Guid: {Id}
            Writed By: {Writer }
            {Content}
            Like Count: {LikeCount }
            Viewed : { ViewCount }      ");
            
        }
        public void Incerement_Like()
        {
            LikeCount  += 1;
        }
        public void Increment_View() { ViewCount++; }

        ///////////////////////////////////////////////////////Buradan ashagisini yazmamaliam belke de )))
        
       
    }

    /*
    public static class PostNamespace
    {
        public static List<Post> Posts = new List<Post>()
        {
            new Post() { Id = Guid.NewGuid(), Content = "First post", CreationDateTime = DateTime.Now, LikeCount = 0, ViewCount = 0 },
            new Post() { Id =  Guid.NewGuid(), Content = "Second post", CreationDateTime = DateTime.Now, LikeCount = 0, ViewCount = 0 },
            new Post() { Id =  Guid.NewGuid(), Content = "Third post", CreationDateTime = DateTime.Now, LikeCount = 0, ViewCount = 0 }
        };

    }
    */
}














/*
 
namespace AdminNamespace
{
public class Notification
{
public int id { get; set; }
public string Text { get; set; }
public DateTime DateTime { get; set; }
public string FromUser { get; set; }
//////////////////////
    public Notification(string text)
    {
        Text = text;
        DateTime = DateTime.Now;
    }
}

public static class AdminNamespace
{
    public static List<Admin> AdminList = new List<Admin>()
    {
        new Admin() { id = 1, username = "admin", email = "admin@example.com", password = "admin123", Posts = new List<Post>(), Notifications = new List<Notification>() }
    };
}
///////////////////
}

namespace ConsoleApp1
{
class Program
{
static void Main(string[] args)
{
Console.WriteLine("Welcome to the post viewer!");
 



        UserNamespace.User user = Login();

        if (user != null)
        {
            Console.WriteLine($"Welcome {user.name} {user.surname}!");

            while (true)
            {
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("1. View a post");
                Console.WriteLine("2. Like a post");
                Console.WriteLine("3. Exit");

                string input = Console.ReadLine();

                if (input == "1")
                {
                    Console.Write("Enter the ID of the post you would like to view: ");
                    int postId = int.Parse(Console.ReadLine());
                    user.ViewPost(postId);
                }
                else if (input == "2")
                {
                    Console.Write("Enter the ID of the post you would like to like: ");
                    int postId = int.Parse(Console.ReadLine());
                    user.LikePost(postId);
                }
                else if (input == "3")
                {
                    Console.WriteLine("Goodbye!");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please try again.");
                }
            }
        }
    }

    static UserNamespace.User Login()
    {
        Console.WriteLine("Please log in.");

        while (true)
        {
            Console.Write("Username or email: ");
            string usernameOrEmail = Console.ReadLine();
            Console.Write("Password: ");
            string password = Console.ReadLine();

            UserNamespace.User user = UserNamespace.UserNamespace.UserList.Find(u => (u.username == usernameOrEmail || u.email == usernameOrEmail) && u.password == password);
            if (user != null)
            {
                return user;
            }
            else
            {
                Console.WriteLine("Invalid username or password. Please try again.");
            }
        }
    }
}

 */