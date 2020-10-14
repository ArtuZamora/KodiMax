using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_POO_Rafael_Zamora
{
    public static class Menu
    {
        private static StringBuilder str = new StringBuilder();
        private static StringBuilder str1 = new StringBuilder();
        private static StringBuilder str2 = new StringBuilder();
        public static void SetMenus()
        {
            str.Append("++++++++++++ MENU SUPER USUARIO ++++++++++++\n");
            str.Append("    1- Crear nuevo empleado\n\n");
            str.Append("    2- Eliminar empleado\n\n");
            str.Append("    3- Eliminar cliente\n\n");
            str.Append("    4- Modificar Cartelera\n\n");
            str.Append("    5- Modificar Tienda de Golosinas\n\n");
            str.Append("    6- Generar Reportes\n\n");
            str.Append("    7- Cerrar sesión\n\n");
            str.Append("   Ingrese opción deseada: ");

            str1.Append("++++++++++++ MENU EMPLEADO ++++++++++++\n");
            str1.Append("    1- Modificar Cartelera\n\n");
            str1.Append("    2- Modificar Tienda de Golosinas\n\n");
            str1.Append("    3- Cerrar sesión\n\n");
            str1.Append("   Ingrese opción deseada: ");

            str2.Append("++++++++++++ MENU CLIENTE ++++++++++++\n");
            str2.Append("    1- Ver Cartelera\n\n");
            str2.Append("    2- Ver tienda de golosinas\n\n");
            str2.Append("    3- Comprar boletos\n\n");
            str2.Append("    4- Comprar golosinas\n\n");
            str2.Append("    5- Cerrar sesión\n\n");
            str2.Append("   Ingrese opción deseada: ");
        }
        public static void SuperUser()
        {
            Console.Clear();
            Console.Write(str);
        }
        public static void Employee()
        {
            Console.Clear();
            Console.Write(str1);
        }
        public static void Client()
        {
            Console.Clear();
            Console.Write(str2);
        }
    }
}
