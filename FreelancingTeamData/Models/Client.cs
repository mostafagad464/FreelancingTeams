﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FreelancingTeamData.Models
{
    [Table("Client")]
    public partial class Client
    {
        public Client()
        {
            Deals = new HashSet<Deal>();
            ProjectPayments = new HashSet<ProjectPayment>();
            Projects = new HashSet<Project>();
            Reviews = new HashSet<Review>();
        }

        [Key]
        public int Id { get; set; }

        [ForeignKey("Id")]
        [InverseProperty("ClientNavigation")]
        public virtual User IdNavigation { get; set; }
        [InverseProperty("Client")]
        public virtual ICollection<Deal> Deals { get; set; }
        [InverseProperty("Client")]
        public virtual ICollection<ProjectPayment> ProjectPayments { get; set; }
        [InverseProperty("Client")]
        public virtual ICollection<Project> Projects { get; set; }
        [InverseProperty("Client")]
        public virtual ICollection<Review> Reviews { get; set; }
    }
}