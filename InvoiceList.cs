using InvoiceData.Models;
using static InvoiceData.Models.DataAccessClasses.InvoiceDTO;
using Microsoft.Data.SqlClient;

namespace InvoiceTransfer
{
    public partial class InvoiceList : Form
    {
        public InvoiceList()
        {
            InitializeComponent();
        }

        private InvoiceDataAccess data = new();

        private void FormLoad(object sender, EventArgs e)
        {
            DisplayProducts();
        }

        /// <summary>
        /// Displays the data in a data grid view
        /// </summary>
        private void DisplayProducts()
        {
            InvoiceDGV.Columns.Clear();
            InvoiceDGV.DataSource = data.GetAllInvoices();

            //----Everything below this point is to make the display of the data grid view nice.----
            //Format column headers
            InvoiceDGV.EnableHeadersVisualStyles = false;
            InvoiceDGV.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe", 14, FontStyle.Bold);
            InvoiceDGV.ColumnHeadersDefaultCellStyle.BackColor = Color.Indigo;
            InvoiceDGV.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            //Colour of everyother row
            InvoiceDGV.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;

            //Invoice ID column
            InvoiceDGV.Columns[0].HeaderText = "Invoice ID";

            //Vendor ID
            InvoiceDGV.Columns[1].HeaderText = "Vendor ID";

            //Invoice Number
            InvoiceDGV.Columns[2].HeaderText = "Invoice Number";

            //Invoice Date
            InvoiceDGV.Columns[3].HeaderText = "Invoice Date";

            //Invoice Total
            InvoiceDGV.Columns[4].HeaderText = "Invoice Total";

            //Payment Total
            InvoiceDGV.Columns[5].HeaderText = "Payment Total";

            //Credit Total
            InvoiceDGV.Columns[6].HeaderText = "Credit Total";

            //Terms
            InvoiceDGV.Columns[7].HeaderText = "Terms";

            //Invoice Due
            InvoiceDGV.Columns[8].HeaderText = "Invoice Due";

            //Payment Due
            InvoiceDGV.Columns[9].HeaderText = "Payment Due";

            //Format columns loop to reduce redundant code.
            for (int i = 0; i < InvoiceDGV.ColumnCount; i++)
            {
                InvoiceDGV.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                InvoiceDGV.Columns[i].Width = 90;
            }
        }

        /// <summary>
        /// Opens the Transfer funds form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FundsBTN_Click(object sender, EventArgs e)
        {
            //Only could think of the logic to code this in revers
            //Chacks to makes sure the target invoice could actually have funds moved to it
            if (!ValidationCheck.NotPositiveValue(
                Convert.ToDecimal(InvoiceDGV.Rows[InvoiceDGV.CurrentCell.RowIndex].Cells[4].Value.ToString().Trim()),
                Convert.ToDecimal(InvoiceDGV.Rows[InvoiceDGV.CurrentCell.RowIndex].Cells[5].Value.ToString().Trim()),
                Convert.ToDecimal(InvoiceDGV.Rows[InvoiceDGV.CurrentCell.RowIndex].Cells[6].Value.ToString().Trim())
                ))
            {
                MessageBox.Show("Selected invoice has been payed for already.", "Already Paid");
            }
            else //If the invoice can have funds moved to it opens the Transfer Funds form
            {
                FundsTransfer funds = new();
                funds.venId = Convert.ToInt32(InvoiceDGV.Rows[InvoiceDGV.CurrentCell.RowIndex].Cells[1].Value.ToString());
                funds.sourceId = Convert.ToInt32(InvoiceDGV.Rows[InvoiceDGV.CurrentCell.RowIndex].Cells[0].Value.ToString());
                DialogResult result = funds.ShowDialog();
                DisplayProducts();
            }
        }
    }
}
