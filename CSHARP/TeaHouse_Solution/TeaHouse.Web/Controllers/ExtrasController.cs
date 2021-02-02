using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeaHouse.Logic;
using TeaHouse.Web.Models;

namespace TeaHouse.Web.Controllers
{
    public class ExtrasController : Controller
    {
        ILogic logic;
        IMapper mapper;
        ExtrasViewModel vm;

        public ExtrasController()
        {
            logic = new Logic.Logic();
            mapper = MapperFactory.CreateMapper();
            vm = new ExtrasViewModel();
            vm.Editedextra = new Extra();
            var extras = logic.GetAllExtras();
            vm.ListOfExtras = mapper.Map<IList<Data.EXTRA>, List<Models.Extra>>(extras);
        }

        private Extra GetExtraModel(int id)
        {
            Data.EXTRA extra = logic.GetExtraById(id);
            return mapper.Map<Data.EXTRA, Models.Extra>(extra);
        }

        // GET: Extras
        public ActionResult Index()
        {
            ViewData["editAction"] = "AddNew";
            return View("ExtraIndex", vm);
        }

        // GET: Extras/Details/5
        public ActionResult Details(int id)
        {
            return View("ExtraDetails", GetExtraModel(id));
        }

        public ActionResult Remove(int id)
        {
            TempData["editResult"] = "Delete Failed...";
            if (logic.RemoveExtra(id))
            {
                TempData["editResult"] = "Delete OK";
            }
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Edit(int id)
        {
            ViewData["editAction"] = "Edit";
            vm.Editedextra = GetExtraModel(id);
            return View("ExtraIndex", vm);
        }

        [HttpPost]
        public ActionResult Edit(Extra extra, string editAction)
        {
            if (ModelState.IsValid && extra != null)
            {
                TempData["editResult"] = "Edit OK";
                if (editAction == "AddNew")
                {
                    logic.AddExtra(extra.Category, extra.ExtraName,extra.Allergen, extra.Available, extra.Price);
                }
                else
                {
                    if (!logic.ChangeExtra(extra.Id, extra.Category, extra.ExtraName, extra.Allergen, extra.Available, extra.Price))
                    {
                        TempData["editResult"] = "Edit Failed...";
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ViewData["editAction"] = "Edit";
                vm.Editedextra = extra;
                return View("ExtraIndex", vm);
            }
        }

    }
}
