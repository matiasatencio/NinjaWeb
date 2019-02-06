using ninja.model.Entity;
using ninja.model.Manager;
using ninja.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ninja.Controllers
{
    public class InvoiceController : Controller
    {
        private InvoiceManager manager = new InvoiceManager();

        // GET: Invoice
        public ActionResult Index()
        {
            InvoiceViewModels vm = new InvoiceViewModels();
            IEnumerable<Invoice> invoices = manager.GetAll();
            IEnumerable<InvoiceViewModels> invoicesVM = vm.Map(invoices);

            return View(invoicesVM);
        }

        // GET: Invoice/Details/5
        public ActionResult Detail(long id)
        {
            InvoiceDetailViewModels vm = new InvoiceDetailViewModels();
            IEnumerable<InvoiceDetail> invDetails = manager.GetById(id).GetDetail();
            IEnumerable<InvoiceDetailViewModels> detailVM = vm.Map(invDetails);
            return View(detailVM);
        }
        
    }
}
