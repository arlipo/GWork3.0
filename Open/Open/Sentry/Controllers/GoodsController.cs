using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Open.Aids;
using Open.Core;
using Open.Data.Goods;
using Open.Domain.Goods;
using Open.Facade.Goods;

namespace Open.Sentry.Controllers {

    public class GoodsController : Controller // ISentryController
    {
        private readonly IGoodsRepository repository;
        internal const string properties =
            "ID, Name, Code, ImageType, Description, Price, Type, Image";
        public GoodsController(IGoodsRepository r) {
            repository = r;
        }

        public async Task<IActionResult> Index(string sortOrder = null, string currentFilter = null,
            string searchString = null, int? page = null)
        {
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
            o.Data.Code = c.Description;
            o.Data.Image = c.Image;
            o.Data.Price = c.Price;

            await repository.UpdateObject(o);
            return RedirectToAction("Index");
        }
        public IActionResult Create() {
            return View();
        }

        [HttpPost] public async Task<IActionResult> Create([Bind(properties)] GoodView c) {
            await validateId(c.Code, ModelState);
            if (!ModelState.IsValid) return View(c);
            var o = GoodFactory.Create(c.ID, c.Name, c.Code, c.Description, c.Price, c.Type, c.Image);
            await repository.AddObject(o);
            return RedirectToAction("Index");
        }

        private async Task validateId(string id, ModelStateDictionary d) {
            if (await isIdInUse(id))
                d.AddModelError(string.Empty, idIsInUseMessage(id));
        }
        private async Task<bool> isIdInUse(string id) {
            return (await repository.GetObject(id))?.Data?.ID == id;
        }
        private static string idIsInUseMessage(string id) {
            var name = GetMember.DisplayName<GoodView>(c => c.Code);
            return string.Format(Messages.ValueIsAlreadyInUse, id, name);
        }
    }
}
//}
//        // GET: Goods/Create
//        /
//        public IActionResult Create()
//        {
//            return View();
//        }

//// POST: Goods/Create

//[HttpPost]
//[ValidateAntiForgeryToken]
//public IActionResult Create(IFormCollection collection)
//{
//    try
//    {
//        // TODO: Add insert logic here

//        return RedirectToAction(nameof(Index));
//    }
//    catch
//    {
//        return View();
//    }
//}


//// GET: Goods/Edit/5
//public IActionResult Edit(int id)
//{
//    return View();
//}

//        // POST: Goods/Edit/5
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public IActionResult Edit(int id, IFormCollection collection)
//        {
//            try
//            {
//                // TODO: Add update logic here

//                return RedirectToAction(nameof(Index));
//            }
//            catch
//            {
//                return View();
//            }
//        }

//        // GET: Goods/Delete/5
//        public IActionResult Delete(int id)
//        {
//            return View();
//        }

//        // POST: Goods/Delete/5
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public IActionResult Delete(int id, IFormCollection collection)
//        {
//            try
//            {
//                // TODO: Add delete logic here

//                return RedirectToAction(nameof(Index));
//            }
//            catch
//            {
//                return View();
//            }
//        }


//        // GET: Goods/Details/5
//        public IActionResult Details(int id)
//        {
//            return View();
//        }

//    }
//}

