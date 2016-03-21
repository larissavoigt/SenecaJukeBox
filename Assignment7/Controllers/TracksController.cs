using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment7.Controllers
{
    public class TracksController : Controller
    {
        private Manager m = new Manager();

        // GET: Tracks
        public ActionResult Index()
        {
            return View(m.TrackGetAllWithDetail());
        }

        // GET: Tracks/Details/5
        public ActionResult Details(int? id)
        {
            var o = m.TrackGetByIdWithDetail(id.GetValueOrDefault());

            if (o == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(o);
            }
        }

        // GET: Tracks/Create
        [Authorize(Roles = "Clerk")]
        public ActionResult Create()
        {
            var form = new TrackAddForm();

            form.GenreList = new SelectList
                    (items: m.GenreGetAll(),
                    dataValueField: "Name",
                    dataTextField: "Name");

            return View(form);
        }

        // POST: Tracks/Create
        [HttpPost]
        [Authorize(Roles = "Clerk")]
        public ActionResult Create(TrackAdd newItem)
        {
            newItem.Clerk = HttpContext.User.Identity.Name;
            ModelState.Clear();

            if (!ModelState.IsValid)
            {
                return View(newItem);
            }

            var addedItem = m.TrackAdd(newItem);

            if (addedItem == null)
            {
                return View(newItem);
            }
            else
            {
                return RedirectToAction("details", new { id = addedItem.Id });
            }
        }

        // GET: Tracks/Edit/5
        [Authorize(Roles = "Clerk")]
        public ActionResult Edit(int? id)
        {
            var o = m.TrackGetByIdWithDetail(id.GetValueOrDefault());

            if (o == null)
            {
                return HttpNotFound();
            }
            else
            {
                var form = AutoMapper.Mapper.Map<TrackEditForm>(o);

                form.GenreList = new SelectList
                    (items: m.GenreGetAll(),
                    dataValueField: "Name",
                    dataTextField: "Name",
                    selectedValue: o.Genre);

                return View(form);
            }
        }

        // POST: Tracks/Edit/5
        [Authorize(Roles = "Clerk")]
        [HttpPost]
        public ActionResult Edit(int? id, TrackEdit newItem)
        {
            newItem.Clerk = HttpContext.User.Identity.Name;
            ModelState.Clear();

            if (!TryValidateModel(newItem))
            {
                return RedirectToAction("Edit", new { id = newItem.Id });
            }

            if (id.GetValueOrDefault() != newItem.Id)
            {
                return RedirectToAction("Index");
            }

            var editedItem = m.TrackEdit(newItem);

            if (editedItem == null)
            {
                return RedirectToAction("Edit", new { id = newItem.Id });
            }
            else
            {
                return RedirectToAction("Details", new { id = newItem.Id });
            }
        }

        // GET: Tracks/Delete/5
        [Authorize(Roles = "Clerk")]
        public ActionResult Delete(int? id)
        {
            var itemToDelete = m.TrackGetByIdWithDetail(id.GetValueOrDefault());

            if (itemToDelete == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(itemToDelete);
            }
        }

        // POST: Tracks/Delete/5
        [Authorize(Roles = "Clerk")]
        [HttpPost]
        public ActionResult Delete(int? id, FormCollection collection)
        {
            var result = m.TrackDelete(id.GetValueOrDefault());
            return RedirectToAction("Index");
        }

    }
}
