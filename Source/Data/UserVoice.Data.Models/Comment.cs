using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserVoice.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using UserVoice.Data.Common.Models;

    public class Comment : BaseModel<int>
    {
        [Required]
        [MinLength(3)]
        public string Content { get; set; }

        [Required]
        public string AuthorIp { get; set; }

        public int IdeaId { get; set; }

        public virtual Idea Idea { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string AuthorEmail { get; set; }
    }
}
