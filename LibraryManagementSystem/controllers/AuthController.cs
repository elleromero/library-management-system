using Isopoh.Cryptography.Argon2;
using LibraryManagementSystem.dao;
using LibraryManagementSystem.interfaces;
using LibraryManagementSystem.models;
using LibraryManagementSystem.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.controllers
{
    internal class AuthController : BaseController
    {
        public static ControllerModifyData<User> Register(
            string username,
            string password,
            string firstName,
            string lastName,
            string address,
            string phone,
            string email = ""
            ) {
            ControllerModifyData<User> returnData = new ControllerModifyData<User>();
            returnData.Result = default(User);
            Dictionary<string, string> errors = new Dictionary<string, string>();
            bool isSuccess = false;

            // validate fields
            if (!Validator.IsName(firstName)) errors.Add("first_name", "Name is invalid");
            if (!Validator.IsName(lastName)) errors.Add("last_name", "Name is invalid");
            if (string.IsNullOrWhiteSpace(address)) errors.Add("address", "Address is required");
            if (string.IsNullOrWhiteSpace(phone)) errors.Add("phone", "Phone is required");
            if (!string.IsNullOrWhiteSpace(email) && !Validator.IsEmail(email)) errors.Add("email", "Email is invalid");
            if (!Validator.IsUsername(username)) errors.Add(
                "username",
                "Username should contain only letters, numbers, underscores, or hyphens"
                );
            if (!Validator.IsUsernameUnique(username)) errors.Add(
                "username",
                "Username already exists"
                );
            if (!Validator.IsPassword(password)) errors.Add(
                "password",
                "Password is too short"
                );

            // register user if theres no error
            if (errors.Count == 0)
            {
                AuthDAO authDao = new AuthDAO();
                ReturnResult<User> result = authDao.Create(new User {
                    Username = username,
                    PasswordHash = Argon2.Hash(password), // This method consumes some time (2-10 secs.)
                    Member = new Member
                    {
                        FirstName = firstName,
                        LastName = lastName,
                        Address = address,
                        Phone = phone
                    },
                    Role = new Role
                    {
                        ID = 1
                    }
                });

                isSuccess = result.IsSuccess;
                if (isSuccess) returnData.Result = result.Result;
            }

            returnData.Errors = errors;
            returnData.IsSuccess = isSuccess;
            return returnData;
        }

        public void SignIn(string username, string password)
        {
            AuthDAO authDao = new AuthDAO();
        }

        public void LogOut() { }
    }
}
