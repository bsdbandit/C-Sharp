//Creating a local Windows account 
//Written by bsdbandit



//C# Modules 
using System;
using System.DirectoryServices;
using System.Data;


//Account Class 
class Accounts
    {
     public static string Name;
     public static string Pass;


     static void Main(string[] args)
     { 
        Console.WriteLine("Windows Local Account Creator");
        Console.WriteLine("Enter the username");
        Name = Console.ReadLine();

        Console.WriteLine("Enter user password");
        Pass = Console.ReadLine();

        createUser(Name, Pass);

        }


        public static void createUser(string Name, string Pass) { 

            try 
            {

                DirectoryEntry AD = new DirectoryEntry("WinNT://" + Environment.MachineName + ",computer");
                DirectoryEntry NewUser = AD.Children.Add(Name, "user");
                NewUser.Invoke("SetPassword", new object[] { Pass });
                NewUser.Invoke("Put", new object[] { "Description", "suga bear from .NET" });
                NewUser.CommitChanges();
                DirectoryEntry grp;

                grp = AD.Children.Find("Administrators", "group");
                if (grp != null) { grp.Invoke("Add", new object[] { NewUser.Path.ToString() }); } 
                Console.WriteLine("Local Account was Created Successfully");
                Console.WriteLine("Press Enter to Continue....");
                Console.ReadLine();

            }
            catch (Exception ex)
            {

                 Console.WriteLine(ex.Message);
                 Console.ReadLine();

            }

        }
    }



