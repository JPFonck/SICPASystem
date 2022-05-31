using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SICPASystem.Models
{
    public class EnterpriseModel
    {
        [Key]
        public int Id { get; set; }

        [Display(Name ="Created by")]
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

        [Required(ErrorMessage = "Address is required")]
        [Display(Name = "Address")]
        public string address { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [Display(Name = "Name")]
        public string name { get; set; }

        [Required(ErrorMessage = "Phone is required")]
        [Display(Name = "Phone")]
        public string phone { get; set; }
    }
}
