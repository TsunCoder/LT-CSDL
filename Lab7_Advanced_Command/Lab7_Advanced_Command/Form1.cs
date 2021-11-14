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
    public partial class Form1 : Form
    {
        private DataTable foodTable;
        public Form1()
        {
            InitializeComponent();
        }

        public void setNameColumn(DataTable table)
        {
            dgvFoodList.DataSource = table;
            dgvFoodList.Columns[0].ReadOnly = true;
            dgvFoodList.Columns[0].HeaderCell.Value = "Mã món ăn";
            dgvFoodList.Columns[1].HeaderCell.Value = "Tên món ăn";
            dgvFoodList.Columns[2].HeaderCell.Value = "Đơn vị";
            dgvFoodList.Columns[3].HeaderCell.Value = "Mã loại";
            dgvFoodList.Columns[4].HeaderCell.Value = "Giá";
            dgvFoodList.Columns[5].HeaderCell.Value = "Ghi chú";
        }

        public void LoadCategory()
        {
            this.Text = "Danh sách món ăn";
            string connectionString = "Data Source=DESKTOP-LH1UFFR\\THIENSON;Initial Catalog=RestaurantManagement;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = sqlConnection.CreateCommand();

            sqlCommand.CommandText = "Select ID, Name From Category";

            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
            DataTable table = new DataTable();

            sqlConnection.Open();
            adapter.Fill(table);

            sqlConnection.Close();
            sqlConnection.Dispose();

            cbbCategory.DataSource = table;

            cbbCategory.DisplayMember = "Name";

            cbbCategory.ValueMember = "ID";
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.LoadCategory();
        }

        private void cbbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbCategory.SelectedIndex == -1) return;

            string connectionString = "Data Source=DESKTOP-LH1UFFR\\THIENSON;Initial Catalog=RestaurantManagement;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandText = "SELECT * FROM Food WHERE FoodCategoryID = @categoryId";

            sqlCommand.Parameters.Add("@categoryId", SqlDbType.Int);

            if(cbbCategory.SelectedValue is DataRowView)
            {
                DataRowView rowView = cbbCategory.SelectedValue as DataRowView;
                sqlCommand.Parameters["@categoryId"].Value = rowView["ID"];
            }
            else
            {
                sqlCommand.Parameters["@categoryId"].Value = cbbCategory.SelectedValue;
            }

            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
            foodTable = new DataTable();

            sqlConnection.Open();
            adapter.Fill(foodTable);
            setNameColumn(foodTable);
            sqlConnection.Close();
            sqlConnection.Dispose();

            dgvFoodList.DataSource = foodTable;

            lblQuantity.Text = foodTable.Rows.Count.ToString();
            lblCatName.Text = cbbCategory.Text;
        }

        private void tsmiCalculateQuantity_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-LH1UFFR\\THIENSON;Initial Catalog=RestaurantManagement;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandText = "SELECT @numSaleFood = sum(Quantity) FROM BillDetails WHERE FoodID = @foodId";

            if(dgvFoodList.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvFoodList.SelectedRows[0];
                DataRowView rowView = selectedRow.DataBoundItem as DataRowView;

                sqlCommand.Parameters.Add("@foodId", SqlDbType.Int);
                sqlCommand.Parameters["@foodId"].Value = rowView["ID"];
                sqlCommand.Parameters.Add("@numSaleFood", SqlDbType.Int);
                sqlCommand.Parameters["@numSaleFood"].Direction = ParameterDirection.Output;

                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();

                string result = sqlCommand.Parameters["@numSaleFood"].Value.ToString();
                MessageBox.Show("Tổng số lượng món " + rowView["Name"] + " đã bán là: " + result + " " + rowView["Unit"]);

                sqlConnection.Close();
            }
            sqlCommand.Dispose();
            sqlConnection.Dispose();
        }

        private void tsmiAddFood_Click(object sender, EventArgs e)
        {
            FoodInfoForm frm = new FoodInfoForm();
            frm.FormClosed += new FormClosedEventHandler(Form1_FormClosed);
            frm.Show(this);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            int index = cbbCategory.SelectedIndex;
            cbbCategory.SelectedIndex = -1;
            cbbCategory.SelectedIndex = index;
        }

        private void tsmiUpdate_Click(object sender, EventArgs e)
        {
            if(dgvFoodList.Rows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvFoodList.SelectedRows[0];
                DataRowView rowView = selectedRow.DataBoundItem as DataRowView;

                FoodInfoForm frm = new FoodInfoForm();
                frm.FormClosed += new FormClosedEventHandler(Form1_FormClosed);

                frm.Show(this);
                frm.DisplayFoodInfo(rowView);
            }
        }

        private void txtSearchByName_TextChanged(object sender, EventArgs e)
        {
            if (foodTable == null) return;
            string filterExpresstion = "Name like '%" + txtSearchByName.Text + "%'";
            string sortExpresstion = "Price Desc";
            DataViewRowState rowStateFilter = DataViewRowState.OriginalRows;

            DataView foodView = new DataView(foodTable, filterExpresstion, sortExpresstion, rowStateFilter);

            dgvFoodList.DataSource = foodView;
        }

        private void btnViewHoaDon_Click(object sender, EventArgs e)
        {
            OrdersForm frm = new OrdersForm();
            frm.Show();
        }

        private void btnViewAccount_Click(object sender, EventArgs e)
        {
            AccountForm form = new AccountForm();
            form.Show();
        }
    }
}
