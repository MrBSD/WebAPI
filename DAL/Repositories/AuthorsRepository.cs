using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;
using Core.Interfaces;
using System.Data;
using System.Data.SqlClient;

namespace DAL.Repositories
{
    public class AuthorsRepository: IAuthorsRepository
    {

        
        private readonly string _connectionString= "server=DESKTOP-D7JUM7C; database=LibraryDB; Integrated Security=True";
        public ICollection<Author> Authors { get; set; }

        public AuthorsRepository()
        {
            Authors = new List<Author>();
        }


        public IEnumerable<Author> GetAllAuthors()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                    cmd.CommandText = @"SELECT * FROM Authors";

                connection.Open();
                var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var author = new Author();
                        Map(reader, author);
                        Authors.Add(author);

                    }
                connection.Close();
            }
            return Authors;
        }

        public Author GetAuthor(Guid authorId)
        {

            var author = new Author();
            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandText = @"SELECT * FROM Authors WHERE Id=@authorId";
                cmd.Parameters.AddWithValue("@authorId", authorId);

                connection.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Map(reader, author);
                }
                connection.Close();
            }

            if (author.Id == Guid.Parse("00000000-0000-0000-0000-000000000000"))
                author = null;

            return author;
        }

        private Author Map(IDataRecord record, Author author)
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
