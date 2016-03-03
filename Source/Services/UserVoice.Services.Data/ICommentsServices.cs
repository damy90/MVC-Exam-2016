namespace UserVoice.Services.Data
{
    using System.Linq;

    using UserVoice.Data.Models;

    public interface ICommentsServices
    {
        IQueryable<Comment> All();

        Comment GetById(int id);

        void Add(Comment idea);

        void SaveChanges();

        void Update(Comment idea);

        void Delete(Comment idea);
    }
}
