using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class BillTypeFormModel
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("Наименование")]
        [MaxLength(50)]
        public string TypeName { get; set; }
    }
}