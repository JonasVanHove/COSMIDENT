using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using COSMIDENT.Data;
using COSMIDENT.Models;
using COSMIDENT.Interfaces;

namespace COSMIDENT.Controllers
{
    public class SupplierController : Controller
    {
        private readonly ISupplier _supplierRepo;
        public SupplierController(ISupplier supplierrepo)
        {
            _supplierRepo = supplierrepo;
        }

        private SortModel ApplySort(string sortExpression)
        {
            ViewData["SortParamName"] = "name";
            ViewData["SortParamDesc"] = "email";

            ViewData["SortIconName"] = "name";
            ViewData["SortIconDesc"] = "email";

            SortModel sortModel = new SortModel();

            switch (sortExpression.ToLower())
            {
                case "name_desc":
                    sortModel.SortedOrder = SortOrder.Descending;
                    sortModel.SortedProperty = "name";
                    ViewData["SortIconName"] = "fa fa-arrow-up";
                    ViewData["SortParamName"] = "name";
                    break;

                case "email":
                    sortModel.SortedOrder = SortOrder.Ascending;
                    sortModel.SortedProperty = "email";
                    ViewData["SortIconDesc"] = "fa fa-arrow-down";
                    ViewData["SortParamDesc"] = "email_desc";
                    break;

                case "email_desc":
                    sortModel.SortedOrder = SortOrder.Descending;
                    sortModel.SortedProperty = "email";
                    ViewData["SortIconDesc"] = "fa fa-arrow-up";
                    ViewData["SortParamDesc"] = "email";
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

        public IActionResult Index(string sortExpression="")
        {
            SortModel sortModel = new SortModel();

            sortModel.AddColumn("name");
            sortModel.AddColumn("email");
            sortModel.ApplySort(sortExpression);
            ViewData["sortModel"] = sortModel;

            List<Supplier> suppliers = _supplierRepo.GetItems(sortModel.SortedProperty, sortModel.SortedOrder); 
            return View(suppliers);
        }

        public IActionResult Create()
        {
            Supplier supplier = new Supplier();
            return View(supplier);
        }

        [HttpPost]
        public IActionResult Create(Supplier supplier)
        {
            try
            {
                supplier = _supplierRepo.Create(supplier);
            }
            catch
            {

            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int id)
        {
            Supplier supplier = _supplierRepo.GetSupplier(id);
            return View(supplier);
        }

        public IActionResult Edit(int id)
        {
            Supplier supplier = _supplierRepo.GetSupplier(id);
            return View(supplier);
        }

        [HttpPost]
        public IActionResult Edit(Supplier supplier)
        {
            try
            {
                supplier = _supplierRepo.Edit(supplier);
            }
            catch
            {

            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            Supplier supplier = _supplierRepo.GetSupplier(id);
            return View(supplier);
        }

        [HttpPost]
        public IActionResult Delete(Supplier supplier)
        {
            try
            {
                supplier = _supplierRepo.Delete(supplier);
            }
            catch
            {

            }

            return RedirectToAction(nameof(Index));
        }

    }
}
