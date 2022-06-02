using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SICPASystem.Models
{
    public class Department_EmployeeModel
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Created by")]
        public string created_by { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Created date")]
        public DateTime created_date { get; set; }

        [Display(Name = "Modified by")]
        public string modified_by { get; set; }

        [Display(Name = "Modified date")]
        [DataType(DataType.Date)]
        public DateTime modified_date { get; set; }

        [Required(ErrorMessage = "Status is required")]
        [Display(Name = "Status")]
        public bool status { get; set; }

        [Required]
        [Display(Name = "Department")]
        [ForeignKey("Department")]
        public int id_department{ get; set; }
        public virtual DepartmentModel Department { get; set; }

        [Required]
        [Display(Name = "Employee")]
        [ForeignKey("Employee")]
        public int id_employee { get; set; }
        public virtual EmployeeModel Employee { get; set; }
    }
}
