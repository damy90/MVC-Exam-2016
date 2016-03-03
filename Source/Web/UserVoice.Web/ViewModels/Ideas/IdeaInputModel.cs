namespace UserVoice.Web.ViewModels.Ideas
{
    using System.ComponentModel.DataAnnotations;

    public class IdeaInputModel
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }
        
        //TODO: separate create and eddit models, recieve ip from browser
        //[Required]
        public string AuthorIpAddress { get; set; }
    }
}