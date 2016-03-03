namespace UserVoice.Web.ViewModels.Comments
{
    using System.ComponentModel.DataAnnotations;

    using UserVoice.Data.Models;

    public class CommentInputModel
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        public string Content { get; set; }

        //[Required]
        public string AuthorIp { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string AuthorEmail { get; set; }
    }
}