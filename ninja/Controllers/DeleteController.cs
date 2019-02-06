using ninja.model.Helpers;
using ninja.model.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ninja.Controllers
{
    public class DeleteController : Controller
    {
        private InvoiceManager manager = new InvoiceManager();

        // GET: Delete
        public ActionResult Delete(long id)
        {
            if (manager.Exists(id))
            {
                manager.Delete(id);
                return RedirectToAction("Index", "Invoice");
            }
            else
            {
                return Content(string.Format(Constants.C_FACTURA_INEXISTENTE), id.ToString());
            }
        }
    }
}