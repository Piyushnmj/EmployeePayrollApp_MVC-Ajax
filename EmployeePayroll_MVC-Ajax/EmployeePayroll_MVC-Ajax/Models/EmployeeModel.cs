using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace EmployeePayroll_MVC_Ajax.Models
{
    public class EmployeeModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmpID { get; set; }

        [Required(ErrorMessage = "This Field is required.")]
        public string EmpName { get; set; }

        [Required(ErrorMessage = "This Field is required.")]
        public string ProfileImg { get; set; }

        [Required(ErrorMessage = "This Field is required.")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "This Field is required.")]
        public string Department { get; set; }

        [Required(ErrorMessage = "This Field is required.")]
        public double Salary { get; set; }

        [Required(ErrorMessage = "This Field is required.")]
        public DateTime StartDate { get; set; }

        public string Notes { get; set; }
    }
}
