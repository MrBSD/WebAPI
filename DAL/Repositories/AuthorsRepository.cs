using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;
using Core.Interfaces;
using System.Data;

namespace DAL.Repositories
{
    public class AuthorsRepository: IAuthorsRepository
    {




        public IEnumerable<Author> GetAllAuthors()
        {
            return null;
        }

        public Author GetAuthor(Guid authorId)
        {
            return null;
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
