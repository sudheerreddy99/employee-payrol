﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace empclass
{
    public partial class Register
    {
        public Register()
        {
            Attendecees = new HashSet<Attendecee>();
            Leaves = new HashSet<Leave>();
            Salaries = new HashSet<Salary>();
        }

        public int Employeeid { get; set; }
        [Required(ErrorMessage = "Please Enter your Email")]
        [EmailAddress(ErrorMessage = "Invalid Email Format")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please Enter Firstname")]
        public string Firstname { get; set; }
        [Required(ErrorMessage = "Please Enter Lastname")]
        public string Lastname { get; set; }
        [Required(ErrorMessage = "Please Enter Mobile number")]
        
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        public long? Mobile { get; set; }
        [Required(ErrorMessage = "Please Enter Password")]
        public string Passwords { get; set; }
        public string Designation { get; set; }
        
        public string Address1 { get; set; }
        [Required(ErrorMessage = "Please Enter Gender")]
        public string Gender { get; set; }
        public string States { get; set; }
        
        public string City { get; set; }
        [Required(ErrorMessage = "Please Enter Your Dateofbirth")]
        public DateTime? Dob { get; set; }
        public string Pincode { get; set; }

        public virtual ICollection<Attendecee> Attendecees { get; set; }
        public virtual ICollection<Leave> Leaves { get; set; }
        public virtual ICollection<Salary> Salaries { get; set; }
    }
}