﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment7.Controllers
{
    public class AlbumsController : Controller
    {
        private Manager m = new Manager();

        // GET: Albums
        public ActionResult Index()
        {
            return View();
        }

        // GET: Albums/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Albums/Create
        public ActionResult Create(int? id)
        {
            // Attempt to fetch the matching object
            var a = m.ArtistGetById(id.GetValueOrDefault());

            if (a == null)
            {
                return HttpNotFound();
            }
            else
            {
                ViewBag.ArtistName = a.Name;

                var form = new AlbumEditArtistsForm();
                var selectedValues = new List<int> { a.Id };

                form.ArtistList = new MultiSelectList
                        (items: m.ArtistGetAll(),
                        dataValueField: "Id",
                        dataTextField: "Name",
                        selectedValues: selectedValues,
                        disabledValues: selectedValues);

                return View(form);
            }

        }

        // POST: Albums/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

    }
}
