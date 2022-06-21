﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace empclass
{
    public partial class employeeContext : DbContext
    {
        public employeeContext()
        {
        }

        public employeeContext(DbContextOptions<employeeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Attendecee> Attendecees { get; set; }
        public virtual DbSet<Leave> Leaves { get; set; }
        public virtual DbSet<Register> Registers { get; set; }
        public virtual DbSet<Salary> Salaries { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-CM3D0NO\\SQLEXPRESS;Initial Catalog=employee;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Attendecee>(entity =>
            {
                entity.HasKey(e => e.AttendId)
                    .HasName("PK__attendec__3354C18B39D8AC07");

                entity.ToTable("attendecee");

                entity.Property(e => e.AttendId).HasColumnName("attendId");

                entity.Property(e => e.Astatus)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("astatus");

                entity.Property(e => e.Employeeid).HasColumnName("employeeid");

                entity.Property(e => e.Fullname)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("fullname");

                entity.Property(e => e.Mail)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("mail");

                entity.Property(e => e.Pdate)
                    .HasColumnType("date")
                    .HasColumnName("pdate");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Attendecees)
                    .HasForeignKey(d => d.Employeeid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__attendece__emplo__5165187F");
            });

            modelBuilder.Entity<Leave>(entity =>
            {
                entity.ToTable("leave");

                entity.Property(e => e.Leaveid).HasColumnName("leaveid");

                entity.Property(e => e.Employeeid).HasColumnName("employeeid");

                entity.Property(e => e.Fromdate)
                    .HasColumnType("date")
                    .HasColumnName("fromdate");

                entity.Property(e => e.Reason)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("reason");

                entity.Property(e => e.Status)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("status");

                entity.Property(e => e.Todate)
                    .HasColumnType("date")
                    .HasColumnName("todate");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Leaves)
                    .HasForeignKey(d => d.Employeeid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__leave__employeei__4E88ABD4");
            });

            modelBuilder.Entity<Register>(entity =>
            {
                entity.HasKey(e => e.Employeeid)
                    .HasName("PK__register__C135F5E9324D4C10");

                entity.ToTable("register");

                entity.Property(e => e.Employeeid).HasColumnName("employeeid");

                entity.Property(e => e.Address1)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("address1");

                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("city");

                entity.Property(e => e.Designation)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("designation");

                entity.Property(e => e.Dob)
                    .HasColumnType("date")
                    .HasColumnName("dob");

                entity.Property(e => e.Email)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Firstname)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("firstname");

                entity.Property(e => e.Gender)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("gender");

                entity.Property(e => e.Lastname)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("lastname");

                entity.Property(e => e.Mobile).HasColumnName("mobile");

                entity.Property(e => e.Passwords)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("passwords");

                entity.Property(e => e.Pincode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("pincode");

                entity.Property(e => e.States)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("states");
            });

            modelBuilder.Entity<Salary>(entity =>
            {
                entity.ToTable("salary");

                entity.Property(e => e.Salaryid).HasColumnName("salaryid");

                entity.Property(e => e.Allowence)
                    .HasColumnType("decimal(16, 2)")
                    .HasColumnName("allowence");

                entity.Property(e => e.Basicpay)
                    .HasColumnType("decimal(16, 2)")
                    .HasColumnName("basicpay");

                entity.Property(e => e.Bonus)
                    .HasColumnType("decimal(16, 2)")
                    .HasColumnName("bonus");

                entity.Property(e => e.Employeeid).HasColumnName("employeeid");

                entity.Property(e => e.Hra)
                    .HasColumnType("decimal(16, 2)")
                    .HasColumnName("hra");

                entity.Property(e => e.Medicalallowence)
                    .HasColumnType("decimal(16, 2)")
                    .HasColumnName("medicalallowence");

                entity.Property(e => e.Netsalary)
                    .HasColumnType("decimal(16, 2)")
                    .HasColumnName("netsalary");

                entity.Property(e => e.Pf)
                    .HasColumnType("decimal(16, 2)")
                    .HasColumnName("pf");

                entity.Property(e => e.Professionaltax)
                    .HasColumnType("decimal(16, 2)")
                    .HasColumnName("professionaltax");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Salaries)
                    .HasForeignKey(d => d.Employeeid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__salary__employee__4BAC3F29");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}