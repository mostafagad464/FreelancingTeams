﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FreelancingTeamData.Models
{
    [Table("ClientSendTransactionToTeam")]
    public partial class ClientSendTransactionToTeam
    {
        [Key]
        public int ClientId { get; set; }
        [Key]
        public int TeamId { get; set; }
        [Key]
        public int TransactionId { get; set; }
        public bool? Done { get; set; }

        [ForeignKey("ClientId")]
        [InverseProperty("ClientSendTransactionToTeams")]
        public virtual Client Client { get; set; }
        [ForeignKey("TeamId")]
        [InverseProperty("ClientSendTransactionToTeams")]
        public virtual Team Team { get; set; }
        [ForeignKey("TransactionId")]
        [InverseProperty("ClientSendTransactionToTeams")]
        public virtual Transaction Transaction { get; set; }
    }
}