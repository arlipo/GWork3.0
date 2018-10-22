using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Open.Domain.Goods;
using Open.Facade.Goods;

namespace Open.Sentry.Controllers
{
    [Authorize]
    public class GoodsController : Controller //, ISentryController
    {
        private readonly IGoodsRepository repository;
        internal const string properties = "ID, Name, Code, ImageType, Description, FileLocation, Price";
        public GoodsController(IGoodsRepository r)
        {
            repository = r;
        }

        public async Task<IActionResult> Index(string sortOrder = null, string currentFilter = null,
            string searchString = null, int? page = null)
        {
            //...
            var l = await repository.GetObjectsList();
            return View(new GoodViewsList(l));
        }

        // GET: Goods/Create
        /*
        public IActionResult Create()
        {
            return View();
        }

        // POST: Goods/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        
        // GET: Goods/Edit/5
        public IActionResult Edit(int id)
        {
            return View();
        }

        // POST: Goods/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Goods/Delete/5
        public IActionResult Delete(int id)
        {
            return View();
        }

        // POST: Goods/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        
        
        // GET: Goods/Details/5
        public IActionResult Details(int id)
        {
            return View();
        }
        */
    }
}