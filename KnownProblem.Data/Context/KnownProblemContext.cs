using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using KnownProblem.Data.Entity;

namespace KnownProblem.Data.Context
{
    public class KnownProblemContext: DbContext
    {
        public KnownProblemContext(DbContextOptions<KnownProblemContext> options):base(options)
        {
        }

        public DbSet<Problem> ProblemItems { get; set; }
        public DbSet<Tag> TagItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var problemBuilder = modelBuilder.Entity<Problem>();
            problemBuilder.HasKey(p => p.Id);
            problemBuilder.HasOne<Tag>(p => p.Tag).WithMany(t => t.Problems);

            var tagBuilder = modelBuilder.Entity<Tag>();
            tagBuilder.HasKey(t => t.Id);

            base.OnModelCreating(modelBuilder);
        }
    }
}
