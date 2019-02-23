using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace test_reverse_engineer.Models
{
    public partial class pmo_dbContext : DbContext
    {
        public pmo_dbContext()
        {
        }

        public pmo_dbContext(DbContextOptions<pmo_dbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Assign> Assign { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Closing> Closing { get; set; }
        public virtual DbSet<Document> Document { get; set; }
        public virtual DbSet<Execute> Execute { get; set; }
        public virtual DbSet<Initiative> Initiative { get; set; }
        public virtual DbSet<Permission> Permission { get; set; }
        public virtual DbSet<Plan> Plan { get; set; }
        public virtual DbSet<Project> Project { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<RoleHasPermission> RoleHasPermission { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.2-servicing-10034");

            modelBuilder.Entity<Assign>(entity =>
            {
                entity.ToTable("ASSIGN");

                entity.HasIndex(e => e.ProjectId)
                    .HasName("RELATIONSHIP_1_FK");

                entity.HasIndex(e => e.RoleId)
                    .HasName("RELATIONSHIP_2_FK");

                entity.HasIndex(e => e.UserId)
                    .HasName("RELATIONSHIP_3_FK");

                entity.Property(e => e.AssignId).HasColumnName("ASSIGN_ID");

                entity.Property(e => e.AssignCreatedDate)
                    .HasColumnName("ASSIGN_CREATED_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.AssignModifiedDate)
                    .HasColumnName("ASSIGN_MODIFIED_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.ProjectId).HasColumnName("PROJECT_ID");

                entity.Property(e => e.RoleId).HasColumnName("ROLE_ID");

                entity.Property(e => e.UserId).HasColumnName("USER_ID");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.Assign)
                    .HasForeignKey(d => d.ProjectId)
                    .HasConstraintName("FK_ASSIGN_RELATIONS_PROJECT");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Assign)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_ASSIGN_RELATIONS_ROLE");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Assign)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_ASSIGN_RELATIONS_USER");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("CATEGORY");

                entity.Property(e => e.CategoryId).HasColumnName("CATEGORY_ID");

                entity.Property(e => e.CategoryCreatedDate)
                    .HasColumnName("CATEGORY_CREATED_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.CategoryDescription)
                    .HasColumnName("CATEGORY_DESCRIPTION")
                    .HasColumnType("text");

                entity.Property(e => e.CategoryModifiedDate)
                    .HasColumnName("CATEGORY_MODIFIED_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.CategoryName)
                    .HasColumnName("CATEGORY_NAME")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.FileStream).HasColumnName("FILE_STREAM");
            });

            modelBuilder.Entity<Closing>(entity =>
            {
                entity.ToTable("CLOSING");

                entity.HasIndex(e => e.ProjectId)
                    .HasName("RELATIONSHIP_9_FK");

                entity.Property(e => e.ClosingId).HasColumnName("CLOSING_ID");

                entity.Property(e => e.ClosingLessonLearned)
                    .HasColumnName("CLOSING_LESSON_LEARNED")
                    .HasColumnType("text");

                entity.Property(e => e.ProjectId).HasColumnName("PROJECT_ID");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.Closing)
                    .HasForeignKey(d => d.ProjectId)
                    .HasConstraintName("FK_CLOSING_RELATIONS_PROJECT");
            });

            modelBuilder.Entity<Document>(entity =>
            {
                entity.HasKey(e => e.DocId);

                entity.ToTable("DOCUMENT");

                entity.HasIndex(e => e.CategoryId)
                    .HasName("RELATIONSHIP_15_FK");

                entity.HasIndex(e => e.ProjectId)
                    .HasName("RELATIONSHIP_14_FK");

                entity.Property(e => e.DocId).HasColumnName("DOC_ID");

                entity.Property(e => e.CategoryId).HasColumnName("CATEGORY_ID");

                entity.Property(e => e.DocCreatedDate)
                    .HasColumnName("DOC_CREATED_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.DocDescription)
                    .HasColumnName("DOC_DESCRIPTION")
                    .HasColumnType("text");

                entity.Property(e => e.DocModifiedDate)
                    .HasColumnName("DOC_MODIFIED_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.DocName)
                    .HasColumnName("DOC_NAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DocStatus)
                    .HasColumnName("DOC_STATUS")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.DocStream).HasColumnName("DOC_STREAM");

                entity.Property(e => e.ProjectId).HasColumnName("PROJECT_ID");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Document)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_DOCUMENT_RELATIONS_CATEGORY");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.Document)
                    .HasForeignKey(d => d.ProjectId)
                    .HasConstraintName("FK_DOCUMENT_RELATIONS_PROJECT");
            });

            modelBuilder.Entity<Execute>(entity =>
            {
                entity.ToTable("EXECUTE");

                entity.HasIndex(e => e.ProjectId)
                    .HasName("RELATIONSHIP_11_FK");

                entity.Property(e => e.ExecuteId).HasColumnName("EXECUTE_ID");

                entity.Property(e => e.ExecuteLessonLearned)
                    .HasColumnName("EXECUTE_LESSON_LEARNED")
                    .HasColumnType("text");

                entity.Property(e => e.ProjectId).HasColumnName("PROJECT_ID");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.Execute)
                    .HasForeignKey(d => d.ProjectId)
                    .HasConstraintName("FK_EXECUTE_RELATIONS_PROJECT");
            });

            modelBuilder.Entity<Initiative>(entity =>
            {
                entity.ToTable("INITIATIVE");

                entity.HasIndex(e => e.ProjectId)
                    .HasName("RELATIONSHIP_7_FK");

                entity.Property(e => e.InitiativeId).HasColumnName("INITIATIVE_ID");

                entity.Property(e => e.AcknowledgedBy)
                    .HasColumnName("ACKNOWLEDGED_BY")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AgreedBy)
                    .HasColumnName("AGREED_BY")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BackgroundInformation)
                    .HasColumnName("BACKGROUND_INFORMATION")
                    .HasColumnType("text");

                entity.Property(e => e.Building)
                    .HasColumnName("BUILDING")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Contingency)
                    .HasColumnName("CONTINGENCY")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Equipment)
                    .HasColumnName("EQUIPMENT")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.ExecutiveSummary)
                    .HasColumnName("EXECUTIVE_SUMMARY")
                    .HasColumnType("text");

                entity.Property(e => e.ExpenseUnderDevelopment)
                    .HasColumnName("EXPENSE_UNDER_DEVELOPMENT")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Infrastructure)
                    .HasColumnName("INFRASTRUCTURE")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.InitiativeLessonLearned)
                    .HasColumnName("INITIATIVE_LESSON_LEARNED")
                    .HasColumnType("text");

                entity.Property(e => e.InitiativeTitle)
                    .HasColumnName("INITIATIVE_TITLE")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LandCompensation)
                    .HasColumnName("LAND_COMPENSATION")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.LandImprovement)
                    .HasColumnName("LAND_IMPROVEMENT")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Objective)
                    .HasColumnName("OBJECTIVE")
                    .HasColumnType("text");

                entity.Property(e => e.ObjectiveBenefit)
                    .HasColumnName("OBJECTIVE_BENEFIT")
                    .HasColumnType("text");

                entity.Property(e => e.PlantMachine)
                    .HasColumnName("PLANT_MACHINE")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.PreparedDate)
                    .HasColumnName("PREPARED_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.ProjectDefinition)
                    .HasColumnName("PROJECT_DEFINITION")
                    .HasColumnType("text");

                entity.Property(e => e.ProjectId).HasColumnName("PROJECT_ID");

                entity.Property(e => e.RequestedBy)
                    .HasColumnName("REQUESTED_BY")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Timeline)
                    .HasColumnName("TIMELINE")
                    .HasColumnType("text");

                entity.Property(e => e.Total)
                    .HasColumnName("TOTAL")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Vision)
                    .HasColumnName("VISION")
                    .HasColumnType("text");

                entity.Property(e => e.WorkingCapital)
                    .HasColumnName("WORKING_CAPITAL")
                    .HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.Initiative)
                    .HasForeignKey(d => d.ProjectId)
                    .HasConstraintName("FK_INITIATI_RELATIONS_PROJECT");
            });

            modelBuilder.Entity<Permission>(entity =>
            {
                entity.ToTable("PERMISSION");

                entity.Property(e => e.PermissionId).HasColumnName("PERMISSION_ID");

                entity.Property(e => e.PermissionCreatedDate)
                    .HasColumnName("PERMISSION_CREATED_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.PermissionModifiedDate)
                    .HasColumnName("PERMISSION_MODIFIED_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.PermissionName)
                    .HasColumnName("PERMISSION_NAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Plan>(entity =>
            {
                entity.ToTable("PLAN");

                entity.HasIndex(e => e.ProjectId)
                    .HasName("RELATIONSHIP_13_FK");

                entity.Property(e => e.PlanId).HasColumnName("PLAN_ID");

                entity.Property(e => e.PlanLessonLearned)
                    .HasColumnName("PLAN_LESSON_LEARNED")
                    .HasColumnType("text");

                entity.Property(e => e.ProjectId).HasColumnName("PROJECT_ID");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.Plan)
                    .HasForeignKey(d => d.ProjectId)
                    .HasConstraintName("FK_PLAN_RELATIONS_PROJECT");
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.ToTable("PROJECT");

                entity.HasIndex(e => e.ClosingId)
                    .HasName("RELATIONSHIP_8_FK");

                entity.HasIndex(e => e.ExecuteId)
                    .HasName("RELATIONSHIP_10_FK");

                entity.HasIndex(e => e.InitiativeId)
                    .HasName("RELATIONSHIP_6_FK");

                entity.HasIndex(e => e.PlanId)
                    .HasName("RELATIONSHIP_12_FK");

                entity.Property(e => e.ProjectId).HasColumnName("PROJECT_ID");

                entity.Property(e => e.ClosingId).HasColumnName("CLOSING_ID");

                entity.Property(e => e.ExecuteId).HasColumnName("EXECUTE_ID");

                entity.Property(e => e.InitiativeId).HasColumnName("INITIATIVE_ID");

                entity.Property(e => e.PlanId).HasColumnName("PLAN_ID");

                entity.Property(e => e.ProjectCategory)
                    .HasColumnName("PROJECT_CATEGORY")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ProjectCreatedDate)
                    .HasColumnName("PROJECT_CREATED_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.ProjectDescription)
                    .HasColumnName("PROJECT_DESCRIPTION")
                    .HasColumnType("text");

                entity.Property(e => e.ProjectModifiedDate)
                    .HasColumnName("PROJECT_MODIFIED_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.ProjectStatus)
                    .HasColumnName("PROJECT_STATUS")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.ProjectTitle)
                    .HasColumnName("PROJECT_TITLE")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.ClosingNavigation)
                    .WithMany(p => p.ProjectNavigation)
                    .HasForeignKey(d => d.ClosingId)
                    .HasConstraintName("FK_PROJECT_RELATIONS_CLOSING");

                entity.HasOne(d => d.ExecuteNavigation)
                    .WithMany(p => p.ProjectNavigation)
                    .HasForeignKey(d => d.ExecuteId)
                    .HasConstraintName("FK_PROJECT_RELATIONS_EXECUTE");

                entity.HasOne(d => d.InitiativeNavigation)
                    .WithMany(p => p.ProjectNavigation)
                    .HasForeignKey(d => d.InitiativeId)
                    .HasConstraintName("FK_PROJECT_RELATIONS_INITIATI");

                entity.HasOne(d => d.PlanNavigation)
                    .WithMany(p => p.ProjectNavigation)
                    .HasForeignKey(d => d.PlanId)
                    .HasConstraintName("FK_PROJECT_RELATIONS_PLAN");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("ROLE");

                entity.Property(e => e.RoleId).HasColumnName("ROLE_ID");

                entity.Property(e => e.RoleCreatedDate)
                    .HasColumnName("ROLE_CREATED_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.RoleModifiedDate)
                    .HasColumnName("ROLE_MODIFIED_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.RoleName)
                    .HasColumnName("ROLE_NAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RoleHasPermission>(entity =>
            {
                entity.HasKey(e => new { e.RhpId, e.RoleId, e.PermissionId });

                entity.ToTable("ROLE_HAS_PERMISSION");

                entity.HasIndex(e => e.PermissionId)
                    .HasName("RELATIONSHIP_5_FK");

                entity.HasIndex(e => e.RoleId)
                    .HasName("RELATIONSHIP_4_FK");

                entity.Property(e => e.RhpId)
                    .HasColumnName("RHP_ID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.RoleId).HasColumnName("ROLE_ID");

                entity.Property(e => e.PermissionId).HasColumnName("PERMISSION_ID");

                entity.Property(e => e.RhpCreatedDate)
                    .HasColumnName("RHP_CREATED_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.RhpModifiedDate)
                    .HasColumnName("RHP_MODIFIED_DATE")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.Permission)
                    .WithMany(p => p.RoleHasPermission)
                    .HasForeignKey(d => d.PermissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ROLE_HAS_RELATIONS_PERMISSI");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.RoleHasPermission)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ROLE_HAS_RELATIONS_ROLE");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("USER");

                entity.Property(e => e.UserId).HasColumnName("USER_ID");

                entity.Property(e => e.UserCreatedDate)
                    .HasColumnName("USER_CREATED_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.UserEmail)
                    .HasColumnName("USER_EMAIL")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UserModifiedDate)
                    .HasColumnName("USER_MODIFIED_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.UserName)
                    .HasColumnName("USER_NAME")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.UserPassword)
                    .HasColumnName("USER_PASSWORD")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.UserStatus)
                    .HasColumnName("USER_STATUS")
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });
        }
    }
}
