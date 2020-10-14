using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_POO_Rafael_Zamora
{
    public class Products
    {
        #region Properties
        private string iD;
        private string name;
        private double price;
        private string type;
        #endregion

        #region Encapsulation
        public string ID
        {
            get
            {
                return iD;
            }

            set
            {
                iD = value;
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
        public double Price
        {
            get
            {
                return price;
            }

            set
            {
                price = value;
            }
        }
        public string Type
        {
            get
            {
                return type;
            }

            set
            {
                type = value;
            }
        }
        #endregion
    }
    public static class Store
    {
        public static List<Products> list = new List<Products>();
        public static int identity = 1;
        public static int ticketIdentity = 1;//TXXXX
    }
    public class ProductTicket
    {
        #region Properties
        public string ID { get; set; }
        public string TheatherName { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeID { get; set; }
        public DateTime Date { get; set; }
        public string ProductName { get; set; }
        #endregion
    }
}
