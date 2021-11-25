using COSMIDENT.Interfaces;
using COSMIDENT.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace COSMIDENT.Controllers
{
    public class StockController : Controller
    {
        private readonly IUnit _unitRepo;
        public StockController(IUnit unitrepo)
        {
            _unitRepo = unitrepo;
        }

        private SortModel ApplySort(string sortExpression = "")
        {
            ViewData["SortParamName"] = "name";
            ViewData["SortParamDesc"] = "description";
            ViewData["SortParamBarc"] = "barcode";
            ViewData["SortParamQuan"] = "quantity";

            ViewData["SortIconName"] = "name";
            ViewData["SortIconDesc"] = "description";
            ViewData["SortIconBarc"] = "barcode";
            ViewData["SortIconQuan"] = "quantity";

            SortModel sortModel = new SortModel();

            switch (sortExpression.ToLower())
            {
                case "name_desc":
                    sortModel.SortedOrder = SortOrder.Descending;
                    sortModel.SortedProperty = "name";
                    ViewData["SortIconName"] = "fa fa-arrow-up";
                    ViewData["SortParamName"] = "name";
                    break;

                case "description":
                    sortModel.SortedOrder = SortOrder.Ascending;
                    sortModel.SortedProperty = "description";
                    ViewData["SortIconDesc"] = "fa fa-arrow-down";
                    ViewData["SortParamDesc"] = "description_desc";
                    break;

                case "description_desc":
                    sortModel.SortedOrder = SortOrder.Descending;
                    sortModel.SortedProperty = "description";
                    ViewData["SortIconDesc"] = "fa fa-arrow-up";
                    ViewData["SortParamDesc"] = "description";
                    break;

                case "barcode_desc":
                    sortModel.SortedOrder = SortOrder.Descending;
                    sortModel.SortedProperty = "barcode";
                    ViewData["SortIconBarc"] = "fa fa-arrow-up";
                    ViewData["SortParamBarc"] = "barcode";
                    break;

                case "barcode":
                    sortModel.SortedOrder = SortOrder.Ascending;
                    sortModel.SortedProperty = "barcode";
                    ViewData["SortIconBarc"] = "fa fa-arrow-down";
                    ViewData["SortParamBarc"] = "barcode_desc";
                    break;

                case "quantity_desc":
                    sortModel.SortedOrder = SortOrder.Descending;
                    sortModel.SortedProperty = "quantity";
                    ViewData["SortIconQuan"] = "fa fa-arrow-up";
                    ViewData["SortParamQuan"] = "quantity";
                    break;

                case "quantity":
                    sortModel.SortedOrder = SortOrder.Ascending;
                    sortModel.SortedProperty = "quantity";
                    ViewData["SortIconQuan"] = "fa fa-arrow-down";
                    ViewData["SortParamQuan"] = "quantity_desc";
                    break;

                default:
                    sortModel.SortedOrder = SortOrder.Ascending;
                    sortModel.SortedProperty = "name";
                    ViewData["SortIconName"] = "fa fa-arrow-down";
                    ViewData["SortParamName"] = "name_desc";
                    break;
            }
            return sortModel;
        }

        public IActionResult Index(string sortExpression = "", string SearchText = "", int pageSize = 5, int pg = 1)
        {
            SortModel sortModel = new SortModel();

            sortModel.AddColumn("name");
            sortModel.AddColumn("description");
            sortModel.AddColumn("barcode");
            sortModel.AddColumn("quantity");
            sortModel.ApplySort(sortExpression);
            ViewData["sortModel"] = sortModel;

            ViewBag.SearchText = SearchText;

            PaginatedList<Unit> units = _unitRepo.GetItems(sortModel.SortedProperty, sortModel.SortedOrder, SearchText, pg, pageSize); //_context.Units.ToList();

            int totRecs = ((PaginatedList<Unit>)units).TotalRecords;

            var pager = new PagerModel(units.TotalRecords, pg, pageSize);
            pager.SortExpression = sortExpression;
            this.ViewBag.Pager = pager;

            TempData["CurrentPage"] = pg;

            //units = units.Skip((pg - 1) * pageSize).Take(pageSize).ToList();


            return View(units);
        }

        public IActionResult Create()
        {
            Unit unit = new Unit();
            return View(unit);
        }

        [HttpPost]
        public IActionResult Create(Unit unit)
        {
            try
            {
                unit = _unitRepo.Create(unit);
            }
            catch
            {

            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int id)
        {
            Unit unit = _unitRepo.GetUnit(id);

            return View(unit);
        }

        public IActionResult Edit(int id)
        {
            Unit unit = _unitRepo.GetUnit(id);
            return View(unit);
        }

        [HttpPost]
        public IActionResult Edit(Unit unit)
        {
            try
            {
                unit = _unitRepo.Edit(unit);
            }
            catch
            {

            }

            int currentPage = 1;
            if (TempData["CurrentPage"] != null)
            {
                currentPage = (int)TempData["CurrentPage"];
            }
            return RedirectToAction(nameof(Index), new { pg = currentPage });
        }

        public IActionResult Delete(int id)
        {
            Unit unit = _unitRepo.GetUnit(id);
            return View(unit);
        }

        [HttpPost]
        public IActionResult Delete(Unit unit)
        {
            try
            {
                unit = _unitRepo.Delete(unit);
            }
            catch
            {

            }

            return RedirectToAction(nameof(Index));
        }

    }
}
