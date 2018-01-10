using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KnownProblem.Data.Entity
{
    public class Problem: BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Resolution { get; set; }
        public bool IsResolved { get; set; }

        public virtual ICollection<Problem> Dublicates { get; set; }
        public virtual Tag Tag { get; set; }
    }
}
