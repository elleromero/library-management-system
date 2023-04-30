using Isopoh.Cryptography.Argon2;
using LibraryManagementSystem.controllers;
using LibraryManagementSystem.models;

namespace LMSTest
{
    [TestClass]
    public class AdminControllerTest
    {
        [TestMethod]
        public void Should_Create_Admin()
        {
            ControllerModifyData<User> admin = AdminController.CreateAdmin(
                "admin_omineko132",
                "password",
                "admin",
                "romero",
                "717 Apitong st.",
                "+63910083695"
                );

            Assert.IsTrue(admin.IsSuccess);
        }

        [TestMethod]
        public void Should_Update_User()
        {
            bool isUpdated = false;

            ControllerModifyData<User> admin = AdminController.CreateAdmin(
                "admin1",
                "password",
                "admin",
                "romero",
                "717 Apitong st.",
                "+63910083695",
                "gibberish@test.com"
                );

            if (admin.IsSuccess && admin.Result != null)
            {
                ControllerModifyData<User> adminUpd = AdminController.UpdateUser(
                    admin.Result.ID.ToString(),
                    "admin_updated",
                    "password",
                    "admin",
                    "romero",
                    "717 Apitong st.",
                    "+63910083695",
                    "normal@email.com"
                    );

                isUpdated = adminUpd.IsSuccess;
            }

            Assert.IsTrue(isUpdated);
        }

        [TestMethod]
        public void Should_GetById()
        {
            ControllerModifyData<User> res = AdminController.GetUserById("993CC885-4EA2-4210-8468-7B81C7F0DE2F");

            Assert.IsTrue(res.IsSuccess);
        }

        [TestMethod]
        public void Should_GetAllUsers()
        {
            ControllerAccessData<User> res = AdminController.GetAllUsers();

            Assert.IsTrue(res.IsSuccess);
        }

        [TestMethod]
        public void Should_RemoveById()
        {
            ControllerActionData res = AdminController.RemoveById("4749519F-3818-424A-B9CE-30BF0B31DAF5", "admin");

            Console.WriteLine(res.IsSuccess);
        }
    }
}