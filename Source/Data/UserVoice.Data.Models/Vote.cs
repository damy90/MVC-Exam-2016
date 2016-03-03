namespace UserVoice.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using UserVoice.Data.Common.Models;

    public class Vote : BaseModel<int>
    {
        [Required]
        [Range(0, 3)]
        public int Value { get; set; }

        [Required]
        public string AuthorIpAddress { get; set; }

        public int IdeaId { get; set; }

        public virtual Idea Idea { get; set; }
    }
}
