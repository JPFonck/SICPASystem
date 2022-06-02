using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SICPASystem.Models
{
    public class EmployeeModel
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

        [Required(ErrorMessage = "Age is required")]
        [Display(Name = "Age")]
        public string age { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [Display(Name = "Email")]
        public string email { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [Display(Name = "Name")]
        public string name { get; set; }

        [Required(ErrorMessage = "Position is required")]
        [Display(Name = "Position")]
        public string position { get; set; }

        [Required(ErrorMessage = "Surname is required")]
        [Display(Name = "Surname")]
        public string surname { get; set; }

        public virtual ICollection<Department_EmployeeModel> Department_Employee { get; set; }
    }
}
