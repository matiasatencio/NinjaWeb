using ninja.model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ninja.Models
{
    public class InvoiceViewModels
    {
        public long Id { get; set; }
        public string Type { get; set; }
        public IList<InvoiceDetail> Detail { get; set; }

        public enum Types
        {
            A,
            B,
            C
        }

        public InvoiceViewModels()
        {

        }
        public InvoiceViewModels(long id, string type)
        {
            Id = id;
            Type = type;
            Detail = new List<InvoiceDetail>();
        }
        public InvoiceViewModels(long id, string type, IList<InvoiceDetail> detail)
        {
            Id = id;
            Type = type;
            Detail = detail;
        }

        public List<InvoiceViewModels> Map(IEnumerable<Invoice> invoices)
        {
            List<InvoiceViewModels> list = new List<InvoiceViewModels>();
            foreach (Invoice inv in invoices)
            {
                list.Add(new InvoiceViewModels(inv.Id, inv.Type, inv.GetDetail()));
            }

            return list;
        }

        public InvoiceViewModels Map(Invoice invoice)
        {
            return new InvoiceViewModels(invoice.Id, invoice.Type, invoice.GetDetail());
        }


    }
}