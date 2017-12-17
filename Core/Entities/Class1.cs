using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class Author
    {
        public Guid Id { get; set; }
        public string FirstName{ get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Genre { get; set; }
        public ICollection<Book> Books { get; set; }

        public Author()
        {
            Books = new ICollection<Book>();
        }
    }
}
