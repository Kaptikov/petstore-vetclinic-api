﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using petstore_vetclinic_api.Data;

#nullable disable

namespace petstore_vetclinic_api.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240611090111_ChangeProductTableAddTableProductCharacteristicsValue")]
    partial class ChangeProductTableAddTableProductCharacteristicsValue
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("petstore_vetclinic_api.Models.Animals.Animal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Breed")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("imgUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Animals");
                });

            modelBuilder.Entity("petstore_vetclinic_api.Models.Carts.CartItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int?>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("UserId");

                    b.ToTable("CartItems");
                });

            modelBuilder.Entity("petstore_vetclinic_api.Models.Categories.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ImgUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ParentCategoryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ParentCategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("petstore_vetclinic_api.Models.Clinic.Appointment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AnimalId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DoctorId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<TimeSpan>("Time")
                        .HasColumnType("time");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AnimalId");

                    b.HasIndex("DoctorId");

                    b.HasIndex("UserId");

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("petstore_vetclinic_api.Models.Clinic.Doctor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Specialization")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("petstore_vetclinic_api.Models.Clinic.Request", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Requests");
                });

            modelBuilder.Entity("petstore_vetclinic_api.Models.Clinic.Schedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("DoctorId")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("EndTime")
                        .HasColumnType("time");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("bit");

                    b.Property<TimeSpan>("StartTime")
                        .HasColumnType("time");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.ToTable("Schedules");
                });

            modelBuilder.Entity("petstore_vetclinic_api.Models.Favourites.FavouriteItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("UserId");

                    b.ToTable("FavouriteItems");
                });

            modelBuilder.Entity("petstore_vetclinic_api.Models.Orders.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("OrderNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("TotalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("petstore_vetclinic_api.Models.Orders.OrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int?>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("petstore_vetclinic_api.Models.Products.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("Article")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Discount")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("OldPrice")
                        .HasColumnType("int");

                    b.Property<decimal?>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("imgUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("petstore_vetclinic_api.Models.Products.ProductAdvantage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductAdvantages");
                });

            modelBuilder.Entity("petstore_vetclinic_api.Models.Products.ProductCharacteristics", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductCharacteristics");
                });

            modelBuilder.Entity("petstore_vetclinic_api.Models.Products.ProductCharacteristicsValue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductCharacteristicsId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductCharacteristicsId")
                        .IsUnique();

                    b.ToTable("ProductCharacteristicsValues");
                });

            modelBuilder.Entity("petstore_vetclinic_api.Models.Products.ProductComposition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId")
                        .IsUnique();

                    b.ToTable("ProductCompositions");
                });

            modelBuilder.Entity("petstore_vetclinic_api.Models.Products.ProductDescription", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId")
                        .IsUnique();

                    b.ToTable("productDescriptions");
                });

            modelBuilder.Entity("petstore_vetclinic_api.Models.Products.ProductImg", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("imgUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductImgs");
                });

            modelBuilder.Entity("petstore_vetclinic_api.Models.Products.ProductNutritionalValue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductNutritionalValues");
                });

            modelBuilder.Entity("petstore_vetclinic_api.Models.Reviews.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("UserId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("petstore_vetclinic_api.Models.Users.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("petstore_vetclinic_api.Models.Users.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataRegistration")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lastname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("petstore_vetclinic_api.Models.Users.UserDto", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("UserDtos");
                });

            modelBuilder.Entity("petstore_vetclinic_api.Models.Animals.Animal", b =>
                {
                    b.HasOne("petstore_vetclinic_api.Models.Users.User", "Users")
                        .WithMany("Animals")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Users");
                });

            modelBuilder.Entity("petstore_vetclinic_api.Models.Carts.CartItem", b =>
                {
                    b.HasOne("petstore_vetclinic_api.Models.Products.Product", "Products")
                        .WithMany("CartItems")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("petstore_vetclinic_api.Models.Users.User", "Users")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Products");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("petstore_vetclinic_api.Models.Categories.Category", b =>
                {
                    b.HasOne("petstore_vetclinic_api.Models.Categories.Category", "ParentCategory")
                        .WithMany("ChildCategories")
                        .HasForeignKey("ParentCategoryId");

                    b.Navigation("ParentCategory");
                });

            modelBuilder.Entity("petstore_vetclinic_api.Models.Clinic.Appointment", b =>
                {
                    b.HasOne("petstore_vetclinic_api.Models.Animals.Animal", "Animal")
                        .WithMany("Appointments")
                        .HasForeignKey("AnimalId");

                    b.HasOne("petstore_vetclinic_api.Models.Clinic.Doctor", "Doctor")
                        .WithMany()
                        .HasForeignKey("DoctorId");

                    b.HasOne("petstore_vetclinic_api.Models.Users.User", "User")
                        .WithMany("Appointments")
                        .HasForeignKey("UserId");

                    b.Navigation("Animal");

                    b.Navigation("Doctor");

                    b.Navigation("User");
                });

            modelBuilder.Entity("petstore_vetclinic_api.Models.Clinic.Schedule", b =>
                {
                    b.HasOne("petstore_vetclinic_api.Models.Clinic.Doctor", "Doctor")
                        .WithMany("Schedules")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");
                });

            modelBuilder.Entity("petstore_vetclinic_api.Models.Favourites.FavouriteItem", b =>
                {
                    b.HasOne("petstore_vetclinic_api.Models.Products.Product", "Products")
                        .WithMany("FavouriteItems")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("petstore_vetclinic_api.Models.Users.User", "Users")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Products");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("petstore_vetclinic_api.Models.Orders.Order", b =>
                {
                    b.HasOne("petstore_vetclinic_api.Models.Users.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("petstore_vetclinic_api.Models.Orders.OrderItem", b =>
                {
                    b.HasOne("petstore_vetclinic_api.Models.Orders.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("petstore_vetclinic_api.Models.Products.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("petstore_vetclinic_api.Models.Products.Product", b =>
                {
                    b.HasOne("petstore_vetclinic_api.Models.Categories.Category", "Categories")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categories");
                });

            modelBuilder.Entity("petstore_vetclinic_api.Models.Products.ProductAdvantage", b =>
                {
                    b.HasOne("petstore_vetclinic_api.Models.Products.Product", "Product")
                        .WithMany("ProductAdvantage")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("petstore_vetclinic_api.Models.Products.ProductCharacteristics", b =>
                {
                    b.HasOne("petstore_vetclinic_api.Models.Products.Product", "Product")
                        .WithMany("ProductCharacteristic")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("petstore_vetclinic_api.Models.Products.ProductCharacteristicsValue", b =>
                {
                    b.HasOne("petstore_vetclinic_api.Models.Products.ProductCharacteristics", "ProductCharacteristics")
                        .WithOne("ProductCharacteristicsValue")
                        .HasForeignKey("petstore_vetclinic_api.Models.Products.ProductCharacteristicsValue", "ProductCharacteristicsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductCharacteristics");
                });

            modelBuilder.Entity("petstore_vetclinic_api.Models.Products.ProductComposition", b =>
                {
                    b.HasOne("petstore_vetclinic_api.Models.Products.Product", "Product")
                        .WithOne("ProductComposition")
                        .HasForeignKey("petstore_vetclinic_api.Models.Products.ProductComposition", "ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("petstore_vetclinic_api.Models.Products.ProductDescription", b =>
                {
                    b.HasOne("petstore_vetclinic_api.Models.Products.Product", "Product")
                        .WithOne("ProductDescription")
                        .HasForeignKey("petstore_vetclinic_api.Models.Products.ProductDescription", "ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("petstore_vetclinic_api.Models.Products.ProductImg", b =>
                {
                    b.HasOne("petstore_vetclinic_api.Models.Products.Product", "Products")
                        .WithMany("ProductImgs")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Products");
                });

            modelBuilder.Entity("petstore_vetclinic_api.Models.Products.ProductNutritionalValue", b =>
                {
                    b.HasOne("petstore_vetclinic_api.Models.Products.Product", "Product")
                        .WithMany("ProductNutritionalValue")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("petstore_vetclinic_api.Models.Reviews.Review", b =>
                {
                    b.HasOne("petstore_vetclinic_api.Models.Products.Product", "Products")
                        .WithMany("Reviews")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("petstore_vetclinic_api.Models.Users.User", "Users")
                        .WithMany("Reviews")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Products");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("petstore_vetclinic_api.Models.Users.User", b =>
                {
                    b.HasOne("petstore_vetclinic_api.Models.Users.Role", "Roles")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Roles");
                });

            modelBuilder.Entity("petstore_vetclinic_api.Models.Users.UserDto", b =>
                {
                    b.HasOne("petstore_vetclinic_api.Models.Users.User", "Users")
                        .WithOne("UserDtos")
                        .HasForeignKey("petstore_vetclinic_api.Models.Users.UserDto", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Users");
                });

            modelBuilder.Entity("petstore_vetclinic_api.Models.Animals.Animal", b =>
                {
                    b.Navigation("Appointments");
                });

            modelBuilder.Entity("petstore_vetclinic_api.Models.Categories.Category", b =>
                {
                    b.Navigation("ChildCategories");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("petstore_vetclinic_api.Models.Clinic.Doctor", b =>
                {
                    b.Navigation("Schedules");
                });

            modelBuilder.Entity("petstore_vetclinic_api.Models.Orders.Order", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("petstore_vetclinic_api.Models.Products.Product", b =>
                {
                    b.Navigation("CartItems");

                    b.Navigation("FavouriteItems");

                    b.Navigation("ProductAdvantage");

                    b.Navigation("ProductCharacteristic");

                    b.Navigation("ProductComposition")
                        .IsRequired();

                    b.Navigation("ProductDescription")
                        .IsRequired();

                    b.Navigation("ProductImgs");

                    b.Navigation("ProductNutritionalValue");

                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("petstore_vetclinic_api.Models.Products.ProductCharacteristics", b =>
                {
                    b.Navigation("ProductCharacteristicsValue");
                });

            modelBuilder.Entity("petstore_vetclinic_api.Models.Users.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("petstore_vetclinic_api.Models.Users.User", b =>
                {
                    b.Navigation("Animals");

                    b.Navigation("Appointments");

                    b.Navigation("Reviews");

                    b.Navigation("UserDtos");
                });
#pragma warning restore 612, 618
        }
    }
}
