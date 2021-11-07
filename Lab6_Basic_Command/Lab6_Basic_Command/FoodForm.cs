using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab6_Basic_Command
{
    public partial class FoodForm : Form
    {
        int categoryID;
        int countBegin = 0, countAfter = 0;

        public FoodForm()
        {
            InitializeComponent();
        }

        public void LoadFood(int categoryID)
        {
            this.categoryID = categoryID;

            string connectionString = "Data Source=DESKTOP-LH1UFFR\\THIENSON;Initial Catalog=RestaurantManagement;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            SqlCommand sqlCommand = sqlConnection.CreateCommand();

            sqlCommand.CommandText = "select Name from Category where ID = " + categoryID;

            sqlConnection.Open();
            
            string catName = sqlCommand.ExecuteScalar().ToString();
            this.Text = "Danh sách các món ăn thuộc nhóm: " + catName;

            sqlCommand.CommandText = "select * from Food where FoodCategoryID = " + categoryID; 

            SqlDataAdapter sqlData = new SqlDataAdapter(sqlCommand);

            DataTable dataTable = new DataTable("Food");
            sqlData.Fill(dataTable);

            dgvView.DataSource = dataTable;
            countBegin = dgvView.Rows.Count - 1;

            sqlConnection.Close();
            sqlConnection.Dispose();
            sqlData.Dispose();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            countAfter = dgvView.Rows.Count - 1;
            int num = 0;
            string connectionString = "Data Source=DESKTOP-LH1UFFR\\THIENSON;Initial Catalog=RestaurantManagement;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            
            if (countAfter > countBegin)
            {
                sqlConnection.Open();
                for (int i = 0; i < countBegin; i++)
                {
                    DataGridViewRow row = dgvView.Rows[i];
                    sqlCommand.CommandText = $"update Food set Name = N'{row.Cells[1].Value.ToString()}'" +
                        $", Unit = N'{row.Cells[2].Value.ToString()}'" +
                        $", FoodCategoryID = {row.Cells[3].Value.ToString()}" +
                        $", Price = {row.Cells[4].Value}" +
                        $", Notes = N'{row.Cells[5].Value.ToString()}'" +
                        $" where ID = {row.Cells[0].Value}";
                    num += sqlCommand.ExecuteNonQuery();
                }

                for (int i = countBegin; i < countAfter ; i++)
                {
                    DataGridViewRow row = dgvView.Rows[i];
                    sqlCommand.CommandText = $"insert into Food(Name, Unit, FoodCategoryID, Price, Notes)" +
                        $" Values(N'{row.Cells[1].Value.ToString()}',N'{row.Cells[2].Value.ToString()}', {row.Cells[3].Value}, {row.Cells[4].Value}, N'{row.Cells[5].Value}')";
                    num += sqlCommand.ExecuteNonQuery();
                }
                sqlConnection.Close();

                if(num == countAfter)
                {
                    MessageBox.Show("Lưu thành công");
                }
                else
                {
                    MessageBox.Show("Lỗi");
                }
            }
            else if(countAfter == countBegin)
            {
                sqlConnection.Open();
                for (int i = 0; i < countBegin; i++)
                {
                    DataGridViewRow row = dgvView.Rows[i];
                    sqlCommand.CommandText = $"update Food set Name = N'{row.Cells[1].Value.ToString()}'" +
                        $", Unit = N'{row.Cells[2].Value.ToString()}'" +
                        $", FoodCategoryID = {row.Cells[3].Value.ToString()}" +
                        $", Price = {row.Cells[4].Value}" +
                        $", Notes = N'{row.Cells[5].Value.ToString()}'" +
                        $" where ID = {row.Cells[0].Value}";
                    num += sqlCommand.ExecuteNonQuery();
                }
                sqlConnection.Close();
                if (num == countAfter)
                {
                    MessageBox.Show("Lưu thành công");
                }
                else
                {
                    MessageBox.Show("Lỗi");
                }
            }
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(dgvView.SelectedRows.Count == 0)
            {
                return;
            }

            var selectedRow = dgvView.SelectedRows[0];

            string foodID = selectedRow.Cells[0].Value.ToString();

            string connectionString = "Data Source=DESKTOP-LH1UFFR\\THIENSON;Initial Catalog=RestaurantManagement;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = sqlConnection.CreateCommand();

            string query = "delete from Food where ID = " + foodID;

            sqlConnection.Open();

            sqlCommand.CommandText = "delete from BillDetails where ID = " + foodID;
            sqlCommand.ExecuteNonQuery();

            sqlCommand.CommandText = query;

            int numOfRowEffected = sqlCommand.ExecuteNonQuery();
            if (numOfRowEffected != 1)
            {
                MessageBox.Show("Đã xảy ra lỗi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                dgvView.Rows.Remove(selectedRow);
                MessageBox.Show("Xóa thành công!", "Thông báo");
            }

            sqlConnection.Close();
        }

        private void FoodForm_Load(object sender, EventArgs e)
        {
        }
    }
}
