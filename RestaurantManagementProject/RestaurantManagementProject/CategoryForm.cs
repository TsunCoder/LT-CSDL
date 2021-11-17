using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAccess;
using BusinessLogic;
namespace RestaurantManagementProject
{
    public partial class CategoryForm : Form
    {
        List<Category> listCategory = new List<Category>();
        public CategoryForm()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtCategory.Text = "";
            if(cbbType.Items.Count > 0)
            {
                cbbType.SelectedIndex = 0;
            }
        }

        private void LoadType()
        {
            
        }

        private void CategoryForm_Load(object sender, EventArgs e)
        {

        }
    }
}
