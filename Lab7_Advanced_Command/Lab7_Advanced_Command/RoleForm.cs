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
    public partial class RoleForm : Form
    {
        string name;
        public RoleForm(string name)
        {
            InitializeComponent();
            DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
            checkBoxColumn.HeaderText = "Check";
            checkBoxColumn.Width = 50;
            checkBoxColumn.ReadOnly = true;
            dgvRole.Columns.Add(checkBoxColumn);
            this.name = name;
        }

        private void setNameColumns(DataTable table)
        {
            dgvRole.DataSource = table;

            dgvRole.Columns[1].HeaderCell.Value = "Mã vai trò";
            dgvRole.Columns[2].HeaderCell.Value = "Tên vai trò";
            dgvRole.Columns[3].HeaderCell.Value = "Đường dẫn";
            dgvRole.Columns[4].HeaderCell.Value = "Ghi chú";
        }
        public void LoadRole()
        {
            this.Text = "Danh sách vai trò";
            string connectionString = "Data Source=DESKTOP-LH1UFFR\\THIENSON;Initial Catalog=RestaurantManagement;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandText = $"Select * From Role";
            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
            DataTable dt = new DataTable();
 
            sqlConnection.Open();
            adapter.Fill(dt);
            setNameColumns(dt);
            dgvRole.DataSource = dt;
            sqlConnection.Close();
        }

        public void LoadCheck(string nameAccount)
        {
            string connectionString = "Data Source=DESKTOP-LH1UFFR\\THIENSON;Initial Catalog=RestaurantManagement;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
            DataTable dt = new DataTable();
            sqlCommand.CommandText = $"select RoleID from RoleAccount, Role, Account Where RoleAccount.RoleID = Role.ID and Account.AccountName = '" + nameAccount + "'";
            for (int i = 0; i <= dgvRole.Rows.Count - 1; i++)
            {
                bool checkRole = (bool)dgvRole.Rows[i].Cells[0].Value;
                sqlConnection.Open();
                adapter.Fill(dt);
                int num = sqlCommand.ExecuteNonQuery();
                if (num > 0)
                {
                    checkRole = true;
                }
                sqlConnection.Close();

            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = "Data Source=DESKTOP-LH1UFFR\\THIENSON;Initial Catalog=RestaurantManagement;Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);

                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandText = "EXEC InsertRole @ID output, @RoleName, @Path, @Notes";

                sqlCommand.Parameters.Add("@ID", SqlDbType.Int);
                sqlCommand.Parameters.Add("@RoleName", SqlDbType.NVarChar, 1000);
                sqlCommand.Parameters.Add("@Path", SqlDbType.NVarChar, 1000);
                sqlCommand.Parameters.Add("@Notes", SqlDbType.NVarChar, 3000);

                sqlCommand.Parameters["@ID"].Direction = ParameterDirection.Output;

                sqlCommand.Parameters["@RoleName"].Value = txtRoleName.Text;
                sqlCommand.Parameters["@Path"].Value = txtPath.Text;
                sqlCommand.Parameters["@Notes"].Value = txtNotes.Text;
                sqlConnection.Open();
                int numRowAffected = sqlCommand.ExecuteNonQuery();
                if (numRowAffected > 0)
                {
                    MessageBox.Show("Thêm thành công vai trò", "Message");
                    LoadRole();
                }
                else
                {
                    MessageBox.Show("Đã xảy ra lỗi", "Message");
                }
            }
            catch (SqlException exception)
            {
                MessageBox.Show(exception.Message, "SQL Error");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error");
            }


        }

        private void RoleForm_Load(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = "Data Source=DESKTOP-LH1UFFR\\THIENSON;Initial Catalog=RestaurantManagement;Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                SqlCommand sqlCommand = sqlConnection.CreateCommand();

                sqlCommand.CommandText = "EXEC UpdateRole @ID, @RoleName, @Path, @Notes";

                sqlCommand.Parameters.Add("@ID", SqlDbType.Int);
                sqlCommand.Parameters.Add("@RoleName", SqlDbType.NVarChar, 1000);
                sqlCommand.Parameters.Add("@Path", SqlDbType.NVarChar, 3000);
                sqlCommand.Parameters.Add("@Notes", SqlDbType.NVarChar, 3000);

                sqlCommand.Parameters["@ID"].Value = int.Parse(txtID.Text);
                sqlCommand.Parameters["@RoleName"].Value = txtRoleName.Text;
                sqlCommand.Parameters["@Path"].Value = txtPath.Text;
                sqlCommand.Parameters["@Notes"].Value = txtNotes.Text;

                sqlConnection.Open();

                int numRowAffected = sqlCommand.ExecuteNonQuery();

                if (numRowAffected > 0)
                {
                    MessageBox.Show("Cập nhập thành công", "Message");
                    resetText();
                    LoadRole();

                }
                else
                {
                    MessageBox.Show("Cập nhập thất bại");
                }

                sqlConnection.Close();
                sqlConnection.Dispose();
            }
            catch (Exception exc)
            {

                MessageBox.Show(exc.Message, "SQL Error");
            }
        }

        private void resetText()
        {
            txtID.ResetText();
            txtRoleName.ResetText();
            txtPath.ResetText();
            txtNotes.ResetText();
        }
        private void dgvRole_Click(object sender, EventArgs e)
        {
            int index = dgvRole.CurrentRow.Index;
            if(index != null)
            {
                txtID.Text = dgvRole.Rows[index].Cells[1].Value.ToString();
                txtRoleName.Text = dgvRole.Rows[index].Cells[2].Value.ToString();
                txtPath.Text = dgvRole.Rows[index].Cells[3].Value.ToString();
                txtNotes.Text = dgvRole.Rows[index].Cells[4].Value.ToString();
            }
        }
    }
}
