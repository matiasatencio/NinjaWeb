using ninja.model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ninja.Models
{
    public class InvoiceDetailViewModels
    {
        public double Taxes { get; set; }
        public long InvoiceId { get; set; }
        public long Id { get; set; }
        public string Description { get; set; }
        public double Amount { get; set; }
        public double UnitPrice { get; set; }
        public double TotalPrice { get; set; }
        public double TotalPriceWithTaxes { get; set; }

        public InvoiceDetailViewModels()
        {
        }
        public InvoiceDetailViewModels(double taxes, long invoiceId, long id, string description, double amount, double unitPrice, double totalPrice, double totalPriceWithTaxes)
        {
            Taxes = taxes;
            InvoiceId = invoiceId;
            Id = id;
            Description = description;
            Amount = amount;
            UnitPrice = unitPrice;
            TotalPrice = totalPrice;
            TotalPriceWithTaxes = totalPriceWithTaxes;
        }

        public List<InvoiceDetailViewModels> Map(IEnumerable<InvoiceDetail> details)
        {
            List<InvoiceDetailViewModels> list = new List<InvoiceDetailViewModels>();
            foreach (InvoiceDetail inv in details)
            {
                list.Add(new InvoiceDetailViewModels(inv.Taxes, inv.InvoiceId, inv.Id, inv.Description, inv.Amount, inv.UnitPrice, inv.TotalPrice, inv.TotalPriceWithTaxes));
            }

            return list;
        }
    }
}