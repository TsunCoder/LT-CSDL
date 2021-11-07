
namespace Lab6_Basic_Command
{
    partial class ViewRoleAccount
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
            this.dgvViewRole = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvViewRole)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvViewRole
            // 
            this.dgvViewRole.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvViewRole.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvViewRole.Location = new System.Drawing.Point(12, 12);
            this.dgvViewRole.Name = "dgvViewRole";
            this.dgvViewRole.RowHeadersWidth = 51;
            this.dgvViewRole.RowTemplate.Height = 24;
            this.dgvViewRole.Size = new System.Drawing.Size(841, 203);
            this.dgvViewRole.TabIndex = 0;
            // 
            // ViewRoleAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(865, 233);
            this.Controls.Add(this.dgvViewRole);
            this.Name = "ViewRoleAccount";
            this.Text = "ViewRoleAccount";
            ((System.ComponentModel.ISupportInitialize)(this.dgvViewRole)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvViewRole;
    }
}