using InvoiceData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceData
{
    public static class Operations
    {
        /// <summary>
        /// Creates a transaction to update the invoices in the DB
        /// </summary>
        /// <param name="sourceInID"></param>
        /// <param name="sourcePayAmount"></param>
        /// <param name="targetInID"></param>
        /// <param name="targetPayAmount"></param>
        /// <param name="payAmount"></param>
        public static void UpdateInvoiceWithLine
            (int sourceInID, decimal sourcePayAmount, int targetInID, decimal targetPayAmount, decimal payAmount)
        {
            //Opens connection to the DB
            using (APContext db = new APContext()) 
            {
                //Starts the transaction
                var tran = db.Database.BeginTransaction(); // start a transaction
                try
                {
                    //Gets the invoice where the source of the funds came from
                    Invoice invoiceSource = db.Invoices.Where(i => i.InvoiceId == sourceInID && i.PaymentTotal == sourcePayAmount).
                                            FirstOrDefault();

                    //Gets the invoice where the funds will be payed to
                    Invoice invoiceTarget = db.Invoices.Where(i => i.InvoiceId == targetInID && i.PaymentTotal == targetPayAmount).
                                            FirstOrDefault();
                    if (invoiceTarget == null)
                    {
                        throw new Exception("No target invoice with this code");
                    }

                    if (invoiceSource == null)
                    {
                        throw new Exception("No source invoice with this code");
                    }

                    //Makes the changes to the entries
                    invoiceSource.PaymentTotal -= payAmount;
                    invoiceTarget.PaymentTotal += payAmount;

                    //Saves to the DB
                    db.SaveChanges();

                    //Transaction ends and commited to the DB
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    //reverses the transaction if there was an issue
                    if (tran != null)
                        tran.Rollback();
                    throw ex;
                }
            }
        }
    }
}
