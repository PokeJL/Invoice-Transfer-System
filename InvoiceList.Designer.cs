namespace InvoiceTransfer
{
    partial class InvoiceList
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            InvoiceDGV = new DataGridView();
            FundsBTN = new Button();
            ((System.ComponentModel.ISupportInitialize)InvoiceDGV).BeginInit();
            SuspendLayout();
            // 
            // InvoiceDGV
            // 
            InvoiceDGV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            InvoiceDGV.Location = new Point(12, 12);
            InvoiceDGV.Name = "InvoiceDGV";
            InvoiceDGV.Size = new Size(960, 408);
            InvoiceDGV.TabIndex = 0;
            // 
            // FundsBTN
            // 
            FundsBTN.Font = new Font("Segoe UI", 12F);
            FundsBTN.Location = new Point(12, 436);
            FundsBTN.Name = "FundsBTN";
            FundsBTN.Size = new Size(122, 37);
            FundsBTN.TabIndex = 1;
            FundsBTN.Text = "Transfer Funds";
            FundsBTN.UseVisualStyleBackColor = true;
            FundsBTN.Click += FundsBTN_Click;
            // 
            // InvoiceList
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(987, 503);
            Controls.Add(FundsBTN);
            Controls.Add(InvoiceDGV);
            Name = "InvoiceList";
            Text = "Invoice List";
            Load += FormLoad;
            ((System.ComponentModel.ISupportInitialize)InvoiceDGV).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView InvoiceDGV;
        private Button FundsBTN;
    }
}
