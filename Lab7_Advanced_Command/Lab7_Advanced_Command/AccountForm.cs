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

namespace Lab7_Advanced_Command
{
    public partial class AccountForm : Form
    {
        public AccountForm()
        {
            InitializeComponent();
        }

        private void setNameColumns(DataTable table)
        {
            dgvAccount.DataSource = table;
            dgvAccount.Columns[0].ReadOnly = true;

            dgvAccount.Columns[0].HeaderCell.Value = "Tên tài khoản";
            dgvAccount.Columns[1].HeaderCell.Value = "Password";
            dgvAccount.Columns[2].HeaderCell.Value = "Họ tên";
            dgvAccount.Columns[3].HeaderCell.Value = "Email";
            dgvAccount.Columns[4].HeaderCell.Value = "SĐT";
            dgvAccount.Columns[5].HeaderCell.Value = "Ngày tạo";
        }

        public void LoadAccount()
        {
            try
            {
                this.Text = "Danh sách tài khoản";
                string connectionString = "Data Source=DESKTOP-LH1UFFR\\THIENSON;Initial Catalog=RestaurantManagement;Integrated Security=True";
                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT * FROM Account";

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();

                connection.Open();
                adapter.Fill(dataTable);
                dgvAccount.DataSource = dataTable;
                setNameColumns(dataTable);
                connection.Close();
                connection.Dispose();
            }
            catch (Exception exc)
            {

                MessageBox.Show(exc.Message,"SQL Error!");
            }
            
        }

        private void AccountForm_Load(object sender, EventArgs e)
        {
            btnUpdate.Enabled = false;
            this.LoadAccount();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = "Data Source=DESKTOP-LH1UFFR\\THIENSON;Initial Catalog=RestaurantManagement;Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);

                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandText = "EXEC InsertAccount @AccountName, @Password, @FullName, @Email, @Tell, @DateCreated";

                sqlCommand.Parameters.Add("@AccountName", SqlDbType.NVarChar, 100);
                sqlCommand.Parameters.Add("@Password", SqlDbType.NVarChar, 100);
                sqlCommand.Parameters.Add("@FullName", SqlDbType.NVarChar, 1000);
                sqlCommand.Parameters.Add("@Email", SqlDbType.NVarChar, 300);
                sqlCommand.Parameters.Add("@Tell", SqlDbType.NVarChar, 100);
                sqlCommand.Parameters.Add("@DateCreated", SqlDbType.SmallDateTime);

                sqlCommand.Parameters["@AccountName"].Value = txtAccountName.Text;
                sqlCommand.Parameters["@Password"].Value = txtPass.Text;
                sqlCommand.Parameters["@FullName"].Value = txtFullName.Text;
                sqlCommand.Parameters["@Email"].Value = txtEmail.Text;
                sqlCommand.Parameters["@Tell"].Value = txtTell.Text;
                sqlCommand.Parameters["@DateCreated"].Value = DateTime.Now.ToShortDateString();

                sqlConnection.Open();

                int num = sqlCommand.ExecuteNonQuery();
                if (num == 1)
                {
                    LoadAccount();
                    resetText();
                    MessageBox.Show("Thêm thành công!");
                }
                else
                {
                    MessageBox.Show("Đã xảy ra lỗi vui lòng thử lại");
                }
                sqlConnection.Close();

            }
            catch (Exception exc)
            {

                MessageBox.Show(exc.Message, "SQL Error!");
            }
        }

        public void resetText()
        {
            txtAccountName.ResetText();
            txtPass.ResetText();
            txtFullName.ResetText();
            txtEmail.ResetText();
            txtTell.ResetText();

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = "Data Source=DESKTOP-LH1UFFR\\THIENSON;Initial Catalog=RestaurantManagement;Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);

                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandText = "EXEC UpdateAccount @AccountName, @Password, @FullName, @Email, @Tell, @DateCreated";

                sqlCommand.Parameters.Add("@AccountName", SqlDbType.NVarChar, 100);
                sqlCommand.Parameters.Add("@Password", SqlDbType.NVarChar, 100);
                sqlCommand.Parameters.Add("@FullName", SqlDbType.NVarChar, 1000);
                sqlCommand.Parameters.Add("@Email", SqlDbType.NVarChar, 300);
                sqlCommand.Parameters.Add("@Tell", SqlDbType.NVarChar, 100);
                sqlCommand.Parameters.Add("@DateCreated", SqlDbType.SmallDateTime);

                sqlCommand.Parameters["@AccountName"].Value = txtAccountName.Text;
                sqlCommand.Parameters["@Password"].Value = txtPass.Text;
                sqlCommand.Parameters["@FullName"].Value = txtFullName.Text;
                sqlCommand.Parameters["@Email"].Value = txtEmail.Text;
                sqlCommand.Parameters["@Tell"].Value = txtTell.Text;
                sqlCommand.Parameters["@DateCreated"].Value = DateTime.Now.ToShortDateString();

                sqlConnection.Open();

                int num = sqlCommand.ExecuteNonQuery();
                if (num == 1)
                {
                    LoadAccount();
                    resetText();
                    MessageBox.Show("Sửa thành công!");
                }
                else
                {
                    MessageBox.Show("Đã xảy ra lỗi vui lòng thử lại");
                }
                sqlConnection.Close();

            }
            catch (Exception exc)
            {

                MessageBox.Show(exc.Message, "SQL Error!");
            }
        }

        private void dgvAccount_Click(object sender, EventArgs e)
        {
            int index = dgvAccount.CurrentRow.Index;
            if (index != null)
            {
                txtAccountName.Text = dgvAccount.Rows[index].Cells["AccountName"].Value.ToString();
                txtPass.Text = dgvAccount.Rows[index].Cells["Password"].Value.ToString();
                txtFullName.Text = dgvAccount.Rows[index].Cells["FullName"].Value.ToString();
                txtEmail.Text = dgvAccount.Rows[index].Cells["Email"].Value.ToString();
                txtTell.Text = dgvAccount.Rows[index].Cells["Tell"].Value.ToString();
                btnUpdate.Enabled = true;
            }
        }

        private void tsmiViewRole_Click(object sender, EventArgs e)
        {
            if (dgvAccount.SelectedRows.Count == 0) return;
            var rowSelected = dgvAccount.SelectedRows[0];
            string name = dgvAccount.SelectedRows[0].Cells[0].Value.ToString();
            RoleForm roleForm = new RoleForm(name);
            roleForm.LoadRole();
            roleForm.LoadCheck(name);
            roleForm.ShowDialog();

        }

        private void tsmiViewAction_Click(object sender, EventArgs e)
        {
            string accountName = dgvAccount.SelectedRows[0].Cells[0].Value.ToString();
            if (dgvAccount.SelectedRows.Count == 0) return;
            DiaryForm diaryForm = new DiaryForm();
            diaryForm.LoadBills(accountName);
            diaryForm.ShowDialog();
        }
    }
}
