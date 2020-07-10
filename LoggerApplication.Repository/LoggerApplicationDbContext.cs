using LoggerApplication.Repository.Domain.Logging;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoggerApplication.Repository
{
    public class LoggerApplicationDbContext : DbContext
    {
        public LoggerApplicationDbContext(DbContextOptions<LoggerApplicationDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Log> Log { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.RemovePluralizingTableNameConvention();
        }
    }
}
