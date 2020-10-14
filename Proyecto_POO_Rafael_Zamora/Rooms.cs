using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_POO_Rafael_Zamora
{
    public abstract class Rooms
    {
        #region Properties
        public int Columns { get; set; }
        public int Rows { get; set; }
        public int ActualColumn { get; set; }
        public int ActualRow { get; set; }
        public double Price { get; set; }

        public MovieTicket[,] tickets;
        #endregion

        #region Methods
        public bool ValidateSpaces(int spaces)
        {
            if(spaces <= ((Columns - ActualColumn) * (Rows - ActualRow)))
            {
                return true;
            }
            return false;
        }
        public void AddTicket(MovieTicket ticket)
        {
            tickets[ActualRow, ActualColumn] = ticket;
            ActualColumn++;
            if(ActualColumn == Columns)
            {
                ActualColumn = 0;
                ActualRow++;
            }
        }
        public string PrintSeats(MovieTicket ticket)
        {
            StringBuilder str = new StringBuilder();
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    if (tickets[i, j] == ticket)
                    {
                        str.Append(string.Format("{0}-{1} ", Program.AbecedaryRepo[j], i + 1));
                    }
                }
            }
            return str.ToString();
        }
        public void ClearRoom()
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    tickets[i, j] = null;
                }
            }
            ActualColumn = 0;
            ActualRow = 0;
        }
        #endregion
    }
    public class Standard : Rooms
    {
        #region Constructor
        public Standard()
        {
            Columns = 8;
            Rows = 8;
            tickets = new MovieTicket[Rows, Columns];
            ActualColumn = 0;
            ActualRow = 0;
            Price = 3.55;
        }
        #endregion
    }
    public class Premium : Rooms
    {
        #region Constructor
        public Premium()
        {
            Columns = 8;
            Rows = 5;
            tickets = new MovieTicket[Rows, Columns];
            ActualColumn = 0;
            ActualRow = 0;
            Price = 3.55;
            Price = 4.75;
        }
        #endregion
    }
    public class VIP : Rooms
    {
        #region Constructor
        public VIP()
        {
            Columns = 6;
            Rows = 5;
            tickets = new MovieTicket[Rows, Columns];
            ActualColumn = 0;
            ActualRow = 0;
            Price = 3.55;
            Price = 6.50;
        }
        #endregion
    }
}
