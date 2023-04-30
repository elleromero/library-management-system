using LibraryManagementSystem.dao;
using LibraryManagementSystem.models;
using LibraryManagementSystem.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.controllers
{
    internal class BookController : BaseController
    {

        public static ControllerModifyData<Book> CreateBook(
            int genreId,
            string title,
            string author,
            string publisher,
            DateTime publicationDate,
            string isbn,
            string coverPath = "",
            string sypnosis = "No sypnosis available"
            )
        {
            ControllerModifyData<Book> returnData = new ControllerModifyData<Book>();
            Dictionary<string, string> errors = new Dictionary<string, string>();
            bool isSuccess = false;

            // is not admin
            if (!AuthGuard.IsAdmin())
            {
                errors.Add("permission", "Forbidden");
                returnData.Errors = errors;
                returnData.IsSuccess = false;

                return returnData;
            }

            // validation
            if (!Validator.IsGenreIdValid(genreId)) errors.Add("genreId", "ID is invalid");
            if (string.IsNullOrWhiteSpace(title)) errors.Add("title", "Title is required");
            if (string.IsNullOrWhiteSpace(author)) errors.Add("author", "Author is required");
            if (string.IsNullOrWhiteSpace(publisher)) errors.Add("publisher", "Publisher is required");
            if (!Validator.IsDateBeforeOrOnPresent(publicationDate)) errors.Add("publicationDate", "Datetime must be before or on the present date");
            if (!Validator.IsValidISBN(isbn)) errors.Add("isbn", "Invalid ISBN. Make sure the ISBN is in ISBN-10 or ISBN-13 format");

            if (errors.Count == 0)
            {
                BookDAO bookDao = new BookDAO();
                ReturnResult<Book> result = bookDao.Create(new Book
                {
                    Title = title,
                    Sypnosis = sypnosis,
                    Author = author,
                    Cover = coverPath,
                    Publisher = publisher,
                    PublicationDate = publicationDate,
                    ISBN = isbn,
                    Genre = new Genre
                    {
                        ID = genreId
                    }
                });

                isSuccess = result.IsSuccess;
                returnData.Result = result.Result;
            }

            returnData.Errors = errors;
            returnData.IsSuccess = isSuccess;
            return returnData;
        }
    }
}
