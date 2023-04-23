using LibraryManagementSystem.controllers;
using LibraryManagementSystem.models;

namespace LMSTest
{
    [TestClass]
    public class AuthControllerTest
    {
        [TestMethod]
        public void Register()
        {
            ControllerModifyData<User> res = AuthController.Register(
                "omineko",
                "password",
                "elle",
                "romero",
                "Bancal St.",
                "+639100813695",
                "romero@gmail.com"
                );

            Assert.IsTrue(res.IsSuccess);
        }
    }
}