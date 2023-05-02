using LibraryManagementSystem.controllers;
using LibraryManagementSystem.models;

namespace LMSTest
{
    [TestClass]
    public class BookControllerTest
    {
        [TestMethod]
        public void Should_Create_Book()
        {
            AuthController.SignIn("admin", "password");
            ControllerModifyData<Book> res = BookController.CreateBook(
                1,
                "HTML Semantics",
                "K. Heart",
                "freecodecamp",
                new DateTime(2003, 1, 23),
                "978-3-16-148410-0"
                );

            Assert.IsTrue(res.IsSuccess);
        }

        [TestMethod]
        public void Should_Get_Book_By_Id()
        {
            AuthController.SignIn("admin", "password");
            ControllerModifyData<Book> res = BookController.GetBookById("47298E60-74EA-4F20-AAF2-55FAC9797492");

            Assert.IsTrue(res.IsSuccess);
        }

        [TestMethod]
        public void Should_Update_Book()
        {
            AuthController.SignIn("admin", "password");
            ControllerModifyData<Book> res = BookController.UpdateBook(
                "47298E60-74EA-4F20-AAF2-55FAC9797492",
                1,
                "HTML Semantic",
                "Kevin Bacon",
                "freecodecamp",
                new DateTime(2003, 1, 23),
                "978-3-16-148410-0"
                );

            Console.WriteLine(res.IsSuccess);
            Console.WriteLine(res.Result?.Author);
        }
    }
}