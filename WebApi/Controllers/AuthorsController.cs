using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.Dto;
using Core.Entities;
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

        [HttpPost]
        public IActionResult CreateAuthor([FromBody] AuthorForCreateDto authorForCreateDto)
        {
            var author = _mapper.Map<Author>(authorForCreateDto);
            var createdAuthor = _repository.AddAuthor(author);
            var authorToReturn = _mapper.Map<AuthorDto>(createdAuthor);
            return CreatedAtRoute("GetAuthor",
                new {id = authorToReturn.Id},
                authorToReturn
            );
        }

        [HttpGet]
        public IActionResult GetAllAuthors()
        {
            var authors = _repository.GetAllAuthors();
            return Ok(authors);
        }

        [HttpGet("{id}", Name = "GetAuthor")]
        public IActionResult GetAuthor(Guid id)
        {
            var author = _repository.GetAuthor(id);

            if (author == null)
                return NotFound();

            return Ok(_mapper.Map<AuthorDto>(author));
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAuthor(Guid id)
        {
            _repository.DeleteAuthor(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAuthor(Guid id, [FromBody]AuthorForUpdateDto authorForUpdateDto)
        {
            var authorInDb = _repository.GetAuthor(id);
            if (authorInDb==null)
            {
                return NotFound();
            }

            var updatedAuthor = _mapper.Map<AuthorForUpdateDto, Author>(authorForUpdateDto, authorInDb);
            _repository.UpdateAuthor(updatedAuthor);

            return NoContent();
        }



    }
}