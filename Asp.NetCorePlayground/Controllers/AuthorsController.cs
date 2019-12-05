using Asp.NetCorePlayground.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.NetCorePlayground.Controllers
{
    [ApiController]
    [Route("api/authors")]
    // [Route("api/[Controller]")] - Serves the same role as above.

    public class AuthorsController : ControllerBase
    {
        private readonly ICourseLibraryRepository _courseLibraryRepository;
        public AuthorsController(ICourseLibraryRepository courseLibraryRepository)
        {
            _courseLibraryRepository = courseLibraryRepository ?? throw new ArgumentNullException(nameof(courseLibraryRepository));
        }

        [HttpGet()]
        public IActionResult GetAuthors()
        {
            var authorsFromRepo = _courseLibraryRepository.GetAuthors();
            return Ok(authorsFromRepo);
        }

        [HttpGet("{authorId}")]
        // [HttpGet("{authorId:guid}")] - will only match if the author id can be casted to a guid
        public IActionResult GetAuthor(Guid authorId)
        {
            var authorFromRepo = _courseLibraryRepository.GetAuthor(authorId);
            if(authorFromRepo == null)
            {
                return NotFound();
            }
            return Ok(authorFromRepo);
        }
    }
}
