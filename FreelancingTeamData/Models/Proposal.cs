﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FreelancingTeamData.Models
{
    [Table("Proposal")]
    public partial class Proposal
    {
        [Key]
        public int Id { get; set; }
        public int TeamId { get; set; }
        public int ProjectId { get; set; }
        [Required]
        public string Description { get; set; }
        [Column(TypeName = "money")]
        public decimal? Money { get; set; }
        [Column(TypeName = "date")]
        public DateTime? Date { get; set; }
        [StringLength(50)]
        public string Duration { get; set; }

        [ForeignKey("ProjectId")]
        [InverseProperty("Proposals")]
        public virtual Project Project { get; set; }
        [ForeignKey("TeamId")]
        [InverseProperty("Proposals")]
        public virtual Team Team { get; set; }
    }
}