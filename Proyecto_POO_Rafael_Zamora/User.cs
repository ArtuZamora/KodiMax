using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_POO_Rafael_Zamora
{
    public class User
    {
        #region Properties
        private string userID;
        private string username;//
        private string password;//
        private string userType;
        private string name;//
        private string lastname;//
        private string email;//
        private string cellphone;//
        private string gender;//
        private string birthdate;//
        #endregion

        #region Encapsulation
        public string UserID
        {
            get
            {
                return userID;
            }

            set
            {
                userID = value;
            }
        }
        public string Username
        {
            get
            {
                return username;
            }

            set
            {
                username = value;
            }
        }
        public string Password
        {
            get
            {
                return password;
            }
        }
        public string UserType
        {
            get
            {
                return userType;
            }

            set
            {
                userType = value;
            }
        }
        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }
        public string Lastname
        {
            get
            {
                return lastname;
            }

            set
            {
                lastname = value;
            }
        }
        public string Email
        {
            get
            {
                return email;
            }

            set
            {
                email = value;
            }
        }
        public string Cellphone
        {
            get
            {
                return cellphone;
            }

            set
            {
                cellphone = value;
            }
        }
        public string Gender
        {
            get
            {
                return gender;
            }

            set
            {
                gender = value;
            }
        }
        public string Birthdate
        {
            get
            {
                return birthdate;
            }

            set
            {
                birthdate = value;
            }
        }
        #endregion
        
        #region Methods
        public void SetAdminPass()
        {
            password = "@dminM@x";
        }
        public void SetEmployeePass()
        {
            password = UserRepository.CheckPassword(">Ingrese la contraseña del empleado: ");
        }
        public void SetUserPass()
        {
            password = UserRepository.CheckPassword(">Ingrese su contraseña: ");
        }
        #endregion
    }
    public static class UserRepository
    {
        public static List<User> Users = new List<User>();
        public static int identity = 2;
        public static string CheckPassword(string EnterText)
        {
            Console.Write(EnterText);
            string EnteredVal = "";
            do
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                {
                    EnteredVal += key.KeyChar;
                    Console.Write("*");
                }
                else
                {
                    if (key.Key == ConsoleKey.Backspace && EnteredVal.Length > 0)
                    {
                        EnteredVal = EnteredVal.Substring(0, (EnteredVal.Length - 1));
                        Console.Write("\b \b");
                    }
                    else if (key.Key == ConsoleKey.Enter)
                    {
                        if (string.IsNullOrWhiteSpace(EnteredVal))
                        {
                            Console.WriteLine("");
                            Console.WriteLine("No puede dejar una contraseña en blanco");
                            CheckPassword(EnterText);
                            return EnteredVal;
                        }
                        else
                        {
                            Console.WriteLine("");
                            return EnteredVal;
                        }
                    }
                }
            } while (true);
        }
    }
}
