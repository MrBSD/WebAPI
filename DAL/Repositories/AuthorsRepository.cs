using System;
using System.Collections.Generic;
using Core.Entities;
using Core.Interfaces;
using System.Data;

namespace DAL.Repositories
{
    public class AuthorsRepository: IAuthorsRepository
    {
        private readonly IDatabaseConnector _connector;

        public AuthorsRepository(IDatabaseConnector connector)
        {
            _connector = connector;
        }
        
        public Author AddAuthor(Author author)
        {
            author.Id = Guid.NewGuid();
            using (var connection = _connector.GetSqlConnection())
            {
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = @"spAddAuthor";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@authorId", author.Id);
                    cmd.Parameters.AddWithValue("@firstName", author.FirstName);
                    cmd.Parameters.AddWithValue("@lastName", author.LastName);
                    cmd.Parameters.AddWithValue("@genre", author.Genre);
                    cmd.Parameters.AddWithValue("@dateOfBirth", author.DateOfBirth);

                    cmd.ExecuteNonQuery();
                }
            }
            return author;
        }

        public IEnumerable<Author> GetAllAuthors()
        {
            var authors = new List<Author>();
            using (var connection = _connector.GetSqlConnection())
            {
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = @"SELECT * FROM Authors";
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var author = new Author();
                        Map(reader, author);
                        authors.Add(author);
                    }
                }
            }
            return authors;
        }

        public Author GetAuthor(Guid authorId)
        {
            var author = new Author();
            using (var connection = _connector.GetSqlConnection())
            {
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = @"spGetAuthor";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@authorId", authorId);

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Map(reader, author);
                    }
                }
            }

            if (author.Id == Guid.Parse("00000000-0000-0000-0000-000000000000"))
                author = null;

            return author;
        }

        public void DeleteAuthor(Guid authorId)
        {
            using (var connection = _connector.GetSqlConnection())
            {
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = @"spDeleteAuthor";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@authorId", authorId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void UpdateAuthor(Author author)
        {
            using (var connection = _connector.GetSqlConnection())
            {
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = @"spUpdateAuthor";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@authorId", author.Id);
                    cmd.Parameters.AddWithValue("@firstName", author.FirstName);
                    cmd.Parameters.AddWithValue("@lastName", author.LastName);
                    cmd.Parameters.AddWithValue("@genre", author.Genre);
                    cmd.Parameters.AddWithValue("@dateOfBirth", author.DateOfBirth);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        private static Author Map(IDataRecord record, Author author)
        {
            author.Id = Guid.Parse(record["Id"].ToString());
            author.FirstName = record["FirstName"].ToString();
            author.LastName = record["LastName"].ToString();
            author.DateOfBirth = DateTime.Parse(record["DateOfBirth"].ToString());
            author.Genre = record["Genre"].ToString();

            return author;
        }
    }

   
}
