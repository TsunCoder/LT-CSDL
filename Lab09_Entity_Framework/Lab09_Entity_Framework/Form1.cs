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

        private List<FoodModel> GetFoodByCategory(int? categoryId)
        {
            var dbContext = new RestaurantContext();
            var foods = dbContext.Foods.AsQueryable();
            if (categoryId != null && categoryId > 0)
            {
                foods = foods.Where(x => x.FoodCategoryId == categoryId);
            }

            return foods.OrderBy(x => x.Name).Select(x => new FoodModel()
            {
                Id = x.Id,
                Name = x.Name,
                Unit = x.Unit,
                Price = x.Price,
                Notes = x.Notes,
                CategoryName = x.Category.Name
            }).ToList();
        }

        private List<FoodModel> GetFoodByCategoryType(CategoryType categoryType)
        {
            var dbContext = new RestaurantContext();

            return dbContext.Foods.Where(x => x.Category.Type == categoryType).OrderBy(x => x.Name).Select(x => new FoodModel()
            {
                Id = x.Id,
                Name = x.Name,
                Unit = x.Unit,
                Price = x.Price,
                Notes = x.Notes,
                CategoryName = x.Category.Name
            }).ToList();
        }

        private void ShowFoodsForNode(TreeNode node)
        {
            lvFood.Items.Clear();
            if (node == null)
            {
                return;
            }

            List<FoodModel> foods = null;

            if (node.Level == 1)
            {
                var categoryType = (CategoryType)node.Tag;
                foods = GetFoodByCategoryType(categoryType);
            }
            else
            {
                var category = node.Tag as Category;
                foods = GetFoodByCategory(category?.Id);
            }
            ShowFoodsOnListView(foods);
        }
        private void ShowFoodsOnListView(List<FoodModel> foods)
        {
            foreach (var foodItem in foods)
            {
                var item = lvFood.Items.Add(foodItem.Id.ToString());
                item.SubItems.Add(foodItem.Name);
                item.SubItems.Add(foodItem.Unit);
                item.SubItems.Add(foodItem.Price.ToString("##,###"));
                item.SubItems.Add(foodItem.CategoryName);
                item.SubItems.Add(foodItem.Notes);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ShowCategories();
        }

        private void btnReloadCategory_Click(object sender, EventArgs e)
        {
            ShowCategories();
        }

        private void tvCategory_AfterSelect(object sender, TreeViewEventArgs e)
        {
            ShowFoodsForNode(e.Node);
        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            var dialog = new UpdateCategoryForm();
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                ShowCategories();
            }
        }

        private void tvCategory_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node == null || e.Node.Level < 2 || e.Node.Tag == null)
            {
                return;
            }
            var category = e.Node.Tag as Category;
            var dialog = new UpdateCategoryForm(category?.Id);
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                ShowCategories();
            }
        }

        private void btnReloadFood_Click(object sender, EventArgs e)
        {
            ShowFoodsForNode(tvCategory.SelectedNode);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lvFood.SelectedItems.Count == 0) 
            {
                return;
            }
            var dbContext = new RestaurantContext();
            var selectedFoodId = int.Parse(lvFood.SelectedItems[0].Text);
            var selectedFood = dbContext.Foods.Find(selectedFoodId);

            if (selectedFood != null)
            {
                dbContext.Foods.Remove(selectedFood);
                dbContext.SaveChanges();
                lvFood.Items.Remove(lvFood.SelectedItems[0]);
            }
        }

        private void btnAddFood_Click(object sender, EventArgs e)
        {
            var dialog = new UpdateFoodForm();
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                ShowFoodsForNode(tvCategory.SelectedNode);
            }
        }

        private void lvFood_DoubleClick(object sender, EventArgs e)
        {
            if (lvFood.SelectedItems.Count == 0)
            {
                return;
            }
            var foodId = int.Parse(lvFood.SelectedItems[0].Text);
            var dialog = new UpdateFoodForm(foodId);
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                ShowFoodsForNode(tvCategory.SelectedNode);
            }
        }
    }
}
