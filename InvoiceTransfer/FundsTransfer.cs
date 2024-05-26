using InvoiceData;
using InvoiceData.Models;
using InvoiceData.Models.DataAccessClasses;
using Microsoft.Data.SqlClient;
using static InvoiceData.Models.DataAccessClasses.InvoiceDTO;

namespace InvoiceTransfer
{
    public partial class FundsTransfer : Form
    {
        public int venId; //Stores the vendors ID
        public int sourceId; //Stores the source invoice ID
        public FundsTransfer()
        {
            InitializeComponent();
            venId = 0;
            sourceId = 0;
        }

        public Invoice Invoice { get; set; } = null;
        private InvoiceDataAccess data = new();
        private Invoice target = new();

        private void FormLoad(object sender, EventArgs e)
        {
            DisplayProducts();
        }

        /// <summary>
        /// Dispalys the list of usuable invoices for the Funds Transfer form
        /// </summary>
        private void DisplayProducts()
        {
            List<Invoice> inv = new(); //The invoice list

            //Gets all invoives for a vendor then filters them to ones the user can use
            foreach (InvoiceDTO invo in data.GetAllVendorInvoices(venId).ToArray())
            {
                if (invo.InvoiceId != sourceId) //Ensures the target invoice is not included
                {
                    if ((decimal)invo.PaymentTotal > (decimal)0.0) //Adds invoices with a positive Payment total
                    {
                        inv.Add(data.CopyInvoice(invo));
                    }
                }
                else
                    target = data.CopyInvoice(invo); //Stores the target invoice sepratly
            }

            //If the vendor only has 1 invoice the form will auto close the tell the user that
            if (inv.Count == 0)
            {
                MessageBox.Show("No valid invoices found.", "No Results");
                Close();
            }

            VendorInvoiceDGV.Columns.Clear();
            VendorInvoiceDGV.DataSource = inv;

            //Fills in the text boxes with usefull info for the user to see
            TargetInvoiceTXT.Text = (target.InvoiceTotal - target.PaymentTotal - target.CreditTotal).ToString();
            SourceMoveAmountTXT.Text = VendorInvoiceDGV.Rows[VendorInvoiceDGV.CurrentCell.RowIndex].Cells[5].Value.ToString().Trim();

            //----Everything below this point is to make the display of the data grid view nice.----
            //Format column headers
            VendorInvoiceDGV.EnableHeadersVisualStyles = false;
            VendorInvoiceDGV.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe", 14, FontStyle.Bold);
            VendorInvoiceDGV.ColumnHeadersDefaultCellStyle.BackColor = Color.Goldenrod;
            VendorInvoiceDGV.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            //Colour of everyother row
            VendorInvoiceDGV.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;

            //Invoice ID column
            VendorInvoiceDGV.Columns[0].HeaderText = "Invoice ID";

            //Vendor ID
            VendorInvoiceDGV.Columns[1].HeaderText = "Vendor ID";

            //Invoice Number
            VendorInvoiceDGV.Columns[2].HeaderText = "Invoice Number";

            //Invoice Date
            VendorInvoiceDGV.Columns[3].HeaderText = "Invoice Date";

            //Invoice Total
            VendorInvoiceDGV.Columns[4].HeaderText = "Invoice Total";

            //Payment Total
            VendorInvoiceDGV.Columns[5].HeaderText = "Payment Total";

            //Credit Total
            VendorInvoiceDGV.Columns[6].HeaderText = "Credit Total";

            //Terms
            VendorInvoiceDGV.Columns[7].HeaderText = "Terms";

            //Invoice Due
            VendorInvoiceDGV.Columns[8].HeaderText = "Invoice Due";

            //Payment Due
            VendorInvoiceDGV.Columns[9].HeaderText = "Payment Due";

            //Remove uneeded columns
            VendorInvoiceDGV.Columns[10].Visible = false;
            VendorInvoiceDGV.Columns[11].Visible = false;
            VendorInvoiceDGV.Columns[12].Visible = false;

            //Format columns loop to reduce redundant code.
            for (int i = 0; i < VendorInvoiceDGV.ColumnCount; i++)
            {
                VendorInvoiceDGV.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                VendorInvoiceDGV.Columns[i].Width = 90;
            }
        }

        /// <summary>
        /// Update the source invoice payment amout textbox when the user click on a cell
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Invoice_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SourceMoveAmountTXT.Text = VendorInvoiceDGV.Rows[e.RowIndex].Cells[5].Value.ToString().Trim();
        }

        /// <summary>
        /// Closes the form when the close button is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseBTN_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Submits the transfer of funds when the submit button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TransferBTN_Click(object sender, EventArgs e)
        {
            //Validates the data of the funds that are being moved
            if (ValidationCheck.NotEmpty(TransferFundsTXT) &&
                ValidationCheck.ProperNumber(TransferFundsTXT) &&
                ValidationCheck.ProperPayAmount(TargetInvoiceTXT, SourceMoveAmountTXT, TransferFundsTXT)
                )
            {
                try
                {
                    //Start of the transaction passing the Source invoice ID and payamount, target invoice ID and payamount, and amount of payment
                    Operations.UpdateInvoiceWithLine(
                        Convert.ToInt32(VendorInvoiceDGV.Rows[VendorInvoiceDGV.CurrentCell.RowIndex].Cells[0].Value.ToString().Trim()),
                        Convert.ToDecimal(VendorInvoiceDGV.Rows[VendorInvoiceDGV.CurrentCell.RowIndex].Cells[5].Value.ToString().Trim()), 
                        target.InvoiceId, 
                        target.PaymentTotal, 
                        Convert.ToDecimal(TransferFundsTXT.Text.Trim()));// transaction
                    DialogResult = DialogResult.OK; //If all good return to main form
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message, "Database Error");
                    DialogResult = DialogResult.Cancel;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Operation Cancelled");
                    DialogResult = DialogResult.Cancel;
                }
            }
        }
    }
}
