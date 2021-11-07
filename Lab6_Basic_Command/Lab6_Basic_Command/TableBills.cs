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
    public partial class TableBills : Form
    {
        string tableID;
        public TableBills()
        {
            InitializeComponent();
        }

        public void LoadBills(string TableID)
        {
            this.tableID = TableID;
            this.Text = "Danh mục hóa đơn";
            string connectionString = "Data Source=DESKTOP-LH1UFFR\\THIENSON;Initial Catalog=RestaurantManagement;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = sqlConnection.CreateCommand();

            string query = "select distinct CheckoutDate from Bills WHERE TableID = " + TableID;

            sqlConnection.Open();

            sqlCommand.CommandText = query;
            sqlCommand.ExecuteNonQuery();

            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
            DataSet data = new DataSet();

            adapter.Fill(data, "Bills");
            DataTable dt = data.Tables[0];
            DataRow row = null;

            foreach (DataRow item in dt.Rows)
            {
                row = item;
                lbDate.Items.Add(item["CheckoutDate"]);
            }

            sqlConnection.Close();
            adapter.Dispose();
        }

        private void lbDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedDate = lbDate.SelectedItem.ToString();

            string connectionString = "Data Source=DESKTOP-LH1UFFR\\THIENSON;Initial Catalog=RestaurantManagement;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = sqlConnection.CreateCommand();

            string query = String.Format("select b.ID,b.Name,b.Amount,b.Discount, b.Account, f.Name, bd.Quantity " +
                "from Bills b, BillDetails bd, Food f " +
                "where TableID = {0} and b.ID = bd.InvoiceID and CheckoutDate = '{1}' and f.ID = bd.FoodID", tableID, selectedDate);

            sqlConnection.Open();

            sqlCommand.CommandText = query;
            sqlCommand.ExecuteNonQuery();

            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
            DataTable table = new DataTable();

            adapter.Fill(table);

            dgvTableBills.DataSource = table;
            dgvTableBills.Columns[0].ReadOnly = true;

            sqlConnection.Close();
            adapter.Dispose();
        }
    }
}
