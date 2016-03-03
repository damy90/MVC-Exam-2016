namespace UserVoice.Web.ViewModels.Comments
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using UserVoice.Data.Models;
    using UserVoice.Web.Infrastructure.Mapping;

    public class CommentViewModel : IMapFrom<Comment>
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string AuthorEmail { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}