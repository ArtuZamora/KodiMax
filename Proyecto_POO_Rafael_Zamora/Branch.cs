using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_POO_Rafael_Zamora
{
    public class Branch
    {
        public string ID { get; set; }
        public string Name { get; set; }
    }
    public static class BranchData
    {
        public static List<Branch> officeBranches = new List<Branch>();
        public static int branchIdentity = 1; //BXXXX
    }
}
