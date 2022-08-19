using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
#nullable disable

namespace MVCDB1.Models
{
    public partial class Emp
    {
        [Display(Name = "Emp Code")]
        public int Id { get; set; }

        [Display (Name="Emp Name")]
        [Required(ErrorMessage ="Name cannot be blank")]
        public string Name { get; set; }

        [Display(Name = "Salary")]
        [Range(10000,90000,ErrorMessage = "Salary must be within 10000 and 90000")]
        public int? Salary { get; set; }

        [Display(Name="Department")]
        public int? Deptid { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode =true,DataFormatString ="{0:yyyy-MM-dd}")] //this is the format understood by majority of the browsers

        public DateTime? Dob { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public virtual Dept Dept { get; set; }
    }
}
