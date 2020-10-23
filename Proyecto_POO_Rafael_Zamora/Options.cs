using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_POO_Rafael_Zamora
{
    public static class Options
    {
        private static Int32 option;

        #region Option Classes
        public static class AdminOpt
        {
            public static void Option1()
            {
                User newEmployee = new User();
                Console.Clear();
                Console.WriteLine("--->Creación de nuevo empleado\n");
                Console.Write("\n>Ingrese el nombre del empleado: ");
                newEmployee.Name = Console.ReadLine();
                Console.Write("\n>Ingrese el apellido del empleado: ");
                newEmployee.Lastname = Console.ReadLine();
                Console.Write("\n>Ingrese el nombre de usuario del empleado: ");
                newEmployee.Username = Console.ReadLine();
                newEmployee.SetEmployeePass();
                Console.Write("\n>Ingrese el correo electrónico del empleado: ");
                newEmployee.Email = Console.ReadLine();
                Console.Write("\n>Ingrese el numero de telefono del empleado: ");
                newEmployee.Cellphone = Console.ReadLine();
                Console.Write("\n>Ingrese el género del empleado: ");
                newEmployee.Gender = Console.ReadLine();
                Console.Write("\n>Ingrese la fecha de nacimiento del empleado (dd/mm/aaaa): ");
                newEmployee.Gender = Console.ReadLine();
                newEmployee.UserID = string.Format("E{0,0:D4}", UserRepository.identity);
                UserRepository.identity++;
                newEmployee.UserType = "Empleado";
                UserRepository.Users.Add(newEmployee);
                Console.WriteLine("\n\nEmpleado agregado con éxito");
            }
            public static void Option2()
            {
                Console.Clear();
                Console.WriteLine("--->Eliminación de empleado\n");
                int eNum = 0;
                Console.WriteLine(">Lista de empleados<\n");
                foreach (User user in UserRepository.Users)
                {
                    if (Convert.ToChar(user.UserID.Substring(0, 1)) == 'E')
                    {
                        Console.WriteLine("UserID: {0} ; Username: {1} ; Nombre: {2} {3}",
                            user.UserID, user.Username, user.Name, user.Lastname);
                        eNum++;
                    }
                }
                if (eNum == 0)
                {
                    Console.WriteLine("\nNo existen empleados para eliminar.");
                }
                else
                {
                    Console.Write("\nIngrese el ID de usuario que quiere eliminar: ");
                    string idTR = Console.ReadLine();
                    if (ExistID(idTR))
                    {
                        DeleteByID(idTR);
                        Console.WriteLine("\n\nEmpleado eliminado con éxito");
                    }
                    else
                    {
                        Console.WriteLine("El ID ingresado no existe.");
                    }
                }
            }
            public static void Option3()
            {
                Console.Clear();
                Console.WriteLine("--->Eliminación de cliente\n");
                int eNum = 0;
                Console.WriteLine(">Lista de clientes<\n");
                foreach (User user in UserRepository.Users)
                {
                    if (Convert.ToChar(user.UserID.Substring(0, 1)) == 'C')
                    {
                        Console.WriteLine("UserID: {0} ; Username: {1} ; Nombre: {2} {3}",
                            user.UserID, user.Username, user.Name, user.Lastname);
                        eNum++;
                    }
                }
                if (eNum == 0)
                {
                    Console.WriteLine("\nNo existen clientes para eliminar.");
                }
                else
                {
                    Console.Write("\nIngrese el ID de usuario que quiere eliminar: ");
                    string idTR = Console.ReadLine();
                    if (ExistID(idTR))
                    {
                        DeleteByID(idTR);
                        Console.WriteLine("\n\nCliente eliminado con éxito");
                    }
                    else
                    {
                        Console.WriteLine("El ID ingresado no existe.");
                    }
                }
            }
            public static void Option4()
            {
                BillBoardModif();
            }
            public static void Option5()
            {
                StoreModif();
            }
            public static void Option6()
            {
                string JSON;
                Console.Clear();
                Console.WriteLine("--->Generación de Reportes\n");
                Console.WriteLine(" U - Reporte de Usuarios\n");
                Console.WriteLine(" C - Reporte de Peliculas\n");
                Console.WriteLine(" G - Reporte de Golosinas\n");
                Console.WriteLine(" V - Reporte de Ventas por Sucursal\n");
                Console.Write("  Ingrese opcion deseada: ");
                string opt = Console.ReadLine();
                switch (opt)
                {
                    case "U":
                        JSON = JsonConvert.SerializeObject(UserRepository.Users.ToArray());
                        if (!Directory.Exists("C:\\JSON"))
                        {
                            Directory.CreateDirectory("C:\\JSON");
                        }
                        File.WriteAllText(@"C:\\JSON\\Users.json", JSON);
                        Console.WriteLine("JSON Generado exitosamente, URL: C:\\JSON\\Users.json");
                        break;
                    case "C":
                        JSON = JsonConvert.SerializeObject(Billboard.list.ToArray());
                        if (!Directory.Exists("C:\\JSON"))
                        {
                            Directory.CreateDirectory("C:\\JSON");
                        }
                        File.WriteAllText(@"C:\\JSON\\Movies.json", JSON);
                        Console.WriteLine("JSON Generado exitosamente, URL: C:\\JSON\\Movies.json");
                        break;
                    case "G":
                        JSON = JsonConvert.SerializeObject(Store.list.ToArray());
                        if (!Directory.Exists("C:\\JSON"))
                        {
                            Directory.CreateDirectory("C:\\JSON");
                        }
                        File.WriteAllText(@"C:\\JSON\\Candies.json", JSON);
                        Console.WriteLine("JSON Generado exitosamente, URL: C:\\JSON\\Candies.json");
                        break;
                    case "V":
                        JSON = JsonConvert.SerializeObject(Program.stdRoom.tickets);
                        string JSON1 = JsonConvert.SerializeObject(Program.premRoom.tickets);
                        string JSON2 = JsonConvert.SerializeObject(Program.vipRoom.tickets);
                        string JSON3 = JsonConvert.SerializeObject(Program.driveIn.tickets);
                        if (!Directory.Exists("C:\\JSON"))
                        {
                            Directory.CreateDirectory("C:\\JSON");
                        }
                        File.WriteAllText(@"C:\\JSON\\Sells.json", JSON + "\n" + JSON1 + "\n" + JSON2 + "\n" + JSON3 + "\n");
                        Console.WriteLine("JSON Generado exitosamente, URL: C:\\JSON\\Sells.json");
                        break;
                    default:
                        Console.WriteLine("Opción no contemplada");
                        break;
                }
            }
            public static void Option7()
            {
                AddBranchOffice();
            }
            public static void Option8()
            {
                ModifyBranchOffice();
            }
            public static void Option9()
            {
                ModifyPrices();
            }
        }
        public static class ClientOpt
        {
            public static void Option1()
            {
                Console.Clear();
                Console.WriteLine("-----> Cartelera CineMax <-----\n");
                if (Billboard.list.Count != 0)
                {
                    foreach (Movie movie in Billboard.list)
                    {
                        Console.WriteLine("---------------------------------");
                        Console.WriteLine("ID Pelicula: {0}", movie.ID);
                        Console.WriteLine("Titulo de la Pelicula: {0}", movie.Title);
                        Console.WriteLine("Duración de la película: {0}", movie.Duration);
                        Console.WriteLine("Tipo de la película: {0}", movie.Type);
                        Console.WriteLine("---------------------------------");
                    }
                }
                else Console.WriteLine("No hay peliculas disponibles en este momento.");
            }
            public static void Option2()
            {
                Console.Clear();
                Console.WriteLine("-----> Golosinas CineMax <-----\n");
                if (Store.list.Count != 0)
                {
                    foreach (Products product in Store.list)
                    {
                        Console.WriteLine("---------------------------------");
                        Console.WriteLine("ID Producto: {0}", product.ID);
                        Console.WriteLine("Producto: {0}", product.Name);
                        Console.WriteLine("Precio: {0}", product.Price);
                        Console.WriteLine("Tipo de producto: {0}", product.Type);
                        Console.WriteLine("---------------------------------");
                    }
                }
                else Console.WriteLine("No hay productos disponibles en este momento.");
            }
            public static void Option3()
            {
                Console.Clear();
                Console.WriteLine("-----> Comprar Boletos <-----\n");
                Console.Write("\nIngrese el ID de la pelicula a comprar: ");
                Movie movie = ExistMovie(Console.ReadLine());
                if (movie != null)
                {
                    double subtotal = 0;
                    double total;
                    Console.WriteLine("Pelicula Elegida");
                    Console.WriteLine("---------------------------------");
                    Console.WriteLine("ID Pelicula: {0}", movie.ID);
                    Console.WriteLine("Titulo de la Pelicula: {0}", movie.Title);
                    Console.WriteLine("Duración de la película: {0}", movie.Duration);
                    Console.WriteLine("Tipo de la película: {0}", movie.Type);
                    Console.WriteLine("---------------------------------");
                    Console.WriteLine("\nSucursales: ");
                    if(BranchData.officeBranches.Count == 0)
                    {
                        Console.WriteLine("No existen sucursales disponibles en este momento.");
                        return;
                    }
                    foreach (Branch office in BranchData.officeBranches)
                    {
                        Console.WriteLine("--------------------------------");
                        Console.WriteLine("ID de la sucursal: {0}", office.ID);
                        Console.WriteLine("Nombre de la sucursal: {0}", office.Name);
                        Console.WriteLine("--------------------------------");
                    }
                    Branch selectOffice = null;
                    Console.Write("Ingrese el ID de la sucursal: ");
                BranchAgain:
                    string bID = Console.ReadLine();
                    foreach (Branch office in BranchData.officeBranches)
                    {
                        if(office.ID == bID)
                        {
                            selectOffice = office;
                            break;
                        }
                    }
                    if(selectOffice == null)
                    {
                        Console.WriteLine("Sucursal no encontrada. Ingrese nuevamente el ID: ");
                        goto BranchAgain;
                    }
                    Console.WriteLine("\nSalas de exhibición:");
                    Console.WriteLine(" 1 - Estándar\n");
                    Console.WriteLine(" 2 - Premium\n");
                    Console.WriteLine(" 3 - VIP\n");
                    Console.WriteLine(" 4 - Autocine\n");
                    Console.Write("\nIngrese una opcion deseada: ");
                    do
                    {
                        validateOption();
                        if (option < 1 || option > 4)
                        {
                            Console.WriteLine("Ingrese una opcion correcta: ");
                        }
                    } while (option < 1 || option > 4);
                    Console.Write("\nIngrese la cantidad de boletos a comprar: ");
                    int numOfTickets;
                    do
                    {
                        while (!Int32.TryParse(Console.ReadLine(), out numOfTickets))
                        {
                            Console.Write("\nIngrese una cantidad válida: ");
                        }
                        if (numOfTickets <= 0)
                        {
                            Console.Write("\nDebe ingresar una cantidad mayor a 0: ");
                        }
                    } while (numOfTickets <= 0);
                    bool space = true;
                    Rooms room = null;
                    switch (option)
                    {
                        case 1:
                            room = Program.stdRoom;
                            break;
                        case 2:
                            room = Program.premRoom;
                            break;
                        case 3:
                            room = Program.vipRoom;
                            break;
                        case 4:
                            room = Program.driveIn;
                            break;
                    }
                    if (option != 4) space = room.ValidateSpaces(numOfTickets);
                    else space = true;
                    if (space)
                    {
                        MovieTicket ticket = new MovieTicket();
                        ticket.ID = string.Format("T{0,0:D4}", Billboard.ticketIdentity);
                        Billboard.ticketIdentity++;
                        ticket.MovieName = movie.Title;
                        ticket.TheatherName = "KODI-MAX";
                        ticket.Room = room;
                        subtotal = room.Price * numOfTickets;
                        ticket.Date = DateTime.Now;
                        ticket.branch = selectOffice;
                        Random rdn = new Random();
                        int countEmployees = 0;
                        foreach (User user in UserRepository.Users)
                        {
                            if (Convert.ToChar(user.UserID.Substring(0, 1)) == 'E')
                            {
                                countEmployees++;
                            }
                        }
                        if (countEmployees == 0)
                        {
                            ticket.EmployeeID = "V0000";
                            ticket.EmployeeName = "Empleado Virtual";
                        }
                        else
                        {
                            int random = rdn.Next(1, countEmployees + 1);
                            int countToSelect = 0;
                            foreach (User user in UserRepository.Users)
                            {
                                if (Convert.ToChar(user.UserID.Substring(0, 1)) == 'E')
                                {
                                    countToSelect++;
                                    if (countToSelect == random)
                                    {
                                        ticket.EmployeeID = user.UserID;
                                        ticket.EmployeeName = user.Name;
                                        break;
                                    }
                                }
                            }
                        }
                        for (int i = 0; i < numOfTickets; i++)
                        {
                            room.AddTicket(ticket);
                        }
                        double tax = Math.Round(subtotal * 0.3533, 2);
                        double optPayment = 0;
                        total = Math.Round(subtotal + tax, 2);
                        Console.WriteLine("\n\n>Impresión del ticket<");
                        Console.WriteLine("------------------------------------------------------------------");
                        Console.WriteLine("Nombre del cine: {0}", ticket.TheatherName);
                        Console.WriteLine("Nombre del empleado que lo atendió: {0}", ticket.EmployeeName);
                        Console.WriteLine("ID del empleado que lo atendió: {0}", ticket.EmployeeID);
                        Console.WriteLine("Fecha y hora de compra: {0}", ticket.Date);
                        Console.WriteLine("Nombre de la pelicula: {0}", ticket.MovieName);
                        Console.WriteLine("Nombre de la sucursal: {0}", ticket.branch.Name);
                        if (option == 4)
                        {
                            Console.WriteLine("Modalidad: Autocine");
                            Console.WriteLine("Precio de parqueo: $1.50");
                            optPayment = 1.50;
                        }
                        else
                        {
                            Console.WriteLine("Modalidad: Sala normal");
                            Console.WriteLine("Sala: {0}", ticket.Room.Name);
                            Console.WriteLine("Asientos: {0}", room.PrintSeats(ticket));
                        }
                        Console.WriteLine("Subtotal: ${0}", Math.Round(subtotal, 2) + optPayment);
                        Console.WriteLine("Impuesto aplicado (35.33%): ${0}", tax);
                        Console.WriteLine("Total: ${0}", total);
                        Console.WriteLine("------------------------------------------------------------------");
                    Again:
                        Console.Write("\n\nIngrese el efectivo: $");
                        double payment;
                        do
                        {
                            while (!Double.TryParse(Console.ReadLine(), out payment))
                            {
                                Console.Write("Ingrese una cantidad válida: $");
                            }
                            if (payment < 0)
                            {
                                Console.Write("Ingrese una cantidad válida: $");
                            }
                        } while (payment < 0);

                        if (payment == total)
                        {
                            Console.WriteLine("Cobro exacto, gracias por comprar en KODIMAX.");
                        }
                        else if (payment > total)
                        {
                            Console.WriteLine("Su cambio es ${0}, gracias por comprar en KODIMAX", Math.Round(payment - total, 2));
                        }
                        else
                        {
                            Console.WriteLine("Pago insuficiente");
                            goto Again;
                        }
                    }
                    else Console.WriteLine("\nNo hay espacio suficiente en la sala para efectuar su compra.");
                }
                else Console.WriteLine("El ID de pelicula ingresado no existe");
            }
            public static void Option4()
            {
                Console.Clear();
                Console.WriteLine("-----> Comprar Golosinas <-----\n");
                Console.Write("\nIngrese el ID del producto a comprar: ");
                Products product = ExistProduct(Console.ReadLine());
                if (product != null)
                {
                    Console.WriteLine("\nProducto Elegido");
                    Console.WriteLine("---------------------------------");
                    Console.WriteLine("ID Producto: {0}", product.ID);
                    Console.WriteLine("Producto: {0}", product.Name);
                    Console.WriteLine("Precio: {0}", product.Price);
                    Console.WriteLine("Tipo de producto: {0}", product.Type);
                    Console.WriteLine("---------------------------------");
                    Console.Write("\nIngrese la cantidad de producto a comprar: ");
                    int numOfProducts;
                    do
                    {
                        while (!Int32.TryParse(Console.ReadLine(), out numOfProducts))
                        {
                            Console.Write("\nIngrese una cantidad válida: ");
                        }
                        if (numOfProducts <= 0)
                        {
                            Console.Write("\nDebe ingresar una cantidad mayor a 0: ");
                        }
                    } while (numOfProducts <= 0);
                    ProductTicket ticket = new ProductTicket();
                    ticket.ID = string.Format("S{0,0:D4}", Store.ticketIdentity);
                    Store.ticketIdentity++;
                    ticket.TheatherName = "KODI-MAX";
                    ticket.ProductName = product.Name;
                    ticket.Date = DateTime.Now;
                    Random rdn = new Random();
                    int countEmployees = 0;
                    foreach (User user in UserRepository.Users)
                    {
                        if (Convert.ToChar(user.UserID.Substring(0, 1)) == 'E')
                        {
                            countEmployees++;
                        }
                    }
                    if (countEmployees == 0)
                    {
                        ticket.EmployeeID = "V0000";
                        ticket.EmployeeName = "Empleado Virtual";
                    }
                    else
                    {
                        int random = rdn.Next(1, countEmployees + 1);
                        int countToSelect = 0;
                        foreach (User user in UserRepository.Users)
                        {
                            if (Convert.ToChar(user.UserID.Substring(0, 1)) == 'E')
                            {
                                countToSelect++;
                                if (countToSelect == random)
                                {
                                    ticket.EmployeeID = user.UserID;
                                    ticket.EmployeeName = user.Name;
                                    break;
                                }
                            }

                        }
                    }
                    double subtotal = product.Price * numOfProducts;
                    double tax = subtotal * 0.0453;
                    double total = subtotal + tax;
                    Console.WriteLine("\n\n>Impresión del ticket<");
                    Console.WriteLine("------------------------------------------------------------------");
                    Console.WriteLine("Nombre del cine: {0}", ticket.TheatherName);
                    Console.WriteLine("Nombre del empleado que lo atendió: {0}", ticket.EmployeeName);
                    Console.WriteLine("ID del empleado que lo atendió: {0}", ticket.EmployeeID);
                    Console.WriteLine("Fecha y hora de compra: {0}", ticket.Date);
                    Console.WriteLine("Nombre del producto: {0}", ticket.ProductName);
                    Console.WriteLine("Precio del producto: ${0}", product.Price);
                    Console.WriteLine("Subtotal: ${0}", Math.Round(subtotal, 2));
                    Console.WriteLine("Impuesto aplicado (4.53%): ${0}", Math.Round(tax, 2));
                    Console.WriteLine("Total: ${0}", Math.Round(total, 2));
                    Console.WriteLine("------------------------------------------------------------------");
                Again:
                    Console.Write("\n\nIngrese el efectivo: $");
                    double payment;
                    do
                    {
                        while (!Double.TryParse(Console.ReadLine(), out payment))
                        {
                            Console.Write("Ingrese una cantidad válida: $");
                        }
                        if (payment < 0)
                        {
                            Console.Write("Ingrese una cantidad válida: $");
                        }
                    } while (payment < 0);

                    if (payment == total)
                    {
                        Console.WriteLine("Cobro exacto, gracias por comprar en KODIMAX.");
                    }
                    else if (payment > total)
                    {
                        Console.WriteLine("Su cambio es ${0}, gracias por comprar en KODIMAX", Math.Round(payment - total, 2));
                    }
                    else
                    {
                        Console.WriteLine("Pago insuficiente");
                        goto Again;
                    }
                }
                else
                {
                    Console.WriteLine("\nEl producto indicado no existe");
                }
            }
            public static void Option5()
            {
                Console.Clear();
                Console.WriteLine("-----> Sucursales KodiMax <-----\n");
                if (BranchData.officeBranches.Count != 0)
                {
                    foreach (Branch office in BranchData.officeBranches)
                    {
                        Console.WriteLine("--------------------------------");
                        Console.WriteLine("ID de la sucursal: {0}", office.ID);
                        Console.WriteLine("Nombre de la sucursal: {0}", office.Name);
                        Console.WriteLine("--------------------------------");
                    }
                }
                else Console.WriteLine("No hay sucursales disponibles en este momento.");
            }
        }
        public static class EmployeeOpt
        {
            public static void Option1()
            {
                BillBoardModif();
            }
            public static void Option2()
            {
                StoreModif();
            }
            public static void Option3()
            {
                AddBranchOffice();
            }
            public static void Option4()
            {
                ModifyBranchOffice();
            }
            public static void Option5()
            {
                ModifyPrices();
            }
        }
        #endregion

        #region Data Manipulation
        private static void BillBoardModif()
        {
            Console.Clear();
            Console.WriteLine("--->Cartelera de peliculas\n");
            Console.WriteLine(" 1 - Agregar Pelicula\n");
            Console.WriteLine(" 2 - Eliminar Pelicula\n");
            Console.WriteLine(" 3 - Modificar la sala de exhibición\n");
            Console.Write("   Ingrese opcion deseada: ");
            do
            {
                validateOption();
                if (option < 1 || option > 3)
                {
                    Console.WriteLine("Ingrese una opcion correcta: ");
                }
            } while (option != 1 && option != 2 && option != 3);
            switch (option)
            {
                case 1:
                    AddMovie();
                    break;
                case 2:
                    DeleteMovie();
                    break;
                case 3:
                    ModifyExRoom();
                    break;
            }
        }
        private static void AddMovie()
        {
            Console.Clear();
            Movie newMovie = new Movie();
            Console.WriteLine("---> Agregar pelicula\n");
            Console.Write("Ingrese el nombre de la pelicula: ");
            newMovie.Title = Console.ReadLine();
            Console.Write("Ingrese el tipo de pelicula: ");
            newMovie.Type = Console.ReadLine();
            Console.Write("Ingrese la duracion de la pelicula (hh:mm) : ");
            newMovie.Duration = Console.ReadLine();
            newMovie.ID = string.Format("M{0,0:D4}", Billboard.identity);
            Billboard.identity++;
            Billboard.list.Add(newMovie);
            Console.WriteLine("\nPelicula ingresada existosamente!");
        }
        private static void DeleteMovie()
        {

            Console.Clear();
            Console.WriteLine("---> Eliminar pelicula\n");
            Console.WriteLine("Peliculas existentes: ");
            foreach (Movie movie in Billboard.list)
            {
                Console.WriteLine("---------------------------------");
                Console.WriteLine("ID Pelicula: {0}", movie.ID);
                Console.WriteLine("Titulo de la Pelicula: {0}", movie.Title);
                Console.WriteLine("Duración de la película: {0}", movie.Duration);
                Console.WriteLine("Tipo de la película: {0}", movie.Type);
                Console.WriteLine("---------------------------------");
            }
            if (Billboard.list.Count == 0)
            {
                Console.WriteLine(">No existen peliculas para eliminar");
            }
            else
            {
                Console.Write("Ingrese el ID de la pelicula a eliminar: ");
                Movie movieToD = ExistMovie(Console.ReadLine());
                if (movieToD != null)
                {
                    Billboard.list.Remove(movieToD);
                    Console.WriteLine("La pelicula ha sido eliminada!");
                }
                else
                {
                    Console.WriteLine("La pelicula indicada no existe");
                }
            }
        }
        private static void ModifyExRoom()
        {
            Console.Clear();
            Console.WriteLine("---> Modificar Sala de exhibiciones\n");
            Console.WriteLine("\n 1 - Sala Estándar");
            Console.WriteLine("\n 2 - Sala Premium");
            Console.WriteLine("\n 3 - Sala VIP");
            Console.Write("\n Ingrese la sala que quiere modificar: ");
            do
            {
                validateOption();
                if (option < 1 || option > 3)
                {
                    Console.Write("\nDebe ingresar una opcion correcta: ");
                }
            } while (option != 1 && option != 2 && option != 3);
            Rooms room = null;
            switch (option)
            {
                case 1:
                    room = Program.stdRoom;
                    Console.Clear();
                    Console.WriteLine("---> Modificar Sala Estándar\n");
                    break;
                case 2:
                    room = Program.premRoom;
                    Console.Clear();
                    Console.WriteLine("---> Modificar Sala Premium\n");
                    break;
                case 3:
                    room = Program.vipRoom;
                    Console.Clear();
                    Console.WriteLine("---> Modificar Sala VIP\n");
                    break;
            }
            Console.WriteLine("\nA ---> Modificar Precio");
            Console.WriteLine("\nB ---> Limpiar Sala");
            Console.Write("\nElija opcion deseada: ");
            string opt = Console.ReadLine();
            while (opt != "A" && opt != "B" && opt != "a" && opt != "b")
            {
                Console.Write("\nElija una opción correcta: ");
                opt = Console.ReadLine();
            }
            if (opt == "A" || opt == "a")
            {
                Console.Write("\n\nIngresa el nuevo precio de la sala: $");
                double newPrice = 0;
                do
                {
                    while (!Double.TryParse(Console.ReadLine(), out newPrice))
                    {
                        Console.Write("\nPrecio incorrecto, ingrese un nuevo precio: $");
                    }
                    if (newPrice < 0)
                    {
                        Console.Write("\nPrecio incorrecto, ingrese un nuevo precio: $");
                    }
                } while (newPrice < 0);
                room.Price = newPrice;
                Console.WriteLine("\nPrecio actualizado exitosamente!");
            }
            else
            {
                Console.WriteLine("\n\n¿Está seguro de que quiere borrar todos los tickets de la sala?");
                Console.WriteLine(" Ingrese Y para sí o cualquier otra cosa para No");
                string opt2 = "";
                opt2 = Console.ReadLine();
                if (opt2 == "Y" || opt2 == "y")
                {
                    room.ClearRoom();
                    Console.WriteLine("\nSala limpiada exitosamente!");
                }
                else
                {
                    Console.WriteLine("\nOperación abortada");
                }
            }
        }
        private static void DeleteByID(string ID)
        {
            foreach (User user in UserRepository.Users)
            {
                if (user.UserID == ID)
                {
                    UserRepository.Users.Remove(user);
                    break;
                }
            }
        }
        private static void StoreModif()
        {
            Console.Clear();
            Console.WriteLine("--->Tienda de golosinas\n");
            Console.WriteLine(" 1 - Agregar golosinas\n");
            Console.WriteLine(" 2 - Eliminar golosinas\n");
            Console.WriteLine(" 3 - Modificar golosinas\n");
            Console.Write("   Ingrese opcion deseada: ");
            do
            {
                validateOption();
                if (option < 1 || option > 3)
                {
                    Console.WriteLine("Ingrese una opcion correcta: ");
                }
            } while (option != 1 && option != 2 && option != 3);
            switch (option)
            {
                case 1:
                    AddProduct();
                    break;
                case 2:
                    DeleteProduct();
                    break;
                case 3:
                    ModifyProduct();
                    break;
            }
        }
        private static void AddProduct()
        {
            Console.Clear();
            double price;
            Products newProduct = new Products();
            Console.WriteLine("---> Agregar producto a la tienda\n");
            Console.Write("Ingrese el nombre del producto: ");
            newProduct.Name = Console.ReadLine();
            Console.Write("Ingrese el tipo del producto: ");
            newProduct.Type = Console.ReadLine();
            Console.Write("Ingrese el precio del producto: ");
            do
            {
                while (!Double.TryParse(Console.ReadLine(), out price))
                {
                    Console.WriteLine("Precio inválido, ingrese de nuevo: ");
                }
                if (price < 0)
                {
                    Console.WriteLine("Precio inválido, ingrese de nuevo: ");
                }
            } while (price < 0);
            newProduct.Price = price;
            newProduct.ID = string.Format("P{0,0:D4}", Store.identity);
            Store.identity++;
            Store.list.Add(newProduct);
            Console.WriteLine("\nProducto ingresado existosamente!");
        }
        private static void DeleteProduct()
        {
            Console.Clear();
            Console.WriteLine("---> Eliminar producto de la tienda\n");
            Console.WriteLine("Productos existentes: ");
            foreach (Products product in Store.list)
            {
                Console.WriteLine("--------------------------------");
                Console.WriteLine("ID de producto: {0}", product.ID);
                Console.WriteLine("Nombre del producto: {0}", product.Name);
                Console.WriteLine("Precio del producto: {0}", product.Price);
                Console.WriteLine("Tipo de producto: {0}", product.Type);
                Console.WriteLine("--------------------------------");
            }
            if (Store.list.Count == 0)
            {
                Console.WriteLine(">No existen productos para eliminar");
            }
            else
            {
                Console.Write("Ingrese el ID del producto a eliminar: ");
                Products productToE = ExistProduct(Console.ReadLine());
                if (productToE != null)
                {
                    Store.list.Remove(productToE);
                    Console.WriteLine("El producto ha sido eliminado!");
                }
                else
                {
                    Console.WriteLine("El producto indicado no existe");
                }
            }
        }
        private static void ModifyProduct()
        {

            Console.Clear();
            Console.WriteLine("---> Modificar producto de la tienda\n");
            Console.WriteLine("Productos existentes: ");
            foreach (Products product in Store.list)
            {
                Console.WriteLine("--------------------------------");
                Console.WriteLine("ID de producto: {0}", product.ID);
                Console.WriteLine("Nombre del producto: {0}", product.Name);
                Console.WriteLine("Precio del producto: {0}", product.Price);
                Console.WriteLine("Tipo de producto: {0}", product.Type);
                Console.WriteLine("--------------------------------");
            }
            if (Store.list.Count == 0)
            {
                Console.WriteLine(">No existen productos para modificar");
            }
            else
            {
                Console.Write("Ingrese el ID del producto a modificar: ");
                Products productToM = ExistProduct(Console.ReadLine());
                if (productToM != null)
                {
                    Console.WriteLine("\n 1 - Modificar precio");
                    Console.WriteLine("\n 2 - Modificar tipo");
                    Console.Write("  Ingrese opcion deseada: ");
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
                        Console.Write("\n\nIngrese el nuevo precio: ");
                        double price;
                        do
                        {
                            while (!Double.TryParse(Console.ReadLine(), out price))
                            {
                                Console.WriteLine("Precio inválido, ingrese de nuevo: ");
                            }
                            if (price < 0)
                            {
                                Console.WriteLine("Precio inválido, ingrese de nuevo: ");
                            }
                        } while (price < 0);
                        productToM.Price = price;
                    }
                    else
                    {
                        Console.Write("\n\nIngrese el nuevo tipo: ");
                        productToM.Type = Console.ReadLine();
                    }
                    Console.WriteLine("\n¡Producto modificado exitosamente!");
                }
                else
                {
                    Console.WriteLine("El producto indicado no existe");
                }
            }
        }
        private static void AddBranchOffice()
        {
            Console.Clear();
            Branch newBranchOffice = new Branch();
            Console.WriteLine("---> Agregar nueva sucursal\n");
            Console.Write("Ingrese el nombre de la sucursal: ");
            newBranchOffice.Name = Console.ReadLine();
            newBranchOffice.ID = string.Format("B{0,0:D4}", BranchData.branchIdentity);
            BranchData.branchIdentity++;
            BranchData.officeBranches.Add(newBranchOffice);
            Console.WriteLine("\nSucursal agregada existosamente!");
        }
        private static void ModifyBranchOffice()
        {
            Console.Clear();
            Console.WriteLine("---> Modificar sucursales\n");
            Console.WriteLine("Sucursales existentes: ");
            foreach (Branch office in BranchData.officeBranches)
            {
                Console.WriteLine("--------------------------------");
                Console.WriteLine("ID de la sucursal: {0}", office.ID);
                Console.WriteLine("Nombre de la sucursal: {0}", office.Name);
                Console.WriteLine("--------------------------------");
            }
            if (BranchData.officeBranches.Count == 0)
            {
                Console.WriteLine(">No existen sucursales para modificar");
            }
            else
            {
                Console.Write("Ingrese el ID de la sucursal a modifcar: ");
                Branch officetoM = ExistsOffice(Console.ReadLine());
                if (officetoM != null)
                {
                    Console.WriteLine("Ingrese el nuevo nombre de la sucursal: ");
                    officetoM.Name = Console.ReadLine();
                    Console.WriteLine("\n\nSucursal modificada existosamente!");
                }
                else
                {
                    Console.WriteLine("El producto indicado no existe");
                }
            }
        }
        private static void ModifyPrices()
        {
            Console.Clear();
            Console.WriteLine("---> Modificar precio de autocine\n");
            Console.WriteLine("Precio actual: $" + Program.driveIn.Price);
            Console.Write("\nIngrese el nuevo precio: $");
            double price;
            do
            {
                while (!Double.TryParse(Console.ReadLine(), out price))
                {
                    Console.WriteLine("\nPrecio inválido, ingrese de nuevo: $");
                }
                if (price < Program.premRoom.Price)
                {
                    Console.WriteLine("\nPrecio inválido (debe ser mayor a la de la sala mas cara), ingrese de nuevo: $");
                }
            } while (price < Program.premRoom.Price);
            Program.driveIn.Price = price;
            Console.WriteLine("\n\nPrecio modificado exitosamente!");
        }
        #endregion

        #region Data Verification/Validation
        private static bool ExistID(string ID)
        {
            foreach (User users in UserRepository.Users)
            {
                if (users.UserID == ID)
                {
                    return true;
                }
            }
            return false;
        }
        private static Movie ExistMovie(string ID)
        {
            foreach (Movie movie in Billboard.list)
            {
                if (ID == movie.ID)
                {
                    return movie;
                }
            }
            return null;
        }
        private static Products ExistProduct(string ID)
        {
            foreach (Products product in Store.list)
            {
                if(ID == product.ID)
                {
                    return product;
                }
            }
            return null;
        }
        private static Branch ExistsOffice(string ID)
        {
            foreach (Branch office in BranchData.officeBranches)
            {
                if (ID == office.ID)
                {
                    return office;
                }
            }
            return null;
        }
        private static void validateOption()
        {
            while (!Int32.TryParse(Console.ReadLine(), out option))
            {
                Console.WriteLine("   ¡Opcion ingresada inválida!\n");
                Console.Write("   Ingrese opción deseada: ");
            }
        }
        #endregion
    }
}
