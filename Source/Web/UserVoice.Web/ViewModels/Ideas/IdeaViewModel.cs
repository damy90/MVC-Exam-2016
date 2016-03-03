namespace UserVoice.Web.ViewModels.Ideas
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    using AutoMapper;
    using UserVoice.Data.Models;
    using UserVoice.Web.Infrastructure.Mapping;

    public class IdeaViewModel : IMapFrom<Idea>, IHaveCustomMappings
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        //TODO: moove to new model
        [Required]
        public string AuthorIpAddress { get; set; }

        public DateTime? ModifiedOn { get; set; }

        //public bool IsDescriptionShortened { get; set; }

        public int? Votes { get; set; }

        //public int? CommentsCount { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Idea, IdeaViewModel>()
                .ForMember(x => x.Votes, opt => opt.MapFrom(x => x.Votes.Select(v => v.Value).Sum()));
            //.ForMember(x => x.CommentsCount, opt => opt.MapFrom(x => x.Comments.Count));
            //.ForMember(x => x.Description, opt => opt.MapFrom(x => x.Description.Substring(0, 300)))
            //.ForMember(x => x.IsDescriptionShortened, opt => opt.MapFrom(x => x.Description.Length > 300));
        }
    }
}