using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Web.ViewModels
{
    public class BillTypeListVM
    {
        public int Id { get; set; }
        [Display(Name="Тип квитанции")]
        [MaxLength(50)]
        public string TypeName { get; set; }
        [Display(Name = "Кол-во квитанций")]
        public  int BillCount { get; set; }
    }
}