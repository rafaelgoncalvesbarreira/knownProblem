using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnownProblem.Api.Models
{
    public class ProblemDuplication
    {
        public int OriginalId { get; set; }
        public int DuplicatedId { get; set; }
    }
}
