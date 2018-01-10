using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnownProblem.Api.Models
{
    public class ProblemModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Resolution { get; set; }
        public bool IsResolved { get; set; }
        public int? TagId { get; set; }
        public string TagName { get; set; }
    }
}
