﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FreelancingTeamData.Models
{
    [Table("UserLanguage")]
    public partial class UserLanguage
    {
        [Key]
        public int UserId { get; set; }
        [Key]
        [StringLength(50)]
        public string Language { get; set; }

        [ForeignKey("UserId")]
        [InverseProperty("UserLanguages")]
        public virtual User User { get; set; }
    }
}