using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Dto
{
    public class AuthorDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Genre { get; set; }
    }
}
