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
    public partial class AddAccount : Form
    {
        public AddAccount()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int numRowEffected = 0;
            int numOfRole;
            string connectionString = "Data Source=DESKTOP-LH1UFFR\\THIENSON;Initial Catalog=RestaurantManagement;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = sqlConnection.CreateCommand();

            sqlConnection.Open();
            sqlCommand.CommandText = $"insert into Account(AccountName, Password, FullName, Email, Tell, DateCreated)" +
                $" Values('{txtAccountName.Text}', '{txtPass.Text}', N'{txtFullName.Text}', '{txtEmail.Text}', '{txtTell.Text}', '{dtpDateCreated.Value.ToString("MM/dd/yyyy")}')";

            numRowEffected += sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();

            sqlConnection.Open();
            foreach (var item in clbRole.CheckedItems)
            {
                if (item.ToString() == "Administrator")
                {
                    numOfRole = 1;
                }
                else if (item.ToString() == "Kế toán")
                {
                    numOfRole = 2;
                }
                else if (item.ToString() == "Nhân viên thanh toán")
                {
                    numOfRole = 3;
                }
                else
                {
                    numOfRole = 4;
                }

                sqlCommand.CommandText = $"insert into RoleAccount(RoleID, AccountName, Actived, Notes)" +
                    $" Values({numOfRole}, '{txtAccountName.Text}', 1, N'{txtNotes.Text}')";
                numRowEffected += sqlCommand.ExecuteNonQuery();
            }
            sqlConnection.Close();

            if(numRowEffected == this.clbRole.CheckedItems.Count + 1)
            {
                MessageBox.Show("Thêm thành công");
                Close();
            }
            else
            {
                MessageBox.Show("Đã xảy ra lỗi");
            }
        }
    }
}
