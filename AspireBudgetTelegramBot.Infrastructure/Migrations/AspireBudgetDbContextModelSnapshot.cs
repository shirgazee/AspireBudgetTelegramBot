﻿// <auto-generated />
using System;
using AspireBudgetTelegramBot.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AspireBudgetTelegramBot.Infrastructure.Migrations
{
    [DbContext(typeof(AspireBudgetDbContext))]
    partial class AspireBudgetDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7");

            modelBuilder.Entity("AspireBudgetTelegramBot.Infrastructure.Models.MemoItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("TEXT");

                    b.Property<string>("AccountFrom")
                        .IsRequired()
                        .HasColumnName("account_from")
                        .HasColumnType("TEXT");

                    b.Property<string>("AccountTo")
                        .HasColumnName("account_to")
                        .HasColumnType("TEXT");

                    b.Property<string>("Category")
                        .HasColumnName("category")
                        .HasColumnType("TEXT");

                    b.Property<string>("Memo")
                        .IsRequired()
                        .HasColumnName("memo")
                        .HasColumnType("TEXT");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnName("type")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Memo");

                    b.ToTable("memo_item");
                });
#pragma warning restore 612, 618
        }
    }
}