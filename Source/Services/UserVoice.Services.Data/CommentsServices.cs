namespace UserVoice.Services.Data
{
    using System.Linq;

    using UserVoice.Data.Common;
    using UserVoice.Data.Models;

    public class CommentsServices:ICommentsServices
    {
        private readonly IDbRepository<Comment> comments;

        public CommentsServices(IDbRepository<Comment> comments)
        {
            this.comments = comments;
        }

        public IQueryable<Comment> All()
        {
            return this.comments.All();
        }

        public Comment GetById(int id)
        {
            return this.comments.GetById(id);
        }

        public void Add(Comment comment)
        {
            this.comments.Add(comment);
        }

        public void SaveChanges()
        {
            this.comments.Save();
        }

        public void Update(Comment comment)
        {
            this.comments.Update(comment);
        }

        public void Delete(Comment comment)
        {
            this.comments.Delete(comment);
        }
    }
}
