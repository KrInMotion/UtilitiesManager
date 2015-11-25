using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using Web.Models;

namespace Web.Migrations
{
    [DbContext(typeof(UtilitiesContext))]
    [Migration("20151123122633_entities")]
    partial class entities
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Web.Models.Entities.Bill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BillProviderId");

                    b.Property<double>("BillSum");

                    b.Property<int>("BillTypeId");

                    b.Property<int>("BillYear");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int>("MonthId");

                    b.Property<DateTime?>("PaymentDate");

                    b.Property<double?>("PaymentSum");

                    b.Property<DateTime?>("UpdatedAt");

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:TableName", "Bill");
                });

            modelBuilder.Entity("Web.Models.Entities.BillProvider", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ProviderName")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 255);

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:TableName", "BillProvider");
                });

            modelBuilder.Entity("Web.Models.Entities.BillType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("TypeName")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:TableName", "BillType");
                });

            modelBuilder.Entity("Web.Models.Entities.Month", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 30);

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:TableName", "Month");
                });

            modelBuilder.Entity("Web.Models.Entities.Bill", b =>
                {
                    b.HasOne("Web.Models.Entities.BillProvider")
                        .WithMany()
                        .HasForeignKey("BillProviderId");

                    b.HasOne("Web.Models.Entities.BillType")
                        .WithMany()
                        .HasForeignKey("BillTypeId");

                    b.HasOne("Web.Models.Entities.Month")
                        .WithMany()
                        .HasForeignKey("MonthId");
                });
        }
    }
}
