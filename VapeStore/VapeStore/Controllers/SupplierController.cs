﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VapeStore.DataAccess;
using VapeStore.ViewModel;

namespace VapeStore.Controllers
{
    public class SupplierController : Controller
    {
        // GET: Supplier
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult List()
        {
            return View(SupplierDataAccess.GetAll());
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(SupplierViewModel model)
        {
            return CreateEdit(model);
        }
        [HttpPost]
        public ActionResult CreateEdit (SupplierViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (SupplierDataAccess.Update(model))
                    {
                        return Json(new { success = true, message = "berhasil" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { success = false, mesage = SupplierDataAccess.Message }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    return Json(new { succes = false, message = "Isi data dulu dengan benar!" },JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);

            }
        }
        public ActionResult Edit (int id)
        {
            return View(SupplierDataAccess.GetById(id));
        }
        [HttpPost]
       public ActionResult Edit(SupplierViewModel model)
        {
            return CreateEdit(model);
        }

        public ActionResult Delete (int id)
        {
            return View(SupplierDataAccess.GetById(id));
        }
        [HttpPost]
        public ActionResult DeleteConfirm (int id)
        {
            if (SupplierDataAccess.Delete(id))
            {
                return Json(new {success = true , message ="Sukses" },JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { success = false, message = SupplierDataAccess.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}