using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SICPASystem.Models
{
    public class DepartmentModel
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

        [Required(ErrorMessage = "Description is required")]
        [Display(Name = "Description")]
        public string description { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [Display(Name = "Name")]
        public string name { get; set; }

        [Required(ErrorMessage = "Phone is required")]
        [Display(Name = "Phone")]
        public string phone { get; set; }

        [Required]
        [Display(Name = "Enterprise")]
        [ForeignKey("Enterprise")]
        public int id_enterprise { get; set; }

        public virtual EnterpriseModel Enterprise { get; set; }
        public virtual ICollection<Department_EmployeeModel> Department_Employee { get; set; }
    }
}
