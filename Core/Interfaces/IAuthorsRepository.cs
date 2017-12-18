using System;
using System.Collections.Generic;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IAuthorsRepository
    {
        Author AddAuthor(Author author);
        void DeleteAuthor(Guid authorId);
        IEnumerable<Author> GetAllAuthors();
        Author GetAuthor(Guid authorId);
        void UpdateAuthor(Author author);
    }
}
