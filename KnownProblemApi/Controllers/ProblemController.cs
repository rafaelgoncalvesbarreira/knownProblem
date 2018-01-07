using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using KnownProblemApi.Models.Context;
using KnownProblemApi.Models;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KnownProblemApi.Controllers
{
    [Route("api/[controller]")]
    public class ProblemController : Controller
    {
        private KnownProblemContext context;

        public ProblemController(KnownProblemContext context)
        {
            this.context = context;

            //POG
            if(this.context.ProblemItems.Count() == 0)
            {
                this.context.ProblemItems.Add(new Problem
                {
                    Id = 1,
                    Title = "Problem mock",
                    Description = "There isn't data here",
                    IsResolved = false
                });
                this.context.SaveChanges();    
            }
        }

        [HttpGet]
        public IEnumerable<ProblemModel> GetAll([FromQuery]ProblemQuery query)
        {
            return (from problem in context.ProblemItems.AsNoTracking()
                    select new ProblemModel
                    {
                        Id = problem.Id,
                        Title = problem.Title,
                        Description = problem.Description,
                        IsResolved = problem.IsResolved,
                        Resolution = problem.Resolution
                    }).ToList();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]ProblemModel problem)
        {
            var newProblem = new Problem
            {
                Title = problem.Title,
                Description = problem.Description,
                Resolution = problem.Resolution,
                IsResolved = problem.IsResolved
            };

            context.ProblemItems.Add(newProblem);
            await context.SaveChangesAsync();

            return new OkResult();;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody]ProblemModel problem)
        {
            var oldProblem = context.ProblemItems.SingleOrDefault(p => p.Id == id);
            oldProblem.Title = problem.Title;
            oldProblem.Description = problem.Description;
            oldProblem.Resolution = problem.Resolution;
            oldProblem.IsResolved = problem.IsResolved;

            await context.SaveChangesAsync();

            return new OkResult();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var problemDelete = new Problem
            {
                Id = id
            };

            context.Entry(problemDelete).State = EntityState.Deleted;
            await context.SaveChangesAsync();

            return new OkResult();
        }

    }
}
