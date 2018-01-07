using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace KnownProblemApi.Models.Context
{
    public class KnownProblemContext: DbContext
    {
        public KnownProblemContext(DbContextOptions<KnownProblemContext> options):base(options)
        {
        }

        public DbSet<Problem> ProblemItems { get; set; }
    }
}
