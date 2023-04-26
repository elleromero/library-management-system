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
                "admin23",
                "password",
                "admin",
                "romero",
                "717 Apitong st.",
                "+63910083695"
                );

            Assert.IsTrue(admin.IsSuccess);
        }

        [TestMethod]
        public void Should_Update_Admin()
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
            ControllerModifyData<User> res = AdminController.GetUserById("993CC85-4EA2-4210-8468-7B81C7F0DE2F");

            Console.WriteLine(res.Result?.Username);
            Assert.IsTrue(res.IsSuccess);
        }
    }
}