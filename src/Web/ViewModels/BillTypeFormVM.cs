using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewModels
{
    public class BillTypeFormVM
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Тип квитанции")]
        [MaxLength(50)]
        public string TypeName { get; set; }
    }
}
