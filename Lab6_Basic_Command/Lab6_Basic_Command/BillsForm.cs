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
    public partial class BillsForm : Form
    {
        public BillsForm()
        {
            InitializeComponent();
        }

        public void LoadBills(string fromTime,string toTime)
        {
            this.Text = "Danh sách hóa đơn";
            string connectionString = "Data Source=DESKTOP-LH1UFFR\\THIENSON;Initial Catalog=RestaurantManagement;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = sqlConnection.CreateCommand();

            sqlCommand.CommandText = string.Format($"select * from Bills where CheckoutDate between '{fromTime}' and '{toTime}'");

            sqlConnection.Open();

            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
            DataTable table = new DataTable("Food");
            adapter.Fill(table);

            dgvHoaDon.DataSource = table;
            dgvHoaDon.Columns[0].ReadOnly = true;

            sqlConnection.Close();
            sqlConnection.Dispose();
            sqlCommand.Dispose();
        }

        private void BillsForm_Load(object sender, EventArgs e)
        {

        }

        private void dgvHoaDon_DoubleClick(object sender, EventArgs e)
        {
            BillDetail billDetail = new BillDetail();
            string billID = dgvHoaDon.SelectedRows[0].Cells[0].Value.ToString();
            billDetail.LoadBillDetails(int.Parse(billID));
            billDetail.Show();
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            if(dtpFromTime.Value.ToShortDateString() != null || dtpToTime.Value.ToShortDateString() != null)
            {
                LoadBills(dtpFromTime.Value.ToShortDateString(), dtpToTime.Value.ToShortDateString());
            }
        }
    }
}
