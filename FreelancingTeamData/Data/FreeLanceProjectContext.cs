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
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("DefaultConnection");
            }
        }
        public FreeLanceProjectContext()
        {
        }

        public FreeLanceProjectContext(DbContextOptions<FreeLanceProjectContext> options)
            : base(options)
        {
            
        }

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
        public virtual DbSet<UserConnection> UserConnections { get; set; }
        public virtual DbSet<UserCredit> UserCredits { get; set; }
        public virtual DbSet<UserLanguage> UserLanguages { get; set; }
        public virtual DbSet<UserSocial> UserSocials { get; set; }
        public virtual DbSet<Wallet> Wallets { get; set; }

   
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountMessage>(entity =>
            {
                entity.HasOne(d => d.Reciever)
                    .WithMany(p => p.AccountMessageRecievers)
                    .HasForeignKey(d => d.RecieverId)
                    .HasConstraintName("FK__AccountMe__Recie__5E1FF51F");

                entity.HasOne(d => d.Sender)
                    .WithMany(p => p.AccountMessageSenders)
                    .HasForeignKey(d => d.SenderId)
                    .HasConstraintName("FK__AccountMe__Sende__5D2BD0E6");
            });

            modelBuilder.Entity<Admin>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Admin)
                    .HasForeignKey<Admin>(d => d.Id)
                    .HasConstraintName("FK__Admin__Id__7FB5F314");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasMany(d => d.Skills)
                    .WithMany(p => p.Categories)
                    .UsingEntity<Dictionary<string, object>>(
                        "SkillCategory",
                        l => l.HasOne<Skill>().WithMany().HasForeignKey("SkillId").HasConstraintName("FK__SkillCate__Skill__2B947552"),
                        r => r.HasOne<Category>().WithMany().HasForeignKey("CategoryId").HasConstraintName("FK__SkillCate__Categ__2AA05119"),
                        j =>
                        {
                            j.HasKey("CategoryId", "SkillId").HasName("PK__SkillCat__74F33313388D917B");

                            j.ToTable("SkillCategory");
                        });
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.ClientNavigation)
                    .HasForeignKey<Client>(d => d.Id)
                    .HasConstraintName("FK__Client__Id__11D4A34F");
            });

            modelBuilder.Entity<Complain>(entity =>
            {
                entity.HasOne(d => d.AdminHandler)
                    .WithMany(p => p.Complains)
                    .HasForeignKey(d => d.AdminHandlerId)
                    .HasConstraintName("FK__Complain__AdminH__6D6238AF");

                entity.HasOne(d => d.ComplainingTeam)
                    .WithMany(p => p.Complains)
                    .HasForeignKey(d => d.ComplainingTeamId)
                    .HasConstraintName("FK__Complain__Compla__6C6E1476");

                entity.HasOne(d => d.ComplainingUser)
                    .WithMany(p => p.Complains)
                    .HasForeignKey(d => d.ComplainingUserId)
                    .HasConstraintName("FK__Complain__Compla__6B79F03D");
            });

            modelBuilder.Entity<Deal>(entity =>
            {
                entity.HasKey(e => new { e.ClientId, e.TeamId, e.ProjectId })
                    .HasName("PK__Deal__962BAEE3191C1A56");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Deals)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Deal__ClientId__4FD1D5C8");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.Deals)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Deal__ProjectId__51BA1E3A");

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.Deals)
                    .HasForeignKey(d => d.TeamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Deal__TeamId__50C5FA01");
            });

            modelBuilder.Entity<Freelancer>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.FreelancerNavigation)
                    .HasForeignKey<Freelancer>(d => d.Id)
                    .HasConstraintName("FK__Freelancer__Id__14B10FFA");
            });

            modelBuilder.Entity<FreelancerCertificate>(entity =>
            {
                entity.HasKey(e => new { e.FreelancerId, e.Title })
                    .HasName("PK__Freelanc__FFCB8521DBDD6D3D");

                entity.HasOne(d => d.Freelancer)
                    .WithMany(p => p.FreelancerCertificates)
                    .HasForeignKey(d => d.FreelancerId)
                    .HasConstraintName("FK__Freelance__Freel__1D4655FB");
            });

            modelBuilder.Entity<FreelancerEducation>(entity =>
            {
                entity.HasKey(e => new { e.FreelancerId, e.gradYear })
                    .HasName("PK__Freelanc__E5D6D5979BA651C1");

                entity.HasOne(d => d.Freelancer)
                    .WithMany(p => p.FreelancerEducations)
                    .HasForeignKey(d => d.FreelancerId)
                    .HasConstraintName("FK__Freelance__Freel__178D7CA5");
            });

            modelBuilder.Entity<FreelancerExperience>(entity =>
            {
                entity.HasKey(e => new { e.FreelancerId, e.StartDate })
                    .HasName("PK__Freelanc__59E17CA330D926BC");

                entity.HasOne(d => d.Freelancer)
                    .WithMany(p => p.FreelancerExperiences)
                    .HasForeignKey(d => d.FreelancerId)
                    .HasConstraintName("FK__Freelance__Freel__1A69E950");
            });

            modelBuilder.Entity<FreelancerSkill>(entity =>
            {
                entity.HasKey(e => new { e.FreelancerId, e.SkillId })
                    .HasName("PK__Freelanc__50FAEA74C8301E2D");

                entity.HasOne(d => d.Freelancer)
                    .WithMany(p => p.FreelancerSkills)
                    .HasForeignKey(d => d.FreelancerId)
                    .HasConstraintName("FK__Freelance__Freel__2E70E1FD");

                entity.HasOne(d => d.Skill)
                    .WithMany(p => p.FreelancerSkills)
                    .HasForeignKey(d => d.SkillId)
                    .HasConstraintName("FK__Freelance__Skill__2F650636");
            });

            modelBuilder.Entity<Notification>(entity =>
            {
                entity.HasMany(d => d.Accounts)
                    .WithMany(p => p.Notifications)
                    .UsingEntity<Dictionary<string, object>>(
                        "AccountNotification",
                        l => l.HasOne<Account>().WithMany().HasForeignKey("AccountId").HasConstraintName("FK__AccountNo__Accou__351DDF8C"),
                        r => r.HasOne<Notification>().WithMany().HasForeignKey("NotificationId").HasConstraintName("FK__AccountNo__Notif__3429BB53"),
                        j =>
                        {
                            j.HasKey("NotificationId", "AccountId").HasName("PK__AccountN__5386F448F44F9DD2");

                            j.ToTable("AccountNotification");
                        });

                entity.HasMany(d => d.Teams)
                    .WithMany(p => p.Notifications)
                    .UsingEntity<Dictionary<string, object>>(
                        "TeamNotification",
                        l => l.HasOne<Team>().WithMany().HasForeignKey("TeamId").HasConstraintName("FK__TeamNotif__TeamI__3DB3258D"),
                        r => r.HasOne<Notification>().WithMany().HasForeignKey("NotificationId").HasConstraintName("FK__TeamNotif__Notif__3CBF0154"),
                        j =>
                        {
                            j.HasKey("NotificationId", "TeamId").HasName("PK__TeamNoti__A1EC806B0412EE6B");

                            j.ToTable("TeamNotification");
                        });
            });

            modelBuilder.Entity<Portoflio>(entity =>
            {
                entity.HasOne(d => d.Freelancer)
                    .WithMany(p => p.Portoflios)
                    .HasForeignKey(d => d.FreelancerId)
                    .HasConstraintName("FK__Portoflio__Freel__2022C2A6");

                entity.HasMany(d => d.Skills)
                    .WithMany(p => p.Portoflios)
                    .UsingEntity<Dictionary<string, object>>(
                        "PortoflioSkill",
                        l => l.HasOne<Skill>().WithMany().HasForeignKey("SkillId").HasConstraintName("FK__Portoflio__Skill__25DB9BFC"),
                        r => r.HasOne<Portoflio>().WithMany().HasForeignKey("PortoflioId").HasConstraintName("FK__Portoflio__Porto__24E777C3"),
                        j =>
                        {
                            j.HasKey("PortoflioId", "SkillId").HasName("PK__Portofli__66C7E7F2748C93FA");

                            j.ToTable("PortoflioSkill");
                        });
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Projects)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Project__ClientI__4460231C");

                entity.HasMany(d => d.Skills)
                    .WithMany(p => p.Projects)
                    .UsingEntity<Dictionary<string, object>>(
                        "ProjectSkill",
                        l => l.HasOne<Skill>().WithMany().HasForeignKey("SkillId").HasConstraintName("FK__ProjectSk__Skill__4CF5691D"),
                        r => r.HasOne<Project>().WithMany().HasForeignKey("ProjectId").HasConstraintName("FK__ProjectSk__Proje__4C0144E4"),
                        j =>
                        {
                            j.HasKey("ProjectId", "SkillId").HasName("PK__ProjectS__1BE0B7E830A87847");

                            j.ToTable("ProjectSkill");
                        });
            });

            modelBuilder.Entity<ProjectPayment>(entity =>
            {
                entity.HasKey(e => new { e.TransactionId, e.ClientId, e.ProjectId })
                    .HasName("PK__ProjectP__FA52C177AB532527");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.ProjectPayments)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ProjectPa__Clien__67A95F59");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.ProjectPayments)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ProjectPa__Proje__689D8392");

                entity.HasOne(d => d.Transaction)
                    .WithMany(p => p.ProjectPayments)
                    .HasForeignKey(d => d.TransactionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ProjectPa__Trans__66B53B20");
            });

            modelBuilder.Entity<Proposal>(entity =>
            {
                entity.HasOne(d => d.Project)
                    .WithMany(p => p.Proposals)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Proposal__Projec__61F08603");

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.Proposals)
                    .HasForeignKey(d => d.TeamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Proposal__TeamId__60FC61CA");
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.HasKey(e => new { e.ClientId, e.TeamId, e.ProjectId })
                    .HasName("PK__Review__962BAEE3193D27B0");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Review__ClientId__54968AE5");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Review__ProjectI__567ED357");

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.TeamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Review__TeamId__558AAF1E");
            });

            modelBuilder.Entity<Team>(entity =>
            {
                entity.HasOne(d => d.Leader)
                    .WithMany(p => p.Teams)
                    .HasForeignKey(d => d.LeaderId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK__Team__LeaderId__38EE7070");

                entity.HasOne(d => d.Wallet)
                    .WithMany(p => p.Teams)
                    .HasForeignKey(d => d.WalletId)
                    .HasConstraintName("FK__Team__WalletId__39E294A9");
            });

            modelBuilder.Entity<TeamFreelancerMessage>(entity =>
            {
                entity.HasOne(d => d.Team)
                    .WithMany(p => p.TeamFreelancerMessages)
                    .HasForeignKey(d => d.TeamId)
                    .HasConstraintName("FK__TeamFreel__TeamI__5A4F643B");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TeamFreelancerMessages)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_TeamFreelancerMessages_User");
            });

            modelBuilder.Entity<TeamMember>(entity =>
            {
                entity.HasKey(e => new { e.TeamId, e.FreelancerId })
                    .HasName("PK__TeamMemb__C1EAE9AFE99C2D7A");

                entity.HasOne(d => d.Freelancer)
                    .WithMany(p => p.TeamMembers)
                    .HasForeignKey(d => d.FreelancerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TeamMembe__Freel__4183B671");

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.TeamMembers)
                    .HasForeignKey(d => d.TeamId)
                    .HasConstraintName("FK__TeamMembe__TeamI__408F9238");
            });

            modelBuilder.Entity<TeamTransaction>(entity =>
            {
                entity.HasKey(e => new { e.TeamId, e.FreelancerId, e.ProjectId })
                    .HasName("PK__TeamTran__309CF31166E82BA1");

                entity.HasOne(d => d.Freelancer)
                    .WithMany(p => p.TeamTransactions)
                    .HasForeignKey(d => d.FreelancerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TeamTrans__Freel__4830B400");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.TeamTransactions)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TeamTrans__Proje__4924D839");

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.TeamTransactions)
                    .HasForeignKey(d => d.TeamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TeamTrans__TeamI__473C8FC7");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.AdminValidatedNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.AdminValidated)
                    .HasConstraintName("FK__User__AdminValid__056ECC6A");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.User)
                    .HasForeignKey<User>(d => d.Id)
                    .HasConstraintName("FK__User__Id__047AA831");

                entity.HasOne(d => d.Wallet)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.WalletId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK__User__WalletId__0662F0A3");
            });

            modelBuilder.Entity<UserConnection>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.ConnectionId });

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserConnections)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserConnection_Account");
            });

            modelBuilder.Entity<UserCredit>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.CreditNumber })
                    .HasName("PK__UserCred__3DBB4B31B1931CD5");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserCredits)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__UserCredi__UserI__0C1BC9F9");
            });

            modelBuilder.Entity<UserLanguage>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.Language })
                    .HasName("PK__UserLang__1BB59569686CFB1A");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserLanguages)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__UserLangu__UserI__093F5D4E");
            });

            modelBuilder.Entity<UserSocial>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.Type })
                    .HasName("PK__UserSoci__A8134604CD1BFF8F");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserSocials)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__UserSocia__UserI__0EF836A4");
            });

            modelBuilder.HasSequence<int>("SalesOrderNumber", "SalesLT");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}