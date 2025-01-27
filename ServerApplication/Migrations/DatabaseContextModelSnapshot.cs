﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ServerApplication;

#nullable disable

namespace ServerApplication.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("main")
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ServerApplication.Domain.CustomerAddress", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("AddressLine1")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("address_line1");

                    b.Property<string>("AddressLine2")
                        .HasColumnType("text")
                        .HasColumnName("address_line2");

                    b.Property<string>("Area")
                        .HasColumnType("text")
                        .HasColumnName("area");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("city");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("country");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("created_on");

                    b.Property<decimal?>("Lat")
                        .HasColumnType("decimal(12,3)")
                        .HasColumnName("lat");

                    b.Property<decimal?>("Lng")
                        .HasColumnType("decimal(12,3)")
                        .HasColumnName("lng");

                    b.Property<Guid>("StoreId")
                        .HasColumnType("uuid")
                        .HasColumnName("store_id");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("updated_on");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_customer_address");

                    b.HasIndex("StoreId")
                        .IsUnique()
                        .HasDatabaseName("ix_customer_address_store_id");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_customer_address_user_id");

                    b.ToTable("customer_address", "main");
                });

            modelBuilder.Entity("ServerApplication.Domain.Orders", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("created_on");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uuid")
                        .HasColumnName("customer_id");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("order_date");

                    b.Property<string>("OrderStatus")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("order_status");

                    b.Property<Guid>("PartId")
                        .HasColumnType("uuid")
                        .HasColumnName("part_id");

                    b.Property<int>("Quantities")
                        .HasColumnType("integer")
                        .HasColumnName("quantities");

                    b.Property<Guid>("StoreId")
                        .HasColumnType("uuid")
                        .HasColumnName("store_id");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(12,3)")
                        .HasColumnName("total_price");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("updated_on");

                    b.HasKey("Id")
                        .HasName("pk_orders");

                    b.ToTable("orders", "main");
                });

            modelBuilder.Entity("ServerApplication.Domain.Pricing", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("created_on");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(12,3)")
                        .HasColumnName("price");

                    b.Property<Guid>("SparePartId")
                        .HasColumnType("uuid")
                        .HasColumnName("spare_part_id");

                    b.Property<Guid>("StoreId")
                        .HasColumnType("uuid")
                        .HasColumnName("store_id");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("updated_on");

                    b.HasKey("Id")
                        .HasName("pk_pricing");

                    b.ToTable("pricing", "main");
                });

            modelBuilder.Entity("ServerApplication.Domain.SpareParts", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Brand")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("brand");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("created_on");

                    b.Property<string>("Description")
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)")
                        .HasColumnName("description");

                    b.Property<bool>("IsSuspended")
                        .HasColumnType("boolean")
                        .HasColumnName("is_suspended");

                    b.Property<string>("MadeIn")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("made_in");

                    b.Property<int?>("Model")
                        .IsRequired()
                        .HasColumnType("integer")
                        .HasColumnName("model");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)")
                        .HasColumnName("name");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer")
                        .HasColumnName("quantity");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("updated_on");

                    b.HasKey("Id")
                        .HasName("pk_spare_parts");

                    b.ToTable("spare_parts", "main");
                });

            modelBuilder.Entity("ServerApplication.Domain.Stores", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("created_on");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)")
                        .HasColumnName("name");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("uuid")
                        .HasColumnName("owner_id");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("updated_on");

                    b.Property<bool>("isAccepted")
                        .HasColumnType("boolean")
                        .HasColumnName("is_accepted");

                    b.Property<int>("rate")
                        .HasColumnType("integer")
                        .HasColumnName("rate");

                    b.HasKey("Id")
                        .HasName("pk_stores");

                    b.ToTable("stores", "main");
                });

            modelBuilder.Entity("ServerApplication.Domain.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("created_on");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("first_name");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("last_name");

                    b.Property<string>("MiddleName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("middle_name");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("password_hash");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("phone_number");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("updated_on");

                    b.Property<int>("UserRole")
                        .HasColumnType("integer")
                        .HasColumnName("user_role");

                    b.HasKey("Id")
                        .HasName("pk_user");

                    b.ToTable("user", "main");
                });

            modelBuilder.Entity("ServerApplication.Domain.CustomerAddress", b =>
                {
                    b.HasOne("ServerApplication.Domain.Stores", "Store")
                        .WithOne("CustomerAddresses")
                        .HasForeignKey("ServerApplication.Domain.CustomerAddress", "StoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_customer_address_stores_store_id");

                    b.HasOne("ServerApplication.Domain.User", "User")
                        .WithMany("CustomerAddresses")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_customer_address_user_user_id");

                    b.Navigation("Store");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ServerApplication.Domain.Stores", b =>
                {
                    b.Navigation("CustomerAddresses")
                        .IsRequired();
                });

            modelBuilder.Entity("ServerApplication.Domain.User", b =>
                {
                    b.Navigation("CustomerAddresses");
                });
#pragma warning restore 612, 618
        }
    }
}
