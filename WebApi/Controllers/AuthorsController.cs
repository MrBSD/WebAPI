using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.Dto;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("/api/authors/")]
    public class AuthorsController : Controller
    {
        private readonly IAuthorsRepository _repository;
        private readonly IMapper _mapper;

        public AuthorsController(IAuthorsRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllAuthors()
        {
            var authors = _repository.GetAllAuthors();
            return Ok(authors);
        }

        [HttpGet("{id}")]
        public IActionResult GetAuthor(Guid id)
        {
            var author = _repository.GetAuthor(id);

            if (author == null)
                return NotFound();

            return Ok(_mapper.Map<AuthorDto>(author));
        }

    }
}