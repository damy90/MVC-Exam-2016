using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserVoice.Services.Data
{
    using UserVoice.Data.Common;
    using UserVoice.Data.Models;

    class IdeasServices : IIdeasServices
    {
        private readonly IDbRepository<Idea> ideas;

        public IdeasServices(IDbRepository<Idea> ideas)
        {
            this.ideas = ideas;
        }

        public IQueryable<Idea> All()
        {
            return this.ideas.All();
        }

        public Idea GetById(int id)
        {
            return this.ideas.GetById(id);
        }

        public void Add(Idea idea)
        {
            this.ideas.Add(idea);
        }

        public void SaveChanges()
        {
            this.ideas.Save();
        }

        public void Update(Idea idea)
        {
            this.ideas.Update(idea);
        }

        public void Delete(Idea idea)
        {
            this.ideas.Delete(idea);
        }
    }
}
