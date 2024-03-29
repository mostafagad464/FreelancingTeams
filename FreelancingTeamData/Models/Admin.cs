﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FreelancingTeamData.Models
{
    [Table("Admin")]
    public partial class Admin
    {
        public Admin()
        {
            Complains = new HashSet<Complain>();
            Users = new HashSet<User>();
        }

        [Key]
        public int Id { get; set; }

        [ForeignKey("Id")]
        [InverseProperty("Admin")]
        public virtual Account IdNavigation { get; set; }
        [InverseProperty("AdminHandler")]
        public virtual ICollection<Complain> Complains { get; set; }
        [InverseProperty("AdminValidatedNavigation")]
        public virtual ICollection<User> Users { get; set; }
    }
}