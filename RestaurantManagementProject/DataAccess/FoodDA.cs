using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DataAccess
{
    public class FoodDA
    {
        public List<Food> GetAll()
        {
            SqlConnection sqlConnection = new SqlConnection(Ultilities.ConnectionString);
            sqlConnection.Open();

            SqlCommand cmd = sqlConnection.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = Ultilities.Food_GetAll;

            SqlDataReader reader = cmd.ExecuteReader();
            List<Food> listFood = new List<Food>();
            while (reader.Read())
            {
                Food food = new Food();
                food.ID = Convert.ToInt32(reader["ID"]);
                food.Name = reader["Name"].ToString();
                food.Unit = reader["Unit"].ToString();
                food.FoodCategoryID = Convert.ToInt32(reader["FoodCategoryID"]);
                food.Price = Convert.ToInt32(reader["Price"]);
                food.Notes = reader["Notes"].ToString();

                listFood.Add(food);
            }
            sqlConnection.Close();
            return listFood;
        }

        public int Insert_Update_Delete(Food food, int action)
        {
            SqlConnection sqlConnection = new SqlConnection(Ultilities.ConnectionString);
            sqlConnection.Open();

            SqlCommand cmd = sqlConnection.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = Ultilities.Food_InsertUpdateDelete;

            SqlParameter IDPara = new SqlParameter("@ID", System.Data.SqlDbType.Int);
            IDPara.Direction = System.Data.ParameterDirection.InputOutput;

            cmd.Parameters.Add(IDPara).Value = food.ID;
            cmd.Parameters.Add("@Name", System.Data.SqlDbType.NVarChar, 1000).Value = food.Name;
            cmd.Parameters.Add("@Unit", System.Data.SqlDbType.NVarChar).Value = food.Unit;
            cmd.Parameters.Add("@FoodCategoryID", System.Data.SqlDbType.Int).Value = food.FoodCategoryID;
            cmd.Parameters.Add("@Price", System.Data.SqlDbType.Int).Value = food.FoodCategoryID;
            cmd.Parameters.Add("@Notes", System.Data.SqlDbType.NVarChar, 3000).Value = food.Notes;
            cmd.Parameters.Add("@Action", System.Data.SqlDbType.Int).Value = action;
            int result = cmd.ExecuteNonQuery();

            if(result > 0)
            {
                return (int)cmd.Parameters["@ID"].Value;
            }
            return 0;
        }
    }
}
