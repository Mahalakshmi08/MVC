using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
#nullable disable

namespace MVCDB1.Models
{
    public partial class Dept
    {
        public Dept()
        {
            Emps = new HashSet<Emp>();
        }
        [Required(ErrorMessage = "Id is required")]
        [Display (Name = "Department Code")]

        public int Id { get; set; }
        [Required(ErrorMessage = "Name cannot be Blank")]
        [Display(Name = "Department Name")]
        public string Name { get; set; }
        [Display(Name = "Location")]
        [StringLength(25,ErrorMessage ="3 Chars",MinimumLength =3)]

        public string Location { get; set; }

        public virtual ICollection<Emp> Emps { get; set; }


    }
}
