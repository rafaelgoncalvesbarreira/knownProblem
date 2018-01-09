using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KnownProblem.Data.Entity
{
    public class Tag
    {
		[Key]
        public int Id { get; set; }
        public string Name { get; set; }

		public virtual IEnumerable<Problem> Problems { get; set; }
    }
}
