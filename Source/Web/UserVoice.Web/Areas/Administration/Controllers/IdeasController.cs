using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using UserVoice.Data.Models;

namespace UserVoice.Web.Areas.Administration.Controllers
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using UserVoice.Data;
    using UserVoice.Services.Data;
    using UserVoice.Web.Infrastructure.Mapping;
    using UserVoice.Web.ViewModels.Ideas;

    //[Authorize]
    public class IdeasController : Controller
    {
        //private ApplicationDbContext db = new ApplicationDbContext();

        private readonly IIdeasServices Ideas;

        public IdeasController(IIdeasServices ideas)
        {
            this.Ideas = ideas;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Ideas_Read([DataSourceRequest]DataSourceRequest request)
        {
            Mapper.AssertConfigurationIsValid();
            IQueryable<Idea> ideas = this.Ideas.All().Where(i => i.IsDeleted == false);
            DataSourceResult result = ideas.To<IdeaViewModel>()
                .ToDataSourceResult(request);

            return Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Ideas_Update([DataSourceRequest]DataSourceRequest request, IdeaInputModel idea)
        {
            if (ModelState.IsValid)
            {
                var entity = this.Ideas.GetById(idea.Id);
                entity.Description = idea.Description;
                entity.Title = idea.Title;

                this.Ideas.Update(entity);
                this.Ideas.SaveChanges();
            }

            var ideaToDisplay = this.Ideas.All().To<IdeaViewModel>().FirstOrDefault(x => x.Id == idea.Id);

            return Json(new[] { ideaToDisplay }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Ideas_Destroy([DataSourceRequest]DataSourceRequest request, Idea idea)
        {
            var entity = this.Ideas.GetById(idea.Id);
            this.Ideas.Delete(entity);
            this.Ideas.SaveChanges();

            return Json(new[] { idea }.ToDataSourceResult(request, ModelState));
        }

        /*protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }*/
    }
}
