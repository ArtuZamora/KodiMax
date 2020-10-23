using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;


namespace Proyecto_POO_Rafael_Zamora
{
    class Program
    {
        #region Properties
        private static Int32 option;
        public static Rooms stdRoom = new Standard();
        public static Rooms premRoom = new Premium();
        public static Rooms vipRoom = new VIP();
        public static Rooms driveIn = new DriveIn();
        public static string[] AbecedaryRepo = new string[8] { "A", "B", "C", "D", "E", "F", "G", "H" };
        #endregion

        #region Main
        static void Main(string[] args)
        {
            Menu.SetMenus();
            SetAdmin(); 
        Login:
            char userType = ShowLogin();
        Home:
            switch (userType)
            {
                case 'S':  //SuperUser
                    Menu.SuperUser();
                    do
                    {
                        validateOption();
                        if(option < 1 || option > 10)
                        {
                            Console.WriteLine("Ingrese una opcion correcta: ");
                        }
                    } while (option < 1 || option > 10);
                    if (option != 10)
                    {
                        AdminOptions();
                        Console.WriteLine(">Presione una tecla para continuar<");
                        Console.ReadKey();
                        goto Home;
                    }
                    else goto Login;
                case 'C':  //Client
                    Menu.Client();
                    do
                    {
                        validateOption();
                        if (option < 1 || option > 6)
                        {
                            Console.WriteLine("Ingrese una opcion correcta: ");
                        }
                    } while (option < 1 || option > 6);
                    if (option != 6)
                    {
                        ClientOptions();
                        Console.WriteLine(">Presione una tecla para continuar<");
                        Console.ReadKey();
                        goto Home;
                    }
                    else goto Login;
                case 'E':  //Employee
                    Menu.Employee();
                    do
                    {
                        validateOption();
                        if (option < 1 || option > 6)
                        {
                            Console.WriteLine("Ingrese una opcion correcta: ");
                        }
                    } while (option < 1 || option > 6);
                    if (option != 6)
                    {
                        EmployeeOptions();
                        Console.WriteLine(">Presione una tecla para continuar<");
                        Console.ReadKey();
                        goto Home;
                    }
                    else goto Login;
            }
            Console.ReadKey();
        }
        #endregion

        #region Options
        private static char ShowLogin()
        {
            Console.Clear();
            Console.WriteLine("------ BIENVENIDO A CINEMAX ------");
            Console.WriteLine("Ingrese sus datos para continuar... \n");
            Console.Write("Usuario: ");
            string username = Console.ReadLine();
            string password = UserRepository.CheckPassword("Contraseña: ");
            User user = ValidateUser(username, password);
            if (user != null)
            {
                return Convert.ToChar(user.UserID.Substring(0, 1));
            }
            else
            {
                Console.WriteLine("\n¡Usuario y/o contraseña incorrectos!");
                Console.WriteLine("¿Deseas registrarte? Sí (1), No (2)");
                do
                {
                    validateOption();
                    if (option < 1 || option > 2)
                    {
                        Console.WriteLine("Ingrese una opcion correcta: ");
                    }
                } while (option != 1 && option != 2);
                if (option == 1)
                {
                    Register();
                }
                return ShowLogin();
            }
        }
        private static void AdminOptions()
        {
            switch (option)
            {
                case 1:
                    Options.AdminOpt.Option1();
                    break;
                case 2:
                    Options.AdminOpt.Option2();
                    break;
                case 3:
                    Options.AdminOpt.Option3();
                    break;
                case 4:
                    Options.AdminOpt.Option4();
                    break;
                case 5:
                    Options.AdminOpt.Option5();
                    break;
                case 6:
                    Options.AdminOpt.Option6();
                    break;
                case 7:
                    Options.AdminOpt.Option7();
                    break;
                case 8:
                    Options.AdminOpt.Option8();
                    break;
                case 9:
                    Options.AdminOpt.Option9();
                    break;
            }
        }
        private static void ClientOptions()
        {
            switch (option)
            {
                case 1:
                    Options.ClientOpt.Option1();
                    break;
                case 2:
                    Options.ClientOpt.Option2();
                    break;
                case 3:
                    Options.ClientOpt.Option3();
                    break;
                case 4:
                    Options.ClientOpt.Option4();
                    break;
                case 5:
                    Options.ClientOpt.Option5();
                    break;
            }
        }
        private static void EmployeeOptions()
        {
            switch (option)
            {
                case 1:
                    Options.EmployeeOpt.Option1();
                    break;
                case 2:
                    Options.EmployeeOpt.Option2();
                    break;
                case 3:
                    Options.EmployeeOpt.Option3();
                    break;
                case 4:
                    Options.EmployeeOpt.Option4();
                    break;
                case 5:
                    Options.EmployeeOpt.Option5();
                    break;
            }
        }
        #endregion

        #region Data Validation
        static void validateOption()
        {
            while (!Int32.TryParse(Console.ReadLine(), out option))
            {
                Console.WriteLine("   ¡Opcion ingresada inválida!\n");
                Console.Write("   Ingrese opción deseada: ");
            }
        }
        static User ValidateUser(string username, string pass)
        {
            foreach (User user in UserRepository.Users)
            {
                if (username == user.Username && pass == user.Password)
                {
                    return user;
                }
            }
            return null;
        }
        #endregion

        #region Data Manipulation
        private static void SetAdmin()
        {
            User newUser = new User();
            newUser.UserID = "S0001";
            newUser.Username = "admin-max";
            newUser.SetAdminPass();
            newUser.Name = "Super";
            newUser.Name = "Admin";
            newUser.UserType = "Administrador";
            UserRepository.Users.Add(newUser); 
        }
        private static void Register()
        {
            User newUser = new User();
            Console.Clear();
            Console.WriteLine("--->Creación de nuevo usuario\n");
            Console.Write("\n>Ingrese su nombre: ");
            newUser.Name = Console.ReadLine();
            Console.Write("\n>Ingrese su apellido: ");
            newUser.Lastname = Console.ReadLine();
            Console.Write("\n>Ingrese su nombre de usuario: ");
            newUser.Username = Console.ReadLine();
            newUser.SetUserPass();
            Console.Write("\n>Ingrese su correo electrónico: ");
            newUser.Email = Console.ReadLine();
            Console.Write("\n>Ingrese su numero de telefono: ");
            newUser.Cellphone = Console.ReadLine();
            Console.Write("\n>Ingrese su género: ");
            newUser.Gender = Console.ReadLine();
            Console.Write("\n>Ingrese su fecha de nacimiento (dd/mm/aaaa): ");
            newUser.Gender = Console.ReadLine();
            Console.Write("\n>Ingrese el ID de la empresa (si no se posee, ingrese 0): ");
            string ID = Console.ReadLine();
            if(ID == "1234567890")
            {
                newUser.UserID = string.Format("E{0,0:D4}", UserRepository.identity);
                UserRepository.identity++;
                newUser.UserType = "Empleado";
            }
            else
            {
                newUser.UserID = string.Format("C{0,0:D4}", UserRepository.identity);
                UserRepository.identity++;
                newUser.UserType = "Cliente";
            }
            UserRepository.Users.Add(newUser);
            Console.WriteLine("\n\nSe ha registrado agregado con éxito");
        }
        #endregion
    }
}
