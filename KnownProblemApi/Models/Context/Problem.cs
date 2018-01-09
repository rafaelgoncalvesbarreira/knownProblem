using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KnownProblemApi.Models.Context
{
    public class Problem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Resolution { get; set; }
        public bool IsResolved { get; set; }

        public virtual ICollection<Problem> Dublicates { get; set; }
        public virtual Tag Tag { get; set; }
    }
}
