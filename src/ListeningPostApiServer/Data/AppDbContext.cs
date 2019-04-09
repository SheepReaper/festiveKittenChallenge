using ListeningPostApiServer.Models;
using Microsoft.EntityFrameworkCore;

namespace ListeningPostApiServer.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<CommandTask> CommandTasks { get; set; }
        public DbSet<DeployTask> DeployTasks { get; set; }
        public DbSet<Implant> Implants { get; set; }
        public DbSet<PayloadFile> PayloadFiles { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<ExfiltratedFile> RetrievedFiles { get; set; }
        public DbSet<RetrieveTask> RetrieveTasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaskBase>().ToTable("Tasks")
                .HasOne(t => t.Result)
                .WithOne(r => r.TaskBase)
                .HasForeignKey<Result>(r => r.TaskId);
            modelBuilder.Entity<FileBase>().ToTable("Files");
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (optionsBuilder.IsConfigured) return;
        //    optionsBuilder.UseLazyLoadingProxies();
        //}
    }
}