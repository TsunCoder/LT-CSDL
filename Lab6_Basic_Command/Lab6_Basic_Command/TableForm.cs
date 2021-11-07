using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Lab6_Basic_Command
{
    public partial class TableForm : Form
    {
        public TableForm()
        {
            InitializeComponent();
        }

        public void LoadTable()
        {
            string connectionString = "Data Source=DESKTOP-LH1UFFR\\THIENSON;Initial Catalog=RestaurantManagement;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = sqlConnection.CreateCommand();

            sqlConnection.Open();
            sqlCommand.CommandText = "select * from [Table]";
            sqlCommand.ExecuteNonQuery();

            this.Text = "Danh sách tất cả các bàn";

            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
            DataTable table = new DataTable();

            adapter.Fill(table);
            dgvTable.DataSource = table;
            dgvTable.Columns[0].ReadOnly = true;

            sqlConnection.Close();
            adapter.Dispose();
        }

        private bool CheckThongTin()
        {
            if (string.IsNullOrEmpty(txtTable.Text)) return false;
            else if (string.IsNullOrEmpty(cbbStatus.Text)) return false;
            else if (string.IsNullOrEmpty(txtCapacity.Text)) return false;
            return true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (CheckThongTin())
            {
                string connectionString = "Data Source=DESKTOP-LH1UFFR\\THIENSON;Initial Catalog=RestaurantManagement;Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                SqlCommand sqlCommand = sqlConnection.CreateCommand();

                sqlConnection.Open();

                sqlCommand.CommandText = $"select Name from [Table] where Name = '{txtTable.Text}'";
                var check = sqlCommand.ExecuteScalar();

                if(check == null)
                {
                    sqlCommand.CommandText = string.Format($"insert into [Table](Name, Status, Capacity) values (N'{txtTable.Text}', {(cbbStatus.Text == "Trống" ? 0 : 1)}, {txtCapacity.Text})");
                    int numOfRow = sqlCommand.ExecuteNonQuery();
                    if(numOfRow == 1)
                    {
                        LoadTable();
                        MessageBox.Show("Thêm thành công");
                    }
                    else
                    {
                        MessageBox.Show("Lỗi");
                    }
                }
                else
                {
                    MessageBox.Show("Bàn đã tồn tại");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (CheckThongTin())
            {
                string connectionString = "Data Source=DESKTOP-LH1UFFR\\THIENSON;Initial Catalog=RestaurantManagement;Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                string id = dgvTable.SelectedRows[0].Cells[0].Value.ToString();
                sqlConnection.Open();

                sqlCommand.CommandText = $"select Name from [Table] WHERE Name = '{txtTable.Text}'";
                var check = sqlCommand.ExecuteScalar();
                sqlCommand.CommandText = string.Format($"update [Table] set Name = '{txtTable.Text}', Status = {(cbbStatus.Text == "Trống" ? "0" : "1")}, Capacity = {txtCapacity.Text} WHERE ID = {id}");

                int numOfRows = sqlCommand.ExecuteNonQuery();

                if (numOfRows == 1)
                {
                    MessageBox.Show("Cập nhập thành công");
                }
                else
                {                  
                    MessageBox.Show("Đã xảy ra lỗi", "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                }
                sqlConnection.Close();
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            }
        }

        private void dgvTable_Click(object sender, EventArgs e)
        {
            int index = dgvTable.CurrentRow.Index;

            txtTable.Text = dgvTable.Rows[index].Cells["Name"].Value.ToString();
            cbbStatus.Text = dgvTable.Rows[index].Cells["Status"].Value.ToString() == "0" ? "Trống" : "Có người";
            txtCapacity.Text = dgvTable.Rows[index].Cells["Capacity"].Value.ToString();

            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvTable.SelectedRows.Count == 0) return;
            var rowSelect = dgvTable.SelectedRows[0];
            string id = dgvTable.SelectedRows[0].Cells[0].Value.ToString();

            string connectionString = "Data Source=DESKTOP-LH1UFFR\\THIENSON;Initial Catalog=RestaurantManagement;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = sqlConnection.CreateCommand();

            string query = string.Format("Delete from Bills Where TableID = {0}", id);
            sqlCommand.CommandText = query;

            sqlConnection.Open();

            sqlCommand.ExecuteNonQuery();

            sqlCommand.CommandText = "Delete from [Table] Where ID = " + id;
            sqlCommand.ExecuteNonQuery();

            dgvTable.Rows.Remove(rowSelect);
            LoadTable();
            MessageBox.Show("Xóa thành công");

            sqlConnection.Close();
        }

        private void tsmiDelete_Click(object sender, EventArgs e)
        {
            if(dgvTable.SelectedRows.Count > 0)
            {
                btnDelete.PerformClick();
            }
        }

        private void dgvTable_DoubleClick(object sender, EventArgs e)
        {

        }

        private void tsmiViewHD1_Click(object sender, EventArgs e)
        {
            string id = dgvTable.SelectedRows[0].Cells[0].Value.ToString();
            if (dgvTable.SelectedRows.Count == 0) return;

            TableBills frm = new TableBills();
            frm.Show(this);
            frm.LoadBills(id);
        }
    }
}
