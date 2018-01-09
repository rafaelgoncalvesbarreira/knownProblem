using KnownProblemApi.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnownProblemApi.Models.Repository
{
    interface IProblemRepository
    {
        IEnumerable<Problem> GetAll(ProblemQuery query = null);
        bool Create(Problem newProblem);
    }
}
