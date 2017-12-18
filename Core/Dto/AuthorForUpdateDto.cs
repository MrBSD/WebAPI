using System;

namespace Core.Dto
{
    public class AuthorForUpdateDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Genre { get; set; }
    }
}