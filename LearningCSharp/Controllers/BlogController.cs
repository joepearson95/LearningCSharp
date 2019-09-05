using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LearningCSharp.Data;
using LearningCSharp.Models;
using Microsoft.AspNet.Identity;

namespace LearningCSharp.Controllers
{
    public class BlogController : Controller
    {
        private LearningCSharpDBContext db = new LearningCSharpDBContext();

        // GET: Blog
        public ActionResult Index()
        {
            return View(db.Blogs.ToList());
        }

        // GET: Blog/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // GET: Blog/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Blog/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Blog blog)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    blog = new Blog
                    {
                        PostTitle = blog.PostTitle,
                        PostBody = blog.PostBody,
                        Author = User.Identity.GetUserName(),
                        CreatedOn = DateTime.Now,
                        EditedOn = DateTime.Now 
                    };
                    db.Blogs.Add(blog);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                } catch (Exception error)
                {
                    System.Diagnostics.Debug.WriteLine(error);
                    return RedirectToAction("Create");
                }
            }

            return View(blog);
        }

        // GET: Blog/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // POST: Blog/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Blog blog)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    blog = new Blog
                    {
                        PostID = blog.PostID,
                        PostBody = blog.PostBody,
                        PostTitle = blog.PostTitle,
                        EditedOn = DateTime.Now
                    };

                    db.Blogs.Attach(blog);
                    db.Entry(blog).Property(x => x.PostTitle).IsModified = true;
                    db.Entry(blog).Property(x => x.PostBody).IsModified = true;
                    db.Entry(blog).Property(x => x.EditedOn).IsModified = true;

                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (DbEntityValidationException ex)
                {
                    foreach (var errors in ex.EntityValidationErrors)
                    {
                        foreach (var validationError in errors.ValidationErrors)
                        {
                            // get the error message 
                            string errorMessage = validationError.ErrorMessage;
                            System.Diagnostics.Debug.WriteLine(errorMessage);
                        }
                    }
                }
            }
            return View(blog);
        }

        // GET: Blog/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // POST: Blog/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Blog blog = db.Blogs.Find(id);
            db.Blogs.Remove(blog);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
