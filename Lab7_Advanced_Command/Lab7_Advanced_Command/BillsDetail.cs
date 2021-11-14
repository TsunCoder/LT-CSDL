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
    public partial class BillsDetail : Form
    {
        public BillsDetail()
        {
            InitializeComponent();
        }

        private void setNameColumns(DataTable table)
        {
            dgvBillDetails.DataSource = table;

            dgvBillDetails.Columns[0].ReadOnly = true;
            dgvBillDetails.Columns[0].HeaderCell.Value = "Mã hóa đơn thanh toán";
            dgvBillDetails.Columns[1].HeaderCell.Value = "Mã món ăn";
            dgvBillDetails.Columns[2].HeaderCell.Value = "Số Lượng";

        }
        public void LoadBillsDetail(string billID)
        {
            try
            {
                this.Text = "Chi tiết hóa đơn";
                string connectionString = "Data Source=DESKTOP-LH1UFFR\\THIENSON;Initial Catalog=RestaurantManagement;Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                SqlCommand sqlCommand = sqlConnection.CreateCommand();

                sqlCommand.CommandText = "EXEC GetBillDetailsByID @ID";

                sqlCommand.Parameters.Add("@ID", SqlDbType.Int);
                sqlCommand.Parameters["@ID"].Value = billID;

                SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
                DataTable dt = new DataTable();
                sqlConnection.Open();
                adapter.Fill(dt);
                setNameColumns(dt);
                dgvBillDetails.DataSource = dt;
                dgvBillDetails.Columns[0].ReadOnly = true;

                sqlConnection.Close();

            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "SQL Error");
            }
            
        }
    }
}
