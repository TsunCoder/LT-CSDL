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
    public partial class DiaryForm : Form
    {
        public DiaryForm()
        {
            InitializeComponent();
            this.Text = "Chi tiết hóa đơn";
        }

        private void setNameColumns(DataTable table)
        {
            dgvHoaDon.DataSource = table;
            dgvHoaDon.Columns[0].HeaderCell.Value = "Mã hóa đơn";
            dgvHoaDon.Columns[1].HeaderCell.Value = "Mã món ăn";
            dgvHoaDon.Columns[2].HeaderCell.Value = "Tên món ăn";
            dgvHoaDon.Columns[3].HeaderCell.Value = "Số lượng";
        }

        public void LoadBills(string accountName)
        {
            string connectionString = "Data Source=DESKTOP-LH1UFFR\\THIENSON;Initial Catalog=RestaurantManagement;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = sqlConnection.CreateCommand();

            sqlCommand.CommandText = "SELECT CheckoutDate From Bills Where Account = '" + accountName + "'";
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();

            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
            DataSet data = new DataSet();
            DataRow row = null;

            adapter.Fill(data);
            DataTable dt = data.Tables[0];
            foreach (DataRow item in dt.Rows)
            {
                row = item;
                lbDate.Items.Add(item["CheckoutDate"]);
            }

            sqlConnection.Close();
            adapter.Dispose();

            lblSumInvoice.Text = lbDate.Items.Count.ToString();

        }

        private void lbDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string selectedDate = lbDate.SelectedItem.ToString();
                string connectionString = "Data Source=DESKTOP-LH1UFFR\\THIENSON;Initial Catalog=RestaurantManagement;Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandText = "EXEC GetBillDetailsByDate @CheckoutDate";

                sqlCommand.Parameters.Add("@CheckoutDate", SqlDbType.SmallDateTime);
                sqlCommand.Parameters["@CheckoutDate"].Value = selectedDate;

                SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable table = new DataTable();

                sqlConnection.Open();
                dataAdapter.Fill(table);
                sqlCommand.CommandText = "Select Sum(Amount) From Bills Where CheckoutDate = '" + selectedDate +"'";
                var tongTien = sqlCommand.ExecuteScalar();
                lblAmount.Text = tongTien.ToString() + " VND";
                setNameColumns(table);
                dgvHoaDon.DataSource = table;
                sqlConnection.Close();
            }
            catch (Exception exc)
            {

                MessageBox.Show(exc.Message, "SQL Error");
            }
            
        }
    }
}
