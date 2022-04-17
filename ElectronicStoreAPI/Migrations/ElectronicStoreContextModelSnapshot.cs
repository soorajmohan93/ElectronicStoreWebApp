﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ElectronicStoreAPI.Migrations
{
    [DbContext(typeof(ElectronicStoreContext))]
    partial class ElectronicStoreContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.15");

            modelBuilder.Entity("ElectronicStoreModels.Models.Cart", b =>
                {
                    b.Property<int>("CartId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CartQuantity")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Customer")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Product")
                        .HasColumnType("INTEGER");

                    b.HasKey("CartId");

                    b.HasIndex("Customer");

                    b.HasIndex("Product");

                    b.ToTable("Cart");
                });

            modelBuilder.Entity("ElectronicStoreModels.Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CustomerAddress")
                        .HasColumnType("TEXT");

                    b.Property<string>("CustomerEmail")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("PhoneNumber")
                        .HasColumnType("INTEGER");

                    b.HasKey("CustomerId");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("ElectronicStoreModels.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Category")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ProductDesc")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("ProductPrice")
                        .HasColumnType("TEXT");

                    b.Property<int>("ProductStock")
                        .HasColumnType("INTEGER");

                    b.HasKey("ProductId");

                    b.HasIndex("Category");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("ElectronicStoreModels.Models.ProductCategory", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("CategoryId");

                    b.ToTable("ProductCategory");
                });

            modelBuilder.Entity("ElectronicStoreModels.Models.Cart", b =>
                {
                    b.HasOne("ElectronicStoreModels.Models.Customer", "Customers")
                        .WithMany("Carts")
                        .HasForeignKey("Customer")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ElectronicStoreModels.Models.Product", "Products")
                        .WithMany("Carts")
                        .HasForeignKey("Product")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customers");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("ElectronicStoreModels.Models.Product", b =>
                {
                    b.HasOne("ElectronicStoreModels.Models.ProductCategory", "ProductCategory")
                        .WithMany("Products")
                        .HasForeignKey("Category")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductCategory");
                });

            modelBuilder.Entity("ElectronicStoreModels.Models.Customer", b =>
                {
                    b.Navigation("Carts");
                });

            modelBuilder.Entity("ElectronicStoreModels.Models.Product", b =>
                {
                    b.Navigation("Carts");
                });

            modelBuilder.Entity("ElectronicStoreModels.Models.ProductCategory", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
