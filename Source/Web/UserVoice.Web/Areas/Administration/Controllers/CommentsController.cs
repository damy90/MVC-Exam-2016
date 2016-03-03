﻿using System;
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
    using UserVoice.Services.Data;
    using UserVoice.Web.Infrastructure.Mapping;
    using UserVoice.Web.ViewModels.Comments;

    [Authorize]
    public class CommentsController : Controller
    {
        //private ApplicationDbContext db = new ApplicationDbContext();

        private readonly ICommentsServices Comments;

        public CommentsController(ICommentsServices comments)
        {
            this.Comments = comments;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Comments_Read([DataSourceRequest]DataSourceRequest request)
        {
            IQueryable<Comment> comments =this.Comments.All();
            DataSourceResult result = comments.To<CommentViewModel>()
                .ToDataSourceResult(request);

            return Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Comments_Update([DataSourceRequest]DataSourceRequest request, CommentViewModel comment)
        {
            if (ModelState.IsValid)
            {
                var entity = this.Comments.GetById(comment.Id);
                entity.AuthorEmail = comment.AuthorEmail;
                entity.Content = comment.Content;

                this.Comments.SaveChanges();
            }

            var commentToDisplay = this.Comments.All().To<CommentViewModel>().FirstOrDefault(x => x.Id == comment.Id);

            return Json(new[] { commentToDisplay }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Comments_Destroy([DataSourceRequest]DataSourceRequest request, CommentViewModel comment)
        {
            var entity = this.Comments.GetById(comment.Id);
            this.Comments.Delete(entity);
            this.Comments.SaveChanges();

            return Json(new[] { comment }.ToDataSourceResult(request, ModelState));
        }

        /*protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }*/
    }
}
