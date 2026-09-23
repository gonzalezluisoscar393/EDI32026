using AutoMapper;
using Libros.Application;
using Libros.Application.Dtos.Autor;
using Libros.Entitties;
using Libros.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Libros.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class AutoresController : ControllerBase
    {
        private readonly ILogger<AutoresController> _logger;
        private readonly IStringService _stringService;
        private readonly IApplication<Autor> _autor;
        private readonly IMapper _mapper;
        public AutoresController(IApplication<Autor> autor
            , ILogger<AutoresController> logger
            , IStringService stringService
            , IMapper mapper)
        {
            _autor = autor;
            _logger = logger;
            _stringService = stringService;
            _mapper = mapper;
        }
        [HttpGet]
        [Route("All")]
        public async Task<IActionResult> All()
        {
            return Ok(_mapper.Map<IList<AutorResponseDto>>(_autor.GetAll()));
        }

        [HttpGet]
        [Route("ById")]
        public async Task<IActionResult> ById(int? Id)
        {
            if (!Id.HasValue)
            {
                return BadRequest();
            }
            Autor autor = _autor.GetById(Id.Value);
            if (autor is null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<AutorResponseDto>(autor));
        }

        [HttpPost]
        public async Task<IActionResult> Crear(AutorRequestDto autorRequestDto)
        {
            if (!ModelState.IsValid)
            { return BadRequest(); }
            var autor = _mapper.Map<Autor>(autorRequestDto);
            _autor.Save(autor);
            return Ok(autor.Id);
        }

        [HttpPut]
        public async Task<IActionResult> Editar(int? Id, AutorRequestDto autorRequestDto)
        {
            if (!Id.HasValue)
            { return BadRequest(); }
            if (!ModelState.IsValid)
            { return BadRequest(); }
            Autor autorBack = _autor.GetById(Id.Value);
            if (autorBack is null)
            { return NotFound(); }
            _mapper.Map(autorRequestDto, autorBack);
            _autor.Save(autorBack);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Borrar(int? Id)
        {
            if (!Id.HasValue)
            { return BadRequest(); }            
            Autor autorBack = _autor.GetById(Id.Value);
            if (autorBack is null)
            { return NotFound(); }
            _autor.Delete(autorBack.Id);
            return Ok();
        }
    }
}
