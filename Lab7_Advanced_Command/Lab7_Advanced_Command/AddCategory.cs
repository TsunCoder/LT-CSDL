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
    public partial class AddCategory : Form
    {
        public AddCategory()
        {
            InitializeComponent();
        }

        public void LoadType()
        {
            string connectionString = "Data Source=DESKTOP-LH1UFFR\\THIENSON;Initial Catalog=RestaurantManagement;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand cmd = sqlConnection.CreateCommand();

            cmd.CommandText = "SELECT DISTINCT Type FROM Category";
            sqlConnection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            cbbType.DataSource = table;
            cbbType.DisplayMember = "Type";
            sqlConnection.Close();

        }

        private void AddCategory_Load(object sender, EventArgs e)
        {
            this.LoadType();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void resetText()
        {
            txtID.ResetText();
            txtName.ResetText();
            cbbType.ResetText();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = "Data Source=DESKTOP-LH1UFFR\\THIENSON;Initial Catalog=RestaurantManagement;Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                SqlCommand cmd = sqlConnection.CreateCommand();

                cmd.CommandText = "EXEC InsertCategory @ID output, @Name, @Type";

                cmd.Parameters.Add("@ID", SqlDbType.Int);
                cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 1000);
                cmd.Parameters.Add("@Type", SqlDbType.Int);

                cmd.Parameters["@ID"].Direction = ParameterDirection.Output;
                cmd.Parameters["@Name"].Value = txtName.Text;
                cmd.Parameters["@Type"].Value = cbbType.Text;

                sqlConnection.Open();

                int num = cmd.ExecuteNonQuery();

                if(num > 0)
                {
                    var catID = cmd.Parameters["@ID"].Value.ToString();
                    MessageBox.Show("Successfully Adding New Category. Category ID " + catID, "Message");
                    this.resetText();
                }
                else
                {
                    MessageBox.Show("Failes");
                }

                sqlConnection.Close();
                sqlConnection.Dispose();
                this.Close();
            }
            catch (Exception exc)
            {

                MessageBox.Show(exc.Message, "SQL Error!");
            }
        }
    }
}
