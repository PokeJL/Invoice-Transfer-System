namespace InvoiceTransfer
{
    partial class FundsTransfer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            VendorInvoiceDGV = new DataGridView();
            TargetInvoiceTXT = new TextBox();
            SourceMoveAmountTXT = new TextBox();
            TargetInLBL = new Label();
            SourceInLBL = new Label();
            TransferFundsTXT = new TextBox();
            TransferFundsLBL = new Label();
            TransferBTN = new Button();
            CloseBTN = new Button();
            ((System.ComponentModel.ISupportInitialize)VendorInvoiceDGV).BeginInit();
            SuspendLayout();
            // 
            // VendorInvoiceDGV
            // 
            VendorInvoiceDGV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            VendorInvoiceDGV.Location = new Point(12, 12);
            VendorInvoiceDGV.Name = "VendorInvoiceDGV";
            VendorInvoiceDGV.Size = new Size(960, 408);
            VendorInvoiceDGV.TabIndex = 0;
            VendorInvoiceDGV.CellClick += Invoice_CellClick;
            // 
            // TargetInvoiceTXT
            // 
            TargetInvoiceTXT.Enabled = false;
            TargetInvoiceTXT.Location = new Point(12, 454);
            TargetInvoiceTXT.Name = "TargetInvoiceTXT";
            TargetInvoiceTXT.Size = new Size(148, 23);
            TargetInvoiceTXT.TabIndex = 1;
            TargetInvoiceTXT.Tag = "Max Credit";
            // 
            // SourceMoveAmountTXT
            // 
            SourceMoveAmountTXT.Enabled = false;
            SourceMoveAmountTXT.Location = new Point(246, 454);
            SourceMoveAmountTXT.Name = "SourceMoveAmountTXT";
            SourceMoveAmountTXT.Size = new Size(148, 23);
            SourceMoveAmountTXT.TabIndex = 2;
            SourceMoveAmountTXT.Tag = "Max Debit";
            // 
            // TargetInLBL
            // 
            TargetInLBL.AutoSize = true;
            TargetInLBL.Font = new Font("Segoe UI", 12F);
            TargetInLBL.Location = new Point(12, 430);
            TargetInLBL.Name = "TargetInLBL";
            TargetInLBL.Size = new Size(148, 21);
            TargetInLBL.TabIndex = 3;
            TargetInLBL.Text = "Max Credit Amount:";
            // 
            // SourceInLBL
            // 
            SourceInLBL.AutoSize = true;
            SourceInLBL.Font = new Font("Segoe UI", 12F);
            SourceInLBL.Location = new Point(246, 430);
            SourceInLBL.Name = "SourceInLBL";
            SourceInLBL.Size = new Size(143, 21);
            SourceInLBL.TabIndex = 4;
            SourceInLBL.Text = "Max Debit Amount:";
            // 
            // TransferFundsTXT
            // 
            TransferFundsTXT.Location = new Point(479, 454);
            TransferFundsTXT.Name = "TransferFundsTXT";
            TransferFundsTXT.Size = new Size(148, 23);
            TransferFundsTXT.TabIndex = 5;
            TransferFundsTXT.Tag = "Debit Amount";
            // 
            // TransferFundsLBL
            // 
            TransferFundsLBL.AutoSize = true;
            TransferFundsLBL.Font = new Font("Segoe UI", 12F);
            TransferFundsLBL.Location = new Point(479, 430);
            TransferFundsLBL.Name = "TransferFundsLBL";
            TransferFundsLBL.Size = new Size(110, 21);
            TransferFundsLBL.TabIndex = 6;
            TransferFundsLBL.Text = "Debit Amount:";
            // 
            // TransferBTN
            // 
            TransferBTN.Font = new Font("Segoe UI", 12F);
            TransferBTN.Location = new Point(12, 483);
            TransferBTN.Name = "TransferBTN";
            TransferBTN.Size = new Size(74, 31);
            TransferBTN.TabIndex = 7;
            TransferBTN.Text = "Transfer";
            TransferBTN.UseVisualStyleBackColor = true;
            TransferBTN.Click += TransferBTN_Click;
            // 
            // CloseBTN
            // 
            CloseBTN.Font = new Font("Segoe UI", 12F);
            CloseBTN.Location = new Point(246, 483);
            CloseBTN.Name = "CloseBTN";
            CloseBTN.Size = new Size(74, 31);
            CloseBTN.TabIndex = 8;
            CloseBTN.Text = "Close";
            CloseBTN.UseVisualStyleBackColor = true;
            CloseBTN.Click += CloseBTN_Click;
            // 
            // FundsTransfer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(987, 520);
            Controls.Add(CloseBTN);
            Controls.Add(TransferBTN);
            Controls.Add(TransferFundsLBL);
            Controls.Add(TransferFundsTXT);
            Controls.Add(SourceInLBL);
            Controls.Add(TargetInLBL);
            Controls.Add(SourceMoveAmountTXT);
            Controls.Add(TargetInvoiceTXT);
            Controls.Add(VendorInvoiceDGV);
            Name = "FundsTransfer";
            Text = "Funds Transfer";
            Load += FormLoad;
            ((System.ComponentModel.ISupportInitialize)VendorInvoiceDGV).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView VendorInvoiceDGV;
        private TextBox TargetInvoiceTXT;
        private TextBox SourceMoveAmountTXT;
        private Label TargetInLBL;
        private Label SourceInLBL;
        private TextBox TransferFundsTXT;
        private Label TransferFundsLBL;
        private Button TransferBTN;
        private Button CloseBTN;
    }
}