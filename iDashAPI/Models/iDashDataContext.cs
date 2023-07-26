using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
namespace iDashAPI.Models
{
    public partial class iDashDataContext : DbContext
    {
        public virtual DbSet<AppDynamicsData> AppDynamicsData { get; set; }
        public virtual DbSet<GoogleAnalyticsData> GoogleAnalyticsData { get; set; }
        public virtual DbSet<IDashDefinitions> IDashDefinitions { get; set; }
        public virtual DbSet<IDashMetrics> IDashMetrics { get; set; }
        public virtual DbSet<SonarQubeData> SonarQubeData { get; set; }
        public virtual DbSet<TestCoverageData> TestCoverageData { get; set; }

        //        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //        {
        //            if (!optionsBuilder.IsConfigured)
        //            {
        //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
        //                optionsBuilder.UseSqlServer(@"Server=QA1TSIMTM1;Initial Catalog=iDashData;User Id=idashdatauser;Password='2aY}L(f""';");
        //            }
        //        }


        public iDashDataContext(DbContextOptions<iDashDataContext> options): base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppDynamicsData>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AppId)
                    .HasColumnName("AppID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AppName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DateInserted).HasColumnType("datetime");

                entity.Property(e => e.DateLastUpdated).HasColumnType("datetime");

                entity.Property(e => e.MetricName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MetricValue)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<GoogleAnalyticsData>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AppId)
                    .HasColumnName("AppID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AppName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DateInserted).HasColumnType("datetime");

                entity.Property(e => e.DateLastUpdated).HasColumnType("datetime");

                entity.Property(e => e.MetricName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MetricValue)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<IDashDefinitions>(entity =>
            {
                entity.HasKey(e => e.FriendlyMetricName);

                entity.ToTable("iDashDefinitions", "ref");

                entity.Property(e => e.FriendlyMetricName)
                    .HasMaxLength(100)
                    .ValueGeneratedNever();

                entity.Property(e => e.Definition).HasMaxLength(500);

                entity.Property(e => e.InsertedBy)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.InsertedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(sysdatetime())");

                entity.Property(e => e.LastUpdatedBy)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.LastUpdatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(sysdatetime())");

                entity.Property(e => e.Significance).HasMaxLength(500);
            });

            modelBuilder.Entity<IDashMetrics>(entity =>
            {
                entity.HasKey(e => e.ApplicationMetricName);

                entity.ToTable("iDashMetrics", "ref");

                entity.Property(e => e.ApplicationMetricName)
                    .HasMaxLength(100)
                    .ValueGeneratedNever();

                entity.Property(e => e.Bucket)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FriendlyMetricName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.InsertedBy)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.InsertedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(sysdatetime())");

                entity.Property(e => e.LastUpdatedBy)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.LastUpdatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(sysdatetime())");

                entity.Property(e => e.MetricLevel)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SonarQubeData>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AppId)
                    .HasColumnName("AppID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AppName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DateInserted).HasColumnType("datetime");

                entity.Property(e => e.DateLastUpdated).HasColumnType("datetime");

                entity.Property(e => e.MetricName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MetricValue)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TestCoverageData>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AppId)
                    .HasColumnName("AppID")
                    .HasMaxLength(50);

                entity.Property(e => e.AppName).HasMaxLength(50);

                entity.Property(e => e.DateInserted).HasColumnType("datetime");

                entity.Property(e => e.DateLastUpdated).HasColumnType("datetime");

                entity.Property(e => e.MetricName).HasMaxLength(50);

                entity.Property(e => e.MetricValue).HasMaxLength(50);
            });
        }
    }
}
