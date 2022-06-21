﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using FreelancingTeamData.Models;

namespace FreelancingTeamData.Data
{
    public partial class FreeLanceProjectContext : DbContext
    {
        public FreeLanceProjectContext()
        {
        }

        public FreeLanceProjectContext(DbContextOptions<FreeLanceProjectContext> options)
            : base(options)
        {
        }
        //public FreeLanceProjectContext(DbContextOptions options) : base(options)
        //{
        //}

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<AccountMessage> AccountMessages { get; set; }
        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Complain> Complains { get; set; }
        public virtual DbSet<Deal> Deals { get; set; }
        public virtual DbSet<Freelancer> Freelancers { get; set; }
        public virtual DbSet<FreelancerCertificate> FreelancerCertificates { get; set; }
        public virtual DbSet<FreelancerEducation> FreelancerEducations { get; set; }
        public virtual DbSet<FreelancerExperience> FreelancerExperiences { get; set; }
        public virtual DbSet<FreelancerSkill> FreelancerSkills { get; set; }
        public virtual DbSet<Notification> Notifications { get; set; }
        public virtual DbSet<Portoflio> Portoflios { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<ProjectPayment> ProjectPayments { get; set; }
        public virtual DbSet<Proposal> Proposals { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<Skill> Skills { get; set; }
        public virtual DbSet<Team> Teams { get; set; }
        public virtual DbSet<TeamFreelancerMessage> TeamFreelancerMessages { get; set; }
        public virtual DbSet<TeamMember> TeamMembers { get; set; }
        public virtual DbSet<TeamTransaction> TeamTransactions { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserCredit> UserCredits { get; set; }
        public virtual DbSet<UserLanguage> UserLanguages { get; set; }
        public virtual DbSet<UserSocial> UserSocials { get; set; }
        public virtual DbSet<Wallet> Wallets { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Data Source=projectdatabase.database.windows.net;Initial Catalog=FreelancingTeams;Persist Security Info=True;User ID=noah;Password=pass123$");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountMessage>(entity =>
            {
                entity.HasOne(d => d.Reciever)
                    .WithMany(p => p.AccountMessageRecievers)
                    .HasForeignKey(d => d.RecieverId)
                    .HasConstraintName("FK__AccountMe__Recie__725BF7F6");

                entity.HasOne(d => d.Sender)
                    .WithMany(p => p.AccountMessageSenders)
                    .HasForeignKey(d => d.SenderId)
                    .HasConstraintName("FK__AccountMe__Sende__7167D3BD");
            });

            modelBuilder.Entity<Admin>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Admin)
                    .HasForeignKey<Admin>(d => d.Id)
                    .HasConstraintName("FK__Admin__Id__47A6A41B");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasMany(d => d.Skills)
                    .WithMany(p => p.Categories)
                    .UsingEntity<Dictionary<string, object>>(
                        "SkillCategory",
                        l => l.HasOne<Skill>().WithMany().HasForeignKey("SkillId").HasConstraintName("FK__SkillCate__Skill__00DF2177"),
                        r => r.HasOne<Category>().WithMany().HasForeignKey("CategoryId").HasConstraintName("FK__SkillCate__Categ__7FEAFD3E"),
                        j =>
                        {
                            j.HasKey("CategoryId", "SkillId").HasName("PK__SkillCat__74F333133F7F5537");

                            j.ToTable("SkillCategory");
                        });
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.ClientNavigation)
                    .HasForeignKey<Client>(d => d.Id)
                    .HasConstraintName("FK__Client__Id__6442E2C9");
            });

            modelBuilder.Entity<Complain>(entity =>
            {
                entity.HasOne(d => d.AdminHandler)
                    .WithMany(p => p.Complains)
                    .HasForeignKey(d => d.AdminHandlerId)
                    .HasConstraintName("FK__Complain__AdminH__5F492382");

                entity.HasOne(d => d.ComplainingTeam)
                    .WithMany(p => p.Complains)
                    .HasForeignKey(d => d.ComplainingTeamId)
                    .HasConstraintName("FK__Complain__Compla__5E54FF49");

                entity.HasOne(d => d.ComplainingUser)
                    .WithMany(p => p.Complains)
                    .HasForeignKey(d => d.ComplainingUserId)
                    .HasConstraintName("FK__Complain__Compla__5D60DB10");
            });

            modelBuilder.Entity<Deal>(entity =>
            {
                entity.HasKey(e => new { e.ClientId, e.TeamId, e.ProjectId })
                    .HasName("PK__Deal__962BAEE3E2E4D393");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Deals)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Deal__ClientId__40C49C62");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.Deals)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Deal__ProjectId__42ACE4D4");

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.Deals)
                    .HasForeignKey(d => d.TeamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Deal__TeamId__41B8C09B");
            });

            modelBuilder.Entity<Freelancer>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.FreelancerNavigation)
                    .HasForeignKey<Freelancer>(d => d.Id)
                    .HasConstraintName("FK__Freelancer__Id__671F4F74");
            });

            modelBuilder.Entity<FreelancerCertificate>(entity =>
            {
                entity.HasKey(e => new { e.FreelancerId, e.Title })
                    .HasName("PK__Freelanc__FFCB85214437D59E");

                entity.HasOne(d => d.Freelancer)
                    .WithMany(p => p.FreelancerCertificates)
                    .HasForeignKey(d => d.FreelancerId)
                    .HasConstraintName("FK__Freelance__Freel__72910220");
            });

            modelBuilder.Entity<FreelancerEducation>(entity =>
            {
                entity.HasKey(e => new { e.FreelancerId, e.gradYear })
                    .HasName("PK__Freelanc__E5D6D5973A384268");

                entity.HasOne(d => d.Freelancer)
                    .WithMany(p => p.FreelancerEducations)
                    .HasForeignKey(d => d.FreelancerId)
                    .HasConstraintName("FK__Freelance__Freel__6CD828CA");
            });

            modelBuilder.Entity<FreelancerExperience>(entity =>
            {
                entity.HasKey(e => new { e.FreelancerId, e.StartDate })
                    .HasName("PK__Freelanc__59E17CA3696AB00E");

                entity.HasOne(d => d.Freelancer)
                    .WithMany(p => p.FreelancerExperiences)
                    .HasForeignKey(d => d.FreelancerId)
                    .HasConstraintName("FK__Freelance__Freel__6FB49575");
            });

            modelBuilder.Entity<FreelancerSkill>(entity =>
            {
                entity.HasKey(e => new { e.FreelancerId, e.SkillId })
                    .HasName("PK__Freelanc__50FAEA744DA307A6");

                entity.HasOne(d => d.Freelancer)
                    .WithMany(p => p.FreelancerSkills)
                    .HasForeignKey(d => d.FreelancerId)
                    .HasConstraintName("FK__Freelance__Freel__03BB8E22");

                entity.HasOne(d => d.Skill)
                    .WithMany(p => p.FreelancerSkills)
                    .HasForeignKey(d => d.SkillId)
                    .HasConstraintName("FK__Freelance__Skill__04AFB25B");
            });

            modelBuilder.Entity<Notification>(entity =>
            {
                entity.HasMany(d => d.Accounts)
                    .WithMany(p => p.Notifications)
                    .UsingEntity<Dictionary<string, object>>(
                        "AccountNotification",
                        l => l.HasOne<Account>().WithMany().HasForeignKey("AccountId").HasConstraintName("FK__AccountNo__Accou__0A688BB1"),
                        r => r.HasOne<Notification>().WithMany().HasForeignKey("NotificationId").HasConstraintName("FK__AccountNo__Notif__09746778"),
                        j =>
                        {
                            j.HasKey("NotificationId", "AccountId").HasName("PK__AccountN__5386F4486B6B6243");

                            j.ToTable("AccountNotification");
                        });

                entity.HasMany(d => d.Teams)
                    .WithMany(p => p.Notifications)
                    .UsingEntity<Dictionary<string, object>>(
                        "TeamNotification",
                        l => l.HasOne<Team>().WithMany().HasForeignKey("TeamId").HasConstraintName("FK__TeamNotif__TeamI__2610A626"),
                        r => r.HasOne<Notification>().WithMany().HasForeignKey("NotificationId").HasConstraintName("FK__TeamNotif__Notif__251C81ED"),
                        j =>
                        {
                            j.HasKey("NotificationId", "TeamId").HasName("PK__TeamNoti__A1EC806BE7589E77");

                            j.ToTable("TeamNotification");
                        });
            });

            modelBuilder.Entity<Portoflio>(entity =>
            {
                entity.HasOne(d => d.Freelancer)
                    .WithMany(p => p.Portoflios)
                    .HasForeignKey(d => d.FreelancerId)
                    .HasConstraintName("FK__Portoflio__Freel__756D6ECB");

                entity.HasMany(d => d.Skills)
                    .WithMany(p => p.Portoflios)
                    .UsingEntity<Dictionary<string, object>>(
                        "PortoflioSkill",
                        l => l.HasOne<Skill>().WithMany().HasForeignKey("SkillId").HasConstraintName("FK__Portoflio__Skill__7B264821"),
                        r => r.HasOne<Portoflio>().WithMany().HasForeignKey("PortoflioId").HasConstraintName("FK__Portoflio__Porto__7A3223E8"),
                        j =>
                        {
                            j.HasKey("PortoflioId", "SkillId").HasName("PK__Portofli__66C7E7F270BD223A");

                            j.ToTable("PortoflioSkill");
                        });
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Projects)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Project__ClientI__3552E9B6");

                entity.HasMany(d => d.Skills)
                    .WithMany(p => p.Projects)
                    .UsingEntity<Dictionary<string, object>>(
                        "ProjectSkill",
                        l => l.HasOne<Skill>().WithMany().HasForeignKey("SkillId").HasConstraintName("FK__ProjectSk__Skill__3DE82FB7"),
                        r => r.HasOne<Project>().WithMany().HasForeignKey("ProjectId").HasConstraintName("FK__ProjectSk__Proje__3CF40B7E"),
                        j =>
                        {
                            j.HasKey("ProjectId", "SkillId").HasName("PK__ProjectS__1BE0B7E8198B9A65");

                            j.ToTable("ProjectSkill");
                        });
            });

            modelBuilder.Entity<ProjectPayment>(entity =>
            {
                entity.HasKey(e => new { e.TransactionId, e.ClientId, e.ProjectId })
                    .HasName("PK__ProjectP__FA52C177090056E2");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.ProjectPayments)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ProjectPa__Clien__59904A2C");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.ProjectPayments)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ProjectPa__Proje__5A846E65");

                entity.HasOne(d => d.Transaction)
                    .WithMany(p => p.ProjectPayments)
                    .HasForeignKey(d => d.TransactionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ProjectPa__Trans__589C25F3");
            });

            modelBuilder.Entity<Proposal>(entity =>
            {
                entity.HasOne(d => d.Project)
                    .WithMany(p => p.Proposals)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Proposal__Projec__53D770D6");

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.Proposals)
                    .HasForeignKey(d => d.TeamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Proposal__TeamId__52E34C9D");
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.HasKey(e => new { e.ClientId, e.TeamId, e.ProjectId })
                    .HasName("PK__Review__962BAEE3E5EB3931");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Review__ClientId__4A4E069C");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Review__ProjectI__4C364F0E");

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.TeamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Review__TeamId__4B422AD5");
            });

            modelBuilder.Entity<Team>(entity =>
            {
                entity.HasOne(d => d.Leader)
                    .WithMany(p => p.Teams)
                    .HasForeignKey(d => d.LeaderId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK__Team__LeaderId__214BF109");

                entity.HasOne(d => d.Wallet)
                    .WithMany(p => p.Teams)
                    .HasForeignKey(d => d.WalletId)
                    .HasConstraintName("FK__Team__WalletId__22401542");
            });

            modelBuilder.Entity<TeamFreelancerMessage>(entity =>
            {
                entity.HasOne(d => d.Client)
                    .WithMany(p => p.TeamFreelancerMessages)
                    .HasForeignKey(d => d.ClientId)
                    .HasConstraintName("FK__TeamFreel__Clien__4F12BBB9");

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.TeamFreelancerMessages)
                    .HasForeignKey(d => d.TeamId)
                    .HasConstraintName("FK__TeamFreel__TeamI__5006DFF2");
            });

            modelBuilder.Entity<TeamMember>(entity =>
            {
                entity.HasKey(e => new { e.TeamId, e.FreelancerId })
                    .HasName("PK__TeamMemb__C1EAE9AF710A3332");

                entity.HasOne(d => d.Freelancer)
                    .WithMany(p => p.TeamMembers)
                    .HasForeignKey(d => d.FreelancerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TeamMembe__Freel__2DB1C7EE");

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.TeamMembers)
                    .HasForeignKey(d => d.TeamId)
                    .HasConstraintName("FK__TeamMembe__TeamI__2CBDA3B5");
            });

            modelBuilder.Entity<TeamTransaction>(entity =>
            {
                entity.HasKey(e => new { e.TeamId, e.FreelancerId, e.ProjectId })
                    .HasName("PK__TeamTran__309CF3116E92BA18");

                entity.HasOne(d => d.Freelancer)
                    .WithMany(p => p.TeamTransactions)
                    .HasForeignKey(d => d.FreelancerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TeamTrans__Freel__39237A9A");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.TeamTransactions)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TeamTrans__Proje__3A179ED3");

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.TeamTransactions)
                    .HasForeignKey(d => d.TeamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TeamTrans__TeamI__382F5661");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.AdminValidatedNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.AdminValidated)
                    .HasConstraintName("FK__User__AdminValid__55009F39");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.User)
                    .HasForeignKey<User>(d => d.Id)
                    .HasConstraintName("FK__User__Id__540C7B00");

                entity.HasOne(d => d.Wallet)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.WalletId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK__User__WalletId__55F4C372");
            });

            modelBuilder.Entity<UserCredit>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.CreditNumber })
                    .HasName("PK__UserCred__3DBB4B31B52C3E45");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserCredits)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__UserCredi__UserI__5BAD9CC8");
            });

            modelBuilder.Entity<UserLanguage>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.Language })
                    .HasName("PK__UserLang__1BB59569F2B9521D");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserLanguages)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__UserLangu__UserI__58D1301D");
            });

            modelBuilder.Entity<UserSocial>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.Type })
                    .HasName("PK__UserSoci__A81346041E620401");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserSocials)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__UserSocia__UserI__5E8A0973");
            });

            modelBuilder.HasSequence<int>("SalesOrderNumber", "SalesLT");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}