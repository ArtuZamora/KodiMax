using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_POO_Rafael_Zamora
{
    public class Movie
    {
        #region Properties
        private string iD;
        private string title;
        private string duration;
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
        public string Title
        {
            get
            {
                return title;
            }

            set
            {
                title = value;
            }
        }
        public string Duration
        {
            get
            {
                return duration;
            }

            set
            {
                duration = value;
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
    public static class Billboard
    {
        public static List<Movie> list = new List<Movie>();
        public static int identity = 1;
        public static int ticketIdentity = 1;//MXXXX
    }
    public class MovieTicket
    {
        #region Properties
        public string ID { get; set; }
        public string TheatherName { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeID { get; set; }
        public DateTime Date { get; set; }
        public string MovieName { get; set; }
        public string Room{ get; set; }
        #endregion
    }
}
