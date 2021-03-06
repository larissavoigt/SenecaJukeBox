﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment7.Controllers
{
    public class ArtistsController : Controller
    {
        private Manager m = new Manager();

        // GET: Artists
        public ActionResult Index()
        {
            var artists = m.ArtistGetAllWithDetail();
            return View(artists);
        }

        // GET: Artists/Details/5
        public ActionResult Details(int? id)
        {
            var o = m.ArtistGetByIdWithDetail(id.GetValueOrDefault());

            if (o == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(o);
            }
        }

        // GET: Artists/Create
        [Authorize(Roles = "Executive")]
        public ActionResult Create()
        {
            var form = new ArtistAddForm();

            form.GenreList = new SelectList
                    (items: m.GenreGetAll(),
                    dataValueField: "Name",
                    dataTextField: "Name");

            return View(form);
        }

        // POST: Artists/Create
        [HttpPost]
        [Authorize(Roles = "Executive")]
        public ActionResult Create(ArtistAdd newItem)
        {
            newItem.Executive = HttpContext.User.Identity.Name;
            ModelState.Clear();

            if (!ModelState.IsValid)
            {
                return View(newItem);
            }

            var addedItem = m.ArtistAdd(newItem);
            
            if (addedItem == null)
            {
                return View(newItem);
            }
            else
            {
                return RedirectToAction("details", new { id = addedItem.Id });
            }
        }

    }
}
