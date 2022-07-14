﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FreelancingTeamData.Models
{
    [Table("Freelancer")]
    public partial class Freelancer
    {
        public Freelancer()
        {
            FreelancerCertificates = new HashSet<FreelancerCertificate>();
            FreelancerEducations = new HashSet<FreelancerEducation>();
            FreelancerExperiences = new HashSet<FreelancerExperience>();
            FreelancerSkills = new HashSet<FreelancerSkill>();
            Portoflios = new HashSet<Portoflio>();
            TeamMembers = new HashSet<TeamMember>();
            TeamTransactions = new HashSet<TeamTransaction>();
            Teams = new HashSet<Team>();
        }

        [Key]
        public int Id { get; set; }
        [Column(TypeName = "money")]
        public decimal? TotalMoney { get; set; }
        public int? NumberOfClients { get; set; }
        public double? AVGHourlyRate { get; set; }
        public string? Specialization { get; set; }

        [ForeignKey("Id")]
        [InverseProperty("FreelancerNavigation")]
        public virtual User IdNavigation { get; set; }
        [InverseProperty("Freelancer")]
        public virtual ICollection<FreelancerCertificate> FreelancerCertificates { get; set; }
        [InverseProperty("Freelancer")]
        public virtual ICollection<FreelancerEducation> FreelancerEducations { get; set; }
        [InverseProperty("Freelancer")]
        public virtual ICollection<FreelancerExperience> FreelancerExperiences { get; set; }
        [InverseProperty("Freelancer")]
        public virtual ICollection<FreelancerSkill> FreelancerSkills { get; set; }
        [InverseProperty("Freelancer")]
        public virtual ICollection<Portoflio> Portoflios { get; set; }
        [InverseProperty("Freelancer")]
        public virtual ICollection<TeamMember> TeamMembers { get; set; }
        [InverseProperty("Freelancer")]
        public virtual ICollection<TeamTransaction> TeamTransactions { get; set; }
        [InverseProperty("Leader")]
        public virtual ICollection<Team> Teams { get; set; }
    }
}