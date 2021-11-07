using System;
using System.Collections.Generic;
using System.ComponentModel;
//
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Lab6_Basic_Command
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-LH1UFFR\\THIENSON;Initial Catalog=RestaurantManagement;Integrated Security=True ";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandText = "SELECT Id, Name, Type FROM Category";

            sqlConnection.Open();

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            this.DisplayCategory(sqlDataReader);

            sqlConnection.Close();
        }


        private void DisplayCategory(SqlDataReader reader)
        {
            this.lvCategory.Items.Clear();

            while (reader.Read())
            {
                ListViewItem item = new ListViewItem(reader["Id"].ToString());

                lvCategory.Items.Add(item);

                item.SubItems.Add(reader["Name"].ToString());
                item.SubItems.Add(reader["Type"].ToString());
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-LH1UFFR\\THIENSON;Initial Catalog=RestaurantManagement;Integrated Security=True ";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandText = $"insert into Category(Name, [Type]) Values (N'{txtName.Text}', {int.Parse(txtType.Text)})";

            sqlConnection.Open();

            int numOfRowsEffected = sqlCommand.ExecuteNonQuery();

            sqlConnection.Close();

            if(numOfRowsEffected == 1)
            {
                MessageBox.Show("Thêm món ăn thành công");

                btnLoad.PerformClick();

                txtName.Text = "";
                txtType.Text = "";
            }
            else
            {
                MessageBox.Show("Đã xảy ra lỗi, vui lòng thử lại!");
            }
        }

        private void lvCategory_Click(object sender, EventArgs e)
        {
            ListViewItem item = lvCategory.SelectedItems[0];

            txtID.Text = item.Text;
            txtName.Text = item.SubItems[1].Text;
            txtType.Text = item.SubItems[2].Text == "0" ? "Thức uống" : "Đồ ăn";

            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-LH1UFFR\\THIENSON;Initial Catalog=RestaurantManagement;Integrated Security=True ";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            SqlCommand sqlCommand = sqlConnection.CreateCommand();

            string name = txtName.Text;
            string type = txtType.Text == "Thức uống" ? "0" : "1";
            string id = txtID.Text;

            sqlCommand.CommandText = $"update Category set Name = N'{name}', [Type] = {type} where ID = {id}";

            sqlConnection.Open();

            var numOfRowEffected = sqlCommand.ExecuteNonQuery();

            sqlConnection.Close();

            if (numOfRowEffected == 1)
            {
                ListViewItem item = lvCategory.SelectedItems[0];

                item.SubItems[1].Text = txtName.Text;
                item.SubItems[2].Text = txtType.Text;

                txtID.Text = "";
                txtName.Text = "";
                txtType.Text = "";

                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;

                MessageBox.Show("Cập nhập thông tin thành công!");
            }
            else
            {
                MessageBox.Show("Đã có lỗi xảy ra. Vui lòng thử lại!");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-LH1UFFR\\THIENSON;Initial Catalog=RestaurantManagement;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            SqlCommand sqlCommand = sqlConnection.CreateCommand();

            sqlCommand.CommandText = "delete from Category " + "where ID = " + txtID.Text;

            sqlConnection.Open();

            var numOfRowEffected = sqlCommand.ExecuteNonQuery();

            sqlConnection.Close();

            if(numOfRowEffected == 1)
            {
                ListViewItem item = lvCategory.SelectedItems[0];
                lvCategory.Items.Remove(item);

                txtID.Text = "";
                txtName.Text = "";
                txtType.Text = "";

                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;

                MessageBox.Show("Xóa thành công!");
            }
            else
            {
                MessageBox.Show("Đã có lỗi xảy ra. Vui lòng thử lại!");
            }
        }

        private void tsmiDelete_Click(object sender, EventArgs e)
        {
            if(lvCategory.SelectedItems.Count > 0)
            {
                btnDelete.PerformClick();
            }
        }

        private void tsmiViewFood_Click(object sender, EventArgs e)
        {
            if(txtID.Text != "")
            {
                FoodForm foodForm = new FoodForm();
                foodForm.Show(this);
                foodForm.LoadFood(Convert.ToInt32(txtID.Text));
            }
        }

        private void btnViewBills_Click(object sender, EventArgs e)
        {
            BillsForm billsForm = new BillsForm();
            billsForm.ShowDialog();
        }

        private void btnViewAccount_Click(object sender, EventArgs e)
        {
            AccountManager account = new AccountManager();
            account.ShowDialog();
        }

        private void btnTableView_Click(object sender, EventArgs e)
        {
            TableForm table = new TableForm();
            table.Show();
            table.LoadTable();
        }
    }
}
