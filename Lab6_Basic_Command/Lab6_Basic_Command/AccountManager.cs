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
    public partial class AccountManager : Form
    {
        int countBegin = 0, countAfter = 0;
        public AccountManager()
        {
            InitializeComponent();
            LoadAccount();
        }

        public void LoadAccount()
        {
            comboBox1.SelectedIndex = 0;
            this.Text = "Danh sách tài khoản";
            string connectionString = "Data Source=DESKTOP-LH1UFFR\\THIENSON;Initial Catalog=RestaurantManagement;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = sqlConnection.CreateCommand();

            string query = "select * from Account";
            sqlConnection.Open();

            sqlCommand.CommandText = query;
            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);

            DataTable table = new DataTable("Food");
            adapter.Fill(table);

            dgvAccount.DataSource = table;
            countBegin = dgvAccount.Rows.Count - 1;
            sqlConnection.Close();
            sqlConnection.Dispose();
            adapter.Dispose();
        }
        private void AccountManager_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-LH1UFFR\\THIENSON;Initial Catalog=RestaurantManagement;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = sqlConnection.CreateCommand();

            if(comboBox1.SelectedItem.ToString() == "Trạng thái")
            {
                this.dgvAccount.DataSource = null;
                sqlCommand.CommandText = "select RoleAccount.Actived, Account.AccountName, Account.[Password], Account.FullName, Account.Email, Account.Tell, Account.DateCreated, RoleAccount.Notes" +
                    " from Account, [Role]" +
                    " join RoleAccount on [Role].ID = RoleAccount.RoleID" +
                    "   where Account.AccountName = RoleAccount.AccountName";
                sqlConnection.Open();

                SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dgvAccount.DataSource = table;
                dgvAccount.Columns[0].ReadOnly = true;
                sqlConnection.Close();
            }
            else if(comboBox1.SelectedItem.ToString() == "Nhóm")
            {
                this.dgvAccount.DataSource = null;
                sqlCommand.CommandText = "select [Role].ID, Account.AccountName, Account.[Password], Account.FullName, Account.Email, Account.Tell, Account.DateCreated, RoleAccount.Notes" +
                    " from Account, [Role]" +
                    " join RoleAccount on [Role].ID = RoleAccount.RoleID" +
                    " where Account.AccountName = RoleAccount.AccountName";
                sqlConnection.Open();

                SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dgvAccount.DataSource = table;
                dgvAccount.Columns[0].ReadOnly = true;
                sqlConnection.Close();
            }
            else
            {
                this.dgvAccount.DataSource = null;
                sqlCommand.CommandText = "select * from Account";
                sqlConnection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);

                DataTable table = new DataTable("Food");
                adapter.Fill(table);

                dgvAccount.DataSource = table;

                sqlConnection.Close();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            var selectedRow = dgvAccount.SelectedRows[0];
            string accountName = selectedRow.Cells[0].Value.ToString();
            string defaultPassword = "123456789";
            string connectionString = "Data Source=DESKTOP-LH1UFFR\\THIENSON;Initial Catalog=RestaurantManagement;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = sqlConnection.CreateCommand();

            if(comboBox1.SelectedItem.ToString() == "Mặc định")
            {
                sqlConnection.Open();
                sqlCommand.CommandText = string.Format($"UPDATE Account SET Password = '{defaultPassword}' WHERE AccountName = '{accountName}'");
                sqlCommand.ExecuteNonQuery();
                MessageBox.Show("Reset thành công!");

                sqlConnection.Close();
            }
            else
            {
                MessageBox.Show("Reset thất bại. Vui lòng thử lại");
            }
        }

        private void tsmiDeleteAccount_Click(object sender, EventArgs e)
        {
            if (dgvAccount.SelectedRows.Count == 0) return;

            var rowSelected = dgvAccount.SelectedRows[0];
            string account = rowSelected.Cells[0].Value.ToString();

            string connectionString = "Data Source=DESKTOP-LH1UFFR\\THIENSON;Initial Catalog=RestaurantManagement;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = sqlConnection.CreateCommand();

            sqlConnection.Open();
            sqlCommand.CommandText = $"update RoleAccount set Actived = '0' where AccountName = '{account}'";

            int numRowEffected = sqlCommand.ExecuteNonQuery();
            if(numRowEffected == 1)
            {
                MessageBox.Show("Xóa thành công!");
            }
            sqlConnection.Close();
        }

        private void tsmiViewRole_Click(object sender, EventArgs e)
        {
            if (dgvAccount.SelectedRows.Count == 0) return;
            var rowSelected = dgvAccount.SelectedRows[0];
            string account = rowSelected.Cells[0].Value.ToString();

            ViewRoleAccount frm = new ViewRoleAccount();
            frm.Show();
            frm.LoadRole(account);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddAccount frm = new AddAccount();
            frm.Show();
        }
    }
}
