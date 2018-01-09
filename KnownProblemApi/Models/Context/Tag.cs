using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KnownProblemApi.Models.Context
{
    public class Tag
    {
		[Key]
        public int Id { get; set; }
        public string Name { get; set; }

		public virtual IEnumerable<Problem> Problems { get; set; }
    }
}
