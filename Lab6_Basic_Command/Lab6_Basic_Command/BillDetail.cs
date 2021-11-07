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
    public partial class BillDetail : Form
    {
        int billId;
        public BillDetail()
        {
            InitializeComponent();
        }

		public void LoadBillDetails(int billID)
		{
			this.billId = billID;
			string connectionString = "Data Source=DESKTOP-LH1UFFR\\THIENSON;Initial Catalog=RestaurantManagement;Integrated Security=True";
			SqlConnection connection = new SqlConnection(connectionString);
			SqlCommand command = connection.CreateCommand();

			command.CommandText = "SELECT Name FROM Bills WHERE ID = " + billID;

			connection.Open();

			string billName = command.ExecuteScalar().ToString();
			this.Text = billName + " ID + " + billID;

			string query = string.Format(
				"SELECT Name, Unit, Price, Quantity, Price * Quantity AS Total FROM BillDetails " +
				"JOIN Food ON BillDetails.FoodID = Food.ID " +
				"WHERE BillDetails.ID = {0}", billID).ToString();
			command.CommandText = query;

			SqlDataAdapter adapter = new SqlDataAdapter(command);

			DataTable table = new DataTable("Food");
			adapter.Fill(table);

			dgvBillDetails.DataSource = table;

			// Prevent user to edit ID
			dgvBillDetails.Columns[0].ReadOnly = true;

			connection.Close();
			connection.Dispose();
			adapter.Dispose();
		}

		private void BillDetail_Load(object sender, EventArgs e)
        {

        }
    }
}
