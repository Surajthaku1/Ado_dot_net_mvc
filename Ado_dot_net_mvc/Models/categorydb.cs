using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ado_dot_net_mvc.ViewModel;
using System.Data.SqlClient;
using System.Data;

namespace Ado_dot_net_mvc.Models
{
    public class categorydb
    {
        private DbConfig db = new DbConfig();
        public List<Category> GetAllCategory()
        {
            SqlCommand cmd = new SqlCommand("sp_category1", db.sql);
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@action", "select");
            SqlParameter sqlParameter = new SqlParameter();
            sqlParameter.ParameterName = "@action";
            sqlParameter.Value = "select";
            sqlParameter.DbType = DbType.String;
            cmd.Parameters.Add(sqlParameter);

            if (db.sql.State == ConnectionState.Closed)
                db.sql.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            List<Category> categoryList = new List<Category>();
            while(reader.Read())
            {
                Category objcat = new Category();
                objcat.id=(int)reader[0];
                objcat.name = reader[1].ToString();
                categoryList.Add(objcat);
            }
            db.sql.Close();
            return categoryList;


        }
        public void Createcategory(Category category)
        {

            SqlCommand cmd = new SqlCommand("sp_category1", db.sql);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "create");
            cmd.Parameters.AddWithValue("@name",category.name);

            if (db.sql.State == ConnectionState.Closed)
                db.sql.Open();
            var result = cmd.ExecuteReader();
            db.sql.Close();



        }

        public void Deletecategory(int id)
        {

            SqlCommand cmd = new SqlCommand("sp_category1", db.sql);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "delete");
            cmd.Parameters.AddWithValue("@id",id);

            if (db.sql.State == ConnectionState.Closed)
                db.sql.Open();
            var result = cmd.ExecuteReader();
            db.sql.Close();



        }

        public Category Getcategorybyid(int id)
        {

            SqlCommand cmd = new SqlCommand("sp_category1", db.sql);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "select_one");
            cmd.Parameters.AddWithValue("@id",id);

            if (db.sql.State == ConnectionState.Closed)
                db.sql.Open();
            var reader = cmd.ExecuteReader();
            reader.Read();
            Category objcat = new Category();
            objcat.id = (int)reader[0];
            objcat.name = reader[1].ToString();
            

            db.sql.Close();
            return objcat;



        }
        public void Updatecategory(Category category)
        {

            SqlCommand cmd = new SqlCommand("sp_category1", db.sql);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "update");
            cmd.Parameters.AddWithValue("@name", category.name);
            cmd.Parameters.AddWithValue("@id",category.id);

            if (db.sql.State == ConnectionState.Closed)
                db.sql.Open();
            var result = cmd.ExecuteReader();
            db.sql.Close();



        }

    }
}