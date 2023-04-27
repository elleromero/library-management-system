using Isopoh.Cryptography.Argon2;
using LibraryManagementSystem.dao;
using LibraryManagementSystem.models;
using LibraryManagementSystem.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.controllers
{
    internal class AdminController : BaseController
    {
        public static ControllerModifyData<User> CreateAdmin(
            string username,
            string password,
            string firstName,
            string lastName,
            string address,
            string phone,
            string email = ""
            )
        {
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

            // register admin if theres no error
            if (errors.Count == 0)
            {
                AdminDAO adminDao = new AdminDAO();
                ReturnResult<User> result = adminDao.Create(new User
                {
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
                if (isSuccess && result.Result != null)
                {
                    returnData.Result = result.Result;
                }
            }

            returnData.Errors = errors;
            returnData.IsSuccess = isSuccess;
            return returnData;
        }

        public static ControllerModifyData<User> UpdateUser(
            string userId,
            string username,
            string password,
            string firstName,
            string lastName,
            string address,
            string phone,
            string email = ""
            )
        {
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

            // update user if theres no error
            if (errors.Count == 0)
            {
                AdminDAO adminDao = new AdminDAO();

                // check if user with access exists
                ReturnResult<User> user = adminDao.GetById(userId);

                if (!user.IsSuccess)
                {
                    Console.WriteLine("THIS ONE");
                    errors.Add("userId", "User not found");
                    returnData.Errors = errors;
                    returnData.IsSuccess = isSuccess;
                    return returnData;
                }

                // proceed if user is found
                ReturnResult<User> result = adminDao.Update(new User
                {
                    ID = new Guid(userId),
                    Username = username,
                    PasswordHash = Argon2.Hash(password), // This method consumes some time (2-10 secs.)
                    Member = new Member
                    {
                        FirstName = firstName,
                        LastName = lastName,
                        Address = address,
                        Phone = phone,
                        Email = email
                    }
                });

                isSuccess = result.IsSuccess;
                if (isSuccess && result.Result != null)
                {
                    returnData.Result = result.Result;
                }
            }

            returnData.Errors = errors;
            returnData.IsSuccess = isSuccess;
            return returnData;
        }

        public static ControllerModifyData<User> GetUserById(string id)
        {
            ControllerModifyData<User> returnData = new ControllerModifyData<User>();
            returnData.Result = default(User);
            Dictionary<string, string> errors = new Dictionary<string, string>();
            bool isSuccess = false;

            // validate fields
            if (string.IsNullOrWhiteSpace(id)) errors.Add("id", "ID is invalid");

            if (errors.Count == 0)
            {
                AdminDAO adminDao = new AdminDAO();
                ReturnResult<User> result = adminDao.GetById(id);

                isSuccess = result.IsSuccess;
                if (isSuccess && result.Result != null)
                {
                    returnData.Result = result.Result;
                }
            }

            returnData.Errors = errors;
            returnData.IsSuccess = isSuccess;
            return returnData;
        }

        public static ControllerAccessData<User> GetAllUsers(int page = 1)
        {
            ControllerAccessData<User> returnData = new ControllerAccessData<User>();
            returnData.Results = new List<User>();
            Dictionary<string, string> errors = new Dictionary<string, string>();
            bool isSuccess = false;
            returnData.rowCount = 1;
            
            if (page < 0) errors.Add("page", "Invalid page");

            if (errors.Count == 0)
            {
                AdminDAO adminDao = new AdminDAO();
                ReturnResultArr<User> result = adminDao.GetAll(page);

                isSuccess = result.IsSuccess;
                returnData.Results = result.Results;
                returnData.rowCount = result.rowCount;
            }

            returnData.Errors = errors;
            returnData.IsSuccess = isSuccess;
            return returnData;
        }

        public static ControllerActionData RemoveById(string id)
        {
            ControllerActionData returnResult = new ControllerActionData();
            AdminDAO adminDao = new AdminDAO();
            returnResult.IsSuccess = adminDao.Remove(id);

            return returnResult;
        }

    }
}
