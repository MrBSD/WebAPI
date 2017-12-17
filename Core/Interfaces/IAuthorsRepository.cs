using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IAuthorsRepository
    {
        IEnumerable<Author> GetAllAuthors();
        Author GetAuthor(Guid authorId);
    }
}
