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
    public partial class ViewRoleAccount : Form
    {
        public ViewRoleAccount()
        {
            InitializeComponent();
        }

        public void LoadRole(string name)
        {
            string connectionString = "Data Source=DESKTOP-LH1UFFR\\THIENSON;Initial Catalog=RestaurantManagement;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = sqlConnection.CreateCommand();

            sqlCommand.CommandText = "select c.AccountName, a.RoleName " +
                " from Role a, RoleAccount b, Account c" +
                " Where c.AccountName = b.AccountName and a.ID = b.RoleID and c.AccountName = '" + name + "'";

            sqlConnection.Open();

            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);

            DataTable table = new DataTable("Role");
            adapter.Fill(table);

            dgvViewRole.DataSource = table;

            dgvViewRole.Columns[0].ReadOnly = true;

            sqlConnection.Close();
        }
    }
}
