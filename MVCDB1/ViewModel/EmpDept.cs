using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCDB1.Models;



namespace MVCDB1.ViewModel
{
    public class EmpDept
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DeptName { get; set; }
        public string Location { get; set; }    
        public int? Salary { get; set; }
        public int Bonus { get; set; }
    }
}
