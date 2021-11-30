using Lab09_Entity_Framework.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Lab09_Entity_Framework.Models.Category;

namespace Lab09_Entity_Framework
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private List<Category> GetCategories()
        {
            var dbContext = new RestaurantContext();
            return dbContext.Categories.OrderBy(x => x.Name).ToList();
        }

        private void ShowCategories()
        {
            tvCategory.Nodes.Clear();

            var catMap = new Dictionary<CategoryType, string>()
            {
                [CategoryType.Food] = "Đồ ăn",
                [CategoryType.Drink] = "Thức uống"
            };

            var rootNode = tvCategory.Nodes.Add("Tất cả");
            var categories = GetCategories();

            foreach (var catType in catMap)
            {
                var childNode = rootNode.Nodes.Add(catType.Key.ToString(), catType.Value);
                childNode.Tag = catType.Key;

                foreach (var category in categories)
                {
                    if (category.Type != catType.Key) continue;

                    var grantChildNode = childNode.Nodes.Add(category.Id.ToString(), category.Name);
                    grantChildNode.Tag = category;
                    
                }
            }

            tvCategory.ExpandAll();
            tvCategory.SelectedNode = rootNode;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ShowCategories();
        }

        private void btnReloadCategory_Click(object sender, EventArgs e)
        {
            ShowCategories();
        }
    }
}
