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

            Console.WriteLine(res.Errors.GetValueOrDefault("isbn"));
            Console.WriteLine(res.IsSuccess);
            Console.WriteLine(res.Result != null);

        }
    }
}