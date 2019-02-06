using ninja.model.Entity;
using ninja.model.Helpers;
using ninja.model.Manager;
using ninja.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ninja.Controllers
{
    public class NewController : Controller
    {
        private InvoiceManager manager = new InvoiceManager();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult New(long Id, string Type)
        {
            if(manager.Exists(Id))
            {
                return Content(string.Format(Constants.C_FACTURA_EXISTENTE), Id.ToString());
            }
            else if(Type != Invoice.Types.A.ToString() && Type != Invoice.Types.B.ToString() && Type != Invoice.Types.C.ToString())
            {
                return Content(string.Format(Constants.C_TIPO_INEXISTENTE), Id.ToString());
            }
            else
            {
                Invoice invoice = new Invoice(Id, Type);
                manager.Insert(invoice);
                return RedirectToAction("Index", "Invoice");
            }
        }
    }
}