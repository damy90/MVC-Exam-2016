namespace UserVoice.Services.Data
{
    using System.Linq;

    using UserVoice.Data.Models;

    public interface IIdeasServices
    {
        IQueryable<Idea> All();

        Idea GetById(int id);

        void Add(Idea idea);

        void SaveChanges();

        void Update(Idea idea);

        void Delete(Idea idea);

        //void Delete(int id);
    }
}
