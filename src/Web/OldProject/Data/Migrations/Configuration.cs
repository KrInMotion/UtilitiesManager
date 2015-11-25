namespace Data.Migrations
{
    using Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Data.UtilitiesContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(Data.UtilitiesContext context)
        {
            /*context.MonthSet.AddOrUpdate(GenerateMonth());
            context.BillTypeSet.AddOrUpdate(GenerateBillType());
            context.BillProviderSet.AddOrUpdate(GenerateBillProvider());*/
        }

        private Month[] GenerateMonth()
        {
            Month[] months = new Month[]
            {
                new Month {Id=1, Name="Январь" },
                new Month {Id=2, Name="Февраль" },
                new Month {Id=3, Name="Март" },
                new Month {Id=4, Name="Апрель" },
                new Month {Id=5, Name="Май" },
                new Month {Id=6, Name="Июнь" },
                new Month {Id=7, Name="Июль" },
                new Month {Id=8, Name="Август" },
                new Month {Id=9, Name="Сентябрь" },
                new Month {Id=10, Name="Октябрь" },
                new Month {Id=11, Name="Ноябрь" },
                new Month {Id=12, Name="Декабрь" },
             };
            return months;
        }
        private BillType[] GenerateBillType()
        {
            BillType[] billTypes = new BillType[]
            {
                new BillType {TypeName = "Квитанция за газ" },
                new BillType {TypeName = "Квитанция за электроэнергию" }
            };
            return billTypes;
        }

        private BillProvider[] GenerateBillProvider()
        {
            BillProvider[] providers = new BillProvider[]
            {
                new BillProvider {ProviderName = "ОАО \"Тульская энергосбытовая компания\"" },
                new BillProvider {ProviderName = "ООО \"Мега-Т\"" },
                new BillProvider {ProviderName = "ОАО ОЕИРЦ" }
            };
            return providers;
        }
    }
}
