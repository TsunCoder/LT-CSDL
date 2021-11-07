
namespace Lab6_Basic_Command
{
    partial class TableBills
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
            this.lbDate = new System.Windows.Forms.ListBox();
            this.dgvTableBills = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTableBills)).BeginInit();
            this.SuspendLayout();
            // 
            // lbDate
            // 
            this.lbDate.FormattingEnabled = true;
            this.lbDate.ItemHeight = 16;
            this.lbDate.Location = new System.Drawing.Point(12, 12);
            this.lbDate.Name = "lbDate";
            this.lbDate.Size = new System.Drawing.Size(184, 420);
            this.lbDate.TabIndex = 0;
            this.lbDate.SelectedIndexChanged += new System.EventHandler(this.lbDate_SelectedIndexChanged);
            // 
            // dgvTableBills
            // 
            this.dgvTableBills.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTableBills.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTableBills.Location = new System.Drawing.Point(202, 12);
            this.dgvTableBills.Name = "dgvTableBills";
            this.dgvTableBills.RowHeadersWidth = 51;
            this.dgvTableBills.RowTemplate.Height = 24;
            this.dgvTableBills.Size = new System.Drawing.Size(586, 420);
            this.dgvTableBills.TabIndex = 1;
            // 
            // TableBills
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvTableBills);
            this.Controls.Add(this.lbDate);
            this.Name = "TableBills";
            this.Text = "TableBills";
            ((System.ComponentModel.ISupportInitialize)(this.dgvTableBills)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbDate;
        private System.Windows.Forms.DataGridView dgvTableBills;
    }
}