using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserVoice.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using UserVoice.Data.Common.Models;

    public class Idea : BaseModel<int>
    {
        public Idea()
        {
            this.Votes = new HashSet<Vote>();
            this.Comments = new List<Comment>();
        }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string AuthorIpAddress { get; set; }

        public virtual ICollection<Vote> Votes { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
