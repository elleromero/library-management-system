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
    internal class BookDAO : IDAO<Book>
    {
        public ReturnResult<Book> Create(Book model)
        {
            ReturnResult<Book> returnResult = new ReturnResult<Book>();
            returnResult.Result = default(Book);
            returnResult.IsSuccess = false;

            string declareQuery = "DECLARE @book_id UNIQUEIDENTIFIER; SET @book_id = NEWID();";
            string insertQuery = "INSERT INTO books (book_id, genre_id, title, sypnosis, cover, author, publication_date, publisher, isbn) " +
                $"VALUES (@book_id, {model.Genre.ID}, '{model.Title}', '{model.Sypnosis}', '{model.Cover}', '{model.Author}', '{model.PublicationDate.ToString("yyyy-MM-dd HH:mm:ss.fff")}', '{model.Publisher}', '{model.ISBN}');";
            string copyQuery = "INSERT INTO copies (book_id, status_id) VALUES (@book_id, 2);";
            string selectQuery = "SELECT * FROM books b JOIN genres g ON g.genre_id = b.genre_id WHERE book_id = @book_id;";
            string query = $"{declareQuery} {insertQuery} {copyQuery} {selectQuery}";

            SqlClient.Execute((error, conn) =>
            {
                try
                {
                    if (error == null)
                    {
                        SqlCommand command = new SqlCommand(query, conn);
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            returnResult.Result = this.Fill(reader);
                            returnResult.IsSuccess = returnResult.Result != default(Book);
                        }

                        reader.Close();
                    }
                    else return;
                }
                catch {  return; }
            });

            return returnResult;
        }

        public Book? Fill(SqlDataReader reader)
        {
            Book? book = default(Book);

            book = new Book
            {
                ID = reader.GetGuid(reader.GetOrdinal("book_id")),
                Title = reader.GetString(reader.GetOrdinal("title")),
                Sypnosis = reader.GetString(reader.GetOrdinal("sypnosis")),
                Author = reader.GetString(reader.GetOrdinal("author")),
                Cover = reader.GetString(reader.GetOrdinal("cover")),
                Publisher = reader.GetString(reader.GetOrdinal("publisher")),
                PublicationDate = reader.GetDateTime(reader.GetOrdinal("publication_date")),
                ISBN = reader.GetString(reader.GetOrdinal("isbn")),
                Genre = new Genre
                {
                    ID = reader.GetInt32(reader.GetOrdinal("genre_id")),
                    Name = reader.GetString(reader.GetOrdinal("name")),
                    Description = reader.GetString(reader.GetOrdinal("description"))
                }
            };

            return book;
        }

        public ReturnResultArr<Book> GetAll(int page)
        {
            throw new NotImplementedException();
        }

        public ReturnResult<Book> GetById(string id)
        {
            throw new NotImplementedException();
        }

        public bool Remove(string id)
        {
            throw new NotImplementedException();
        }

        public ReturnResult<Book> Update(Book model)
        {
            throw new NotImplementedException();
        }
    }
}
