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
    public partial class OrdersForm : Form
    {
        public OrdersForm()
        {
            InitializeComponent();
            this.Text = "Danh sách hóa đơn";
        }

        private void setNameColumns(DataTable table)
        {
            dgvHoaDon.DataSource = table;
            dgvHoaDon.Columns[0].ReadOnly = true;

            dgvHoaDon.Columns[0].HeaderCell.Value = "Mã hóa đơn";
            dgvHoaDon.Columns[1].HeaderCell.Value = "Tên hóa đơn";
            dgvHoaDon.Columns[2].HeaderCell.Value = "Mã bàn";
            dgvHoaDon.Columns[3].HeaderCell.Value = "Tổng cộng";
            dgvHoaDon.Columns[4].HeaderCell.Value = "Giảm giá";
            dgvHoaDon.Columns[5].HeaderCell.Value = "Tax";
            dgvHoaDon.Columns[6].HeaderCell.Value = "Trạng thái";
            dgvHoaDon.Columns[7].HeaderCell.Value = "Ngày bán";
            dgvHoaDon.Columns[8].HeaderCell.Value = "Tài khoản";
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = "Data Source=DESKTOP-LH1UFFR\\THIENSON;Initial Catalog=RestaurantManagement;Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                SqlCommand cmd = sqlConnection.CreateCommand();
                cmd.CommandText = "EXEC GetBillsByDay @Date";

                cmd.Parameters.Add("@Date", SqlDbType.SmallDateTime);
                cmd.Parameters["@Date"].Value = dtpOutDate.Value.ToShortDateString();

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sqlConnection.Open();
                adapter.Fill(dt);
                cmd.CommandText = "SELECT SUM(Amount) FROM Bills WHERE CheckoutDate = @Date";
                setNameColumns(dt);
                var doanhThu = cmd.ExecuteScalar();
                lblDoanhThu.Text = doanhThu.ToString() + " VND";

                dgvHoaDon.DataSource = dt;
                sqlConnection.Close();

            }
            catch (Exception exc)
            {

                MessageBox.Show(exc.Message,"SQL Error!");
            }
        }

        private void dgvHoaDon_DoubleClick(object sender, EventArgs e)
        {
            var billID = dgvHoaDon.SelectedRows[0].Cells[0].Value.ToString();
            BillsDetail frm = new BillsDetail();
            frm.LoadBillsDetail(billID);
            frm.ShowDialog(this);

        }

        private void OrdersForm_Load(object sender, EventArgs e)
        {

        }
    }
}
