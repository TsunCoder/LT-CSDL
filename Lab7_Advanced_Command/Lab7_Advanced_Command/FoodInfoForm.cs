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
    public partial class FoodInfoForm : Form
    {
        public FoodInfoForm()
        {
            InitializeComponent();
        }

        private void InitValue()
        {
            this.Text = "Thông tin món ăn";
            string connectionString = "Data Source=DESKTOP-LH1UFFR\\THIENSON;Initial Catalog=RestaurantManagement;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandText = "SELECT ID, Name FROM Category";

            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
            DataSet ds = new DataSet();

            sqlConnection.Open();
            adapter.Fill(ds, "Category");

            cbbCatName.DataSource = ds.Tables["Category"];
            cbbCatName.DisplayMember = "Name";
            cbbCatName.ValueMember = "ID";

            sqlConnection.Close();
            sqlConnection.Dispose();
        }

        private void resetText()
        {
            txtFoodID.ResetText();
            txtName.ResetText();
            txtNotes.ResetText();
            txtUnit.ResetText();
            cbbCatName.ResetText();
            nudPrice.ResetText();
        }

        public void DisplayFoodInfo(DataRowView rowView)
        {
            try
            {
                txtFoodID.Text = rowView["ID"].ToString();
                txtName.Text = rowView["Name"].ToString();
                txtUnit.Text = rowView["Unit"].ToString();
                nudPrice.Text = rowView["Price"].ToString();
                txtNotes.Text = rowView["Notes"].ToString();


                cbbCatName.SelectedIndex = -1;

                for (int index = 0; index < cbbCatName.Items.Count; index++)
                {
                    DataRowView cat = cbbCatName.Items[index] as DataRowView;
                    if(cat["ID"].ToString() == rowView["FoodCategoryID"].ToString())
                    {
                        cbbCatName.SelectedIndex = index;
                        break;
                    }
                }
            }
            catch
            {

            }
        }

        private void btnAddFood_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = "Data Source=DESKTOP-LH1UFFR\\THIENSON;Initial Catalog=RestaurantManagement;Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);

                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandText = "EXECUTE [InsertFood] @ID OUTPUT, @Name, @unit, @FoodCategoryID, @Price, @Notes";

                sqlCommand.Parameters.Add("@ID", SqlDbType.Int);
                sqlCommand.Parameters.Add("@Name", SqlDbType.NVarChar, 1000);
                sqlCommand.Parameters.Add("@Unit", SqlDbType.NVarChar, 100);
                sqlCommand.Parameters.Add("@FoodCategoryID", SqlDbType.Int);
                sqlCommand.Parameters.Add("@Price", SqlDbType.Int);
                sqlCommand.Parameters.Add("@Notes", SqlDbType.NVarChar, 3000);

                sqlCommand.Parameters["@ID"].Direction = ParameterDirection.Output;

                sqlCommand.Parameters["@Name"].Value = txtName.Text;
                sqlCommand.Parameters["@Unit"].Value = txtUnit.Text;
                sqlCommand.Parameters["@FoodCategoryID"].Value = cbbCatName.SelectedValue;
                sqlCommand.Parameters["@Price"].Value = nudPrice.Value;
                sqlCommand.Parameters["@Notes"].Value = txtNotes.Text;

                sqlConnection.Open();

                int numRowAffected = sqlCommand.ExecuteNonQuery();

                if(numRowAffected > 0)
                {
                    string foodID = sqlCommand.Parameters["@ID"].Value.ToString();
                    MessageBox.Show("Successfully adding new food. Food ID = " + foodID, "Message");
                    this.resetText();
                }
                else
                {
                    MessageBox.Show("Adding food failed");
                }

                sqlConnection.Close();
                sqlConnection.Dispose();
            }
            catch (SqlException exception)
            {
                MessageBox.Show(exception.Message, "SQL Error");
            }
            catch (Exception exception)
            {

                MessageBox.Show(exception.Message, "Error");
            }
        }

        private void btnUpdateFood_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = "Data Source=DESKTOP-LH1UFFR\\THIENSON;Initial Catalog=RestaurantManagement;Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);

                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandText = "EXECUTE UpdateFood @id, @name, @unit, @foodCategoryID, @price, @notes";

                sqlCommand.Parameters.Add("@id", SqlDbType.Int);
                sqlCommand.Parameters.Add("@name", SqlDbType.NVarChar, 1000);
                sqlCommand.Parameters.Add("@unit", SqlDbType.NVarChar, 100);
                sqlCommand.Parameters.Add("@foodCategoryID", SqlDbType.Int);
                sqlCommand.Parameters.Add("@price", SqlDbType.Int);
                sqlCommand.Parameters.Add("@notes", SqlDbType.NVarChar, 3000);

                sqlCommand.Parameters["@id"].Value = int.Parse(txtFoodID.Text);
                sqlCommand.Parameters["@name"].Value = txtName.Text;
                sqlCommand.Parameters["@unit"].Value = txtUnit.Text;
                sqlCommand.Parameters["@foodCategoryID"].Value = cbbCatName.SelectedValue;
                sqlCommand.Parameters["@price"].Value = nudPrice.Value;
                sqlCommand.Parameters["@notes"].Value = txtNotes.Text;

                sqlConnection.Open();

                int numRowAffected = sqlCommand.ExecuteNonQuery();

                if (numRowAffected > 0)
                {
                    MessageBox.Show("Successfully updating food", "Message");
                    this.ResetText();
                }
                else
                {
                    MessageBox.Show("Updating food failed");
                }

                sqlConnection.Close();
                sqlConnection.Dispose();
            }
            catch(SqlException exception)
            {
                MessageBox.Show(exception.Message, "SQL Error");
            }
            catch(Exception exception)
            {
                MessageBox.Show(exception.Message, "Error");
            }
           
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FoodInfoForm_Load(object sender, EventArgs e)
        {
            this.InitValue();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            AddCategory frm = new AddCategory();
            frm.FormClosed += new FormClosedEventHandler(FoodInfoForm_FormClosed);
            frm.Show();
        }

        private void FoodInfoForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            int index = cbbCatName.SelectedIndex;
            cbbCatName.SelectedIndex = -1; // trả về khi không có mục nào được chọn
            cbbCatName.SelectedIndex = index;

            InitValue();
        }
    }
}
