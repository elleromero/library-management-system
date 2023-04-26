using LibraryManagementSystem.interfaces;
using LibraryManagementSystem.models;
using LibraryManagementSystem.utils;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.dao
{
    internal class AdminDAO : IDAO<User>
    {
        public ReturnResult<User> Create(User model)
        {
            ReturnResult<User> returnResult = new ReturnResult<User>();
            returnResult.Result = default(User);
            returnResult.IsSuccess = false;

            string declareQuery = "DECLARE @member_id UNIQUEIDENTIFIER; SET @member_id = NEWID();";
            string memberQuery = "INSERT INTO members (first_name, last_name, address, phone, email, member_id) " +
                $"VALUES ('{model.Member.FirstName}', '{model.Member.LastName}', '{model.Member.Address}', '{model.Member.Phone}', '{model.Member.Email}', @member_id);";
            string userQuery = "INSERT INTO users (member_id, role_id, username, password_hash) " +
                $"VALUES (@member_id, {model.Role.ID}, '{model.Username}', '{model.PasswordHash}');";
            string selectQuery = "SELECT * FROM members m JOIN users u ON m.member_id = u.member_id JOIN roles r ON r.role_id = u.role_id WHERE u.member_id = @member_id;";
            string query = $"{declareQuery} {memberQuery} {userQuery} {selectQuery}";

            SqlClient.Execute((error, conn) =>
            {
                if (error == null)
                {
                    try
                    {
                        SqlCommand command = new SqlCommand(query, conn);
                        SqlDataReader reader = command.ExecuteReader();

                        returnResult.Result = this.Fill(reader);
                        returnResult.IsSuccess = returnResult.Result != default(User);
                    }
                    catch { return; }
                }
            });

            return returnResult;
        }

        public ReturnResultArr<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public ReturnResult<User> GetById(string id)
        {
            ReturnResult<User> returnResult = new ReturnResult<User>();
            returnResult.Result = default(User);
            returnResult.IsSuccess = false;

            string query = "SELECT * FROM users u " +
                $"JOIN members m ON m.member_id = u.member_id JOIN roles r ON r.role_id = u.role_id WHERE u.user_id = '{id}';";

            SqlClient.Execute((error, conn) =>
            {
                if (error == null)
                {
                    try
                    {
                        SqlCommand command = new SqlCommand(query, conn);
                        SqlDataReader reader = command.ExecuteReader();

                        returnResult.Result = this.Fill(reader);
                        returnResult.IsSuccess = returnResult.Result != default(User);
                    }
                    catch { return; }
                }
            });

            return returnResult;
        }

        public bool Remove(string id)
        {
            throw new NotImplementedException();
        }

        public ReturnResult<User> Update(User model)
        {
            ReturnResult<User> returnResult = new ReturnResult<User>();
            returnResult.Result = default(User);
            returnResult.IsSuccess = false;

            string declareQuery = "DECLARE @user table (member_id UNIQUEIDENTIFIER);";
            string updateUserQuery = "UPDATE users SET " +
                $"username = '{model.Username}', " +
                $"password_hash = '{model.PasswordHash}' " +
                "OUTPUT inserted.member_id INTO @user(member_id) " +
                $"WHERE user_id = '{model.ID}';";
            string updateMemberQuery = "UPDATE members SET " +
                $"first_name = '{model.Member.FirstName}', " +
                $"last_name = '{model.Member.LastName}', " +
                $"address = '{model.Member.Address}', " +
                $"email = 'romero@romero.com', " +
                $"phone = '+639111813695' " +
                "WHERE member_id = (SELECT member_id FROM @user as u WHERE u.member_id = members.member_id);";
            string selectQuery = $"SELECT * FROM users u JOIN members m ON m.member_id = u.member_id JOIN roles r ON r.role_id = u.role_id WHERE user_id = '{model.ID}';";
            string query = $"{declareQuery} {updateUserQuery} {updateMemberQuery} {selectQuery}";

            SqlClient.Execute((error, conn) =>
            {
                if (error == null)
                {
                    try
                    {
                        SqlCommand command = new SqlCommand(query, conn);
                        SqlDataReader reader = command.ExecuteReader();

                        returnResult.Result = this.Fill(reader);
                        returnResult.IsSuccess = returnResult.Result != default(User);
                        Console.WriteLine(returnResult.IsSuccess);
                    }
                    catch { return; }
                }
            });

            return returnResult;
        }

        public User? Fill(SqlDataReader reader)
        {
            User? user = default(User);

            while (reader.Read())
            {
                user = new User
                {
                    ID = reader.GetGuid(reader.GetOrdinal("user_id")),
                    Username = reader.GetString(reader.GetOrdinal("username")),
                    Role = new Role
                    {
                        ID = reader.GetInt32(reader.GetOrdinal("role_id")),
                        Name = reader.GetString(reader.GetOrdinal("name")),
                        HasAccess = reader.GetBoolean(reader.GetOrdinal("has_access"))
                    },
                    Member = new Member
                    {
                        ID = reader.GetGuid(reader.GetOrdinal("member_id")),
                        FirstName = reader.GetString(reader.GetOrdinal("first_name")),
                        LastName = reader.GetString(reader.GetOrdinal("last_name")),
                        Phone = reader.GetString(reader.GetOrdinal("phone")),
                        Email = reader.GetString(reader.GetOrdinal("email")),
                        Address = reader.GetString(reader.GetOrdinal("address")),
                    }
                };
            }

            return user;
        }
    }
}
