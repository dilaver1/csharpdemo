using CourseAdoNet.DataAccess.Abstract;
using CourseAdoNet.DataAccess.Constants;
using CourseAdoNet.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CourseAdoNet.DataAccess.Concrete
{
    public class UserDal : IUserDal
    {
        public void Add(User user)
        {
            //SQL Injection

            string queryString = $"INSERT INTO Users VALUES(@UserName,@Email)";

            using SqlConnection connection = new SqlConnection(ConnectionStrings.CourseConnectionString);
            using SqlCommand command = new SqlCommand(queryString, connection);
            command.Parameters.AddWithValue("@UserName", user.UserName);
            command.Parameters.AddWithValue("@Email", user.Email);
            connection.Open();
            command.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            string DeleteQuery = "DELETE FROM Users WHERE Id=@Id";

            using SqlConnection connection = new SqlConnection(ConnectionStrings.CourseConnectionString);
            using SqlCommand command = new SqlCommand(DeleteQuery, connection);
            connection.Open();
            using SqlDataReader reader = command.ExecuteReader();
        }

        public User Get(int id)
        {
            User user = new User();  //sehvdi
            string AddQuery = "Select * FROM Users WHERE Id=@Id";

            using SqlConnection connection = new SqlConnection(ConnectionStrings.CourseConnectionString);
            using SqlCommand command = new SqlCommand(AddQuery, connection);
            connection.Open();
            using SqlDataReader reader = command.ExecuteReader();
            return user;    //sehvdi
        }

        public List<User> GetAll()
        {
            List<User> list = new List<User>();
            string queryString = "SELECT * FROM Users";

            using SqlConnection connection = new SqlConnection(ConnectionStrings.CourseConnectionString);
            using SqlCommand command = new SqlCommand(queryString, connection);
            connection.Open();
            using SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                User user = new User(Convert.ToInt32(reader["Id"]), reader["UserName"].ToString(), reader["Email"].ToString());
                list.Add(user);
            }
            return list;
        }

        public void Update(User user)
        {
            string UpdateQuery = "UPDATE Users SET Name = NewName, Surname = NewSurname, WHERE User=@user";

            using SqlConnection connection = new SqlConnection(ConnectionStrings.CourseConnectionString);
            using SqlCommand command = new SqlCommand(UpdateQuery, connection);
            connection.Open();
            using SqlDataReader reader = command.ExecuteReader();
        }

        
    }
}
