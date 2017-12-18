using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Dto
{
    public class AuthorForCreateDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Genre { get; set; }
    }
}
