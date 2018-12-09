using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Open.Aids;
using Open.Core;
using Open.Data.Goods;
using Open.Domain.Goods;
using Open.Domain.ShoppingCart;
using Open.Facade.Goods;

namespace Open.Sentry.Controllers {


    public class GoodsController : Controller // ISentryController
    {
        private readonly IGoodsRepository repository;
        internal const string properties =
            "ID, Name, Code, ImageType, Description, Price, Type, Image";
        internal ShoppingCart cart = new ShoppingCart();

        public GoodsController(IGoodsRepository r) {
            repository = r;
        }

        public async Task<IActionResult> Index(string sortOrder = null, string currentFilter = null,
            string searchString = null, int? page = null) {
            if (searchString != null) page = 1;
            else searchString = currentFilter;
            ViewData["CurrentFilter"] = searchString;
            repository.SearchString = searchString;
            repository.PageIndex = page ?? 1;
            var l = await repository.GetObjectsList();
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
        public async Task<IActionResult> Create([Bind(properties)] GoodView c,
            List<IFormFile> Image) {

            c.ID = Guid.NewGuid().ToString();

            c.Code = getRandomCode();
            await changeCodeIfInUse(c.Code, c);

            await validateId(c.ID, ModelState);

            foreach (var item in Image) {
                if (item.Length > 0) {
                    using (var stream = new MemoryStream()) {
                        await item.CopyToAsync(stream);
                        c.Image = stream.ToArray();
                    }
                }
            }

            if (!ModelState.IsValid) return View(c);  

            var o = GoodFactory.Create(c.ID, c.Name, c.Code, c.Description, c.Price, c.Type,
                c.Quantity,
                c.Image);
            await repository.AddObject(o);
            return RedirectToAction("Index");
        }

        private async Task validateId(string id, ModelStateDictionary d) {
            if (await isIdInUse(id))
                d.AddModelError(string.Empty, idIsInUseMessage(id));
        }
        private async Task changeCodeIfInUse(string code, GoodView c) {
            if (await isCodeInUse(code)) c.Code = getRandomCode();
        }
        private static string getRandomCode() {
            string code = GetRandom.String(6, 6) + GetRandom.UInt8(0, 9) + GetRandom.UInt8(0, 9);
            return code;
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
        public IActionResult AddToCart(GoodsData c) {

            var db = new GoodsData
            {
                Code = c.Code,
                Description = c.Description,
                ID = c.ID,
                Image = c.Image,
                Name = c.Name,
                Price = c.Price,
                Type = c.Type
            };
            cart.AddItem(db);
            return RedirectToAction("Index");
        }
    }
}

