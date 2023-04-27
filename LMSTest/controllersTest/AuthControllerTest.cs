using LibraryManagementSystem.controllers;
using LibraryManagementSystem.models;
using LibraryManagementSystem.services;
using LibraryManagementSystem.utils;

namespace LMSTest
{
    [TestClass]
    public class AuthControllerTest
    {
        [TestMethod]
        public void Shoulld_Register()
        {
            ControllerModifyData<User> res = AuthController.Register(
                "test_omineko12",
                "password",
                "elle",
                "romero",
                "Bancal St.",
                "+639100813695",
                "romero@gmail.com"
                );

            Assert.IsTrue(res.IsSuccess);
        }

        [TestMethod]
        public void Should_SignIn()
        {
            ControllerModifyData<User> res = AuthController.SignIn("admin", "password");
            
            Assert.IsTrue(res.IsSuccess);
        }

        [TestMethod]
        public void Should_Logout()
        {
            ControllerActionData res = AuthController.LogOut();
            Assert.IsTrue(res.IsSuccess);

        }
    }
}