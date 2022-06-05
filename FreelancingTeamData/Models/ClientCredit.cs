﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FreelancingTeamData.Models
{
    [Table("ClientCredit")]
    public partial class ClientCredit
    {
        [Key]
        public int ClientId { get; set; }
        [Key]
        public int CreditNumber { get; set; }

        [ForeignKey("ClientId")]
        [InverseProperty("ClientCredits")]
        public virtual Client Client { get; set; }
    }
}