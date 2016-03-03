namespace UserVoice.Web.Controllers
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    using Infrastructure.Mapping;

    using Services.Data;

    using UserVoice.Web.ViewModels.Ideas;

    public class HomeController : BaseController
    {
        private readonly IIdeasServices Ideas;

        public HomeController(IIdeasServices ideas)
        {
            this.Ideas = ideas;
        }

        public ActionResult Index()
        {
            /*var jokes = this.jokes.GetRandomJokes(3).To<JokeViewModel>().ToList();
            var categories =
                this.Cache.Get(
                    "categories",
                    () => this.jokeCategories.GetAll().To<JokeCategoryViewModel>().ToList(),
                    30 * 60);
            var viewModel = new IndexViewModel
            {
                Jokes = jokes,
                Categories = categories
            };*/

            IEnumerable<IdeaViewModel> result = this.Ideas.All().To<IdeaViewModel>().ToList();
            //ViewBag.Ideas = (IEnumerable)(this.Ideas.All().To<IdeaViewModel>().ToList());
            return this.View();
        }
    }
}
