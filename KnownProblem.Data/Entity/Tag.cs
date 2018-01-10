using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KnownProblem.Data.Entity
{
    public class Tag: BaseEntity
    {
        public string Name { get; set; }

		public virtual IEnumerable<Problem> Problems { get; set; }
    }
}
