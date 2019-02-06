using ninja.model.Entity;
using ninja.model.Manager;
using ninja.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ninja.model.Helpers;

namespace ninja.Controllers
{
    public class UpdateController : Controller
    {
        private InvoiceManager manager = new InvoiceManager();

        // GET: Update
        public ActionResult Update(long id, string type)
        {
            InvoiceViewModels vm = new InvoiceViewModels(id, type);
            //Invoice invoice = new Invoice(id, type);
            //IEnumerable<Invoice> invoices = manager.GetAll().Where(c => c.Id == id);
            //IEnumerable<InvoiceViewModels> invoicesVM = vm.Map(invoices);

            return View(vm);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Save(InvoiceViewModels vm, string newId, Invoice.Types newType)
        {
            try
            {
                Invoice invoice = manager.GetById(vm.Id);
                invoice.Id = int.Parse(newId);
                invoice.Type = newType.ToString();

                return RedirectToAction("Index", "Invoice");
            }
            catch
            {
                return Content(Constants.C_ERROR_UPDATE);
            }
        }
    }
}