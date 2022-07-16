﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using IndexAttribute = Microsoft.EntityFrameworkCore.IndexAttribute;


namespace FreelancingTeamData.Models
{
    [Table("Team")]
    [Index("WebSite", Name = "UQ__Team__AEE1DE456CB1558D", IsUnique = true)]
    public partial class Team
    {
        public Team()
        {
            Complains = new HashSet<Complain>();
            Deals = new HashSet<Deal>();
            Proposals = new HashSet<Proposal>();
            Reviews = new HashSet<Review>();
            TeamFreelancerMessages = new HashSet<TeamFreelancerMessage>();
            TeamMembers = new HashSet<TeamMember>();
            TeamTransactions = new HashSet<TeamTransaction>();
            Notifications = new HashSet<Notification>();
        }

        [Key]
        public int Id { get; set; }
        [Column(TypeName = "image")]
        public byte[] Logo { get; set; }
        [Column(TypeName = "date")]
        public DateTime CreationDate { get; set; }
        public string Description { get; set; }
        public double? Rate { get; set; }
        public bool? IsVerfied { get; set; }
        [StringLength(100)]
        public string WebSite { get; set; }
        public int? LeaderId { get; set; }
        public int? WalletId { get; set; }
        public string? Name { get; set; }
        public string? Specialization { get; set; }


        [ForeignKey("LeaderId")]
        [InverseProperty("Teams")]
        public virtual Freelancer Leader { get; set; }
        [ForeignKey("WalletId")]
        [InverseProperty("Teams")]
        public virtual Wallet Wallet { get; set; }
        [InverseProperty("ComplainingTeam")]
        public virtual ICollection<Complain> Complains { get; set; }
        [InverseProperty("Team")]
        public virtual ICollection<Deal> Deals { get; set; }
        [InverseProperty("Team")]
        public virtual ICollection<Proposal> Proposals { get; set; }
        [InverseProperty("Team")]
        public virtual ICollection<Review> Reviews { get; set; }
        [InverseProperty("Team")]
        public virtual ICollection<TeamFreelancerMessage> TeamFreelancerMessages { get; set; }
        [InverseProperty("Team")]
        public virtual ICollection<TeamMember> TeamMembers { get; set; }
        [InverseProperty("Team")]
        public virtual ICollection<TeamTransaction> TeamTransactions { get; set; }

        [ForeignKey("TeamId")]
        [InverseProperty("Teams")]
        public virtual ICollection<Notification> Notifications { get; set; }
    }
}