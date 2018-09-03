using FairyDustFriends.Domain.Entities;
using FairyDustFriends.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace FairyDustFriends.Data
{
    public class FriendStoredProcedureRepository : IFriendRepository
    {

        public void Create(Friend Friend)
        {
            SqlConnection sqlConnection = OpenConnectionAndConnectionString();

            SqlCommand sqlCommandCreateFriend;
            sqlCommandCreateFriend = new SqlCommand("CreateFriend", sqlConnection);
            sqlCommandCreateFriend.CommandType = System.Data.CommandType.StoredProcedure;

            sqlCommandCreateFriend.Parameters.AddWithValue("Id", Friend.Id);
            sqlCommandCreateFriend.Parameters.AddWithValue("FirstName", Friend.FirstName);
            sqlCommandCreateFriend.Parameters.AddWithValue("LastName", Friend.LastName);
            sqlCommandCreateFriend.Parameters.AddWithValue("Email", Friend.Email);
            sqlCommandCreateFriend.Parameters.AddWithValue("Phone", Friend.Phone);
            sqlCommandCreateFriend.Parameters.AddWithValue("Birthday", Friend.Birthday);
            sqlCommandCreateFriend.ExecuteNonQuery();

            sqlConnection.Close();
        }

        public void Delete(string id)
        {
            SqlConnection sqlConnection = OpenConnectionAndConnectionString();

            SqlCommand sqlCommandDeleteFriend;
            sqlCommandDeleteFriend = new SqlCommand("DeleteFriend", sqlConnection);
            sqlCommandDeleteFriend.CommandType = System.Data.CommandType.StoredProcedure;

            sqlCommandDeleteFriend.Parameters.AddWithValue("Id", id);            
            sqlCommandDeleteFriend.ExecuteNonQuery();

            sqlConnection.Close();
        }

        public Friend Get(string id)
        {
            SqlConnection sqlConnection = OpenConnectionAndConnectionString();

            SqlCommand sqlCommandReadFriend;
            sqlCommandReadFriend = new SqlCommand("ReadFriend", sqlConnection);
            sqlCommandReadFriend.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCommandReadFriend.Parameters.AddWithValue("Id", id);
            var reader = sqlCommandReadFriend.ExecuteReader();


            Guid idGuid = Guid.Empty;
            string nome = string.Empty;
            string sobrenome = string.Empty;
            string email = string.Empty;
            string telefone = string.Empty;
            DateTime dataNascimento = new DateTime();

            while (reader.Read())
            {
                idGuid = Guid.Parse(reader["Id"].ToString());
                nome = reader["FirstName"].ToString();
                sobrenome = reader["LastName"].ToString();
                email = reader["Email"].ToString();
                telefone = reader["Phone"].ToString();
                dataNascimento = DateTime.Parse(reader["Birthday"].ToString());
            };

            Friend Friend = new Friend(idGuid, nome, sobrenome, email, telefone, dataNascimento);

            sqlConnection.Close();
            return Friend;
        }

        public List<Friend> GetAll()
        {
            SqlConnection sqlConnection = OpenConnectionAndConnectionString();

            SqlCommand sqlCommandReadFriend;
            sqlCommandReadFriend = new SqlCommand("ReadAllFriend", sqlConnection);
            sqlCommandReadFriend.CommandType = System.Data.CommandType.StoredProcedure;            
            var reader = sqlCommandReadFriend.ExecuteReader();

            List<Friend> Friends = new List<Friend>();

            while (reader.Read())
            {
                Friends.Add(
                    new Friend(
                        Guid.Parse(reader["Id"].ToString()),
                        reader["FirstName"].ToString(),
                        reader["LastName"].ToString(),
                        reader["Email"].ToString(),
                        reader["Phone"].ToString(),
                        DateTime.Parse(reader["Birthday"].ToString())
                    )
                );
            };

            sqlConnection.Close();

            return Friends;
        }

        public void Update(Friend Friend)
        {
            SqlConnection sqlConnection = OpenConnectionAndConnectionString();

            SqlCommand sqlCommandUpdateFriend;
            sqlCommandUpdateFriend = new SqlCommand("UpdateFriend", sqlConnection);
            sqlCommandUpdateFriend.CommandType = System.Data.CommandType.StoredProcedure;

            sqlCommandUpdateFriend.Parameters.AddWithValue("Id", Friend.Id);
            sqlCommandUpdateFriend.Parameters.AddWithValue("FirstName", Friend.FirstName);
            sqlCommandUpdateFriend.Parameters.AddWithValue("LastName", Friend.LastName);
            sqlCommandUpdateFriend.Parameters.AddWithValue("Email", Friend.Email);
            sqlCommandUpdateFriend.Parameters.AddWithValue("Phone", Friend.Phone);
            sqlCommandUpdateFriend.Parameters.AddWithValue("Birthday", Friend.Birthday);
            sqlCommandUpdateFriend.ExecuteNonQuery();

            sqlConnection.Close();            
        }

        private SqlConnection OpenConnectionAndConnectionString()
        {
            var sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["AzureDatabaseConnectionString"].ToString());            

            sqlConnection.Open();

            return sqlConnection;
        }
    }
}
