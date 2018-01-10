using KnownProblem.Data.Context;
using KnownProblem.Data.Entity;
using KnownProblem.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Xunit;
using System.Linq;

namespace UnitTest.Data
{
    public class ProblemRepositoryTest
    {
  

        private DbContext GetDbContext()
        {
            DbContextOptionsBuilder builder = new DbContextOptionsBuilder<KnownProblemContext>();
            builder.UseInMemoryDatabase("KnownProblemTest");
            return new KnownProblemContext((DbContextOptions<KnownProblemContext>) builder.Options);
        }

        [Fact]
        public void IsWorkingSomehow()
        {
            IRepository<Problem> repository = new EntityRepository<Problem>(GetDbContext());
            repository.GetAll();
        }

        [Fact]
        public void CreateNewProblemWithoutTag()
        {
            IRepository<Problem> repository = new EntityRepository<Problem>(GetDbContext());
            var problem = new Problem
            {
                Title = "Test",
                Description = "This is a test Problem",
                IsResolved = false
            };

            Assert.True(repository.Insert(problem));

            var result = repository.GetAll(p => p.Title == "Test");
            Assert.True(result.Count() > 0);
        }

        [Fact]
        public void CreateNewProblemWithTag()
        {
            IRepository<Problem> repository = new EntityRepository<Problem>(GetDbContext());
            var problem = new Problem
            {
                Title = "Test",
                Description = "This is a test Problem",
                IsResolved = false,
                Tag = new Tag
                {
                    Name = "Project #1"
                }
            };

            Assert.True(repository.Insert(problem));

            var result = repository.GetAll(p => p.Title == "Test");
            Assert.True(result.Count() > 0);

            var insertedProblem = result.ToArray()[0];
            Assert.NotNull(insertedProblem.Tag);
        }
    }
}
