using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class BillTypeViewModel
    {
        public int Id { get; set; }
        [DisplayName("Тип квитанции")]
        [MaxLength(50)]
        public string TypeName { get; set; }
        [DisplayName("Кол-во квитанций")]
        public  int BillCount { get; set; }
    }
}