using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace DataAccess
{
    public class CategoryDA
    {
        public List<Category> GetAll()
        {
            SqlConnection sqlConnection = new SqlConnection(Ultilities.ConnectionString);
            sqlConnection.Open();

            SqlCommand cmd = sqlConnection.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = Ultilities.Category_GetAll;

            SqlDataReader reader = cmd.ExecuteReader();
            List<Category> listCategories = new List<Category>();
            while (reader.Read())
            {
                Category category = new Category();
                category.ID = Convert.ToInt32(reader["ID"]);
                category.Name = reader["Name"].ToString();
                category.Type = Convert.ToInt32(reader["Type"]);
                listCategories.Add(category);
            }
            sqlConnection.Close();
            return listCategories;
        }

        public int Insert_Update_Delete(Category category, int action)
        {
            SqlConnection sqlConnection = new SqlConnection(Ultilities.ConnectionString);
            sqlConnection.Open();

            SqlCommand cmd = sqlConnection.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = Ultilities.Category_InsertUpdateDelete;

            SqlParameter IDPara = new SqlParameter("ID", System.Data.SqlDbType.Int); 
            IDPara.Direction = System.Data.ParameterDirection.InputOutput;
            // Thêm các tham số cho thủ tục; Các tham số này chính là các tham số trong thủ tục;
            // ID là tham số có giá trị lấy ra khi thêm và truyền vào khi xoá, sửa
            cmd.Parameters.Add(IDPara).Value = category.ID;
            cmd.Parameters.Add("@Name", System.Data.SqlDbType.NVarChar, 200).Value = category.Name;
            cmd.Parameters.Add("@Type", System.Data.SqlDbType.Int).Value = category.Type;
            cmd.Parameters.Add("@Action", System.Data.SqlDbType.Int).Value = action;

            int result = cmd.ExecuteNonQuery();
            if (result > 0)
            {
                return (int)cmd.Parameters["@ID"].Value;
            }
            return 0;
        }
    }
}
