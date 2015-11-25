using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Data.Entity;
using Web.Models.Entities;

namespace Web.Models
{
    public static class SampleData
    {
        public static void Initialize(IServiceProvider service)
        {
            var context = service.GetService<UtilitiesContext>();
            context.Database.Migrate();
            if(!context.BillTypes.Any())
            {
                context.BillTypes.AddRange(
                    new BillType { TypeName = "Квитанция за газ" },
                    new BillType { TypeName = "Квитанция за электроэнергию" });
                context.SaveChanges();
            }
            if (!context.BillProviders.Any())
            {
                context.BillProviders.AddRange(
                    new BillProvider { ProviderName = "ОАО ОЕИРЦ" },
                    new BillProvider { ProviderName = "ОАО \"Тульская энергосбытовая компания\"" },
                    new BillProvider { ProviderName = "ООО \"Мега - Т\"" });
                context.SaveChanges();
            }
            if (!context.Months.Any())
            {
                context.Months.AddRange(
                    new Month { Name = "Январь" },
                    new Month { Name = "Февраль" },
                    new Month { Name = "Март" },
                    new Month { Name = "Апрель" },
                    new Month { Name = "Май" },
                    new Month { Name = "Июнь" },
                    new Month { Name = "Июль" },
                    new Month { Name = "Август" },
                    new Month { Name = "Сентябрь" },
                    new Month { Name = "Октябрь" },
                    new Month { Name = "Ноябрь" },
                    new Month { Name = "Декабрь" });
                context.SaveChanges();
            }
        }
    }
}
