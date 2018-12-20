﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Open.Aids;
using Open.Core;
using Open.Data.Goods;
using Open.Data.ShoppingCart;
using Open.Domain.Goods;
using Open.Domain.ShoppingCart;
using Open.Facade.Goods;

namespace Open.Sentry.Controllers {


    public class GoodsController : Controller
    {
        private static readonly Dictionary<string, GoodTypes> categories = new Dictionary<string, GoodTypes>
        {
            {"Chemistry", GoodTypes.Chemistry},
            {"Accessories", GoodTypes.Accessories},
            {"SpareParts", GoodTypes.SpareParts}
        };
        private readonly IGoodsRepository repository;
        internal const string properties =
            "ID, Name, Code, ImageType, Description, Price, Type, Image";

        public GoodsController(IGoodsRepository r) {
            repository = r;
        }

        public async Task<IActionResult> Index(string sortOrder = null, string currentFilter = null,
            string category = null,
            string searchString = null, int? page = null) {
            if (searchString != null) page = 1;
            else searchString = currentFilter;
            ViewData["CurrentFilter"] = searchString;
            repository.SearchString = searchString;
            repository.PageIndex = page ?? 1;
            IPaginatedList<Good> l;
            if (category != null && categories.ContainsKey(category))
            {
                l = await repository.GetWithSpecificType(categories[category]);
                ViewBag.Title = category;
            }
            else
            {
                l = await repository.GetObjectsList();
                ViewBag.Title = "All Products";
            }
            return View(new GoodViewsList(l));
        }

        public async Task<IActionResult> Edit(string id) {
            var c = await repository.GetObject(id);
            return View(GoodViewFactory.Create(c));
        }
        [HttpPost] public async Task<IActionResult> Edit([Bind(properties)] GoodView c) {
            if (!ModelState.IsValid) return View(c);
            var o = await repository.GetObject(c.Code);
            o.Data.Name = c.Name;
            o.Data.Description = c.Description;
            o.Data.Image = c.Image;
            o.Data.Price = c.Price;

            await repository.UpdateObject(o);
            return RedirectToAction("Index");
        }
        [HttpGet] public IActionResult Create() {
            return View();
        }

        [Authorize(Roles = "Admin")] [ValidateAntiForgeryToken] [HttpPost]
        public async Task<IActionResult> Create([Bind(properties)] GoodView c) {

            c.ID = Guid.NewGuid().ToString();

            c.Code = GetRandom.Code();
            await changeCodeIfInUse(c.Code, c);

            await validateId(c.ID, ModelState);

            if (!ModelState.IsValid) return View(c);  

            var o = GoodFactory.Create(c.ID, c.Name, c.Code, c.Description, c.Price, c.Type,
                c.Quantity, c.Brand,
                c.Image);
            await repository.AddObject(o);
            return RedirectToAction("Index");
        }

        private async Task validateId(string id, ModelStateDictionary d) {
            if (await isIdInUse(id))
                d.AddModelError(string.Empty, idIsInUseMessage(id));
        }
        private async Task changeCodeIfInUse(string code, GoodView c) {
            if (await isCodeInUse(code)) c.Code = GetRandom.Code();
        }
        private async Task<bool> isIdInUse(string id) {
            return (await repository.GetObject(id))?.Data?.ID == id;
        }
        private static string idIsInUseMessage(string id) {
            var name = GetMember.DisplayName<GoodView>(c => c.Code);
            return string.Format(Messages.ValueIsAlreadyInUse, id, name);
        }
        private async Task<bool> isCodeInUse(string code) {
            return (await repository.GetObjectByCode(code))?.Data?.Code == code;
        }
        public async Task<IActionResult> AddToCart(string id) {

            var o = await repository.GetObject(id);
            var cartData = new CartData {GoodsData = o.Data};
            CartController.Add(cartData);
            return RedirectToAction("Index");
        }
    }
}

