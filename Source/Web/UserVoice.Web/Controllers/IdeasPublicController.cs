using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UserVoice.Web.Controllers
{
    using System.Collections;

    using GenericTools;

    using UserVoice.Data.Models;
    using UserVoice.Services.Data;
    using UserVoice.Web.Infrastructure.Mapping;
    using UserVoice.Web.ViewModels.Ideas;

    public class IdeasPublicController : BaseController
    {
        private readonly IIdeasServices Ideas;

        public IdeasPublicController(IIdeasServices ideas)
        {
            this.Ideas = ideas;
        }

        // GET: Ideas
        public ActionResult Index()
        {
            IEnumerable<IdeaViewModel> result = this.Ideas.All()
                .Where(i => i.IsDeleted == false)
                .To<IdeaViewModel>()
                .ToList();
            //ViewBag.Ideas = (IEnumerable)(this.Ideas.All().To<IdeaViewModel>().ToList());
            return View("_IdeasList", result);
        }

        [HttpPost]
        public ActionResult Search(string query)
        {
            IEnumerable<IdeaViewModel> result = this.Ideas.All()
                .Where(i => i.IsDeleted == false)
                .To<IdeaViewModel>()
                .Where(i => i.Title.Contains(query)).ToList();

            return this.PartialView("_IdeasList", result);
        }

        [HttpPost]
        public ActionResult Post(IdeaInputModel idea)
        {
            if (ModelState.IsValid)
            {

                var entity = new Idea()
                {
                    AuthorIpAddress = RandomIpAddressGenerator.Generate(),
                    CreatedOn = DateTime.UtcNow,
                    Description = idea.Description,
                    Title = idea.Title
                };

                this.Ideas.Add(entity);
                this.Ideas.SaveChanges();
            }

            return this.View("~/Views/Home/Index.cshtml");
        }
    }
}