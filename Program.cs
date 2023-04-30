using AdminNamespace;

using UserNamespace;
using PostNameSpace;
using Namespace_Database;
using System.Transactions;
using System.Net.Mail;
using System.Net;

namespace PostAdminUser
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int row1 = 0;
            
            User U = new User(Guid.NewGuid(),"Emin", "Amrullaev", "EminMuveqqeti@gmail.com", "Emin9999", 1999, 5, 14);
            User U1 = new(Guid.NewGuid(), "Mamed", "Adiev", "MamedMamed@gmail.com", "Mamed9999", 1999, 5, 14);
            var U2 = new User(Guid.NewGuid(), "Evgeny", "Tiersen", "Evgeny@gmail.com", "Maham9999", 1999, 5, 14);

            Post P = new Post(Guid.NewGuid(), "Hi I m Maham", "Mamed");
            Post P1 = new (Guid.NewGuid(), "Hay loremipsumdolorset", "IamMosh");
            var P2 = new Post(Guid.NewGuid(), "Mariam itsFoggy day today", "IamEvgeny");

            Admin A1 = new Admin(Guid.NewGuid(), "xxtentacion", "Levy", "Tentacion@gmail.com", "Yasmin9999", 1999, 5, 14);


            DataBase D1 = new DataBase ();    D1.AddUser(U); D1.AddUser(U1); D1.AddUser(U2);

            D1.AddPost(P); D1.AddPost(P1); D1.AddPost(P2);

            D1.AddAdmin(A1);   D1.AddAdmin(A1);

            
           

            while (true )
            {
                bool firsrCheck = true; bool seCheck = true;
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Magenta ;
                Console.WriteLine(@"
                                 oooooooooooooo
                                oo            oo
                               oo        @     oo
                               o     @@@        o
                               o    @   @       o
                               o    @   @       o
                               o     @@@        o
                               oo              oo
                                oo            oo
                                 ooooooooooooo 
                                           "
                    );
             
                Console.WriteLine("\n\t\t    <<<<<<<<<<<<<< POSTAGRAM >>>>>>>>>>>>>>>>\n\n");

                Console.WriteLine("        ");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                if (row1 == 0){    Console.BackgroundColor = ConsoleColor.White;             }
                else Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine("\n\t\t\tLOG IN ");
                if(row1 == 1) { Console.BackgroundColor = ConsoleColor.White; }
                else Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine("\t\t\tSIGN UP ");


                Console.BackgroundColor = ConsoleColor.Black;


                dynamic choiceF;
                choiceF = Console.ReadKey(true);
                if (choiceF.Key == ConsoleKey.UpArrow && row1 != 0) row1--;
                else if (choiceF.Key == ConsoleKey.DownArrow && row1 != 1) row1++;
                else if (choiceF.Key == ConsoleKey.Enter )
                {
                    if(row1 == 0) 
                    { 
                        int row2 = 0;
                        while (seCheck)
                        {
                            Console.Clear();
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.DarkRed ;
                            Console.WriteLine(@" 
                                                           #       ######   #######   #   #   #
                                                           #       #    #   #         #   # # #  
                                                           #       #    #   #  ^^^^   #   #  ## 
                                                           #####   ######   #######   #   #   #                
                                                                                                       ");
                            if (row2 == 0) { Console.BackgroundColor = ConsoleColor.White; }
                            else Console.BackgroundColor = ConsoleColor.Black;
                            Console.Write("\t\t\tUser \n");
                            if (row2 == 1) { Console.BackgroundColor = ConsoleColor.White; }
                            else Console.BackgroundColor = ConsoleColor.Black;
                            Console.Write("\t\t\tAdmin \n");
                            if (row2 == 2) { Console.BackgroundColor = ConsoleColor.White; }
                            else Console.BackgroundColor = ConsoleColor.Black;
                            Console.Write("\t\t\tExit \n");

                            Console.BackgroundColor = ConsoleColor.Black;

                            dynamic choiceS;
                            choiceS = Console.ReadKey(true);
                            if (choiceS.Key == ConsoleKey.UpArrow & row2 != 0) { row2--; continue; }
                            else if (choiceS.Key == ConsoleKey.DownArrow & row2 != 2) { row2++; continue; }
                            else if (choiceS.Key == ConsoleKey.Enter) { if (row2 == 2) break; }
                            else continue;

                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write("     Gmail :");
                            string gmail; gmail = Console.ReadLine();

                            if (row2 == 0)
                            {
                                try { D1.Find_Mail_User(gmail); }
                                catch (Exception ex)
                                {
                                    Console.Write("\n /* Error Warning :   \n");
                                    Console.BackgroundColor = ConsoleColor.DarkRed; Console.ForegroundColor = ConsoleColor.Black;
                                    Console.WriteLine(ex.Message); Console.BackgroundColor = ConsoleColor.Black;
                                    Console.ForegroundColor = ConsoleColor.White; Console.WriteLine("*/ \n");
                                    Console.WriteLine("Enter any char for Go Back..."); Console.ReadKey(true); continue;
                                }
                            }
                            if (row2 == 1)
                            {
                                try { D1.Find_Mail_Admin(gmail); }
                                catch (Exception ex)
                                {
                                    Console.Write("\n /* Error Warning :   \n");
                                    Console.BackgroundColor = ConsoleColor.Red; Console.ForegroundColor = ConsoleColor.White ;
                                    Console.WriteLine(ex.Message); Console.BackgroundColor = ConsoleColor.Black;
                                    Console.ForegroundColor = ConsoleColor.White; Console.WriteLine("*/ \n");
                                    Console.WriteLine("Enter any char for Go Back..."); Console.ReadKey(true); continue;
                                }
                            }



                            Console.Write("\t Password : "); string password; password = Console.ReadLine();
                            if (row2 == 0)
                            {
                                try { D1.Find_Password_User(gmail, password); }
                                catch (Exception ex)
                                {
                                    Console.Write("\n /* Error Warning :   \n");
                                    Console.BackgroundColor = ConsoleColor.Red; Console.ForegroundColor = ConsoleColor.Black;
                                    Console.WriteLine(ex.Message); Console.BackgroundColor = ConsoleColor.Black;
                                    Console.ForegroundColor = ConsoleColor.White; Console.WriteLine("*/ \n");
                                    Console.WriteLine("Enter any char for Go Back..."); Console.ReadKey(true); continue;
                                }
                            }
                            if (row2 == 1)
                            {
                                try { D1.Find_Password_Admin(gmail, password); }
                                catch (Exception ex)
                                {
                                    Console.Write("\n /* Error Warning :   \n");
                                    Console.BackgroundColor = ConsoleColor.Red; Console.ForegroundColor = ConsoleColor.Black;
                                    Console.WriteLine(ex.Message); Console.BackgroundColor = ConsoleColor.Black;
                                    Console.ForegroundColor = ConsoleColor.White; Console.WriteLine("*/ \n");
                                    Console.WriteLine("Enter any char for Go Back..."); Console.ReadKey(true); continue;
                                }
                            }

                            if (row2 == 0)
                            {
                                int row3 = 0;
                                while (true)
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                                    Console.Clear();
                                    if (row3 == 0) { Console.BackgroundColor = ConsoleColor.White; }
                                    else Console.BackgroundColor = ConsoleColor.Black;
                                    Console.Write(@"    Show posts ");
                                    if (row3 == 1) { Console.BackgroundColor = ConsoleColor.White; }
                                    else Console.BackgroundColor = ConsoleColor.Black;
                                    Console.Write("\tExit \n");

                                    Console.BackgroundColor = ConsoleColor.Black;

                                    dynamic choiceT;
                                    choiceT = Console.ReadKey(true);
                                    if (choiceT.Key == ConsoleKey.UpArrow && row3 != 0) { row3-- ; continue; }
                                    else if (choiceT.Key == ConsoleKey.DownArrow && row3 != 1) { row3++; continue;  }
                                    else if (choiceT.Key == ConsoleKey.Enter) { if (row3 == 1) break; }
                                    else continue;


                                    if (row3 == 0)
                                    {
                                        D1.Print_All_Posts();
                                        Console.WriteLine(@"


                                        If U Wanna Like any post copy its Id and enter 'L' or 'l' character . 

                                        And if U wanna Go Back enter 'E' or 'e' character .");
                                        dynamic LikeOrExit; LikeOrExit = Console.ReadKey(true);
                                        if (LikeOrExit.Key == ConsoleKey.L)
                                        { string guid; Console.WriteLine("Enter Guid: "); guid = Console.ReadLine(); D1.Add_Like(guid); }
                                        else if(LikeOrExit.Key == ConsoleKey.E) { break; }
                                    }
                                }
                            }
                            else if(row2 == 1)
                            {
                                int row3 = 0;
                                while (true)
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                                    Console.Clear();
                                    if (row3 == 0) { Console.BackgroundColor = ConsoleColor.White; }
                                    else Console.BackgroundColor = ConsoleColor.Black;
                                    Console.Write(@"    Show Users ");
                                    if (row3 == 1) { Console.BackgroundColor = ConsoleColor.White; }
                                    else Console.BackgroundColor = ConsoleColor.Black;
                                    Console.Write(@"    Create new Post ");
                                    if (row3 == 2) { Console.BackgroundColor = ConsoleColor.White; }
                                    else Console.BackgroundColor = ConsoleColor.Black;
                                    Console.Write(@"    Delete Post ");
                                    if (row3 == 3) { Console.BackgroundColor = ConsoleColor.White; }
                                    else Console.BackgroundColor = ConsoleColor.Black;
                                    Console.Write("\tExit \n");

                                    Console.BackgroundColor = ConsoleColor.Black;

                                    dynamic choiceT;
                                    choiceT = Console.ReadKey(true);
                                    if (choiceT.Key == ConsoleKey.UpArrow & row3 != 0) { row3--; continue; }
                                    else if (choiceT.Key == ConsoleKey.DownArrow & row3 != 3) { row3++; continue; }
                                    else if (choiceT.Key == ConsoleKey.Enter) { if (row3 == 3) break; }
                                    else continue;

                                    if(row3 == 0)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("All Users : \n\n\n");
                                        D1.Print_All_Users();
                                        Console.WriteLine("Press any key for Go Back ...");
                                        Console.ReadKey(true);   continue;
                                    }
                                    if(row3 == 1)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("You Creating new Post ");
                                        Post newPost = new Post();
                                        try
                                        {
                                            string content, writer;
                                            Console.WriteLine("Enter writer name : ");   writer = Console.ReadLine();  newPost.Writer = writer;
                                            Console .WriteLine("Enter its Content : ");  content = Console.ReadLine(); newPost.Content = content;
                                            D1.AddPost(newPost);
                                            Console.WriteLine("Enter any key for go back ..."); Console.ReadKey(true); continue;
                                        }
                                        catch (Exception ex)
                                        {
                                            Console.Write("\n /* Error Warning :   \n");
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine(ex.Message);
                                            Console.WriteLine("Enter any key for go back ...");   Console.ReadKey(true);   continue;
                                        }
                                    }
                                    if(row3 == 2)
                                    {
                                      
                                        Console.WriteLine("\n\nDelete Post .\n\n");
                                        D1.Print_All_Posts();
                                        try
                                        {
                                            Console.WriteLine(" =============================== \n Enter the Id of Post U want to delete  ");
                                            string guid = Console.ReadLine();
                                            if(D1.Delete_Post(guid))
                                            {
                                                Console.WriteLine("post deleted Successfully .");
                                            }
                                            else { Console.WriteLine("Not find post with this Id..."); }
                                            Console.WriteLine("Enter any key for go back .");    Console.ReadKey(true);  continue;
                                            
                                        }
                                        catch(Exception ex)
                                        {
                                            Console.Write("\n /* Error Warning :   \n");
                                            Console.BackgroundColor = ConsoleColor.Red; Console.ForegroundColor = ConsoleColor.Black;
                                            Console.WriteLine(ex.Message); Console.BackgroundColor = ConsoleColor.Black;
                                            Console.ForegroundColor = ConsoleColor.White; Console.WriteLine("*/ \n");
                                            Console.WriteLine("Enter any char for Go Back..."); Console.ReadKey(true); continue;
                                        }
                                    }

                                }
                            }
                        }
                        //Buralarda hele tamamlanacag cox ish var ...
                    }
                    else if(row1 == 1)
                    {
                        User newUser = new User();
                        while (seCheck)
                        {
                            Console.Clear();
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                            Console.WriteLine(@"     
                                                   #######   #   #######   #     #        #     #   #######
                                                   #         #   ##        # #   #        #     #   #    # #
                                                   #######   #   ######    #  #  #        #     #   ######
                                                         #   #   ##   ##   #   # #        #     #   ##
                                                   #######   #   #######   #     #        ########  ##                   
");

                            
                            while (true)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkYellow; 
                                Console.Write("Enter Name : "); Console.ForegroundColor = ConsoleColor.White ;
                                string name = Console.ReadLine();
                                try { newUser.Name = name; }
                                catch (Exception ex)
                                {
                                    Console.Write("\n /* Error Warning :   \n");
                                    Console.BackgroundColor = ConsoleColor.Red; Console.ForegroundColor = ConsoleColor.Black;
                                    Console.WriteLine(ex.Message); Console.BackgroundColor = ConsoleColor.Black;
                                    Console.ForegroundColor = ConsoleColor.White; Console.WriteLine("*/ \n");
                                    Console.WriteLine("Enter any char for Go Back..."); Console.ReadKey(true); continue;
                                }
                                break;
                            }
                            while (true)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.Write("Enter SurName : "); Console.ForegroundColor = ConsoleColor.White;
                                string surname = Console.ReadLine();
                                try { newUser.Surname = surname; }
                                catch (Exception ex)
                                {
                                    Console.Write("\n /* Error Warning :   \n");
                                    Console.BackgroundColor = ConsoleColor.Red; Console.ForegroundColor = ConsoleColor.Black;
                                    Console.WriteLine(ex.Message); Console.BackgroundColor = ConsoleColor.Black;
                                    Console.ForegroundColor = ConsoleColor.White; Console.WriteLine("*/ \n");
                                    Console.WriteLine("Enter any char for Go Back..."); Console.ReadKey(true); continue;
                                }
                                break;
                            }
                            while (true)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.Write("Enter Gmail : "); Console.ForegroundColor = ConsoleColor.White; string gmail = Console.ReadLine(); 
                                try 
                                { 
                                    D1.Check_Mail(gmail);   newUser.Email = gmail;
                                }
                                catch (Exception ex)
                                {
                                    Console.Write("\n /* Error Warning :   \n");
                                    Console.BackgroundColor = ConsoleColor.Red; Console.ForegroundColor = ConsoleColor.Black;
                                    Console.WriteLine(ex.Message); Console.BackgroundColor = ConsoleColor.Black;
                                    Console.ForegroundColor = ConsoleColor.White; Console.WriteLine("*/ \n");
                                    Console.WriteLine("Enter any char for Go Back..."); Console.ReadKey(true); continue;
                                }
                                break;
                            }
                            while (true)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.Write("Enter Password : "); Console.ForegroundColor = ConsoleColor.White; string password = Console.ReadLine(); 
                                try
                                {
                                    newUser.Password = password;
                                }
                                catch (Exception ex)
                                {
                                    Console.Write("\n /* Error Warning :   \n");
                                    Console.BackgroundColor = ConsoleColor.Red; Console.ForegroundColor = ConsoleColor.Black;
                                    Console.WriteLine(ex.Message); Console.BackgroundColor = ConsoleColor.Black;
                                    Console.ForegroundColor = ConsoleColor.White; Console.WriteLine("*/ \n");
                                    Console.WriteLine("Enter any char for Go Back..."); Console.ReadKey(true); continue;
                                }
                                break;
                            }
                            while (true)
                            {
                                short year, month, day;
                                try
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Console.Write("Enter Year : ");
                                    Console.ForegroundColor = ConsoleColor.White; year  = Convert.ToInt16(Console.ReadLine());
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Console.Write("Enter Month : "); Console.ForegroundColor = ConsoleColor.White ; month  = Convert.ToInt16(Console.ReadLine());
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Console.Write("Enter Day : "); Console.ForegroundColor = ConsoleColor.White ; day  = Convert.ToInt16(Console.ReadLine());

                                    newUser.BirthDate(year, month, day);
                                }
                                catch (Exception ex)
                                {
                                    Console.Write("\n /* Error Warning :   \n");
                                    Console.BackgroundColor = ConsoleColor.Red; Console.ForegroundColor = ConsoleColor.Black;
                                    Console.WriteLine(ex.Message); Console.BackgroundColor = ConsoleColor.Black;
                                    Console.ForegroundColor = ConsoleColor.White; Console.WriteLine("*/ \n");
                                    Console.WriteLine("Enter any char for Go Back..."); Console.ReadKey(true); continue;
                                }
                                break;
                            }

                            bool check3 = true;
                            while (check3 )
                            {
                                Console.Clear();
                                string sms = "Please , Include the varification code that We just will send your Email address .    ";
                                foreach(var let in sms ) { Console.Write(let);   Thread.Sleep(15); }


                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.ForegroundColor = ConsoleColor.White;

                               //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                                Random rnd = new Random();
                                int random_code = rnd.Next(100000, 999999);
                                
                                var fromAddress = new MailAddress("mahamguziyev@gmail.com", "maham1902");
                                var toAddress = new MailAddress(newUser.Email, newUser.Name);
                                const string fromPassword = "ynxwoxlhgjpwcjsc";
                                const string subject = "Instagram";
                                string body = random_code.ToString();
                                
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
                                    Body = body
                                })
                                {
                                    smtp.Send(message);
                                }
                                while (true)
                                {
                                    int verifcation_code;
                                    Console.BackgroundColor = ConsoleColor.White ;   Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.Write("\n\n\t\t\tVerification Code: ");
                                    Console.BackgroundColor = ConsoleColor.Black ; Console.ForegroundColor = ConsoleColor.White ;
                                    verifcation_code = int.Parse(Console.ReadLine());
                                    if (verifcation_code == random_code)
                                    {
                                        Console.Clear();
                                        check3 = false;
                                        D1.AddUser(newUser );
                                        seCheck = false;

                                        break;
                                    }
                                    else
                                    {
                                        Console.Write("\n /* Error Warning :   \n");
                                        Console.BackgroundColor = ConsoleColor.Red;
                                        Console.ForegroundColor = ConsoleColor.Black;
                                        Console.WriteLine("Verification Code is Wrong !!!");
                                        Console.BackgroundColor = ConsoleColor.Black;
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.WriteLine("=========================================");
                                        Console.WriteLine("Enter any char for Go Back..."); Console.ReadKey(true); continue;
                                    }

                                }
                            }

                        }
                        }
               



                }

            







            }







        }
    }
}

/*
 
Bu tapshiriqda programin
AdminNamespace
UserNamespace
PostNameSpace bolmelisiniz
//etdiyiniz elaveler uchun 
meselen:mail uchun networknamespace yarada bilersiniz

Admin=>id,username,email,password,Posts,Notifications
User=>id,name,surname,age,email,password
Post=>id,Content,CreationDateTime,LikeCount,ViewCount

Notification=>id,Text,DateTime,FromUser(bu hansi user terefinden bu bildirishin geldiyidir)

Demeli sistemde 2 teref var User ve Admin
1.program achilanda user ve ya admin kimi daxil olmasi sorushulur
2.her ikisi de username(ve ya email) ve password daxil edirler
3.User yalniz umumi postlara baxa biler ve
Like ede biler(baxmaq ve like procesini ID esasinda apara bilersiniz)
Meselen :posta baxish uchun id ni daxil edin ve like uchun
Id daxil edin
her defe posta baxildiqca ve ya like edildikce postun baxish sayi ve like sayi artir
ve her defe de admine bildirish gelir her baxish ve ya like edilende
(BU SISTEMI DAHA DA TEKMILLESHDIRIB MAIL SISTEMI
YARADA BILERSINIZ MESELEN 
her defe notificationlar yaransin hem Admin klasindaki notification elave olunsun hem de mail olaraq admine gonderile biler)

 */