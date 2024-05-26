using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace InvoiceData.Models.DataAccessClasses
{
    public record InvoiceDTO(int InvoiceId,
                    int VendorId,
                    string InvoiceNumber,
                    DateOnly InvoiceDate,
                    double InvoiceTotal,
                    double PaymentTotal,
                    double CreditTotal,
                    int TermsId,
                    DateOnly InvoiceDueDate,
                    DateOnly? PaymentDate)
    {
        public class InvoiceDataAccess
        {
            private APContext context = new();

            /// <summary>
            /// Gets all product data from the database
            /// </summary>
            /// <returns></returns>
            public List<InvoiceDTO> GetAllInvoices() =>
                context.Invoices
                .Select(i => new InvoiceDTO(i.InvoiceId, i.VendorId, i.InvoiceNumber,
                    i.InvoiceDate, (double)i.InvoiceTotal, (double)i.PaymentTotal, (double)i.CreditTotal, i.TermsId,
                    i.InvoiceDueDate, i.PaymentDate))
                .ToList();

            /// <summary>
            /// Gets all invoices for one vendor
            /// </summary>
            /// <param name="vendor"></param>
            /// <returns></returns>
            public List<InvoiceDTO> GetAllVendorInvoices(int vendor)=>
                context.Invoices
                .Where(v => v.VendorId == vendor)
                .Select(i => new InvoiceDTO(i.InvoiceId, i.VendorId, i.InvoiceNumber,
                    i.InvoiceDate, (double)i.InvoiceTotal, (double)i.PaymentTotal, (double)i.CreditTotal, i.TermsId,
                    i.InvoiceDueDate, i.PaymentDate))
                .ToList();

            /// <summary>
            /// Makes a copy of the InvoiceDTO and store it in an Invoice object
            /// </summary>
            /// <param name="invo"></param>
            /// <returns></returns>
            public Invoice CopyInvoice(InvoiceDTO invo)
            {
                Invoice temp = new();

                temp.InvoiceId = invo.InvoiceId;
                temp.VendorId = invo.VendorId;
                temp.InvoiceNumber = invo.InvoiceNumber;
                temp.InvoiceDate = invo.InvoiceDate;
                temp.InvoiceTotal = (decimal)invo.InvoiceTotal;
                temp.PaymentTotal = (decimal)invo.PaymentTotal;
                temp.CreditTotal = (decimal)invo.CreditTotal;
                temp.TermsId = invo.TermsId;
                temp.InvoiceDueDate = invo.InvoiceDueDate;
                temp.PaymentDate = invo.PaymentDate;

                return temp;
            }
        }
    }
}
